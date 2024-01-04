using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities.Concrete;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete.EntityFramework.Context;

public class AppDbContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\UDEMY;Database=Eng.Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
	}
	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }

	public DbSet<User> Users { get; set; }
	public DbSet<OperationClaim> OperationClaims { get; set; }
	public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}
