using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Base.ApiModels
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
