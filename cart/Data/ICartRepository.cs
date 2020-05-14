using cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cart.Data
{
   public interface ICartRepository
    {
        Task<List<Product>> GetProduct();
        
        Task<List<Cart>> GetCartProduct();
        Task<Cart> AddProduct(int id, Cart cart);
        Task<Cart> DeleteProduct(int id);

    }
}
