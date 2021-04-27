using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Filing.Base.Entities;
using Identity.Base.Entities;

namespace Messaging.Base.Entities
{
    public class Message : ImageFileCollection<Message>
    {
        /// <summary>
        /// The name of the message, usually the senders name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The time the message was deliverd
        /// </summary>
        public DateTime? DeliveredTime { get; set; }
        /// <summary>
        /// The name of the message, usually the senders name
        /// </summary>
        public bool Delivered { get; set; }

        /// <summary>
        /// The time the message was read
        /// </summary>
        public DateTime? ReadTime { get; set; }

        /// <summary>
        /// Flag to indicate if message was read
        /// </summary>
        public bool Read
        {
            get { return ReadTime != null; }
        }

        /// <summary>
        /// The message
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string MessageString { get; set; }

        /// <summary>
        /// The user that sent the message
        /// </summary>
        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; }
        public UserInfo Sender { get; set; }

        /// <summary>
        /// The user that sent the message
        /// </summary>
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; }
        public UserInfo Receiver { get; set; }

        /// <summary>
        /// The Chat this message belongs to
        /// </summary>
        public string ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
