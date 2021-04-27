using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messaging.Core.Context.Services
{
    public class TimeLineContext
    {
        private readonly DbContext _context;

        public TimeLineContext(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimelineItem> GetTimeLine(string id)
        {
            var list = _context.Set<TimelineItem>().Where(c => c.OwnerId == id).OrderBy(c => c.Created).ToList();
            return list;

        }

        public async Task<TimelineItem> AddTimeLineItemAsync(TimelineItem timelineItem)
        {
            try
            {
                _context.Set<TimelineItem>().Add(timelineItem);
                await _context.SaveChangesAsync();
                return timelineItem;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
