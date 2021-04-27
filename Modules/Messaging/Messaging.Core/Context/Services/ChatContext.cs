using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messaging.Core.Context.Services
{
    public class ChatContext
    {
        private readonly DbContext _context;

        public ChatContext(DbContext context)
        {
            _context = context;
        }

        public async Task<Chat> GetChatAsync(string id)
        {
           return await _context.Set<Chat>().Include(c=> c.Messages).Include(c => c.Users).ThenInclude(c => c.User).ThenInclude(c => c.Images)
               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Chat> GetChats(ChatType type, string userId = "")
        {
            var list = _context.Set<Chat>().Include(c => c.Users).ThenInclude(c => c.User).ThenInclude(c => c.Images).OrderByDescending(c => c.Created).ToList();
            if (!string.IsNullOrEmpty(userId))
            {
                list = list.Where(c => c.Users.Any(g => g.UserId == userId)).ToList();
            }
            if (type != ChatType.All)
            {
                list = list.Where(c => c.Type == type).ToList();
            }
            
            return list;

        }

        public async Task<Chat> AddChatAsync(Chat chat)
        {
            try
            {
                _context.Set<Chat>().Add(chat);
                await _context.SaveChangesAsync();
                return chat;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task<Chat> UpdateChatAsync(Chat chat)
        {
            try
            {
                _context.Set<Chat>().Update(chat);
                await _context.SaveChangesAsync();
                return chat;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<Message> AddMessageAsync(Message message)
        {
            _context.Set<Message>().Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        /// <summary>
        /// Adds a new chat user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ChatUser> AddChatUserAsync(ChatUser user)
        {
            _context.Set<ChatUser>().Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Gets all the chatUsers from the database
        /// </summary>
        /// <returns>An Ienumerable of chat Users</returns>
        public async Task<IEnumerable<ChatUser>> GetChatUsersAsync()
        {
            var users = _context.Set<ChatUser>().Include(c => c.Chat);
            await _context.SaveChangesAsync();
            return users;
        }
    }
}
