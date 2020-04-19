using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cart.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public int Quantity { get; set; }

	}
}
