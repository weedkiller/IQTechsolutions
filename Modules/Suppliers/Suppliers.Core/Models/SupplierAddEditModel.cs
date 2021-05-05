using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Filing.Base.Entities;
using Iqt.Base.Entities;
using Microsoft.AspNetCore.Http;
using Suppliers.Base.Entities;

namespace Suppliers.Core.Models
{ 
    /// <summary>
    /// The model used to add or edit a supplier entity
    /// </summary>
    public class SupplierAddEditModel
    {
        #region Constructors

        public SupplierAddEditModel() { }
        public SupplierAddEditModel(Supplier supplier)
        {
            Supplier = supplier;
            if (supplier.Addresses != null)
            {
                foreach (var item in supplier.Addresses)
                {
                   // Locations.Add(new Address<Customer>(Math.Round(item.Location.Latitude, 6), Math.Round(item.Location.Longitude, 6), item.Raduis, customer.ToString(), item.ToString(), customer.Description.TruncateLongString(55), customer.Id));
                }
            }
        }

        #endregion

        /// <summary>
        /// The supplier featured by this model
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();
        
        /// <summary>
        /// Gets or sets the default email addrss
        /// </summary>
        [Required()]
        public string PhoneNr { get; set; }

        /// <summary>
        /// Gets or sets the default email address
        /// </summary>
        [EmailAddress, Required]
        public string Email { get; set; }

        /// <summary>
        /// The first line of the address
        /// </summary>
        [DisplayName("Number")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// The address line
        /// </summary>
        [DisplayName("Street")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The suburb
        /// </summary>
        [DisplayName("Suburb")]
        public string Suburb { get; set; }

        /// <summary>
        /// The Postal Code
        /// </summary>
        [DisplayName("Code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The City
        /// </summary>
        [DisplayName("City")]
        public string City { get; set; }

        /// <summary>
        /// The Province
        /// </summary>
        [DisplayName("Province")]
        public string Province { get; set; }

        /// <summary>
        /// The Country by default in South Africa
        /// </summary>
        [DisplayName("Country")]
        public string Country { get; set; } = "South Africa";


    }
}
