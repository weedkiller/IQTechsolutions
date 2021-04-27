using System.IO;
using System.Linq;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Interfaces;
using Iqt.Base.Interfaces;

namespace Filing.Base.Extensions
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Gets the specific image type folder
        /// </summary>
        /// <param name="type">The image type</param>
        /// <returns>The image path</returns>
        public static string GetImageTypeFolder(this ImageType type)
        {
            switch (type)
            {
                case ImageType.Banner:
                    return "banners";
                case ImageType.Cover:
                    return "covers";
                case ImageType.Icon:
                    return "icons";
                case ImageType.Image:
                    return "images";
                case ImageType.Mockup:
                    return "mockups";
                case ImageType.Slider:
                    return "sliders";
                case ImageType.Profile:
                    return "profileImages";
                case ImageType.StoreFront:
                    return "storefronts";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the first of a specific type image from the database
        /// </summary>
        /// <typeparam name="TItem">The type the image belongs to</typeparam>
        /// <param name="files">The files the image should be retrieved from</param>
        /// <param name="type">The type of image to be retrieved</param>
        /// <returns>a specific image file</returns>
        public static ImageFile<TItem> GetImage<TItem>(this IImageCollectionEntity<TItem> files, ImageType type = ImageType.Cover)
        {
            return files.Images?.FirstOrDefault(c => c.ImageType == type);
        }

        /// <summary>
        /// Gets the image path of the first of a specific type image from the database
        /// </summary>
        /// <typeparam name="TItem">The type the image belongs to</typeparam>
        /// <param name="files">The files the image should be retrieved from</param>
        /// <param name="type">The type of image to be retrieved</param>
        /// <param name="placeHolder">The placeholder path if the the file is null</param>
        /// <returns>The specific image path</returns>
        public static string GetPath<TItem>(this IImageCollectionEntity<TItem> files, ImageType type = ImageType.Cover, string placeHolder = null)
        {
            var entity = files.Images?.FirstOrDefault(c => c.ImageType == type);
            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.RelativePath))
                    return placeHolder;
                return $"/{entity.RelativePath}";
            }
            return placeHolder;
        }

        /// <summary>
        /// Gets the image path of the first of a specific type image from the database from a specific domain
        /// </summary>
        /// <typeparam name="TItem">The type the image belongs to</typeparam>
        /// <param name="files">The files the image should be retrieved from</param>
        /// <param name="website">The domain that the image is located in</param>
        /// <param name="type">The type of image to be retrieved</param>
        /// <param name="placeHolder">The placeholder path if the the file is null</param>
        /// <returns>The specific image path from a specific domain</returns>
        public static string GetPath<TItem>(this IImageCollectionEntity<TItem> files, string website, ImageType type = ImageType.Cover, string placeHolder = null)
        {
            var entity = files.Images?.FirstOrDefault(c => c.ImageType == type);
            if (entity != null)
            {
                if (!string.IsNullOrEmpty(entity.RelativePath))
                {
                    return string.IsNullOrEmpty(website) ? $"/{entity.RelativePath}" : Path.Combine(website, entity.RelativePath);
                }
            }
            if (!string.IsNullOrEmpty(placeHolder))
                return string.IsNullOrEmpty(website) ? placeHolder : Path.Combine(website, placeHolder);
            return null;
        }

        /// <summary>
        /// Get the image path
        /// </summary>
        /// <typeparam name="TEntity">The type this image belongs to</typeparam>
        /// <param name="entity">The image file</param>
        /// <param name="placeHolder">The placeholder path</param>
        /// <returns>The specific image path</returns>
        public static string GetPath<TEntity>(this ImageFile<TEntity> entity, string placeHolder = null)
        {
            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.RelativePath))
                    return placeHolder;
                return $"/{entity.RelativePath}";
            }
            return placeHolder;
        }

        /// <summary>
        /// Get the image path
        /// </summary>
        /// <param name="entity">The image file</param>
        /// <param name="placeHolder">The placeholder path</param>
        /// <returns>The specific image path</returns>
        public static string GetPath(this ImageFile entity, string placeHolder = null)
        {
            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.RelativePath))
                    return placeHolder;
                return $"/{entity.RelativePath}";
            }
            return placeHolder;
        }

        /// <summary>
        /// Get image from the another domain
        /// </summary>
        /// <param name="website">The website that the image should be retrieved from</param>
        /// <param name="file">The image file that must be retrieved</param>
        /// <param name="placeholderPath">The placeholder path</param>
        /// <returns>The specific image path</returns>
        public static string GetPath<TEntity>(this ImageFile<TEntity> file, string website, string placeholderPath = null) where TEntity : IEntityBase
        {
            if (file == null)
            {
                return placeholderPath;
            }
            return $"{Path.Combine(website, file.RelativePath)}";
        }

        /// <summary>
        /// Get image from the another domain
        /// </summary>
        /// <param name="website">The website that the image should be retrieved from</param>
        /// <param name="file">The image file that must be retrieved</param>
        /// <param name="placeholderPath">The placeholder path</param>
        /// <returns>The specific image path</returns>
        public static string GetPath(this ImageFile file, string website, string placeholderPath = null)
        {
            if (file == null)
            {
                return placeholderPath;
            }
            return $"{Path.Combine(website, file.RelativePath)}";
        }

        /// <summary>
        /// Get the image path
        /// </summary>
        /// <typeparam name="TEntity">The type this image belongs to</typeparam>
        /// <param name="file">The video file</param>
        /// <param name="placeHolder">The placeholder path</param>
        /// <returns>The specific image path</returns>
        public static string GetPath<TEntity>(this Video<TEntity> file, string placeHolder = null) where TEntity : IEntityBase
        {
            if (file != null)
            {
                if (string.IsNullOrEmpty(file.RelativePath))
                    return placeHolder;
                return $"/{file.RelativePath}";
            }
            return placeHolder;
        }

        /// <summary>
        /// Get image from the another domain
        /// </summary>
        /// <param name="website">The website that the image should be retrieved from</param>
        /// <param name="file">The image file that must be retrieved</param>
        /// <param name="placeholderPath">The placeholder path</param>
        /// <returns>The specific image path</returns>
        public static string GetPath<TEntity>(this Video<TEntity> file, string website, string placeholderPath = null) where TEntity : IEntityBase
        {
            if (file == null)
            {
                return placeholderPath;
            }
            return $"{Path.Combine(website, file.RelativePath)}";
        }

        /// <summary>
        /// Get the image path
        /// </summary>
        /// <typeparam name="TEntity">The type this image belongs to</typeparam>
        /// <param name="file">The image file that must be retrieved</param>
        /// <param name="placeHolder">The placeholder path</param>
        /// <returns></returns>
        public static string GetPath<TEntity>(this AudioFile<TEntity> file, string placeHolder = null) where TEntity : IEntityBase
        {
            if (file != null)
            {
                if (string.IsNullOrEmpty(file.RelativePath))
                    return placeHolder;
                return $"/{file.RelativePath}";
            }
            return placeHolder;
        }

        /// <summary>
        /// Get image from the another domain
        /// </summary>
        /// <param name="website">The website that the image should be retrieved from</param>
        /// <param name="file">The image file that must be retrieved</param>
        /// <param name="placeholderPath">The placeholder path</param>
        /// <returns></returns>
        public static string GetPath<TEntity>(this AudioFile<TEntity> file, string website, string placeholderPath = null) where TEntity : IEntityBase
        {
            if (file == null)
            {
                return placeholderPath;
            }
            return $"{Path.Combine(website, file.RelativePath)}";
        }
    }
}
