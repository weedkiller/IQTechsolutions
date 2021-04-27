using System.Collections.Generic;
using Filing.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Messaging.Entities;

namespace Messaging.Base.Entities
{
    /// <summary>
    /// This is a chat that different users can use to send messages to each other
    /// </summary>
    public class Chat : EntityBase
    {
        /// <summary>
        /// The chat imageUrl
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The name of the message, usually the senders name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the message, usually the senders name
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of chat this is <see cref="ChatType"/>
        /// </summary>
        public ChatType Type { get; set; }

        /// <summary>
        /// The messages in this chat
        /// </summary>
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        /// <summary>
        /// The users using on this chat
        /// </summary>
        public ICollection<ChatUser> Users { get; set; } = new List<ChatUser>();
    }
}
