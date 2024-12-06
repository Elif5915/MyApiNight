using Microsoft.EntityFrameworkCore;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_DataAccessLayer.Context;
public class ApiContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=NETCADYAZ;initial Catalog=ApiDbNight;integrated Security=true");
	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }
}

