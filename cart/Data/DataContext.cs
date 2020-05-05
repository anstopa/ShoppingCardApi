using cart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cart.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> CartProducts { get; set; }
		


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.Property(s => s.Quantity)
				.HasColumnName("Quantity")
				.HasDefaultValue(1);
		}
	}

}
