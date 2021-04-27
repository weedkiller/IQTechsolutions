using System;
using System.Linq;
using System.Threading.Tasks;
using FeawThings.Web.Identity.Models;
using Identity.Base.Entities;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeawThings.Web.Identity.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private IIdentityServerInteractionService _interactionService;

        public AuthenticationController(SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, IIdentityServerInteractionService interactionService, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _interactionService = interactionService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var model = new LoginViewModel()
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(model.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                    return View(model);
                }

            }
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl, string customerId)
        {
            return View(new RegisterViewModel()
            {
                ReturnUrl = returnUrl,
                CustomerId = customerId
            });
    }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(model.CustomerId))
                id = model.CustomerId;

            ApplicationUser user = new ApplicationUser()
            {
                Id = id,
                UserName = model.Username,
                PhoneNumber = model.Cell,
                Email = model.Email,
                UserInfo = new UserInfo()
                {
                    Id = id,
                    FirstName = model.Name,
                    LastName = model.Surname
                }
            };
            user.EmailConfirmed = true;

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if(!string.IsNullOrEmpty(model.CustomerId))
                    _userManager.AddToRoleAsync(user, "Customer").Wait();
                else
                    _userManager.AddToRoleAsync(user, "Admin").Wait();

                await _signInManager.SignInAsync(user, false);
                return Redirect(model.ReturnUrl);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();

            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);

            if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "HOme");
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(RegisterViewModel model)
        {
            return View();
        }
    }
}
