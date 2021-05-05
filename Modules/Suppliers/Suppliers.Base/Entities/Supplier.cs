using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Filing.Base.Entities;
using Iqt.Base.Entities;

namespace Suppliers.Base.Entities
{
    public class Supplier : ImageFileCollection<Supplier>
    {
        /// <summary>
        /// The name of this customer
        /// </summary>
        [Required(ErrorMessage = "Customer name is a required field")]
        public string Name { get; set; }

        /// <summary>
        /// Flag to indicate if this is a featured employee
        /// </summary>
        public bool Featured { get; set; }

        /// <summary>
        /// The flag to indicate if the employee is an active employee
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// The name of this customer
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The contact numbers for this customer
        /// </summary>
        public ICollection<ContactNumber<Supplier>> ContactNumbers { get; set; } = new List<ContactNumber<Supplier>>();

        /// <summary>
        /// Addresses that belongs to this customer
        /// </summary>
        public ICollection<Address<Supplier>> Addresses { get; set; } = new List<Address<Supplier>>();

        /// <summary>
        /// Email Addresses that belongs to this customer
        /// </summary>
        public ICollection<EmailAddress<Supplier>> EmailAddresses { get; set; } = new List<EmailAddress<Supplier>>();
    }
}
