using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace DuPlessisLegal.Web.Site.Areas.Identity.Data
{
    public class KellenUserInfo : IdentityUser
    {
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
