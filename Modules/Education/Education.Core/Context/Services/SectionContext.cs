using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Education.Core.Models;
using Filing.Base.Entities;
using Filing.Core.Factories;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Context.Services
{
    /// <summary>
    /// The database context service
    /// </summary>
    public class SectionContext
    {
        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <summary>
        /// The default Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        public SectionContext(DbContext context, IFileFactory fileFactory)
        {
            _context = context;
            _fileFactory = fileFactory;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Gets a <see cref="Section"/> of courses from the database
        /// </summary>
        /// <returns>A list of training courses</returns>
        public IQueryable<Section> GetAll()
        {
            var tp = _context.Set<Section>().Include(c => c.Images).Include(c => c.Sections).ThenInclude(c => c.Sections).Include(c => c.Module).ThenInclude(c => c.Course);
            return tp;
        }

        /// <summary>
        /// Gets a <see cref="Section"/> of courses from the database
        /// </summary>
        /// <returns>A list of training courses</returns>
        public async Task<Section> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Gets the parent <see cref="Module"/> from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="Module"/> to get from the database</param>
        /// <returns>The parent <see cref="Module"/></returns>
        public async Task<Module> GetParentAsync(string parentId)
        {
            return await _context.Set<Module>().Include(c => c.Course).FirstOrDefaultAsync(c => c.Id == parentId);
        }

        /// <summary>
        /// Gets the previous database entry
        /// </summary>
        /// <param name="current">The current <see cref="Section"/></param>
        /// <returns>The previous <see cref="Section"/></returns>
        public async Task<Section> GetPreviousAsync(Section current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        /// <summary>
        /// Gets the next database entry
        /// </summary>
        /// <param name="current">The current <see cref="Section"/></param>
        /// <returns>The previous <see cref="Section"/></returns>
        public async Task<Section> GetNextAsync(Section current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Course

        /// <summary>
        /// Adds a <see cref="Section"/> to the database asynchronously
        /// </summary>
        /// <param name="model">The <see cref="SectionAddEditModel"/> used to add the <see cref="Section"/></param>
        /// <returns>The <see cref="Section"/> that was added</returns>
        public async Task<Section> AddAsync(SectionAddEditModel model)
        {
            await _context.Set<Section>().AddAsync(model.Entity);
            
            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Department

        /// <summary>
        /// Update a specific <see cref="Section"/> ont the database
        /// </summary>
        /// <param name="model">The <see cref="SectionAddEditModel"/> to be updated from</param>
        /// <returns>The updated <see cref="Section"/></returns>
        public async Task<Section> UpdateAsync(SectionAddEditModel model)
        {
            var category = await GetAsync(model.Entity.Id);

            _context.Entry(category).CurrentValues.SetValues(model.Entity);

            _context.Set<Section>().Update(category);

            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public async Task<Section> UpdateSectionAsync(Section model)
        {
            _context.Set<Section>().Update(model);

            await _context.SaveChangesAsync();

            return model;
        }

        #endregion

        #region Delete Section

        /// <summary>
        /// Deletes a specific <see cref="Section"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Section"/> to be deleted from the database</param>
        public async Task DeleteAsync(string id)
        {
            Section section = await GetAsync(id);
            if (section.Sections.Any())
            {
                foreach (var item in section.Sections.ToList())
                {
                    await DeleteAsync(item.Id);
                }

                foreach (var image in section.Images.ToList())
                {
                   await _fileFactory.DeleteImageAndRemoveFormDbAsync(image);
                }
            }
            else
            {
                foreach (var image in section.Images.ToList())
                {
                    await _fileFactory.DeleteImageAndRemoveFormDbAsync(image);
                }
                _context.Set<Section>().Remove(section);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public async Task RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Course>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync<Course>(file);
            _context.SaveChanges();
        }

        #endregion

        #region Assessment Elements

        /// <summary>
        /// Get a list of <see cref="AssessmentElement{T}"/> that belong to a specific <see cref="Section"/>
        /// </summary>
        /// <param name="parentId">The identity of the parent <see cref="Section"/></param>
        /// <returns>A list of <see cref="AssessmentElement{T}"/></returns>
        public async Task<IEnumerable<AssessmentElement<Section>>> GetAssessmentElementsAsync(string parentId)
        {
            return await _context.Set<AssessmentElement<Section>>().Include(c => c.Answers).Where(c => c.EntityId == parentId)
                .ToListAsync();
        }

        /// <summary>
        /// Get a specific assessment element from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="AssessmentElement{T}"/></param>
        /// <returns>A specific assessment element</returns>
        public async Task<AssessmentElement<Section>> GetSpecificAssessmentElementAsync(string id)
        {
            return await _context.Set<AssessmentElement<Section>>().Include(c => c.Answers)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new assessment element to the database
        /// </summary>
        /// <param name="formElement">The <see cref="AssessmentElement{T}"/> to be added</param>
        /// <returns>The added <see cref="AssessmentElement{T}"/></returns>
        public async Task<AssessmentElement<Section>> AddAssessmentElementAsync(AssessmentElement<Section> formElement)
        {
            _context.Set<AssessmentElement<Section>>().Add(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }

        /// <summary>
        /// updates an existing assessment element to the database
        /// </summary>
        /// <param name="formElement">The <see cref="AssessmentElement{T}"/> to be added</param>
        /// <returns>The updated <see cref="AssessmentElement{T}"/></returns>
        public async Task<AssessmentElement<Section>> EditAssessmentElementAsync(AssessmentElement<Section> formElement)
        {
            _context.Set<AssessmentElement<Section>>().Update(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }

        /// <summary>
        /// Removes an assessment element form the database
        /// </summary>
        /// <param name="id">The identity of the assessment element to be removed</param>
        public async Task RemoveAssessmentElementAsync(string id)
        {
            var formElement = _context.Set<AssessmentElement<Section>>().FirstOrDefault(c => c.Id == id);

            _context.Set<AssessmentElement<Section>>().Remove(formElement ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Assesment Answers

        /// <summary>
        /// Get specific assessment element answers
        /// </summary>
        /// <param name="parentId">The identity of the parent <see cref="AssessmentElement{T}"/></param>
        /// <returns>A list of <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<IEnumerable<MultipleChoiceAnswer<Section>>> GetAllAssessmentAnswersAsync(string parentId)
        {
            return await _context.Set<MultipleChoiceAnswer<Section>>().Where(c => c.AssessmentElementId == parentId).ToListAsync();
        }

        /// <summary>
        /// Get a specific assessment element answer
        /// </summary>
        /// <param name="id">The identity of the assessment answer</param>
        /// <returns>A specific <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<MultipleChoiceAnswer<Section>> GetAssessmentAnswerAsync(string id)
        {
            return await _context.Set<MultipleChoiceAnswer<Section>>().FirstOrDefaultAsync(c => c.AssessmentElementId == id);
        }

        /// <summary>
        /// Adds a new assessment answer to an assessment element
        /// </summary>
        /// <param name="model">The model of the featured assessment answer <see cref="MultipleChoiceAnswer{T}"/></param>
        /// <returns>returns the added <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<MultipleChoiceAnswer<Section>> AddAssessmentAnswerAsync(MultipleChoiceAnswer<Section> model)
        {
            _context.Set<MultipleChoiceAnswer<Section>>().Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        /// <summary>
        /// Updates a new assessment answer to the database
        /// </summary>
        /// <param name="model">The module that contains the information to be updated</param>
        /// <returns>The updated <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<MultipleChoiceAnswer<Section>> UpdateAssessmentAnswerAsync(MultipleChoiceAnswer<Section> model)
        {
            _context.Set<MultipleChoiceAnswer<Section>>().Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        /// <summary>
        /// Removes an <see cref="AssessmentElement{T}"/> from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="AssessmentElement{T}"/> that needs to be removed</param>
        public async Task RemoveAssessmentAnswerAsync(string id)
        {
            var assessmentAnswer = await GetAssessmentAnswerAsync(id);
            _context.Set<MultipleChoiceAnswer<Section>>().Remove(assessmentAnswer);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
