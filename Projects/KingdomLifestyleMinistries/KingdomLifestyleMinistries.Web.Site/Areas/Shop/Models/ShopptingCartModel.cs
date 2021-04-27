using System;
using System.Collections.Generic;
using Iqt.Commerce.Entities;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Shop.Models
{
    public class ShopptingCartModel
    {
        public ICollection<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

        public string CouponCode { get; set; }

        public string GiftVoucherCode { get; set; }

        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }

        public int ItemCount { get; set; }
        public double SubTotal { get; set; }

        public double Vat { get; set; }

        public double Discount { get; set; } = 0;

        public double Total
        {
            get
            {
                return Math.Round(SubTotal + Vat - Discount, 2);
            }
        }

    }
}
