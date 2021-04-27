using System.ComponentModel.DataAnnotations;
using Employment.Base.Entities;
using Filing.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Employment.Core.Models
{ 
    /// <summary>
    /// The model used to add or edit a employee entity
    /// </summary>
    public class EmployeeAddEditModel : AddEditModelBase<Employee>
    {
        #region Constructors

        public EmployeeAddEditModel() { }
        public EmployeeAddEditModel(Employee employee)
        {
            Entity = employee;
            if (employee.Addresses != null)
            {
                foreach (var item in employee.Addresses)
                {
                   // Locations.Add(new LocationModel(Math.Round(item.Location.Latitude, 6), Math.Round(item.Location.Longitude, 6), item.Raduis, employee.ToString(), item.ToString(), employee.Bio.TruncateLongString(55), employee.Id));
                }
            }
        }

        #endregion

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

      //  public List<LocationModel> Locations = new List<LocationModel>();

        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string PhoneNr { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
