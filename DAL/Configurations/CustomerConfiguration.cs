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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CustomerName).HasMaxLength(50);
            builder.Property(x => x.CustomerSurname).HasMaxLength(50);
            builder.Property(x => x.CustomerEmail).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(500);

            // Customer - Orders
            builder.HasMany(c => c.Orders)
              .WithOne(o => o.Customer)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Cascade); // Müşteri silinirse siparişleri de silinsin


            // Customer - Reservations
            builder.HasMany(c => c.Reservations)
                   .WithOne(r => r.Customer)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade); // Müşteri silinirse rezervasyonları da silinsin

            // Customer - Payments
            builder.HasMany(c => c.Payments)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade); // Müşteri silinirse ödemeleri de silinsin
        }
    }
}
