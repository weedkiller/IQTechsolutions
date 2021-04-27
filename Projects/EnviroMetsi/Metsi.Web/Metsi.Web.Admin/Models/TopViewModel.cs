using System.Collections.Generic;
using Identity.Base.Entities;
using Messaging.Base.Entities;

namespace Metsi.Web.Admin.Models
{
    /// <summary>
    /// This class represents the model used for the top panel
    /// </summary>
    public class TopBarViewModel
    {
        /// <summary>
        /// Gets or sets the signed in application user
        /// </summary>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// Gets or sets the collection of messages
        /// </summary>
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        /// <summary>
        /// Gets or sets the user notifications
        /// </summary>
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
