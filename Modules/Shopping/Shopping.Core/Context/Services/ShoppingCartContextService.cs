using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.Base.Entities;

namespace Shopping.Core.Context.Services
{
    public class ShoppingCartContext 
    {
        #region Members

        private DbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        public ShoppingCartContext(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a paginated collection of products from the web service/api
        /// </summary>
        /// <param name="shoppingCartId">The identity of the shopping cart</param>
        /// <returns>The collection of <see cref="ShoppingCartItem"/> that belongs to the cart</returns>
        public async Task<ICollection<ShoppingCartItem>> GetCartItemsAsync(string shoppingCartId)
        {
            return await _context.Set<ShoppingCartItem>().Include(c => c.Product).ThenInclude(c => c.Images).Where(cart => cart.ShoppingCartId == shoppingCartId).ToListAsync();
        }

        public async Task<ShoppingCartItem> GetSpecificCartItemAsync(string shoppingCartId, string productId)
        {
            return (await GetCartItemsAsync(shoppingCartId)).FirstOrDefault(c => c.ProductId == productId);
        }

        public async Task<ShoppingCartItem> AddCartItemsAsync(ShoppingCartItem item)
        {
            _context.Set<ShoppingCartItem>().Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return item;
        }

        public async Task<ShoppingCartItem> UpdateCartItemsAsync(ShoppingCartItem item)
        {
            _context.Set<ShoppingCartItem>().Update(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return item;
        }

        public async Task MigrateCartItemsAsync(string shoppingCartId, string newCartId)
        {
            var list = (await GetCartItemsAsync(shoppingCartId)).ToList();
            foreach (var item in list)
            {
                item.ShoppingCartId = newCartId;
                _context.Set<ShoppingCartItem>().Update(item);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task RemoveCartItemsAsync(ShoppingCartItem item)
        {
            _context.Set<ShoppingCartItem>().Remove(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task RemoveAllCartItemsAsync(string shoppingCartId)
        {
            var list = (await GetCartItemsAsync(shoppingCartId)).ToList();
            foreach (var cartItem in list)
            {
                _context.Set<ShoppingCartItem>().Remove(cartItem);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Gets the total items in the cart
        /// </summary>
        /// <returns>The total item in a specific cart</returns>
        public async Task<double> GetTotal(string shoppingCartId)
        {
            var x = (await GetCartItemsAsync(shoppingCartId)).Sum(c => c.Qty * c.Product.PriceIncl);
            return x;
        }

        #endregion
    }
}
