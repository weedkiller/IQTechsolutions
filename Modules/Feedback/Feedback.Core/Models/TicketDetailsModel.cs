using Feedback.Base.Entities;
using Iqt.Base.Models;

namespace Feedback.Core.Models
{
    /// <summary>
    /// The model used to add or edit a ticket
    /// </summary>
    public class TicketDetailsModel : DetailsModelBase<SupportTicket>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Constructor from parameter <see cref="SupportTicket" />
        /// </summary>
        /// <param name="entity">The entity used to construct this model</param>
        public TicketDetailsModel(SupportTicket entity) : base(entity) { }
        
        #endregion
    }
}