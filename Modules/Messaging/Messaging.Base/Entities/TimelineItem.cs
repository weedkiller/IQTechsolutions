using System.ComponentModel.DataAnnotations.Schema;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;

namespace Messaging.Base.Entities
{
    public class TimelineItem : EntityBase
    {
        /// <summary>
        /// Gets or sets the url string for the image used
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

        public TimeLineType TimeLineType { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public UserInfo Owner { get; set; }
    }

    public enum TimeLineType
    {
        SharedImage,
        CalenderItem,
        CommentFrom,
        CommentTo,
        Follow,
        FollowFrom,
        Like,
        Dislike,
        Message,
        Feed
    }
}
