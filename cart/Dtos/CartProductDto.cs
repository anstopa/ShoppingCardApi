using cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cart.Dtos
{
    public class CartProductDto
    {
        public int Id { get; set; }
        public Cart cart { get; set; }
    }
}
