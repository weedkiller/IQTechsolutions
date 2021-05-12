using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Iqt.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The standard contact details
    /// </summary>
    public class ContactNumber<T> : EntityBase  
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ContactNumber() { }

        /// <summary>
        /// Contact Number constructor
        /// </summary>
        /// <param name="contactNumber">The contact number this contact number should be created with</param>
        public ContactNumber(ContactNumber<T> contactNumber)
        {
            Name = contactNumber.Name;
            InternationalCode = contactNumber.InternationalCode;
            AreaCode = contactNumber.AreaCode;
            Number = contactNumber.Number;
            Default = contactNumber.Default;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The name of the contact number
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The international dialing code
        /// </summary>
        public string InternationalCode { get; set; }

        /// <summary>
        /// The area dialing code
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// The contact number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Flag to indicate wether this is a default entry
        /// </summary>
        public bool Default { get; set; }

        #endregion

        #region Relationships

        /// <summary>
        /// The person that this contact number belongs to
        /// </summary>
        [ForeignKey("Entity")]
        public string EntityId { get; set; }
        public T Entity { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates this entity to the given values
        /// </summary>
        /// <param name="detail">The details this entity should be updated to</param>
         public void Update(ContactNumber<T> detail)
         {
             Name = detail.Name;
             InternationalCode = detail.InternationalCode;
             AreaCode = detail.AreaCode;
             Number = detail.Number;
             Default = detail.Default;
         }

        #endregion
    }
}
