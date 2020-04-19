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
	public class ProductsController : ControllerBase
	{
		private readonly DataContext context;

		public ProductsController(DataContext context)
		{
			this.context = context;
		}
		// GET: /<controller>/
		[HttpGet ("getProduct")]
		public List<Product> Get()
		{
			var products = context.Products.ToList();
			return products;
		}

		[HttpPost("addProduct")]
		public void AddProduct([FromBody] Product product)
		{
			context.Products.Add(product);
			context.SaveChanges();
		}
	}
}
