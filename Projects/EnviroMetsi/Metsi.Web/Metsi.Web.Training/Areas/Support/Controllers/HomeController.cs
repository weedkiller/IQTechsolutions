using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Feedback.Core.Models;
using GoogleReCaptcha.V3.Interface;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metsi.Web.Site.Training.Areas.Support.Controllers
{
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private DefaultEmailSender _emailSender;
        private readonly ICaptchaValidator _captchaValidator;

        public HomeController(IHttpClientFactory clientFactory, ICaptchaValidator captchaValidator, DefaultEmailSender emailSender)
        {
            _client = clientFactory.CreateClient();
            _captchaValidator = captchaValidator;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Create(string parentId)
        {
            var model = new TicketModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketModel model)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                ModelState.AddModelError("", "Captcha validation failed");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var postTask = await _client.PostAsync("https://localhost:6001/api/v1/supportticket", content);

                    if (postTask.IsSuccessStatusCode)
                    {
                        var callbackUrl = Url.Action("Index", "Home", null, protocol: Request.Scheme);
                        await _emailSender.SendUserSupportTicketEmailAsync($"{model.FirstName} {model.LastName}", model.EmailAddress, callbackUrl);
                        await _emailSender.SendUserSupportTicketEmailAsync($"{model.FirstName} {model.LastName}", model.EmailAddress, callbackUrl);

                        return View("ThanksForSubmitting");
                    }

                    ModelState.AddModelError("", postTask.ReasonPhrase);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return View(model);

        }
    }
}
