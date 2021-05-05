using Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class OrderDetail : EntityBase
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }

        // Candy Object
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
    }
}
