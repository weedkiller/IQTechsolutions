using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Core.Context.Services;
using Products.Core.Models;

namespace GoldTechSolutions.Web.Site.ViewComponents
{
    [ViewComponent]
    public class ProductWidget : ViewComponent
    {
        private readonly ProductContext _productContext;

        public ProductWidget(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string sorting)
        {
            try
            {
                var products = _productContext.GetAll();
                if (sorting == "toprated")
                {
                    products = products.OrderBy(c => c.Sold);
                }
                else if (sorting == "popular")
                {
                    products = products.OrderBy(c => c.Views);
                }
                else if (sorting == "featured")
                {
                    products = products.Where(c => c.Featured);
                }
                else if (sorting == "sale")
                {
                    products = products.Where(c => c.Discount > 0);
                }

                var model = new ProductIndexModel(products.ToList());
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
