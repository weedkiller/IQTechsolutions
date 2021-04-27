using System.Collections.Generic;
using Iqt.Base.BaseTypes;

namespace Shopping.Base.Entities
{
    public class ShoppingCart : EntityBase
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
