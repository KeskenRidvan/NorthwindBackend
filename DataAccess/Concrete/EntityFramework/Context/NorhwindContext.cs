using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;
public class NorhwindContext : DbContext
{
	protected override void OnConfiguring(
		DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\UDEMY;Database=Eng.Northwind;Integrated Security=True;Trusted_Connection=true");
	}

	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }

	public DbSet<User> Users { get; set; }
	public DbSet<OperationClaim> OperationClaims { get; set; }
	public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}