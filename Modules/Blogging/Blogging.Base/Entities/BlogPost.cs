using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Extensions;

namespace Blogging.Base.Entities
{
    /// <summary>
    /// The entity used for posting an object
    /// </summary>
    public class BlogPost : ImageFileCollection<BlogPost>
    {
        #region Properties

        /// <summary>
        /// The title of tht post
        /// </summary>
        [Display(Name = @"Title"), Required(ErrorMessage = @"Blog Entry needs a title")]
        public string Title { get; set; }

        /// <summary>
        /// The rating of the blog post
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// The Amount of likes received for this post
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// The Amount of social shares received for this post
        /// </summary>
        public int SocialShares { get; set; }

        /// <summary>
        /// The ammount of times this post was viewed
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// The full content of the post
        /// </summary>
        [Display(Name = @"Article"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// The shortened content of the post
        /// </summary>
        private string _shortDescription;
        [Display(Name = @"Short Description"), DataType(DataType.MultilineText)]
        public string ShortDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_shortDescription))
                    return Description.HtmlToPlainText().TruncateLongString(250);
                return _shortDescription;
            }
            set => _shortDescription = value;
        }

        /// <summary>
        /// A Flag to indicate whether the Post is approved or not
        /// </summary>
        [Display(Name = @"Active")]
        public bool Active { get; set; }

        /// <summary>
        /// A Flag to indicate whether the Post is featured
        /// </summary>
        [Display(Name = @"Featured")]
        public bool Featured { get; set; }

        /// <summary>
        /// Flag to check wether this is a reply or a message (send or received)
        /// </summary>
        public bool Reply { get; set; }

        /// <summary>
        /// Tags associated with this blog entry
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Author if this is a quote
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Flag that indicates whether this entity contains a Author
        /// </summary>
        public bool HasAuthor => !string.IsNullOrEmpty(Author);

        /// <summary>
        /// Url if this is a quote
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Flag that indicates whether this entity contains a link
        /// </summary>
        public bool HasUrl => !string.IsNullOrEmpty(Url);

        #endregion

        #region Relationships

        #region Audio File

        /// <summary>
        /// The audio file's Identity
        /// </summary>
        [ForeignKey("AudioFile")]
        public string AudioFileId { get; set; }

        /// <summary>
        /// The audio file
        /// </summary>
        public AudioFile<BlogPost> AudioFile { get; set; }

        /// <summary>
        /// Flag that indicates whether this entity contains an audio file
        /// </summary>
        public bool HasAudioFile => AudioFile != null;

        #endregion

        #endregion

        #region Collections

        /// <summary>
        /// The categories this entity belongs to
        /// </summary>
        public ICollection<EntityCategory<BlogPost>> Categories { get; set; } = new List<EntityCategory<BlogPost>>();

        ///// <summary>
        ///// Comments associated with this blog entry
        ///// </summary>
        //public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        #endregion

        #region Overrides

        /// <summary>
        /// Overrides the to string method by displaying the title of the post
        /// </summary>
        /// <returns>The Title of the post</returns>
        public override string ToString()
        {
            return Title;
        }

        #endregion
    }
}