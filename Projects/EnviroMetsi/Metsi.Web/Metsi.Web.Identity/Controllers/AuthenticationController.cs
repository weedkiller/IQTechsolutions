using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Base.Entities;
using IdentityServer4.Services;
using Metsi.Web.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Metsi.Web.Identity.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private IIdentityServerInteractionService _interactionService;
        private DbContext _context;

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
        public IActionResult Register(string returnUrl, string studentId, string employeeId)
        {
            return View(new RegisterViewModel()
            {
                ReturnUrl = returnUrl,
                StudentId = studentId,
                EmployeeId = employeeId
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

            ApplicationUser user = new ApplicationUser
            {
                Id = id,
                UserName = model.Username,
                PhoneNumber = model.Cell,
                Email = model.Email,
                EmailConfirmed = true,
                UserInfo = new UserInfo()
                {
                    Id = id, 
                    FirstName = model.Name, 
                    LastName = model.Surname, 
                    StudentId = model.StudentId,
                }
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.StudentId))
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                }
                else if (!string.IsNullOrEmpty(model.EmployeeId))
                    await _userManager.AddToRoleAsync(user, "Employee");
                else
                    await _userManager.AddToRoleAsync(user, "Admin");

                await _signInManager.SignInAsync(user, false);
                return Redirect(model.ReturnUrl);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
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
