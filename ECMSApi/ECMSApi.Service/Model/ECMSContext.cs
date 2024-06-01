using ECMSApi.Service.BussinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.Model
{
	public partial class ECMSContext : DbContext
	{
		private readonly string _connectionString;
		SQLConnectionString _connectionStringService = new SQLConnectionString();

		public ECMSContext()
		{
			// _connectionString = cnString;
		}
		public ECMSContext(DbContextOptions<ECMSContext> options)
			: base(options)
		{
			_connectionString = _connectionStringService.GetConnectionString("default");
		}
		public virtual DbSet<tblTest> Tests { get; set; } = null!;
		public virtual DbSet<Products> Products { get; set; } = null!;
		public virtual DbSet<Categories> Categories { get; set; } = null!;
		public virtual DbSet<Sizes> Sizes { get; set; } = null!;
		public virtual DbSet<InventoryLevels> InventoryLevels { get; set; } = null!;
		public virtual DbSet<Color> Colors { get; set; } = null!;
		public virtual DbSet<Order> Orders { get; set; } = null!;
		public virtual DbSet<OrderDetails> OrderDetails { get; set; } = null!;
		public virtual DbSet<Customer> Customers { get; set; } = null!;
		public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_connectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblTest>().ToTable("tblTest");
			modelBuilder.Entity<Products>().ToTable("Products");
			modelBuilder.Entity<Sizes>().ToTable("Sizes");
			modelBuilder.Entity<Categories>().ToTable("Categories");
			modelBuilder.Entity<InventoryLevels>().ToTable("Inventory_Levels");
			modelBuilder.Entity<Color>().ToTable("Color");
			modelBuilder.Entity<Order>().ToTable("Order");
			modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails");
			modelBuilder.Entity<Customer>().ToTable("Customer");
			modelBuilder.Entity<UserLogin>().ToTable("UserLogin");

		}
	
	}
}
