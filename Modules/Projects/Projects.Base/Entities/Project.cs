using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.BaseTypes;

namespace Projects.Base.Entities
{
    /// <summary>
    /// Represents a project in the application
    /// </summary>
    public class Project : ImageFileCollection<Project>
    {
        #region Properties

        /// <summary>
        /// The date the project was started
        /// </summary>
        [Display(Name = @"Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The date the project was completed
        /// </summary>
        [Display(Name = @"End Date")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The name of the project
        /// </summary>
        [Display(Name = @"Project Name")]
        [Required(ErrorMessage = @"Project Name is Required")]
        public string ProjectName { get; set; }

        /// <summary>
        /// Flag to indicate if the project is completed
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// The Url of the project
        /// </summary>
        [Display(Name = @"Project Url")]
        public string ProjectUrl { get; set; }

        /// <summary>
        /// Flag to indigate if this is a featured project
        /// </summary>
        [Display(Name = @"Featured")]
        public bool Featured { get; set; }

        /// <summary>
        /// The location where the project was done
        /// </summary>
        [Display(Name = @"Location")]
        public string Location { get; set; }

        /// <summary>
        /// The short description of this project
        /// </summary>
        [Display(Name = @"Short Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// The long description of the project
        /// </summary>
        [Display(Name = @"Long Description")]
        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }

        /// <summary>
        /// The identity of the Customer this project belongs to
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The collection of tags belonging to this project
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// The folder path of the shared projects folder
        /// </summary>
        public string SharedProjectFolderPath { get; set; }

        #endregion

        #region Relationships

        /// <summary>
        /// The parent project if this is a linked project
        /// </summary>
        [ForeignKey(nameof(ParentProject))]
        public string ParentProjectId { get; set; }
        public Project ParentProject { get; set; }

        #endregion

        #region Collection

        /// <summary>
        /// Categories this project belongs to
        /// </summary>
        public virtual ICollection<EntityCategory<Project>> Categories { get; set; } = new List<EntityCategory<Project>>();

        /// <summary>
        /// A list of projects that is linked to this project
        /// </summary>
        public virtual ICollection<Project> LinkedProjects { get; set; } = new List<Project>();

        #endregion
    }
}
