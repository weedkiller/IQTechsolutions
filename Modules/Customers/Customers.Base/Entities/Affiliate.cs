using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Filing.Base.Entities;
using Iqt.Base.Entities;

namespace Customers.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The customer entity
    /// </summary>
    public class Affiliate : ImageFileCollection<Affiliate>
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
        public bool Active { get; set; }

        /// <summary>
        /// The name of this customer
        /// </summary>
        [Required(ErrorMessage = "Customer description is a required field")]
        public string Description { get; set; }

        /// <summary>
        /// The contact numbers for this customer
        /// </summary>
        public ICollection<ContactNumber<Affiliate>> ContactNumbers { get; set; } = new List<ContactNumber<Affiliate>>();

        /// <summary>
        /// Addresses that belongs to this customer
        /// </summary>
        public ICollection<Address<Affiliate>> Addresses { get; set; } = new List<Address<Affiliate>>();

        /// <summary>
        /// Email Addresses that belongs to this customer
        /// </summary>
        public ICollection<EmailAddress<Affiliate>> EmailAddresses { get; set; } = new List<EmailAddress<Affiliate>>();
    }
}