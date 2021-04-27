using System.ComponentModel.DataAnnotations.Schema;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Messaging.Entities;

namespace Messaging.Base.Entities
{
    public class ChatUser
    {
        /// <summary>
        /// The Chat User
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserInfo User { get; set; }

        /// <summary>
        /// The chat that the user is using
        /// </summary>
        [ForeignKey(nameof(Chat))]
        public string ChatId { get; set; }
        public Chat Chat { get; set; }

        /// <summary>
        /// The User Role
        /// </summary>
        public ChatRole UserRole { get; set; }
    }
}
