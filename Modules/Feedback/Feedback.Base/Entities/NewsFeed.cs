using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;

namespace Feedback.Base.Entities
{
    /// <summary>
    /// The object that represents a feed item for an application
    /// </summary>
    public class NewsFeed : ImageFileCollection<NewsFeed>
    {
        #region Properties

        /// <summary>
        /// The image of the message
        /// </summary>
        public string ImageUrl { get; set; }

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
        /// Gets or sets the Private Feed flag
        /// </summary>
        public bool Private { get; set; }

        #endregion

        #region Relationships

        /// <summary>
        /// The user that sent the message
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserInfo User { get; set; }

        /// <summary>
        /// Gets or sets the the parent value of this is a child feed item
        /// </summary>
        [ForeignKey(nameof(ParentFeed))]
        public string ParentFeedId { get; set; }
        public NewsFeed ParentFeed { get; set; }

        #endregion

        #region Collection

        /// <summary>
        /// The collection of likes that belongs to this post
        /// </summary>
        public ICollection<EntityFeeling> FeedFeelings { get; set; } = new List<EntityFeeling>();

        /// <summary>
        /// The collection of feeds that belongs to this post
        /// </summary>
        public ICollection<NewsFeed> Comments { get; set; } = new List<NewsFeed>();

        /// <summary>
        /// The collection of files that belongs to this feed
        /// </summary>
        public ICollection<File<NewsFeed>> Files { get; set; } = new List<File<NewsFeed>>();

        /// <summary>
        /// The collection of audio files that belongs to this feed
        /// </summary>
        public ICollection<AudioFile<NewsFeed>> AudioFiles { get; set; } = new List<AudioFile<NewsFeed>>();

        /// <summary>
        /// The collection of videos that belong to this feed
        /// </summary>
        public ICollection<Video<NewsFeed>> Videos { get; set; } = new List<Video<NewsFeed>>();

        #endregion
    }
}
