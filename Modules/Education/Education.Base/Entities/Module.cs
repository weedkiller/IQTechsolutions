using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;

namespace Education.Base.Entities
{
    /// <summary>
    /// Represents a training module of a training course
    /// </summary>
    public class Module : ImageFileCollection<Module>
    {
        private string _fileFolder;

        /// <summary>
        /// Gets or Sets the module nr
        /// </summary>
        [DisplayName("Module Nr")]
        public int ModuleNr { get; set; }

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
        /// Gets or Sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parent training course
        /// </summary>
        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; }
        public Course Course { get; set; }

        /// <summary>
        /// Gets or Sets the collection of sections that belongs to this training course
        /// </summary>
        public ICollection<Section> Sections { get; set; } = new List<Section>();

        /// <summary>
        /// A Collection of <see cref="AssessmentElement{T}"/> that belongs to this course
        /// </summary>
        public ICollection<AssessmentElement<Module>> AssessmentElements { get; set; } = new List<AssessmentElement<Module>>();
    }
}
