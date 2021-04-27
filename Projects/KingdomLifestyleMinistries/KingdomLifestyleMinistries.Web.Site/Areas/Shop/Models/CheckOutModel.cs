using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Iqt.Commerce.Entities;
using IQTechFramework.Enums.Shop;
using IQTechSolutions.Base.Enums.Accounting;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Shop.Models
{
    public class CheckOutModel
    {
        public string CheckoutMethod { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Cell { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Country { get; set; }

        public string ShippingName
        {
            get => string.IsNullOrEmpty(_shippingName) ? Name : _shippingName;
            set => _shippingName = value;
        }
        private string _shippingName;

        public string ShippingSurname { get; set; }

        [EmailAddress]
        public string ShippingEmail { get; set; }

        public string ShippingCell { get; set; }

        public string ShippingCompanyName { get; set; }

        public string ShippingAddressLine1 { get; set; }

        public string ShippingSuburb { get; set; }

        public string ShippingCity { get; set; }
        
        public string ShippingPostalCode { get; set; }

        public string ShippingProvince { get; set; }

        public string ShippingCountry { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string CouponCode { get; set; }
        public string VoucherCode { get; set; }

        public ICollection<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

        public double SubTotal { get; set; }
        public double ShippingRate { get; set; }
        public double Discount { get; set; }
        public double Vat { get; set; }
        public double Total { get; set; }

        public string Comments { get; set; }

        public bool AgreeToTerms { get; set; }

        public string PaymentGateway { get; set; }

        public bool DifferentPostalAddress { get; set; }
    }
}
