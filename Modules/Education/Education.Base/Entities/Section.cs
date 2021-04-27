using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;

namespace Education.Base.Entities
{
    /// <summary>
    /// Represents a section of a training module
    /// </summary>
    public class Section : ImageFileCollection<Section>
    {
        private string _fileFolder;

        /// <summary>
        /// Gets or Sets the section nr
        /// </summary>
        [DisplayName("Section Nr")]
        public int SectionNr { get; set; }

        /// <summary>
        /// Gets or Sets the folder that contain the files that belong to this Course 
        /// </summary>
        /// <returns>The name of the file folder</returns>
        [DisplayName("File Folder")]
        public string FileFolder
        {
            get
            {
                if (DoNotCreateDocumentsFolder)
                    return null;
                return string.IsNullOrEmpty(_fileFolder) ? Name : _fileFolder;

            }
            set => _fileFolder = value;
        }

        /// <summary>
        /// Gets or Sets the path to the file folder
        /// </summary>
        [DisplayName("File Path")]
        public string FolderPath { get; set; }

        /// <summary>
        /// Gets the full path of the file folder
        /// </summary>
        [DisplayName("Full Path")]
        public string FullPath => string.IsNullOrEmpty(FolderPath) ? FileFolder : FolderPath + "/" + FileFolder;

        /// <summary>
        /// Flag to indicate if a documents folder should be created on the hard disk of the application host
        /// </summary>
        public bool DoNotCreateDocumentsFolder { get; set; }

        /// <summary>
        /// Gets or sets the url of the video featured by this section
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Gets or Sets the name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the description
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the training module this section belongs to
        /// </summary>
        [ForeignKey(nameof(Module))]
        public string ModuleId { get; set; }
        public Module Module { get; set; }

        /// <summary>
        /// Gets of Sets the training section parent if any
        /// </summary>
        public string ParentSectionId { get; set; }
        public Section ParentSection { get; set; }

        /// <summary>
        /// The collection of training sections that belong to this section
        /// </summary>
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
