using System.Linq;
using System.Threading.Tasks;
using Feedback.Base.Entities;
using Feedback.Core.Models;
using Filing.Core.Factories;
using Microsoft.EntityFrameworkCore;

// ReSharper disable PossibleNullReferenceException

namespace Feedback.Core.Context.Services
{
    /// <summary>
    /// The context service that manages service details in the database
    /// </summary>
    public class TicketContext<TEntity>
    {
        private readonly DbContext _context;

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public TicketContext(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Get Tickets

        public IQueryable<SupportTicket> GetAll()
        {
            return _context.Set<SupportTicket>().Include(c => c.Files);
        }

        public async Task<SupportTicket> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        #endregion

        #region Add Service

        /// <summary>
        /// Adds an service to the database asyncronously
        /// </summary>
        /// <param name="model">The model the service should be added from</param>
        /// <returns> The employee that was added</returns>
        public async Task<SupportTicket> AddAsync(TicketAddEditModel model)
        { 
            var entity = new SupportTicket()
            {
                Subject = model.Subject,
                Content = model.Content,
                EmailAddress = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CellNr = model.PhoneNr,
                Priority = model.Priority,
                TicketStatus = model.TicketStatus
            };
            _context.Set<SupportTicket>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        #endregion

        #region Update Service

        /// <summary>
        /// Update a specific service
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The updated service</returns>
        public async Task<SupportTicket> UpdateAsync(TicketAddEditModel model)
        {
            var entity = await _context.Set<SupportTicket>().FirstOrDefaultAsync(c => c.Id == model.Id);

            entity.Subject = model.Subject;
            entity.Content = model.Content;
            entity.EmailAddress = model.EmailAddress;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.CellNr = model.PhoneNr;
            entity.Priority = model.Priority;
            entity.TicketStatus = model.TicketStatus;

            _context.Set<SupportTicket>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        #endregion

        #region Delete Service

        /// <summary>
        /// Deletes a specific Service
        /// </summary>
        /// <param name="id">The identity of the service to be deleted</param>
        /// <returns>The deleted blog post</returns>
        public async Task<SupportTicket> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var supportTicket = await GetAsync(id);

            if (supportTicket.ChildTickets != null && supportTicket.ChildTickets.Any())
            {
                foreach (var message in supportTicket.ChildTickets)
                {
                    await DeleteAsync(message.Id);
                }
            }

            // deletes the product from the database
            _context.Set<SupportTicket>().Remove(supportTicket);
            await _context.SaveChangesAsync();

            return supportTicket;
        }

        #endregion
    }
}