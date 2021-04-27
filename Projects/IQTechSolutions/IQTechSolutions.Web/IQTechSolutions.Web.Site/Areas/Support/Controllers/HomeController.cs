using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Feedback.Core.Models;
using GoogleReCaptcha.V3.Interface;
using Iqt.Base.Enums;
using IQTechSolutions.Web.Email;
using Microsoft.AspNetCore.Mvc;

namespace IQTechSolutions.Web.Site.Areas.Support.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : Controller
    {
        private IHttpClientFactory _clientFactory;
        private DefaultEmailSender _emailSender;
        private readonly ICaptchaValidator _captchaValidator;

        public HomeController(IHttpClientFactory clientFactory, DefaultEmailSender emailSender, ICaptchaValidator captchaValidator)
        {
            _clientFactory = clientFactory;
            _emailSender = emailSender;
            _captchaValidator = captchaValidator;
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(string parentId)
        {
            var model = new TicketAddEditModel()
            {
                ParentId = parentId,
                Priority = Priority.Low
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketAddEditModel model)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                ModelState.AddModelError("Captcha", "Captcha validation failed");
            }
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();
                var postTask = await client.PostAsJsonAsync("http://api.iqtechsolutions.co.za/api/v1/supportticket", model);

                if (postTask.IsSuccessStatusCode)
                {
                    var callbackUrl = Url.Action("Details", "Home", new {area = "Support", id = model.Id},
                        protocol: Request.Scheme);
                    await _emailSender.SendUserSupportTicketEmailAsync($"{model.FirstName} {model.LastName}", model.EmailAddress, callbackUrl);
                    await _emailSender.SendUserSupportTicketEmailAsync($"{model.FirstName} {model.LastName}", model.EmailAddress, callbackUrl);
                    
                    return View("ThanksForSubmitting");
                }

                ModelState.AddModelError("", postTask.ReasonPhrase);
            }

            return View(model);
        }
    }
}