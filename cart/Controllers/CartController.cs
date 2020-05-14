using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cart.Data;
using cart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartRepository repository;

        public CartController(ICartRepository repository)
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        [HttpGet("getCartProducts")]
        public async Task<List<Cart>> GetCartProduct()
        {
            var cartProducts = await repository.GetCartProduct();
            return cartProducts;
           
        }
        [HttpPut("{id}")]
        public async  Task<Cart>AddProduct(int id, [FromBody] Cart  cart)
        {
            var data = await repository.AddProduct(id, cart);
            return data;

            //var data = await context.CartProducts.FindAsync(id);
            //if (data == null)
            //{
            //  await context.CartProducts.AddAsync(cart);
            //   await context.SaveChangesAsync();
            //    return data;
            //}
            //else
            //{
            //    data.Quantity = cart.Quantity;
            //   context.CartProducts.Update(data);
            //   await context.SaveChangesAsync();
            //    return data;
            //}
            
        }
        



        [HttpDelete("{id}")]
        public async Task<Cart>DeleteProduct(int id)
        {
            var data = await repository.DeleteProduct(id);
            return data;
           // var data = await context.CartProducts.FindAsync(id);
           // context.CartProducts.Remove(data);
           //await context.SaveChangesAsync();
           // return data;

        }
    }
}
