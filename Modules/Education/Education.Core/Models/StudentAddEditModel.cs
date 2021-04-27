using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Education.Base.Entities;
using Filing.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Student"/> add/edit model
    /// </summary>
    public class StudentAddEditModel : AddEditModelBase<Student>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Parameter less Constructor
        /// </summary>
        public StudentAddEditModel() { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="student">The <see cref="Student"/> featured by this model</param>
        public StudentAddEditModel(Student student) : base(student) { }

        #endregion

        /// <summary>
        /// Gets or Sets the first name of the <see cref="Student"/>
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets the last name of the <see cref="Student"/>
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets the email address of the <see cref="Student"/>
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
        
        /// <summary>
        /// Gets or Sets the email address of the <see cref="Student"/>
        /// </summary>
        public string PhoneNr { get; set; }

        /// <summary>
        /// The coverImage of the <see cref="Student"/>
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The banner image of the <see cref="Student"/>
        /// </summary>
        public IFormFile BannerUpload { get; set; }
        public CropSettings BannerCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The Image collection of the <see cref="Student"/>
        /// </summary>
        public ICollection<IFormFile> ImagesUploads { get; set; }
    }
}
