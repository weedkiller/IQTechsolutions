using Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public string BrandId { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }
    }
}
