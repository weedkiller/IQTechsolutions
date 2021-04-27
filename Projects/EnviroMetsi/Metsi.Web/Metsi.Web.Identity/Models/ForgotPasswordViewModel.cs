using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Metsi.Web.Identity.Models
{
    public class ForgotPasswordViewModel
    {
        public string ReturnUrl { get; set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        [Required, Display(Name = "First Name")]
        public string Name { get; set; }

        /// <summary>
        /// The surname of the user
        /// </summary>
        [Required, Display(Name = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// The cell phone nr of the user
        /// </summary>
        [Required, Display(Name = "Cell")]
        public string Cell { get; set; }

        /// <summary>
        /// The username of the user
        /// </summary>
        [Required, Display(Name = "Username")]
        public string Username { get; set; }

        /// <summary>
        /// The user email address
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// The field that is used to confirm that the password was typed correctly
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
