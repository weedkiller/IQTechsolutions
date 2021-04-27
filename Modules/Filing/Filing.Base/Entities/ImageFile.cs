using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Enums;

namespace Filing.Base.Entities
{
    /// <summary>
    /// Any Image Files this application uses
    /// </summary>
    public class ImageFile : FileBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ImageFile() : base()
        {
        }

        /// <summary>
        /// Constructor with parameters that utilizes base constructor
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="contentType">The file type</param>
        /// <param name="size">The file size (content length)</param>
        /// <param name="imageType">The image type</param>
        public ImageFile(string filename, string contentType, long size, ImageType imageType = ImageType.Cover) : base(filename, contentType, size)
        {
            ImageType = ImageType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the image type
        /// </summary>
        public ImageType ImageType { get; set; }

        #endregion
    }

    public class ImageFile<TEntity> : ImageFile
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ImageFile() : base()
        {
        }

        /// <summary>
        /// Constructor with parameters that utilizes base constructor
        /// </summary>
        /// <param name="fileEntry">The input</param>
        /// <param name="type">The type of file (for website use)</param>
        public ImageFile(string filename, string contentType, long size, ImageType imageType = ImageType.Cover) : base(filename, contentType, size, imageType)
        {
        }

        #endregion

        /// <summary>
        /// The entity this image belongs to
        /// </summary>
        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public TEntity Entity { get; set; }
    }
}
