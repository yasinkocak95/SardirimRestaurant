using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName).HasMaxLength(50);
            

            builder.Property(x => x.Price).HasColumnType("money");


            // Product -> Category (Bir ürün bir kategoriye ait)
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)     // Bir kategori birden fazla ürüne sahip olabilir
                   .HasForeignKey(p => p.CategoryId)  // Foreign Key: Product.CategoryId
                   .OnDelete(DeleteBehavior.Restrict); // Kategori silindiğinde ürünler silinmez

            // Product -> OrderProduct (Çoktan çoğa ilişki: Sipariş ile ürünler arasında ilişki)
            builder.HasMany(p => p.OrderProducts)
                   .WithOne(op => op.Product)
                   .HasForeignKey(op => op.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); // Ürün silindiğinde ilişkili OrderProduct silinir

            // Product -> Inventory (Bir ürün bir envantere ait olabilir)
            builder.HasMany(p => p.Inventories)
                   .WithOne(i => i.Product)
                   .HasForeignKey(i => i.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); // Ürün silindiğinde envanter kaydı silinir

            // Product -> Supplier (Bir ürün bir tedarikçiden gelir)
            builder.HasOne(p => p.Supplier)
                   .WithMany(s => s.Products)    // Bir tedarikçi birden fazla ürün sağlar
                   .HasForeignKey(p => p.SupplierId)  // Foreign Key: Product.SupplierId
                   .OnDelete(DeleteBehavior.Restrict); // Tedarikçi silindiğinde ürünler silinmez

            // Product -> Menu (Bir ürün bir menüde yer alabilir)
            builder.HasOne(p => p.Menu)
                   .WithMany(m => m.Products)   // Bir menü birden fazla ürüne sahip olabilir
                   .HasForeignKey(p => p.MenuId)  // Foreign Key: Product.MenuId
                   .OnDelete(DeleteBehavior.Restrict); // Menü silindiğinde ürünler silinmez

            builder.HasData();
        }

        //private List<Product> GetProducts()
        //{
        //    return new List<Product>
        //    {
        //        //pizza
        //        new Product{ID=1,ProductName="Domates",Price=15},
        //        new Product{ID=2,ProductName="Mozerella Peyniri",Price=35},
        //        new Product{ID=3,ProductName="Fesleğen",Price=5},
        //        new Product{ID=4,ProductName="Zeytinyağı",Price=45},
        //        new Product{ID=5,ProductName="Tuz",Price=2},
        //        new Product{ID=6,ProductName="Un",Price=15},

        //        //makarna
        //        new Product{ID=7,ProductName="Ayçiçek Yağı",Price=15},
        //        new Product{ID=8,ProductName="500gr Paket Makarna",Price=5},
        //        new Product{ID=9,ProductName="500gr Paket Salça",Price=7}


        //    };


        //}
    }
}
