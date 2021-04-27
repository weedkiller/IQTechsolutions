using System;
using System.Linq;
using System.Threading.Tasks;
using Iqt.Commerce.Entities;
using Iqt.Identity.Entities;
using Iqt.Inventory.Entities;
using Iqt.Location.Entities;
using IQTechFramework.Extentions;
using IQTechFramework.Framework;
using IQTechSolutions.Base.Interfaces;
using IQTechSolutions.Filing.Extensions;
using IQTechSolutions.PayGates.PayFast;
using IQTechSolutions.PayGates.PayFast.AspNetCore;
using KingdomLifestyleMinistries.Web.Email;
using KingdomLifestyleMinistries.Web.Site.Areas.Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PayFast;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("Shop/[controller]/[action]")]
    public class ShoppingCartController : Controller
    {
        #region Private Members

        private readonly IRepositoryManager _manager;
        private readonly ShoppingCart _shoppingCart;
        private readonly PayFastSettings _payFastSettings;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ShoppingCartController(ILogger<ShoppingCartController> _logger, IRepositoryManager manager, ShoppingCart shoppingCart, IOptions<PayFastSettings> payFastSettings, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _payFastSettings = payFastSettings.Value;
            _manager = manager;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
            _signInManager = signInManager;
            logger = _logger;
        }

        #endregion

        #region List Views

        /// <summary>
        /// Gets the index view and model
        /// </summary>
        /// <returns>The index view</returns>
        public async Task<IActionResult> Index()
        {
            var cartItems = await _shoppingCart.GetCartItems();
            var model = new ShopptingCartModel
            {
                CartItems = cartItems,
                ItemCount = await _shoppingCart.GetCount(),
                SubTotal = cartItems.Sum(item => item.Product.PriceIncl * item.Qty),
                Vat = cartItems.Sum(item => item.Product.Vat * item.Qty)
            };

            return View(model);
        }

        #endregion

        #region GiftCertificate

        /// <summary>
        /// Add e-commerce item to shopping cart
        /// </summary>
        /// <param name="id">The identity of the product to be added</param>
        /// <returns>The view from wich the product was added</returns>
        //public async Task<IActionResult> GiftCertificate(GiftCertificate model)
        //{
            //  var item = await _productService.GetAsync(id);
            //
            //  if (HttpContext.Session.GetObjectFromJson<List<ShoppingCartItem>>("cart") == null)
            //  {
            //      List<ShoppingCartItem> cart = new List<ShoppingCartItem>();
            //      cart.Add(new ShoppingCartItem() { Product = item, Qty = 1 });
            //      SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            //  }
            //  else
            //  {
            //      List<ShoppingCartItem> cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");
            //      int index = Exists(id);
            //      if (index != -1)
            //      {
            //          cart[index].Qty++;
            //      }
            //      else
            //      {
            //          cart.Add(new ShoppingCartItem() { Product = item, Qty = 1 });
            //      }
            //      SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            //  }
        //    return RedirectToAction(nameof(Index));
        //}

        #endregion

        #region AddToCart

        /// <summary>
        /// Add e-commerce item to shopping cart
        /// </summary>
        /// <param name="id">The identity of the product to be added</param>
        /// <returns>The view from wich the product was added</returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart(string id, int qty = 1)
        {

            var item = await _manager.Repository<Product>().GetEntityAsync(id, c => c.Images);
            var shoppingcartItem = (await _shoppingCart.GetCartItems()).FirstOrDefault(c => c.ProductId == id);
            var newQty = 0;

            if (shoppingcartItem != null)
            {
                newQty = shoppingcartItem.Qty;
            }
            await _shoppingCart.AddToCart(item, qty);

            var subtotal = await _shoppingCart.GetTotal();
            var vat = 0;
            var discount = (await _shoppingCart.GetTotal()).GetPercentageValue(item.DiscountPercentage);
            var total = subtotal + vat - discount;
            var count = await _shoppingCart.GetCount();

            shoppingcartItem = (await _shoppingCart.GetCartItems()).FirstOrDefault(c => c.ProductId == id);

            return Json(new
            {
                id = shoppingcartItem.Id,
                imageUrl = item.GetImage().GetImagePathFromAnotherWebsite(FrameworkDI.Configuration["Company:WebUrl"], FrameworkDI.Configuration["Placeholders:CoverImage"]),
                name = item.Name,
                quantity = newQty + qty,
                price = item.PriceIncl,
                sub = subtotal,
                vat = vat,
                discount = discount,
                grand = total,
                totalCount = count
            });
        }

        #endregion

        #region Checkout

        /// <summary>
        /// Add e-commerce item to shopping cart
        /// </summary>
        /// <param name="id">The identity of the product to be added</param>
        /// <returns>The view from wich the product was added</returns>
        [Authorize]
        public async Task<IActionResult> Checkout(string id)
        {
            var model = new CheckOutModel();

            if (_signInManager.IsSignedIn(User))
            {
                var userid = _userManager.GetUserId(User);
                var user = await _userManager.Users.Include(c => c.Addresses).FirstOrDefaultAsync(c => c.Id == userid);

                model.Name = user.FirstName;
                model.Surname = user.LastName;
                model.Cell = user.PhoneNumber;
                model.Email = user.Email;
                model.AddressLine1 = user.Addresses.FirstOrDefault(c => c.Default)?.AddressLine1;
                model.Suburb = user.Addresses.FirstOrDefault(c => c.Default)?.Suburb;
                model.City = user.Addresses.FirstOrDefault(c => c.Default)?.City;
                model.PostalCode = user.Addresses.FirstOrDefault(c => c.Default)?.PostalCode;
                model.Province = user.Addresses.FirstOrDefault(c => c.Default)?.Province;
                model.Country = "South Africa";
            }

            return View(model);
        }

        /// <summary>
        /// Add e-commerce item to shopping cart
        /// </summary>
        /// <param name="id">The identity of the product to be added</param>
        /// <returns>The view from wich the product was added</returns>
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckOutModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    OrderNr = (_manager.Repository<Order>().GetAll().Count() + 1).ToString(),
                    OrderNotes = model.Comments,
                    ApplicationUserId = _userManager.GetUserId(User)
                };


                var billingAddress = new Address<Order>()
                {
                    Name = $"{model.Name} {model.Surname}",
                    AddressLine1 = model.AddressLine1,
                    Suburb = model.Suburb,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    Province = model.Province,
                    Country = "South Africa",
                    AddressType = AddressType.Physical,
                    Default = !model.DifferentPostalAddress
                };
                order.Addresses.Add(billingAddress);

                if (!model.DifferentPostalAddress)
                {
                    if (string.IsNullOrEmpty(model.AddressLine1))
                        ModelState.AddModelError("ShippingAddressLine1", "Please enter the shipping Po Box");
                    if (string.IsNullOrEmpty(model.AddressLine1))
                        ModelState.AddModelError("ShippingSuburb", "Please enter the shipping Po Box");
                    if (string.IsNullOrEmpty(model.AddressLine1))
                        ModelState.AddModelError("ShippingCity", "Please enter the shipping Po Box");
                    if (string.IsNullOrEmpty(model.AddressLine1))
                        ModelState.AddModelError("ShippingPostalCode", "Please enter the shipping Po Box");
                    if (string.IsNullOrEmpty(model.AddressLine1))
                        ModelState.AddModelError("ShippingProvince", "Please enter the shipping Po Box");


                    var shippingAddress = new Address<Order>()
                    {
                        Name = $"{model.Name} {model.Surname}",
                        AddressLine1 = model.ShippingAddressLine1,
                        Suburb = model.ShippingSuburb,
                        City = model.ShippingCity,
                        PostalCode = model.ShippingPostalCode,
                        Province = model.ShippingProvince,
                        Country = "South Africa",
                        AddressType = AddressType.Postal,
                        Default = model.DifferentPostalAddress
                    };
                    order.Addresses.Add(shippingAddress);
                }

                foreach (var detail in await _shoppingCart.GetCartItems())
                {
                    var orderDetail = new OrderDetail()
                    {
                        ProductGuid = detail.ProductId,
                        Quantity = detail.Qty,
                        UnitPriceExcl = detail.Product.PriceExcl,
                        UnitVat = detail.Product.Vat,
                        TotalVat = (double) (detail.Qty * detail.Product.Vat),
                        Discount = detail.Product.Discount,
                        OrderId = order.Id
                    };
                    order.OrderDetails.Add(orderDetail);
                }

                _manager.Repository<Order>().Add(order);
                try
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (model.PaymentGateway == "PayFast")
                    {
                        var onceOffRequest = new PayFastRequest(_payFastSettings.PassPhrase);
                        // Merchant Details
                        onceOffRequest.merchant_id = _payFastSettings.MerchantId;
                        onceOffRequest.merchant_key = _payFastSettings.MerchantKey;
                        onceOffRequest.return_url = _payFastSettings.ReturnUrl;
                        onceOffRequest.cancel_url = _payFastSettings.CancelUrl;
                        onceOffRequest.notify_url = _payFastSettings.NotifyUrl;

                        // Buyer Details
                        onceOffRequest.name_first = model.Name;
                        onceOffRequest.name_last = model.Surname;
                        onceOffRequest.email_address = model.Email;
                        onceOffRequest.cell_number = model.Cell;

                        // Transaction Details
                        onceOffRequest.m_payment_id = "8d00bf49-e979-4004-228c-08d452b86380";
                        onceOffRequest.amount = await _shoppingCart.GetTotalDue();
                        onceOffRequest.item_name = "Once off option";
                        onceOffRequest.item_description = "Some details about the once off payment";

                        // Transaction Options
                        onceOffRequest.email_confirmation = true;
                        onceOffRequest.confirmation_address = "admin@klsm.co.za";

                        var redirectUrl = $"{_payFastSettings.ProcessUrl}?{onceOffRequest.ToString()}";

                        await _manager.SaveAsync();
                        return Redirect(redirectUrl);
                    }
                    else
                    {
                        var callbackUrl = Url.Page(
                            "/Orders/Home/Details",
                            pageHandler: null,
                            values: new {area = "Identity", id = order.Id},
                            protocol: Request.Scheme);

                        await DefaultEmailSender.SendCheckOutEmailAsync($"{model.Name} {model.Surname}", model.Email,
                            callbackUrl, order);

                        _shoppingCart.EmptyCart();

                        return RedirectToAction("Index", "Home");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return View(model);
        }

        #endregion

        #region Remove

        /// <summary>
        /// Removes a e-commence item from the shopping cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Remove(string id)
        {
            var items = await _shoppingCart.GetCartItems();
            var cartItem = items.FirstOrDefault(c => c.Id == id);

            var item = await _manager.Repository<Product>().GetEntityAsync(cartItem.ProductId, c => c.Images);
            var qty = await _shoppingCart.RemoveFromCart(id);

            var subtotal = await _shoppingCart.GetTotal();
            var vat = (await _shoppingCart.GetTotal()).GetPercentageValue(15);
            var discount = (await _shoppingCart.GetTotal()).GetPercentageValue(item.DiscountPercentage);
            var total = subtotal + vat - discount;
            var count = await _shoppingCart.GetCount();

            return Json(new
            {
                id = id,
                quantity = qty,
                sub = subtotal,
                vat = vat,
                discount = discount,
                grand = total,
                totalCount = count
            });
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Checks to see if a item exist in the shopping cart
        /// </summary>
        /// <param name="id">The identity of the item to check</param>
        /// <returns>The index of the product if it exists otherwise (-1)</returns>
        private async Task<bool> Exists(string id)
        {
            var shoppingcartItem = (await _shoppingCart.GetCartItems()).FirstOrDefault(c => c.ProductId == id);
            return shoppingcartItem != null;
        }

        #endregion

        public IActionResult Return()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Notify([ModelBinder(BinderType = typeof(PayFastNotifyModelBinder))] PayFastNotify payFastNotifyViewModel)
        {
            payFastNotifyViewModel.SetPassPhrase(_payFastSettings.PassPhrase);

            var calculatedSignature = payFastNotifyViewModel.GetCalculatedSignature();

            var isValid = payFastNotifyViewModel.signature == calculatedSignature;

            this.logger.LogInformation($"Signature Validation Result: {isValid}");

            // The PayFast Validator is still under developement
            // Its not recommended to rely on this for production use cases
            var payfastValidator = new PayFastValidator(_payFastSettings, payFastNotifyViewModel, this.HttpContext.Connection.RemoteIpAddress);

            var merchantIdValidationResult = payfastValidator.ValidateMerchantId();

            this.logger.LogInformation($"Merchant Id Validation Result: {merchantIdValidationResult}");

            var ipAddressValidationResult = await payfastValidator.ValidateSourceIp();

            this.logger.LogInformation($"Ip Address Validation Result: {ipAddressValidationResult}");

            // Currently seems that the data validation only works for success
            if (payFastNotifyViewModel.payment_status == PayFastStatics.CompletePaymentConfirmation)
            {
                var dataValidationResult = await payfastValidator.ValidateData();

                this.logger.LogInformation($"Data Validation Result: {dataValidationResult}");
            }

            if (payFastNotifyViewModel.payment_status == PayFastStatics.CancelledPaymentConfirmation)
            {
                this.logger.LogInformation($"Subscription was cancelled");
            }

            return Ok();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}