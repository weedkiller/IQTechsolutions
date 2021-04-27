using System.ComponentModel.DataAnnotations;
using Iqt.Base.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Iqt.Base.Entities
{
    /// <summary>
    /// The Names of a Person
    /// </summary>
    [Owned]
    public class Names
    {
        /// <summary>
        /// The Nickname
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// The First Names 
        /// </summary>
        [Required(ErrorMessage = "Your first name is a required to continue")]
        public string FirstName { get; set; }

        /// <summary>
        /// Any other names this person has
        /// </summary>
        public string OtherNames { get; set; }

        /// <summary>
        /// The Last Name
        /// </summary>
        [Required(ErrorMessage = "Your last name is a required to continue")]
        public string LastName { get; set; }


        /// <summary>
        /// The Initials, this is calculated by using the first letters of the first name and the other names
        /// </summary>
        public string Initials
        {
            get { return ($"{FirstName} {OtherNames}").GetAllFirstLetters().CreateStringFromCharacters(); }
        }

        /// <summary>
        /// Gets the Full Name, Other Names and Last Name
        /// </summary>
        /// <returns>A string containg the first name, other names and surname</returns>
        public string GetFullNames()
        {
            return $"{FirstName} {OtherNames} {LastName}";
        }

        /// <summary>
        /// Gets the Full Name, Initials and Last Name
        /// </summary>
        /// <returns>A string containg the first name, initails and last name</returns>
        public string GetFormalName()
        {
            return $"{FirstName}, {Initials} {LastName}";
        }

        /// <summary>
        /// Gets the display name
        /// </summary>
        /// <returns>A name and last name</returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
