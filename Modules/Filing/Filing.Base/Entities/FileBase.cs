using System;
using System.IO;
using Iqt.Base.BaseTypes;

namespace Filing.Base.Entities
{
    /// <summary>
    /// The base class for any file type
    /// </summary>
    public abstract class FileBase : EntityBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        protected FileBase() { }

        /// <summary>
        /// Parameter Constructor
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="type">The file-type</param>
        /// <param name="size">The size</param>
        protected FileBase(string filename, string type, long size)
        {
            FileName = Path.GetFileNameWithoutExtension(filename) + "_" + Guid.NewGuid() + Path.GetExtension(filename);
            ContentType = type;
            Size = size;
        }

        /// <summary>
        /// Parameter Constructor
        /// </summary>
        /// <param name="fileName">The Filename</param>
        /// <param name="type">The file type</param>
        /// <param name="length">The content length</param>
        /// <param name="path">The file path</param>
        protected FileBase(string fileName, string type, long length, string path)
        {
            FileName = Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid() + Path.GetExtension(fileName);
            ContentType = type;
            Size = length;
            RelativePath = Path.Combine(path, FileName);
            FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", RelativePath);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The type of Content eg. png, jpg, txt
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The size of the file
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The relative path of the file
        /// </summary>
        public string RelativePath { get; set; }

        /// <summary>
        /// The folder path of the file
        /// </summary>
        public string FolderPath { get; set; }

        /// <summary>
        /// The full path of the file
        /// </summary>
        public string GetFullPath(string subFolderPath = "")
        {
            return Path.Combine(subFolderPath, FileName);
        }

        /// <summary>
        /// The full path of the file
        /// </summary>
        public string GetRelativePath(string subFolderPath = "")
        {
            return "/www/" + Path.Combine(subFolderPath, FileName);
        }

        #endregion
    }
}
