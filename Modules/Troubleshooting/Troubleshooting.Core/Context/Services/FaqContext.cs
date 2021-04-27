using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Models;

namespace Troubleshooting.Core.Context.Services
{
    /// <summary>
    /// The context service that manages faq details in the database
    /// </summary>
    public class FaqContext
    {
        private readonly DbContext _context;

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="context">The injected database context manager</param>
        public FaqContext(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Get Entities

        public IQueryable<Question> GetAll()
        {
            return _context.Set<Question>().Include(c => c.Categories).Include(c => c.Answers);
        }

        public async Task<Question> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        #endregion

        #region Add Blog Post

        /// <summary>
        /// Update a specific employee
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The updated blog post</returns>
        public async Task AddAsync(FaqAddEditModel model)
        {
            _context.Set<Question>().Add(model.Entity);
            await SetFaqCategoriesCategories(model);

          
           await _context.SaveChangesAsync();
        }

        #endregion

        #region Update Blog Post

        /// <summary>
        /// Update a specific employee
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The updated blog post</returns>
        public async Task UpdateAsync(FaqAddEditModel model)
        {
            var blogPost = await GetAsync(model.Entity.Id);

            _context.Entry(blogPost).CurrentValues.SetValues(model.Entity);

            await SetFaqCategoriesCategories(model);

            _context.Set<Question>().Update(blogPost);
            await _context.SaveChangesAsync();
        }

        #endregion


        #region Delete Blog Post

        /// <summary>
        /// Deletes a specific Faq Question
        /// </summary>
        /// <param name="id">The identity of the Faq Question to be deleted</param>
        /// <returns>The deleted Faq Question</returns>
        public async Task DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var question = await GetAsync(id);

            // Check to see if there is a dimension that should be deleted
            if (question.Categories != null && question.Categories.Any())
            {
                foreach (var ans in question.Categories.ToList())
                {
                    question.Categories.Remove(ans);
                    _context.Set<EntityCategory<Question>>().Remove(ans);
                }
            }

            // Check to see if there is a dimension that should be deleted
            if (question.Answers != null && question.Answers.Any())
            {
                foreach (var ans in question.Answers.ToList())
                {
                    question.Answers.Remove(ans);
                    _context.Set<Answer>().Remove(ans);
                }
            }

            _context.Set<Question>().Remove(question);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Children

        #region Answers

        /// <summary>
        /// Get an enumerated list of all the faq question answers
        /// </summary>
        /// <returns>An enumerated list of all the faq question answers</returns>
        public IEnumerable<Answer> GetAllAnswers(string faqQuestionId)
        {
            return _context.Set<Answer>().Where(c => c.QuestionId == faqQuestionId);
        }

        /// <summary>
        /// Get an enumerated list of all the faq question answers
        /// </summary>
        /// <returns>An enumerated list of all the faq question answers</returns>
        public async Task<Answer> GetAnswer(string faqAnswerId)
        {
            return await _context.Set<Answer>().FirstOrDefaultAsync(c => c.Id == faqAnswerId);
        }

        /// <summary>
        /// Adds a new faq answer to the database
        /// </summary>
        /// <param name="faqAnswer">The answer to add to the database</param>
        public async Task AddAnswer(Answer faqAnswer)
        {
            _context.Set<Answer>().Add(faqAnswer);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a faq answer on the database
        /// </summary>
        /// <param name="faqAnswer">The answer the database entry should be updated to</param>
        public async Task UpdateAnswer(Answer faqAnswer)
        {
            try
            {
                _context.Set<Answer>().Update(faqAnswer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a faq answer from the database
        /// </summary>
        /// <param name="faqAnswer">The answer to be removed</param>
        /// <returns></returns>
        public async Task DeleteAnswer(Answer faqAnswer)
        {
            _context.Set<Answer>().Remove(faqAnswer);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Categories

        /// <summary>
        /// Get an enumerated list of all the service categories
        /// </summary>
        /// <returns>An enumerated list of all the blog categories</returns>
        public IEnumerable<Category<Question>> GetCategories()
        {
            return _context.Set<Category<Question>>().Include(c => c.SubCategories);
        }

        /// <summary>
        /// Sets the faq categories on the database and the entity
        /// </summary>
        /// <param name="model">The model that is passed from the view</param>
        public async Task SetFaqCategoriesCategories(FaqAddEditModel model)
        {
            foreach (var category in model.AvailableCategories)
            {
                var faqQeustionCategory = _context.Set<EntityCategory<Question>>().Where(c => c.EntityId == model.Entity.Id).FirstOrDefault(c => c.CategoryId == category.Identity);
                if (faqQeustionCategory == null)
                {
                    if (category.IsSelected)
                    {
                        if (!_context.Set<EntityCategory<Question>>()
                            .Where(c => c.CategoryId == category.Identity).Any(c => c.EntityId == model.Entity.Id))
                        {
                            _context.Set<EntityCategory<Question>>().Add(new EntityCategory<Question>()
                            {
                                CategoryId = category.Identity.ToString(),
                                EntityId = model.Entity.Id
                            });
                        }
                    }
                }
                else
                {
                    if (!category.IsSelected)
                    {
                        if (_context.Set<EntityCategory<Question>>()
                            .Any(c => c.CategoryId == category.Identity))
                        {
                            var entity = _context.Set<EntityCategory<Question>>()
                                .FirstOrDefault(c => c.CategoryId == category.Identity);
                            _context.Set<EntityCategory<Question>>().Remove(entity);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        #endregion

        #endregion
    }
}