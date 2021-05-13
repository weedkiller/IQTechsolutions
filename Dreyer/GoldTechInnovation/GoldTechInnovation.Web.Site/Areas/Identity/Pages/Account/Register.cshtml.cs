using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldTechInnovation.Web.Email;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace GoldTechInnovation.Web.Site.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly DefaultEmailSender _defaultEmailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger, DefaultEmailSender defaultEmailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _defaultEmailSender = defaultEmailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
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
            [Required, EmailAddress, Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            /// The user password
            /// </summary>
            [Required, StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password), Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            /// The field that is used to confirm that the password was typed correctly
            /// </summary>
            [DataType(DataType.Password), Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserInfo = new UserInfo()
                    {
                        FirstName = Input.Name,
                        LastName = Input.Surname
                    },
                    UserName = Input.Username,
                    PhoneNumber = Input.Cell,
                    Email = Input.Email
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _defaultEmailSender.SendUserVerificationEmailAsync(user.UserName, user.Email, callbackUrl);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
