using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Olympia.Web.Site.Models
{
    public class UsersData
    {
        [DisplayName("First name")]
        [Required(ErrorMessage = "Enter a first name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter a last name")]
        public string LastName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter a last name")]
        public string PhoneNr { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter a last name")]
        public string Email { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter a last name")]
        public string Subject { get; set; }


        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter a last name")]
        public string Comment { get; set; }
    }

    

    public static class UrlExtensions
    {

        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue
                    ? $"{request.Path}{request.QueryString}"
                    : request.Path.ToString();
        }

    }
}
