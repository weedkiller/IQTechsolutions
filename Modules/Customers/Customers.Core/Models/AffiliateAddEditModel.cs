using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Customers.Base.Entities;
using Filing.Base.Entities;
using Iqt.Base.Entities;
using Microsoft.AspNetCore.Http;

namespace Customers.Core.Models
{ 
    /// <summary>
    /// The model used to add or edit a employee entity
    /// </summary>
    public class AffiliateAddEditModel
    {
        #region Constructors

        public AffiliateAddEditModel() { }
        public AffiliateAddEditModel(Affiliate customer)
        {
            Affiliate = customer;
            if (customer.Addresses != null)
            {
                foreach (var item in customer.Addresses)
                {
                   // Locations.Add(new Address<Customer>(Math.Round(item.Location.Latitude, 6), Math.Round(item.Location.Longitude, 6), item.Raduis, customer.ToString(), item.ToString(), customer.Description.TruncateLongString(55), customer.Id));
                }
            }
        }

        #endregion

        /// <summary>
        /// The employee featured by this model
        /// </summary>
        public Affiliate Affiliate { get; set; }

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        public List<Address<Affiliate>> Locations = new List<Address<Affiliate>>();

        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string PhoneNr { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
