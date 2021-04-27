using System.Collections.Generic;
using Feedback.Base.Entities;
using Iqt.Base.Models;

namespace Feedback.Core.Models
{
    /// <summary>
    /// The model used to add or edit a ticket
    /// </summary>
    public class TicketIndexModel : IndexModelBase<SupportTicket>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Constructor from parameter <see cref="SupportTicket" />
        /// </summary>
        /// <param name="collection">The support ticket collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page nr</param>
        public TicketIndexModel(ICollection<SupportTicket> collection, int? size = null, int? page = null) : base(collection, size, page) { }
        
        #endregion
    }
}