using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.Models
{
    public class ShoppingCart : EntityBase
    {
        private readonly GoldTechInnovationDBContext _goldTechInnovationDBContext;

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(GoldTechInnovationDBContext goldTechInnovationDBContext)
        {
            _goldTechInnovationDBContext = goldTechInnovationDBContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<GoldTechInnovationDBContext>();

            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            return new ShoppingCart(context) { Id = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem = _goldTechInnovationDBContext.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id &&
            s.Id == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    Id = Id,
                    Product = product,
                    Amount = amount
                };

                _goldTechInnovationDBContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                
                shoppingCartItem.Amount++;
            }

            _goldTechInnovationDBContext.SaveChanges();

        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _goldTechInnovationDBContext.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id &&
            s.Id == Id);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                
                if (shoppingCartItem.Amount > 1)
                {
                    
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _goldTechInnovationDBContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _goldTechInnovationDBContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _goldTechInnovationDBContext.ShoppingCartItems.Where(c => c.Id == Id)
                .Include(s => s.Product)
                .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _goldTechInnovationDBContext.ShoppingCartItems.Where(c => c.Id == Id);

            _goldTechInnovationDBContext.ShoppingCartItems.RemoveRange(cartItems);
            _goldTechInnovationDBContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _goldTechInnovationDBContext.ShoppingCartItems.Where(c => c.Id == Id)
                .Select(c => c.Product.Price * c.Amount).Sum();

            return total;
        }
    }
}
