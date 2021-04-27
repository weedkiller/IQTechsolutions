using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Entities;

namespace Education.Base.Entities
{
    /// <summary>
    /// Represents a training course
    /// </summary>
    public class Course : ImageFileCollection<Course>
    {
        private string _fileFolder;

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
        public string FullPath => string.IsNullOrEmpty(FolderPath) ? FileFolder : Path.Combine(FolderPath, FileFolder);

        /// <summary>
        /// Flag to indicate if a documents folder should be created on the hard disk of the application host
        /// </summary>
        public bool DoNotCreateDocumentsFolder { get; set; }
        
        /// <summary>
        /// Gets or Sets the Categories collection that this <see cref="Course"/> is grouped into
        /// has a many to many relationship with <see cref="EntityCategory{T}"/>
        /// which in turn has a one to many relationship with <see cref="Course"/>
        /// and <see cref="Category{T}"/>
        /// A Category can have many courses and a course can have many categories
        /// </summary>
        public virtual ICollection<EntityCategory<Course>> Categories { get; set; } = new List<EntityCategory<Course>>();

        /// <summary>
        /// Gets or Sets the collection of modules that belongs to this training course
        /// </summary>
        public ICollection<Module> Modules { get; set; } = new List<Module>();

        /// <summary>
        /// A Collection of students that signed in for this course
        /// </summary>
        public ICollection<StudentCourse> Students { get; set; }

        /// <summary>
        /// A Collection of <see cref="FormElement{T}"/> that belongs to this course
        /// </summary>
        public ICollection<AssessmentElement<Course>> AssessmentElements { get; set; } = new List<AssessmentElement<Course>>();
    }
}
