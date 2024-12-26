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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(255);

            // Category ile Product arasındaki bire-çok ilişki
            builder.HasMany(c => c.Products)      // Category -> Products ilişkisi
                   .WithOne(p => p.Category)      // Her Product bir Category'ye ait.
                   .HasForeignKey(p => p.CategoryId) // Foreign key olarak CategoryId'yi kullan
                   .OnDelete(DeleteBehavior.Cascade); // Category silinirse ilişkili Products da silinir.


        }
    }
}
