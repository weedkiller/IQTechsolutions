using System;
using Microsoft.AspNetCore.Http;

namespace Shopping.Core.Extensions
{
    public static class ShoppingCartExtensions
    {
        public const string CartSessionKey = "CartId";

        public static string GetShoppingCartId(HttpContext context)
        {
            string cartId = "";

            if (context.Session.GetString(CartSessionKey) == null)
            {
                cartId = !string.IsNullOrWhiteSpace(context.User.Identity.Name) ? context.User.Identity.Name : Guid.NewGuid().ToString();

            }
            context.Session.SetString(CartSessionKey, cartId);
            return context.Session.GetString(CartSessionKey);
        }
    }
}
