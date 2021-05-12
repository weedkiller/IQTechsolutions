using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Products.Base.Entities;

namespace Shopping.Base.Entities
{
    public class ShoppingCartItem : EntityBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ShoppingCartItem() { }

        /// <summary>
        /// The parameter constructor
        /// </summary>
        /// <param name="qty">The qty of products sold</param>
        /// <param name="productId">The identity of the product sold</param>
        /// <param name="userId">The identity user that bought this application</param>
        /// <param name="deletedItem">Flag to indicate if is deleted method should be applied</param>
        public ShoppingCartItem(int qty, string productId, string userId, bool deletedItem = false)
        {
            Qty = qty;
            ProductId = productId;
            UserId = userId;
            DeletedItem = deletedItem;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The quantity of products
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Flag to indicate if is deleted method should be applied
        /// </summary>
        public bool DeletedItem { get; set; }

        public string ShoppingCartId { get; set; }

        #region ReadOnly

        /// <summary>
        /// The price of the product
        /// </summary>
        public double Price
        {
            get
            {
                if (Product == null)
                {
                    return 0;
                }

                return Product.PriceIncl;
            }
        }

        /// <summary>
        /// The total ammount due
        /// </summary>
        public double? TotalDue
        {
            get
            {
                if (Product == null || Qty == 0)
                    return 0;
                return Qty * Product.PriceIncl;
            }
        }

        #endregion

        #endregion

        #region Relationships

        /// <summary>
        /// The product that is being purchased
        /// </summary>
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }

        #endregion
    }
}
