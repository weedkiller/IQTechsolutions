using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Enums.Support;

namespace Feedback.Base.Entities
{
    public class Comment<T> : EntityBase
    {
        public TicketStatus Status { get; set; } = TicketStatus.New;

        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public T Entity { get; set; }

        /// <summary>
        /// The subject of this message
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// The content of the message
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        /// <summary>
        /// The device that created this message
        /// </summary>
        public string FromDevice { get; set; }

        /// <summary>
        /// The user that sent the message
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserInfo User { get; set; }

        /// <summary>
        /// The collection of likes that belongs to this post
        /// </summary>
        public ICollection<EntityFeeling> FeedFeelings { get; set; } = new List<EntityFeeling>();

        public ICollection<Comment<T>> Comments { get; set; } = new List<Comment<T>>();
    }
}
