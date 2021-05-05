using GoldTechInnovation.Web.Datastores;
using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldTechInnovation.Web.Site.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GoldTechInnovationDBContext _goldTechInnovationDBContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(GoldTechInnovationDBContext goldTechInnovationDBContext, ShoppingCart shoppingCart)
        {
            _goldTechInnovationDBContext = goldTechInnovationDBContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            _goldTechInnovationDBContext.Orders.Add(order);

            _goldTechInnovationDBContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

           
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Product.Price,
                    ProductId = shoppingCartItem.Product.Id,
                    OrderId = order.Id
                };
                _goldTechInnovationDBContext.OrderDetails.Add(orderDetail);
            }
            _goldTechInnovationDBContext.SaveChanges();
        }
    }
}
