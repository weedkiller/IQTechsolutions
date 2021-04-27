using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Iqt.Base.Entities
{
    [Owned]
    public class Location
    {
        #region Constructors

        /// <summary>
        /// Default parameter-less construction
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion
        
        /// <summary>
        /// The latitude of the Location
        /// </summary>
        [DisplayName("Latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of the Location
        /// </summary>
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
    }
}
