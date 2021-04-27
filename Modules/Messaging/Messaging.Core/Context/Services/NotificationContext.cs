using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messaging.Core.Context.Services
{
    public class NotificationContext
    {
        private readonly DbContext _context;

        public NotificationContext(DbContext context)
        {
            _context = context;
        }

        public async Task<Notification> GetNotificationAsync(string id)
        {
           return await _context.Set<Notification>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Notification> GetUnreadNotifications()
        {
            var list = _context.Set<Notification>().Where(c => !c.Read);
            return list;

        }

        public IEnumerable<Notification> GetNotifications()
        {
            var list = _context.Set<Notification>().OrderBy(c => c.Created);
            return list;

        }

        public async Task<Notification> AddNotificationAsync(Notification notification)
        {
            try
            {
                _context.Set<Notification>().Add(notification);
                await _context.SaveChangesAsync();
                return notification;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task<Notification> MarkAsReadAsync(string id)
        {
            var entity = await _context.Set<Notification>().FirstOrDefaultAsync(c => c.Id == id);
            entity.Read = true;
            _context.Set<Notification>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Notification> RemoveNotificationAsync(string id)
        {
            var entity = await _context.Set<Notification>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<Notification>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        
    }
}
