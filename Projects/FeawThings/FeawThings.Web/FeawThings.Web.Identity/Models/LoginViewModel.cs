using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace FeawThings.Web.Identity.Models
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
