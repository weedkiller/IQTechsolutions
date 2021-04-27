using System;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Entities;
using Iqt.Base.Models;
using Iqt.Troubleshooting.Entities;
using Microsoft.EntityFrameworkCore;
using Troubleshooting.Entities;

namespace Troubleshooting.Context.Services
{
    /// <summary>
    /// The database context service
    /// </summary>
    public class ProblemsContext
    {
        private DbContext _context;

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        public ProblemsContext(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all the trouble shooting <see cref="Problem"/> from the database
        /// </summary>
        /// <returns><see cref="IQueryable{T}"/> list of problems</returns>
        public IQueryable<Problem> GetAll()
        {
            return _context.Set<Problem>()
                .Include(c => c.Categories)
                .Include(c => c.Causes)
                .ThenInclude(c => c.CorrectiveActions);
        }

        /// <summary>
        /// Gets a specific problem from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="Problem"/> to be fetched</param>
        /// <returns>a specific <see cref="Problem"/></returns>
        public async Task<Problem> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new <see cref="Problem"/> to the database
        /// </summary>
        /// <param name="problem">The <see cref="Problem"/> to be added</param>
        /// <returns>The <see cref="Problem"/> to be added</returns>
        public async Task<Problem> AddAsync(Problem problem)
        {
            _context.Set<Problem>().Add(problem);
            await _context.SaveChangesAsync();
            return problem;
        }

        /// <summary>
        /// Updates a specific <see cref="Problem"/> in the database
        /// </summary>
        /// <param name="problem">The <see cref="Problem"/> the database should be updated to</param>
        /// <returns>The updated <see cref="Problem"/></returns>
        public async Task<Problem> UpdateAsync(Problem problem)
        {
            _context.Set<Problem>().Update(problem);
            await _context.SaveChangesAsync();
            return problem;
        }

        /// <summary>
        /// Removes a specific <see cref="Problem"/> from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="Problem"/> to be removed</param>
        /// <returns>The <see cref="Problem"/> that was deleted</returns>
        public async Task DeleteAsync(string id)
        {
            var problem = await GetAsync(id);

            if (problem.Categories != null && problem.Categories.Any())
            {
                foreach (var cause in problem.Categories.ToList())
                {
                    problem.Categories.Remove(cause);
                    _context.Set<EntityCategory<Problem>>().Remove(cause);
                }
            }

            // Check to see if there is a coverimage that should be deleted
            if (problem.Causes != null && problem.Causes.Any())
            {
                foreach (var cause in problem.Causes.ToList())
                {
                    if (cause.CorrectiveActions != null && cause.CorrectiveActions.Any())
                    {
                        foreach (var action in cause.CorrectiveActions.ToList())
                        {
                            cause.CorrectiveActions.Remove(action);
                            _context.Set<CorrectiveAction>().Remove(action);
                        }
                    }
                    problem.Causes.Remove(cause);
                    _context.Set<Cause>().Remove(cause);
                }
            }

            _context.Remove(problem);
            await _context.SaveChangesAsync();
        }

        #region Cause

        /// <summary>
        /// Gets a cause to a problem
        /// </summary>
        /// <param name="id">The identity of the cause of the problem</param>
        public IQueryable<Cause> GetProblemCausesAsync(string id)
        {
            return _context.Set<Cause>().Include(c => c.Problem).Include(c => c.CorrectiveActions)
                .Where(c => c.ProblemId == id);
        }

        /// <summary>
        /// Gets a cause to a problem
        /// </summary>
        /// <param name="id">The identity of the cause of the problem</param>
        public async Task<Cause> GetCauseAsync(string id)
        {
            return await _context.Set<Cause>().Include(c => c.Problem).Include(c => c.CorrectiveActions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a cause to a problem
        /// </summary>
        /// <param name="cause">The cause of the problem</param>
        public async Task<Cause> AddCauseAsync(Cause cause)
        {
            _context.Set<Cause>().Add(cause);
            await _context.SaveChangesAsync();
            return cause;
        }

        /// <summary>
        /// Adds a cause to a problem
        /// </summary>
        /// <param name="cause">The cause of the problem</param>
        public async Task<Cause> UpdateCauseAsync(Cause cause)
        {
            _context.Set<Cause>().Update(cause);
            await _context.SaveChangesAsync();
            return cause;
        }

        /// <summary>
        /// Removes a cause from the database
        /// </summary>
        /// <param name="id"></param>
        public async Task RemoveCause(string id)
        {
            var cause = await GetCauseAsync(id);
            _context.Set<Cause>().Remove(cause);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Corrective Action

        /// <summary>
        /// Gets a cause to a problem
        /// </summary>
        /// <param name="causeId">The identity of the cause of the problem</param>
        public IQueryable<CorrectiveAction> GetCorrectiveActionsForCause(string causeId)
        {
            return _context.Set<CorrectiveAction>().Include(c => c.Cause).Where(c => c.CauseId == causeId);
        }

        /// <summary>
        /// Gets a cause to a problem
        /// </summary>
        /// <param name="id">The identity of the cause of the problem</param>
        public async Task<CorrectiveAction> GetCorrectiveActionAsync(string id)
        {
            return await _context.Set<CorrectiveAction>().Include(c => c.Cause).FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a cause to a problem
        /// </summary>
        /// <param name="correctiveAction">The added corrective action</param>
        public async Task<CorrectiveAction> AddCorrectiveActionAsync(CorrectiveAction correctiveAction)
        {
            try
            {
                _context.Set<CorrectiveAction>().Add(correctiveAction);
                await _context.SaveChangesAsync();
                return correctiveAction;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Adds a cause to a problem
        /// </summary>
        /// <param name="correctiveAction">The updated corrective action</param>
        public async Task<CorrectiveAction> UpdateCorrectiveActionAsync(CorrectiveAction correctiveAction)
        {
            _context.Set<CorrectiveAction>().Add(correctiveAction);
            await _context.SaveChangesAsync();
            return correctiveAction;
        }

        /// <summary>
        /// Removes a cause from the database
        /// </summary>
        /// <param name="id"></param>
        public async Task RemoveCorrectiveAction(string id)
        {
            var correctiveAction = await GetCorrectiveActionAsync(id);
            _context.Set<CorrectiveAction>().Remove(correctiveAction);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Categories

        /// <summary>
        /// Gets a <see cref="Problem"/> collection from the database that belongs to a specific <see cref="Category{T}"/>
        /// </summary>
        /// <param name="categoryId">The identity of the <see cref="Category{T}"/> that the <see cref="Problem"/> collection belongs to</param>
        /// <returns>A <see cref="Problem"/> collection</returns>
        public IQueryable<EntityCategory<Problem>> GetCategoryProblems(string categoryId)
        {
            return _context.Set<EntityCategory<Problem>>().Include(c => c.Entity).Where(c => c.CategoryId == categoryId);
        }

        /// <summary>
        /// Gets a specific <see cref="EntityCategory{T}"/> category problem
        /// </summary>
        /// <param name="problemId">The identity of the <see cref="Problem"/> that belongs to the <see cref="Category{T}"/></param>
        /// <param name="categoryId">The identity of the <see cref="Category{T}"/> that the problem belongs to</param>
        /// <returns>The specific <see cref="EntityCategory{T}"/> problem category</returns>
        public Task<EntityCategory<Problem>> GetEntityCategory(string problemId, string categoryId)
        {
            return Task.FromResult(_context.Set<EntityCategory<Problem>>().Where(c => c.EntityId == problemId).FirstOrDefault(c => c.CategoryId == categoryId));
        }

        /// <summary>
        /// Processes a <see cref="CheckBoxSelectionModel{T}"/> for addition as a <see cref="EntityCategory{T}"/>
        /// to add to the database as a problem category
        /// </summary>
        /// <param name="parentId">The identity of the parent <see cref="Problem"/></param>
        /// <param name="item">The identity of the <see cref="Category{T}"/></param>
        public async Task ProcessAvailableCategories(string parentId, CheckBoxSelectionModel<Category<Problem>> item)
        {
            if (item.HasChildSelection)
            {
                foreach (var ss in item.ChildSelection)
                {
                    await ProcessAvailableCategories(parentId, ss);
                }

            }

            var entityCategory = await GetEntityCategory(parentId, item.Identity);

            if (item.IsSelected && entityCategory == null)
            {
                var newCat = new EntityCategory<Problem>
                {
                    CategoryId = item.Identity,
                    EntityId = parentId
                };

                // problem.Categories.Add(newCat);
                await AddCategory(newCat);
            }

            if (!item.IsSelected && entityCategory != null)
            {
                await RemoveCategory(entityCategory);
            }
        }

        /// <summary>
        /// Adds a new product category <see cref="EntityCategory{T}"/> to the database
        /// </summary>
        /// <param name="category">The problem category <see cref="EntityCategory{T}"/> to be added to the database</param>
        /// <returns>The added product category <see cref="EntityCategory{T}"/></returns>
        public async Task<EntityCategory<Problem>> AddCategory(EntityCategory<Problem> category)
        {
            _context.Set<EntityCategory<Problem>>().Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        /// <summary>
        /// Removes a specific product category <see cref="EntityCategory{T}"/> from the database
        /// </summary>
        /// <param name="category">The entity category <see cref="EntityCategory{T}"/></param>
        /// <returns>The removed entity category</returns>
        public async Task<EntityCategory<Problem>> RemoveCategory(EntityCategory<Problem> category)
        {
            _context.Set<EntityCategory<Problem>>().Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        #endregion
    }
}
