using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Iqt.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The address type of a object
    /// </summary>
    public class Address<T> : EntityBase 
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Address() { }

        /// <summary>
        /// Entity Constructor
        /// </summary>
        /// <param name="address">The address used for construction of this address</param>
        public Address(Address<T> address)
        {
            Id = address.Id;
            Name = address.Name;
            UnitNumber = address.UnitNumber;
            Complex = address.Complex;
            StreetNumber = address.StreetNumber;
            AddressLine1 = address.AddressLine1;
            Suburb = address.Suburb;
            PostalCode = address.PostalCode;
            City = address.City;
            Province = address.Province;
            Country = address.Country;
            Location = address.Location;
            Raduis = address.Raduis;
            Default = address.Default;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the address
        /// </summary>
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The unit number of this address
        /// </summary>
        [DisplayName("Unit")]
        public string UnitNumber { get; set; }

        /// <summary>
        /// The complex this unit is situated in
        /// </summary>
        [DisplayName("Complex")]
        public string Complex { get; set; }

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

        /// <summary>
        /// The longtitude and latitude details
        /// </summary>
        [DisplayName("Location")]
        public Location Location { get; set; } = new Location();

        /// <summary>
        /// The radius this address is active for
        /// </summary>
        [DisplayName("Radius")]
        public int Raduis { get; set; } = 50;

        /// <summary>
        /// The Country by default in South Africa
        /// </summary>
        [DisplayName("Default")]
        public bool Default { get; set; }

        public AddressType AddressType { get; set; }

        #endregion

        #region Relational Properties

        /// <summary>
        /// The entity that this address belongs to
        /// </summary>
        [ForeignKey("Entity")]
        public string EntityId { get; set; }
        public T Entity { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the address entity
        /// </summary>
        /// <param name="address"></param>
        public void Update(Address<T> address)
        {
            Name = address.Name;
            UnitNumber = address.UnitNumber;
            Complex = address.Complex;
            StreetNumber = address.StreetNumber;
            AddressLine1 = address.AddressLine1;
            Suburb = address.Suburb;
            PostalCode = address.PostalCode;
            City = address.City;
            Province = address.Province;
            Country = address.Country;
            Location = address.Location;
            Raduis = address.Raduis;
            Default = address.Default;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The ToString override for the address 
        /// </summary>
        /// <returns>A string of the address</returns>
        public override string ToString()
        {
            return $"{AddressLine1} {Suburb} {City} {Province}";
        }

        #endregion
    }

    public enum AddressType
    {
        Physical,
        Postal
    }
}
