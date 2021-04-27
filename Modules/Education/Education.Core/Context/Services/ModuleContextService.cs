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
    public class ModuleContext
    {
        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <summary>
        /// The default Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file manager</param>
        public ModuleContext(DbContext context, IFileFactory fileFactory)
        {
            _context = context;
            _fileFactory = fileFactory;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Gets a <see cref="IQueryable{T}"/> of courses from the database
        /// </summary>
        /// <returns>A list of training courses</returns>
        public IQueryable<Module> GetAll()
        {
            return _context.Set<Module>().Include(c => c.Images).Include(c => c.Sections)
                .Include(c => c.Course).Include(c => c.AssessmentElements);
        }

        /// <summary>
        /// Gets a <see cref="IQueryable{T}"/> of courses from the database
        /// </summary>
        /// <returns>A list of training courses</returns>
        public async Task<Module> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Gets the parent <see cref="Course"/> from the database
        /// </summary>
        /// <param name="parentId">The identity of the <see cref="Course"/> to get from the database</param>
        /// <returns>The parent <see cref="Course"/>The parent <see cref="Course"/></returns>
        public async Task<Course> GetParentAsync(string parentId)
        {
            return await _context.Set<Course>().FirstOrDefaultAsync(c => c.Id == parentId);
        }

        /// <summary>
        /// Gets the previous database entry
        /// </summary>
        /// <param name="current">The current <see cref="Module"/></param>
        /// <returns>The previous <see cref="Module"/></returns>
        public async Task<Module> GetPreviousAsync(Module current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        /// <summary>
        /// Gets the next database entry
        /// </summary>
        /// <param name="current">The current <see cref="Module"/></param>
        /// <returns>The previous <see cref="Module"/></returns>
        public async Task<Module> GetNextAsync(Module current)
        {
            var entityList = await GetAll().Include(c => c.Sections).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Training Course

        /// <summary>
        /// Adds a <see cref="Module"/> to the database asynchronously
        /// </summary>
        /// <param name="model">The <see cref="ModuleAddEditModel"/> used to add the <see cref="Module"/></param>
        /// <returns>The <see cref="Module"/> that was added</returns>
        public async Task<Module> AddAsync(ModuleAddEditModel model)
        {
            await _context.Set<Module>().AddAsync(model.Entity);
            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Department

        /// <summary>
        /// Update a specific <see cref="Module"/> ont the database
        /// </summary>
        /// <param name="model">The <see cref="ModuleAddEditModel"/> to be updated from</param>
        /// <returns>The updated <see cref="Module"/></returns>
        public async Task<Module> UpdateAsync(ModuleAddEditModel model)
        {
            var category = await GetAsync(model.Entity.Id);

            _context.Entry(category).CurrentValues.SetValues(model.Entity);

            _context.Set<Module>().Update(category);

            await _context.SaveChangesAsync();

            return model.Entity;
        }

        /// <summary>
        /// Update a specific <see cref="Module"/> ont the database
        /// </summary>
        /// <param name="module">The updated module</param>
        /// <returns>The updated module</returns>
        public async Task<Module> UpdateAsync(Module module)
        {
            _context.Set<Module>().Update(module);
            await _context.SaveChangesAsync();
            return module;
        }

        #endregion

        #region Delete Department

        /// <summary>
        /// Deletes a specific <see cref="Module"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Module"/> to be deleted from the database</param>
        public async Task DeleteAsync(string id)
        {
            Module department = await GetAsync(id);
            if (department.Sections != null && department.Sections.Any())
            {
                foreach (var sec in department.Sections.ToList())
                {
                    await RemoveSections(sec.Id);
                }
            }
            foreach (var image in department.Images.ToList())
            {
                await _fileFactory.DeleteImageAndRemoveFormDbAsync(image);
            }
            _context.Remove(department);

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

        /// <summary>
        /// Remove child sections from the database when removing a module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveSections(string id)
        {
            Section section = await _context.Set<Section>().Include(c => c.Images).Include(c => c.Sections).ThenInclude(c => c.Sections).FirstOrDefaultAsync(c => c.Id == id);
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
            }
        }

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public async Task RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Module>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync(file);
            _context.SaveChanges();
        }

        #endregion

        #region Assessment Elements

        /// <summary>
        /// Get a list of <see cref="AssessmentElement{T}"/> that belong to a specific <see cref="Module"/>
        /// </summary>
        /// <param name="parentId">The identity of the parent <see cref="Module"/></param>
        /// <returns>A list of <see cref="AssessmentElement{T}"/></returns>
        public async Task<IEnumerable<AssessmentElement<Module>>> GetAssessmentElementsAsync(string parentId)
        {
            return await _context.Set<AssessmentElement<Module>>().Include(c => c.Answers).Where(c => c.EntityId == parentId)
                .ToListAsync();
        }

        /// <summary>
        /// Get a specific assessment element from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="AssessmentElement{T}"/></param>
        /// <returns>A specific assessment element</returns>
        public async Task<AssessmentElement<Module>> GetSpecificAssessmentElementAsync(string id)
        {
            return await _context.Set<AssessmentElement<Module>>().Include(c => c.Answers)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new assessment element to the database
        /// </summary>
        /// <param name="formElement">The <see cref="AssessmentElement{T}"/> to be added</param>
        /// <returns>The added <see cref="AssessmentElement{T}"/></returns>
        public async Task<AssessmentElement<Module>> AddAssessmentElementAsync(AssessmentElement<Module> formElement)
        {
            _context.Set<AssessmentElement<Module>>().Add(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }

        /// <summary>
        /// updates an existing assessment element to the database
        /// </summary>
        /// <param name="formElement">The <see cref="AssessmentElement{T}"/> to be added</param>
        /// <returns>The updated <see cref="AssessmentElement{T}"/></returns>
        public async Task<AssessmentElement<Module>> EditAssessmentElementAsync(AssessmentElement<Module> formElement)
        {
            _context.Set<AssessmentElement<Module>>().Update(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }

        /// <summary>
        /// Removes an assessment element form the database
        /// </summary>
        /// <param name="id">The identity of the assessment element to be removed</param>
        public async Task RemoveAssessmentElementAsync(string id)
        {
            var formElement = _context.Set<AssessmentElement<Module>>().FirstOrDefault(c => c.Id == id);

            _context.Set<AssessmentElement<Module>>().Remove(formElement ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Assesment Answers

        /// <summary>
        /// Get specific assessment element answers
        /// </summary>
        /// <param name="parentId">The idenetity of the parent <see cref="AssessmentElement{T}"/></param>
        /// <returns>A list of <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<IEnumerable<MultipleChoiceAnswer<Module>>> GetAllAssessmentAnswersAsync(string parentId)
        {
            return await _context.Set<MultipleChoiceAnswer<Module>>().Where(c => c.AssessmentElementId == parentId).ToListAsync();
        }

        /// <summary>
        /// Get a specific assessment element answer
        /// </summary>
        /// <param name="id">The identity of the assessment answer</param>
        /// <returns>A specific <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<MultipleChoiceAnswer<Module>> GetAssessmentAnswerAsync(string id)
        {
            return await _context.Set<MultipleChoiceAnswer<Module>>().FirstOrDefaultAsync(c => c.AssessmentElementId == id);
        }

        /// <summary>
        /// Adds a new assessment answer to an assessment element
        /// </summary>
        /// <param name="model">The model of the featured assessment answer <see cref="MultipleChoiceAnswer{T}"/></param>
        /// <returns>returns the added <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<MultipleChoiceAnswer<Module>> AddAssessmentAnswerAsync(MultipleChoiceAnswer<Module> model)
        {
            _context.Set<MultipleChoiceAnswer<Module>>().Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        /// <summary>
        /// Updates a new assessment answer to the database
        /// </summary>
        /// <param name="model">The module that contains the information to be updated</param>
        /// <returns>The updated <see cref="MultipleChoiceAnswer{T}"/></returns>
        public async Task<MultipleChoiceAnswer<Module>> UpdateAssessmentAnswerAsync(MultipleChoiceAnswer<Module> model)
        {
            _context.Set<MultipleChoiceAnswer<Module>>().Update(model);
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
            _context.Set<MultipleChoiceAnswer<Module>>().Remove(assessmentAnswer);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
