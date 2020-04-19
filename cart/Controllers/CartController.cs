using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cart.Data;
using cart.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly DataContext context;

        public CartController(DataContext context )
        {
            this.context = context;
        }

        // GET: /<controller>/
        [HttpGet("getCartProducts")]
        public List<Cart> Get()
        {
            var cartProducts = context.cartProducts.ToList();
            return cartProducts;
           
        }
        [HttpPut("{id}")]
        public void AddProduct(int id, [FromBody] Cart  cart)
        {
            var data = context.cartProducts.Find(id);
            if (data == null)
            {
                context.cartProducts.Add(cart);
                context.SaveChanges();
            }
            else
            {
                data.Quantity = cart.Quantity;
                context.cartProducts.Update(data);
                context.SaveChanges();
            }
            
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var data = context.cartProducts.Find(id);
            context.cartProducts.Remove(data);
            context.SaveChanges();

        }
    }
}
