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
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.MenuName).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);


            // Menu -> Products (Bire-Çok İlişki)
            builder.HasMany(m => m.Products)      // Menü'nün birden fazla ürünü olabilir
                   .WithOne(p => p.Menu)          // Her ürün bir menüye ait
                   .HasForeignKey(p => p.MenuId)  // Foreign Key: Product.MenuId
                   .OnDelete(DeleteBehavior.Cascade); // Menü silindiğinde ilişkili ürünler de silinir
        }
    }
}
