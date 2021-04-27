using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Feedback.Core.Models;
using GoogleReCaptcha.V3.Interface;
using Iqt.Base.Enums;
using Iqt.Base.Interfaces;
using Iqt.Web;
using Iqt.Web.Helpers;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metsi.Web.Site.Areas.Support.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : Controller
    {
        private HttpClient _client;
        private DefaultEmailSender _emailSender;
        private readonly ICaptchaValidator _captchaValidator;
        private IApplicationConfiguration configuration;

        public HomeController(IHttpClientFactory clientFactory, DefaultEmailSender emailSender, ICaptchaValidator captchaValidator, IApplicationConfiguration configuration)
        {
            _client = clientFactory.CreateClient();
            _emailSender = emailSender;
            _captchaValidator = captchaValidator;
            this.configuration = configuration;
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

                        var postTask = await _client.PostAsync(configuration.BaseApiUrl+ "/supportticket", content);

                        if (postTask.IsSuccessStatusCode)
                        {
                            var callbackUrl = Url.Action("Details", "Home", new { area = "Support", id = model.Id },
                                protocol: Request.Scheme);
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
            

           // await WebRequests.PostAsync<ApiResponse>(RouteHelpers.GetAbsoluteRoute("http://localhost:6001/api/v1", "/supportticket"), model);
            return View(model);
            
        }
    }
}
