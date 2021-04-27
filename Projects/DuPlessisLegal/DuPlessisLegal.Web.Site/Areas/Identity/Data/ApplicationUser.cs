using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DuPlessisLegal.Web.Site.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class 
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// This is the address of the user <see cref="Address"/>
        /// </summary>
        public Address Address { get; set; }       

        /// <summary>
        /// This is the user information <see cref="KellenUserInfo"/>
        /// </summary>
        public KellenUserInfo UserInfo { get; set; }

        public City City { get; set; }

        public CellNumber CellNumber { get; set; }

        #region Static Methods

        public static ApplicationUser CreateUser(string firstName, string lastname, string username, string email, string addressFirstLine, string addressSecondLine, string city, string cellNumber)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                UserInfo = new KellenUserInfo
                
                {
                    FirstName = firstName,
                    LastName = lastname
                },
                Address = new Address
                {
                    AddressLine1 = addressFirstLine,
                    AddressLine2 = addressSecondLine
                },

                City = new City
                {
                    UserCity = city
                },

                CellNumber = new CellNumber
                {
                    CellNr = cellNumber
                }



            };

            return user;
        }

        #endregion
    }
}
