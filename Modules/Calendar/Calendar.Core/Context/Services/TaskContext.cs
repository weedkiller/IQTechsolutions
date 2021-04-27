using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Iqt.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Core.Context.Services
{
    public class TaskContext
    {
        private readonly DbContext _context;

        public TaskContext(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<RecurringTask> GetAllRecurringTasks()
        {
            return _context.Set<RecurringTask>().Include(c => c.Address).Include(c => c.ParentTask)
                .Include(c => c.FormElements)
                .Include(c => c.Tasks).ThenInclude(c => c.Tasks)
                .Include(c => c.Tasks).ThenInclude(c => c.ParentTask)
                .Include(c => c.Tasks).ThenInclude(c => c.Address);
        }

        public IEnumerable<RecurringTask> GetAllParentTasks()
        {
            return GetAllRecurringTasks().Where(c => c.ParentTaskId == null);
        }

        public RecurringTask GetRecurringTask(string id)
        {
            return GetAllRecurringTasks()
                .FirstOrDefault(c => c.Id == id);
        }

        public async Task<RecurringTask> AddRecurringTaskAsync(RecurringTask work)
        {
            _context.Set<RecurringTask>().Add(work);
            await _context.SaveChangesAsync();

            return work;
        }

        public async Task<RecurringTask> UpdateRecurringTaskAsync(RecurringTask work)
        {
            _context.Set<RecurringTask>().Update(work);
            await _context.SaveChangesAsync();

            return work;
        }

        public async Task<RecurringTask> RemoveRecurringTaskAsync(RecurringTask work)
        {
            _context.Set<RecurringTask>().Remove(work);
            await _context.SaveChangesAsync();

            return work;
        }

        public async Task<RouteLocation> GetRoutLocation(string id)
        {
            return await _context.Set<RouteLocation>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddLocationTaskAsync(string routeId, string taskId)
        {
            var entity = new EntityTask<RouteLocation>()
            {
                TaskId = taskId,
                EntityId = routeId
            };
            _context.Set<EntityTask<RouteLocation>>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<FormElement<RecurringTask>> AddFormElementAsync(FormElement<RecurringTask> formElement)
        {
            _context.Set<FormElement<RecurringTask>>().Add(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }
    }
}
