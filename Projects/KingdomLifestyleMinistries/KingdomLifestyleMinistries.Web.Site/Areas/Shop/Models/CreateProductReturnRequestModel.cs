using System;
using System.ComponentModel.DataAnnotations;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Shop.Models
{
    public class CreateProductReturnRequestModel
    {
        /// <summary>
        /// The name of the person that purchased the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The surname of the person that purchased the item
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The email of the person that purchased the item
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The telephone nr of the person that purchased the item
        /// </summary>
        public string TelephoneNr { get; set; }

        /// <summary>
        /// The order nr of the order that contains the item
        /// </summary>
        public string OrderNr { get; set; }

        /// <summary>
        /// The date this item was purchased on
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }

        /// <summary>
        /// The name of the item that was purchased
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The barcode of the product that was purchased
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// The name of the person that purchased the item
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// The name of the person that purchased the item
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// The name of the person that purchased the item
        /// </summary>
        public bool Opened { get; set; }
        /// <summary>
        /// The name of the person that purchased the item
        /// </summary>
        public string Notes { get; set; }
    }
}
