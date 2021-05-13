using Microsoft.AspNetCore.Mvc;
using Shopping.Core.Context.Services;

namespace GoldTechInnovation.Web.Site.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCartContext _shoppingCart;

        public ShoppingCartSummary(ShoppingCartContext shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
