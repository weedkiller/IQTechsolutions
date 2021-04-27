using Microsoft.EntityFrameworkCore;

namespace Calendar.Core.Context.Services
{
    public class CalenderContext
    {
        private DbContext _context;

        public CalenderContext(DbContext context)
        {
            _context = context;
        }
    }
}
