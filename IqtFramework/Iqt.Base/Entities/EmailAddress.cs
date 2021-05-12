using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Iqt.Base.Entities
{
    public class EmailAddress<T> : EntityBase 
    {
        public EmailAddress() { }

        /// <summary>
        /// Email string constructor
        /// </summary>
        /// <param name="address">The address this email address should be constructed from</param>
        public EmailAddress(string address)
        {
            Address = address;
        }

        /// <summary>
        /// The address of this mailbox
        /// </summary>
        [DisplayName(@"Name of Mailbox"), Required(ErrorMessage = @"Name of Mailbox is Required")]
        public string Address { get; set; }

        /// <summary>
        /// Flag to indicate if this is a default email address
        /// </summary>
        public bool Default { get; set; }

        /// <summary>
        /// The domain this mailbox belongs to
        /// </summary>
        [ForeignKey("Entity")]
        public string EntityId { get; set; }
        public T Entity { get; set; }
    }
}
