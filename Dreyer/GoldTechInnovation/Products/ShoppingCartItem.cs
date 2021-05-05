using Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class ShoppingCartItem : EntityBase
    {
        public string ShoppingCartId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}
