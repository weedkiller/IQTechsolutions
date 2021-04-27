using System.Collections.Generic;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Iqt.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Core.Context.Services
{
    public class FormElementContext
    {
        private DbContext _context;

        public FormElementContext(DbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<FormElement<RecurringTask>>> GetAll()
        {
            return await _context.Set<FormElement<RecurringTask>>().ToListAsync();
        }

        public async Task<FormElement<RecurringTask>> AddFormElementAsync(FormElement<RecurringTask> formElement)
        {
            _context.Set<FormElement<RecurringTask>>().Add(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }
    }
}
