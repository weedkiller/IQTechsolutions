using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.Enums.Personal;
using Microsoft.EntityFrameworkCore;

namespace Identity.Base.Entities
{
    /// <summary>
    /// The Personal details of a user
    /// </summary>
    [Owned]
    public class PersonalDetails
    {
        /// <summary>
        /// The Title of the Person/Entity
        /// </summary>
        [Column("Title"), DisplayName(@"Title")]
        [EnumDataType(typeof(Title))]
        public Title Title { get; set; } = Title.Mr;

        /// <summary>
        /// The Identity Number
        /// </summary>
        [Column("IdentityNr"), DisplayName(@"Identity Nr")]
        [MaxLength(13, ErrorMessage = @"Only 13 digits allowed"), MinLength(13, ErrorMessage = @"Only 13 digits allowed")]
        [RegularExpression(@"^([0-9]+)", ErrorMessage = @"Please enter numbers only")]
        public string IdentityNr { get; set; }

        /// <summary>
        /// The Marital Status
        /// </summary>
        [Column("MaritalStatus"), DisplayName(@"Marital Status")]
        [EnumDataType(typeof(MaritalStatus))]
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.Single;

        /// <summary>
        /// The Gender
        /// </summary>
        [Column("Gender"), DisplayName(@"Gender")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; } = Gender.Unknown;

        /// <summary>
        /// The Nasionality
        /// </summary>
        [Column("Nationality"), DisplayName(@"Nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// The Passport Number
        /// </summary>
        [Column("PassportNr"), DisplayName(@"Passport Nr")]
        public string PassportNr { get; set; }

        /// <summary>
        /// The Personal Description
        /// </summary>
        [Column("PersonalDescription"), DisplayName(@"Personal Description"), DataType(DataType.MultilineText)]
        public string PersonalDescription { get; set; }

        /// <summary>
        /// Birth date derived from <see cref="IdentityNr"/>
        /// </summary>
        [DisplayName(@"Birth Date")]
        public DateTime? BirthDate
        {
            get
            {
                if (IdentityNr != null)
                {
                    int thisYear = DateTime.Today.Year;
                    int year = int.Parse(IdentityNr.Substring(0, 2));
                    int month = int.Parse(IdentityNr.Substring(2, 2));
                    int day = int.Parse(IdentityNr.Substring(4, 2));

                    if (year + 2000 > thisYear)
                        year = year + 1900;
                    else
                        year = year + 2000;

                    return new DateTime(year, month, day);
                }
                return null;
            }
        }

        /// <summary>
        /// Age derived from <see cref="BirthDate"/>
        /// </summary>
        public int Age
        {
            get
            {
                if (BirthDate != null)
                    return DateTime.Now.Year - ((DateTime)BirthDate).Year;
                return 0;
            }
        }
    }
}
