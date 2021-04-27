using System;
using Iqt.Commerce.Entities;
using IQTechSolutions.PayGates.PayFast;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PayFast;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Donations.Controllers
{
    [Area("Donations")]
    [Route("Donations/[controller]/[action]")]
    public class HomeController : Controller
    {
        #region Private Members

        private readonly PayFastSettings _payFastSettings;

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public HomeController(IOptions<PayFastSettings> payFastSettings)
        {
            _payFastSettings = payFastSettings.Value;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        #region Create

        /// <summary>
        /// Gets the create donation page
        /// </summary>
        /// <returns>The create donation page with a create donation model</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Posts a new once-off donation to the server for payment and archiving
        /// </summary>
        /// <param name="model">The donation made</param>
        /// <returns>The thank you page if successful else the same create donation view with the errors</returns>
        [HttpPost]
        public IActionResult Create(Donation model)
        {
            if (ModelState.IsValid)
            {
                var onceOffRequest = new PayFastRequest(_payFastSettings.PassPhrase);
                // Merchant Details
                onceOffRequest.merchant_id = _payFastSettings.MerchantId;
                onceOffRequest.merchant_key = _payFastSettings.MerchantKey;
                onceOffRequest.return_url = _payFastSettings.ReturnUrl;
                onceOffRequest.cancel_url = _payFastSettings.CancelUrl;
                onceOffRequest.notify_url = _payFastSettings.NotifyUrl;

                // Buyer Details
                onceOffRequest.name_first = "KLSM";
                onceOffRequest.name_last = "Partner";
                onceOffRequest.email_address = "admin@klsm.co.za";
                onceOffRequest.cell_number = "0728117155";

                // Transaction Details
                onceOffRequest.m_payment_id = Guid.NewGuid().ToString();
                onceOffRequest.amount = model.Amount;
                onceOffRequest.item_name = "Once off option";
                onceOffRequest.item_description = "Some details about the once off payment";

                // Transaction Options
                onceOffRequest.email_confirmation = true;
                onceOffRequest.confirmation_address = "admin@klsm.co.za";

                var redirectUrl = $"{_payFastSettings.ProcessUrl}?{onceOffRequest.ToString()}";

                return Redirect(redirectUrl);
            }
            return View(model);
        }

        /// <summary>
        /// Posts a new once-off donation to the server for payment and archiving
        /// </summary>
        /// <param name="model">The donation made</param>
        /// <returns>The thank you page if successful else the same create donation view with the errors</returns>
        [HttpPost]
        public IActionResult CreateRecurring(Donation model)
        {
            if (ModelState.IsValid)
            {
                var onceOffRequest = new PayFastRequest(_payFastSettings.PassPhrase);
                // Merchant Details
                onceOffRequest.merchant_id = _payFastSettings.MerchantId;
                onceOffRequest.merchant_key = _payFastSettings.MerchantKey;
                onceOffRequest.return_url = _payFastSettings.ReturnUrl;
                onceOffRequest.cancel_url = _payFastSettings.CancelUrl;
                onceOffRequest.notify_url = _payFastSettings.NotifyUrl;

                // Buyer Details
                onceOffRequest.name_first = "KLSM";
                onceOffRequest.name_last = "Partner";
                onceOffRequest.email_address = "";
                onceOffRequest.cell_number = "0728117155";

                // Transaction Details
                onceOffRequest.m_payment_id = "8d00bf49-e979-4004-228c-08d452b86380";
                onceOffRequest.amount = model.Amount;
                onceOffRequest.item_name = "Once off option";
                onceOffRequest.item_description = "Some details about the once off payment";

                // Transaction Options
                onceOffRequest.email_confirmation = true;
                onceOffRequest.confirmation_address = "admin@klsm.co.za";

                var redirectUrl = $"{_payFastSettings.ProcessUrl}?{onceOffRequest.ToString()}";

                return View("ThanksForDonating");
            }
            return View("Create", model);
        }

        #endregion


    }
}
