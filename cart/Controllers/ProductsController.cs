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
	public class ProductsController : ControllerBase
	{
		private readonly ICartRepository repository;

		public ProductsController(ICartRepository repository)
		{
			this.repository = repository;
		}
		// GET: /<controller>/
		[HttpGet ("getProduct")]
		public async Task<List<Product>> GetProduct()
		{
			var products =  await repository.GetProduct();
			return products;
		}

		//[HttpPost("addProduct")]
		//public void AddProduct([FromBody] Product product)
		//{
		//	 context.Products.Add(product);
		//	context.SaveChanges();
		//}
	//	[HttpGet("getRelatedProducts{id}")]
	//	public async Task<IEnumerable<int>> GetRelatedProducts(int id)
	//	{
			
	//		var product = await context.Products.Include(x => x.RelatedProducts).FirstOrDefaultAsync(u => u.ProductId == id);
	//		if(product == null)
	//		{
	//			return null;
	//		}
	//		return product.RelatedProducts.Where(u => u.ProductId == id).Select(p => p.RelatedProductId);
	//		//return context.Products.Where(p => p.ProductId.Equals(product.RelatedProducts.Where(u => u.ProductId == id).Select(p => p.RelatedProductId))).Select(p => p.ProductId);
	//}
}
}