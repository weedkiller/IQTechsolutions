using Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
