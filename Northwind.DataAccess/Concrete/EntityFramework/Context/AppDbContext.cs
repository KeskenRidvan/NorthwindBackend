using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete.EntityFramework.Context;

public class AppDbContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\UDEMY;Database=Eng.Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
	}
	public DbSet<Product> Products { get; set; }
}
