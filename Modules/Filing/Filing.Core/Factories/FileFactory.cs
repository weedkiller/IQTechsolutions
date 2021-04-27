using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Helpers;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Filing.Core.Factories
{
    public class FileFactory : IFileFactory
    {
        private readonly string _rootImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private readonly DbContext _context;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">Injected Database Context</param>
        public FileFactory(DbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<ImageFile<T>> UploadImageAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string rootFolderPath, ImageType type, Point point, Size defaultSize, string parentId = null, bool perserveAspectRatio = false) where T : IEntityBase
        {
            var oldFile = _context.Set<ImageFile<T>>().FirstOrDefault(c => c.Id == oldFileId);

            if (upload != null)
            {
                if (oldFileId != null && oldFile != null)
                {
                    DeleteFile(oldFile.FolderPath, oldFile.FileName);
                    _context.Set<ImageFile<T>>().Remove(oldFile);

                    await _context.SaveChangesAsync();
                }

                var ff = await UploadImageAsync<T>(upload, rootFolderPath, point, defaultSize, type, parentId, perserveAspectRatio);
                _context.Set<ImageFile<T>>().Add(ff);
                await _context.SaveChangesAsync();
                return ff;

            }

            if (oldFile != null)
                return oldFile;

            return null;
        }

        public async Task<Video<T>> UploadVideoAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string videoName, string videoDescription, string rootFolderPath, string parentId = null) where T : IEntityBase
        {
            var oldFile = _context.Set<Video<T>>().FirstOrDefault(c => c.Id == oldFileId);

            if (upload != null)
            {
                if (oldFileId != null)
                {
                    DeleteFile(oldFile.FolderPath, oldFile.FileName);
                    _context.Set<Video<T>>().Remove(oldFile);

                    await _context.SaveChangesAsync();
                }

                var ff = await UploadVideoAsync<T>(upload, videoName, videoDescription, rootFolderPath, parentId);
                _context.Set<Video<T>>().Add(ff);
                await _context.SaveChangesAsync();
                return ff;

            }

            if (oldFile != null)
                return oldFile;

            return null;
        }

        public async Task<AudioFile<T>> UploadAudioAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string audioName, string audioDescription, string rootFolderPath, string parentId = null) where T : IEntityBase
        {
            var oldFile = _context.Set<AudioFile<T>>().FirstOrDefault(c => c.Id == oldFileId);

            if (upload != null)
            {
                if (oldFileId != null)
                {
                    DeleteFile(oldFile.FolderPath, oldFile.FileName);
                    _context.Set<AudioFile<T>>().Remove(oldFile);

                    await _context.SaveChangesAsync();
                }

                var ff = await UploadAudioAsync<T>(upload, audioName, audioDescription, rootFolderPath, parentId);
                _context.Set<AudioFile<T>>().Add(ff);
                await _context.SaveChangesAsync();
                return ff;

            }

            if (oldFile != null)
                return oldFile;

            return null;
        }

        public async Task<File<T>> UploadFileAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string name, string description, string rootFolderPath, string parentId = null) where T : IEntityBase
        {
            var oldFile = _context.Set<File<T>>().FirstOrDefault(c => c.Id == oldFileId);

            if (upload != null)
            {
                if (oldFileId != null)
                {
                    DeleteFile(oldFile.FolderPath, oldFile.FileName);
                    _context.Set<File<T>>().Remove(oldFile);

                    await _context.SaveChangesAsync();
                }

                var ff = await UploadFileAsync<T>(upload, name, description, rootFolderPath, parentId);
                _context.Set<File<T>>().Add(ff);
                await _context.SaveChangesAsync();
                return ff;

            }

            if (oldFile != null)
                return oldFile;

            return null;
        }

        public async Task<ImageFile<T>> UploadImageAsync<T>(IFormFile file, string rootFolderPath, Point point, Size defaultSize, ImageType type, string parentId, bool perserveAspectRatio)
        {
            // Check if the file exists
            if (file != null)
            {
                
                    //var filename = ContentDispositionHeaderValue
                    //    .Parse(file.ContentDisposition)
                    //    .FileName
                    //    .Trim('"');

                    // Create the image file
                    var image = CreateImageFile<T>(file, rootFolderPath, type, parentId);
                    // Write the default file to the hard disk
                    await WriteImageToDiskAsync(file, rootFolderPath, image.FileName, point, defaultSize, perserveAspectRatio);

                    // returns the image file used for the uploads
                    return image;
                
                // returns nothing if it was not an image file
                return null;
            }
            // returns nothing if it was not a file
            return null;
        }

        public async Task<Video<T>> UploadVideoAsync<T>(IFormFile file, string videoName, string videoDescription, string rootFolderPath, string parentId) where T : IEntityBase
        {
            // Check if the file exists
            if (file != null)
            {
                
                    //var filename = ContentDispositionHeaderValue
                    //    .Parse(file.ContentDisposition)
                    //    .FileName
                    //    .Trim('"');

                    // Create the image file
                    var image = CreateVideoFile<T>(file, videoName, videoDescription,rootFolderPath, parentId);
                    // Write the default file to the hard disk
                    await WriteToDiskAsync(file, rootFolderPath, image.FileName);

                    // returns the image file used for the uploads
                    return image;
                
            }
            // returns nothing if it was not a file
            return null;
        }

        public async Task<AudioFile<T>> UploadAudioAsync<T>(IFormFile file, string audioName, string audioDescription, string rootFolderPath, string parentId) where T : IEntityBase
        {
            // Check if the file exists
            if (file != null)
            {
                
                    //var filename = ContentDispositionHeaderValue
                    //    .Parse(file.ContentDisposition)
                    //    .FileName
                    //    .Trim('"');

                    // Create the image file
                    var image = CreateAudioFile<T>(file, audioName, audioDescription, rootFolderPath, parentId);
                    // Write the default file to the hard disk
                    await WriteToDiskAsync(file, rootFolderPath, image.FileName);

                    // returns the image file used for the uploads
                    return image;
                
            }
            // returns nothing if it was not a file
            return null;
        }

        public async Task<File<T>> UploadFileAsync<T>(IFormFile file, string name, string description, string rootFolderPath, string parentId) where T : IEntityBase
        {
            // Check if the file exists
            if (file != null)
            {
                //var filename = ContentDispositionHeaderValue
                    //    .Parse(file.ContentDisposition)
                    //    .FileName
                    //    .Trim('"');

                    // Create the image file
                    var image = CreateFile<T>(file, name, description, rootFolderPath, parentId);
                    // Write the default file to the hard disk
                    await WriteToDiskAsync(file, rootFolderPath, image.FileName);

                    // returns the image file used for the uploads
                    return image;
                
            }
            // returns nothing if it was not a file
            return null;
        }

        /// <summary>
        /// Creates a new image file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file">The filelist entry to upload</param>
        /// <param name="path">The image path where the image will be saved</param>
        /// <param name="type">The image type</param>
        /// <param name="parentId">The parentId of the image</param>
        /// <returns></returns>
        public ImageFile<T> CreateImageFile<T>(string filename, string contentType, long size, ImageType type, string parentId)
        {
            try
            {
                var idd = Guid.NewGuid().ToString();

                // Create a new file name for security reasons
                var fileName = Path.GetFileNameWithoutExtension(filename) + "_" + idd + Path.GetExtension(filename);

                // Create a new Filebase
                var newfile = new ImageFile<T>()
                {
                    Id = idd,
                    FileName = fileName,
                    ContentType = contentType,
                    Size = size,
                    ImageType = type,
                    EntityId = parentId,
                    RelativePath = Path.Combine("images", "uploads", typeof(T).Name, type.GetImageTypeFolder(), fileName),
                    FolderPath = Path.Combine(_rootImagePath, "images", "uploads", typeof(T).Name, type.GetImageTypeFolder())
                };

                // Returns the newly created file
                return newfile;
            }
            catch (Exception e)
            {
                // Returns and error message if something went wrong
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new Image File
        /// </summary>
        /// <param name="file">The file being uploaded and should be used</param>
        /// <param name="path">The path structure used</param>
        /// <param name="type">The image type</param>
        /// <param name="parentId">The identity of the image parent</param>
        /// <returns>The file that was created</returns>
        public ImageFile<T> CreateImageFile<T>(IFormFile file, string path, ImageType type, string parentId)
        {
            try
            {
                var idd = Guid.NewGuid().ToString();

                // Create a new file name for security reasons
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + idd + Path.GetExtension(file.FileName);

                // Create a new Filebase
                var newffile = new ImageFile<T>()
                {
                    Id = idd,
                    FileName = fileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    RelativePath = Path.Combine(path, fileName),
                    FolderPath = Path.Combine(_rootImagePath, path),
                    EntityId = parentId,
                    ImageType = type
                };

                // Returns the newly created file
                return newffile;
            }
            catch (Exception e)
            {
                // Returns and error message if something went wrong
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new video file
        /// </summary>
        /// <typeparam name="T">The type the video belongs to</typeparam>
        /// <param name="file">The file being uploaded</param>
        /// <param name="videoName">The name of the video</param>
        /// <param name="videoDescription">The description of the video</param>
        /// <param name="path">The path the video should be saved to</param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public Video<T> CreateVideoFile<T>(IFormFile file, string videoName, string videoDescription, string path, string parentId) where T : IEntityBase
        {
            try
            {
                var idd = Guid.NewGuid().ToString();

                // Create a new file name for security reasons
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + idd + Path.GetExtension(file.FileName);

                // Create a new Filebase
                var newffile = new Video<T>()
                {
                    Name = videoName,
                    Description = videoDescription,
                    Id = idd,
                    FileName = fileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    RelativePath = Path.Combine(path, fileName),
                    FolderPath = Path.Combine(_rootImagePath, path),
                    EntityId = parentId
                };

                // Returns the newly created file
                return newffile;
            }
            catch (Exception e)
            {
                // Returns and error message if something went wrong
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new audio file
        /// </summary>
        /// <typeparam name="T">The type the audio file belongs to</typeparam>
        /// <param name="file">The file being uploaded</param>
        /// <param name="audioName">The audio file name</param>
        /// <param name="audioDescription">The audio file description</param>
        /// <param name="path">The path that the audio file should be saved to</param>
        /// <param name="parentId">The parent entities identity</param>
        /// <returns>The created audio file</returns>
        public AudioFile<T> CreateAudioFile<T>(IFormFile file, string audioName, string audioDescription, string path, string parentId) where T : IEntityBase
        {
            try
            {
                var idd = Guid.NewGuid().ToString();

                // Create a new file name for security reasons
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + idd + Path.GetExtension(file.FileName);

                // Create a new Filebase
                var newffile = new AudioFile<T>()
                {
                    Name = audioName,
                    Description = audioDescription,
                    Id = idd,
                    FileName = fileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    RelativePath = Path.Combine(path, fileName),
                    FolderPath = Path.Combine(_rootImagePath, path),
                    EntityId = parentId
                };

                // Returns the newly created file
                return newffile;
            }
            catch (Exception e)
            {
                // Returns and error message if something went wrong
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new attachment file
        /// </summary>
        /// <typeparam name="T">The type the attachment file belongs to</typeparam>
        /// <param name="file">The file being uploaded</param>
        /// <param name="name">The name of the attachment file</param>
        /// <param name="description">The description of the attachment file</param>
        /// <param name="path">The path the attachment file should be saved to</param>
        /// <param name="parentId">The identity of parent entity</param>
        /// <returns>The created attachment file</returns>
        public File<T> CreateFile<T>(IFormFile file, string name, string description, string path, string parentId) where T : IEntityBase
        {
            try
            {
                var idd = Guid.NewGuid().ToString();

                // Create a new file name for security reasons
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + idd + Path.GetExtension(file.FileName);

                // Create a new Filebase
                var newffile = new File<T>()
                {
                    Name = name,
                    Description = description,
                    Id = idd,
                    FileName = fileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    RelativePath = Path.Combine(path, fileName),
                    FolderPath = Path.Combine(_rootImagePath, path),
                    EntityId = parentId
                };

                // Returns the newly created file
                return newffile;
            }
            catch (Exception e)
            {
                // Returns and error message if something went wrong
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Writes the file to the disk
        /// </summary>
        /// <param name="file">The file that must be uploaded</param>
        /// <param name="filePath">The path of the file</param>
        /// <param name="size">The size of the file path</param>
        /// <param name="perserveAspectRatio">Flag to indicate if the aspect ratio should be persevered</param>
        /// <param name="filename">The name of the file</param>
        public async Task WriteImageToDiskAsync(IFormFile file, string filePath, string filename, Point point, Size size, bool perserveAspectRatio)
        {
            var path = Path.Combine(_rootImagePath, filePath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Write the file to the disk
            using (var bits = new FileStream(Path.Combine(path, filename), FileMode.Create))
            {
                await ResizeImage(file, point, size, perserveAspectRatio).CopyToAsync(bits);
            }
        }

        /// <summary>
        /// Writes the file to the disk
        /// </summary>
        /// <param name="file">The file that must be uploaded</param>
        /// <param name="filePath">The path of the file</param>
        /// <param name="filename">The name of the file</param>
        public async Task WriteToDiskAsync(IFormFile file, string filePath, string filename)
        {
            var path = Path.Combine(_rootImagePath, filePath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Write the file to the disk
            using (var bits = new FileStream(Path.Combine(path, filename), FileMode.Create))
            {
                await file.CopyToAsync(bits);
            }
        }

        public void CreateDirectory(string path)
        {
            if (Directory.Exists(path)) return;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteImageAndRemoveFormDbAsync<T>(ImageFile<T> file) where T : IEntityBase
        {
            if (file != null)
            {
                try
                {
                    DeleteFile(file.FolderPath, file.FileName);
                    _context.Set<ImageFile<T>>().Remove(file);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// Method to delete a file from a root directory
        /// </summary>
        /// <param name="filename">the file being deleted</param>
        /// <param name="path">The root path the file should be deleted from</param>
        public void DeleteFile(string path, string filename)
        {
            WalkDirectoryTreeAndDelete(path, filename);
        }

        /// <summary>
        /// The method used to delete a file from the server
        /// </summary>
        /// <param name="filepath">The path of the file to be deleted</param>
        public static void DeleteFile(string filepath)
        {
            // Check if the file exists
            if (System.IO.File.Exists(filepath))
            {
                // Delete the file
                System.IO.File.Delete(filepath);
            }
        }

        /// <summary>
        /// Walks the directory tree of the specific path to find the file
        /// </summary>
        /// <param name="path">The path of the directory tree</param>
        /// <param name="filename">The filename to find</param>
        public static void WalkDirectoryTreeAndDelete(string path, string filename)
        {
            DirectoryInfo root = new DirectoryInfo(path);

            var files = root.GetFiles("*.*");
            foreach (FileInfo fi in files.Where(fi => fi.Name == filename))
            {
                DeleteFile(fi.FullName);
            }
            var subDirs = root.GetDirectories();
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTreeAndDelete(dirInfo.FullName, filename);
            }
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file">the image file to check</param>
        /// <returns>Boolean as a method result</returns>
        private static bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.Unknown;
        }

        /// <summary>
        /// Resizes a given image
        /// </summary>
        /// <param name="file">the image to resize</param>
        /// <param name="startPoint">The starting point of the image</param>
        /// <param name="size">the size it should be resized to</param>
        /// <param name="perserveRatio">Should the aspect ration be perserved</param>
        /// <returns></returns>
        public MemoryStream ResizeImage(IFormFile file, Point startPoint, Size size, bool perserveRatio)
        {
            using (Image sourceImage = Image.FromStream(file.OpenReadStream()))
            {
                int newWidth = size.Width;
                int newHeight = size.Height;
                var graphicStartPointX = -startPoint.X;
                var graphicStartPointY = -startPoint.Y;
                var graphicWidth = sourceImage.Width; 
                var graphicHeight = sourceImage.Height; 

                

                if (perserveRatio)
                {
                    int originalWidth = sourceImage.Width;
                    int originalHeight = sourceImage.Height;
                    float percentWidth = size.Width / (float)originalWidth;
                    float percentHeight = size.Height / (float)originalHeight;
                    float percent = percentHeight < percentWidth ? percentHeight : percentWidth;

                    newWidth = (int)(originalWidth * percent);
                    newHeight = (int)(originalHeight * percent);
                    graphicStartPointX = startPoint.X;
                    graphicStartPointY = startPoint.Y;
                    graphicWidth = newWidth;
                    graphicHeight = newHeight;
                }



                Bitmap bitmap = new Bitmap(newWidth, newHeight);

                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(sourceImage, graphicStartPointX, graphicStartPointY, graphicWidth, graphicHeight);
                }

                MemoryStream destination = new MemoryStream();

                if (WriterHelper.GetImageFormat(destination.ToArray()) != WriterHelper.ImageFormat.Png)
                {
                    bitmap.Save(destination, ImageFormat.Png);
                }
                else if (WriterHelper.GetImageFormat(destination.ToArray()) != WriterHelper.ImageFormat.Bmp)
                {
                    bitmap.Save(destination, ImageFormat.Bmp);
                }
                else if (WriterHelper.GetImageFormat(destination.ToArray()) != WriterHelper.ImageFormat.Gif)
                {
                    bitmap.Save(destination, ImageFormat.Gif);
                }
                else if (WriterHelper.GetImageFormat(destination.ToArray()) != WriterHelper.ImageFormat.Jpeg)
                {
                    bitmap.Save(destination, ImageFormat.Jpeg);
                }
                else if (WriterHelper.GetImageFormat(destination.ToArray()) != WriterHelper.ImageFormat.Tiff)
                {
                    bitmap.Save(destination, ImageFormat.Tiff);
                }
                else
                {
                    bitmap.Save(destination, ImageFormat.Jpeg);
                }

                destination.Position = 0;
                bitmap.Dispose();
                sourceImage.Dispose();

                return destination;
            }
        }
    }
}
