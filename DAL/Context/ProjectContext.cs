using DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ProjectContext:IdentityDbContext<User>
    {

        public ProjectContext()
        {

        }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        

        //DBSET
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        
        

        //sql
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=KOCAK\\SQLEXPRESS;database=SardırımRestaurantDB;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        //applyconfiguration

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new InventoryConfiguration());
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderProductConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());            
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }



    }
}
