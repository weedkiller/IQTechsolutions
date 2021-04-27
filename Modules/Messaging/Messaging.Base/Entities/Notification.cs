using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Text;
using Filing.Base.Entities;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;

namespace Messaging.Base.Entities
{
    /// <summary>
    /// This class represents a notification
    /// </summary>
    public class Notification : EntityBase
    {
        /// <summary>
        /// The image of the message
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The name of the message, usually the senders name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag to indicate if message was read
        /// </summary>
        public bool Read { get; set; } = false;

        /// <summary>
        /// The message
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string MessageString { get; set; }

        /// <summary>
        /// The user that sent the message
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserInfo User { get; set; }
    }
}
