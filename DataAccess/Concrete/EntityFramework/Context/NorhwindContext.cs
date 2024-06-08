using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;
public class NorhwindContext : DbContext
{
	protected override void OnConfiguring(
		DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\UDEMY;Database=Eng.Northwind;Trusted_Connection=true");
	}

	public DbSet<Product> Products { get; set; }
}