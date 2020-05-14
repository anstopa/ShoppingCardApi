using cart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cart.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext context;

        public CartRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<Cart> AddProduct(int id, [FromBody] Cart cart)
        {
            var data = await context.CartProducts.FindAsync(id);
            if (data == null)
            {
                await context.CartProducts.AddAsync(cart);
                await context.SaveChangesAsync();
                return data;
            }
            else
            {
                data.Quantity = cart.Quantity;
                context.CartProducts.Update(data);
                await context.SaveChangesAsync();
                return data;
            }
        }

        public async Task<Cart> DeleteProduct(int id)
        {
            var data = await context.CartProducts.FindAsync(id);
            context.CartProducts.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<List<Cart>> GetCartProduct()
        {
            var cartProduct = await context.CartProducts.ToListAsync();
            return cartProduct;
        }

        public async Task<List<Product>> GetProduct()
        {
            var product = await context.Products.ToListAsync();
            return product;
        }
    }
}
