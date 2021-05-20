using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldTechSolutions.Web.Site.Models;
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
                var model = new ProductComponentModel()
                {
                    Products = products.Take(10).ToList()
                };

                if (sorting == "toprated")
                {
                    model.Products = products.OrderBy(c => c.Sold);
                    model.WidgetTitle = "Top Rated Products";
                }
                else if (sorting == "popular")
                {
                    model.Products = products.OrderBy(c => c.Views);
                    model.WidgetTitle = "Propular Products";
                }
                else if (sorting == "featured")
                {
                    model.Products = products.Where(c => c.Featured);
                    model.WidgetTitle = "Featured Products";
                }
                else if (sorting == "sale")
                {
                    model.Products = products.Where(c => c.DiscountPercentage > 0);
                    model.WidgetTitle = "Products On Sale";
                }
                else if (sorting == "new")
                {
                    model.Products = products.Where(c => c.Created > DateTime.Now.AddMonths(2));
                    model.WidgetTitle = "New Arrivals";
                }

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
