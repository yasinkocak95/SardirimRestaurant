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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.Amount).HasColumnType("money");


            // Payment -> Order (Bir ödeme bir siparişe ait)
            builder.HasOne(p => p.Order)
                   .WithOne(o => o.Payment)  // Her sipariş yalnızca bir ödeme ile ilişkilidir
                   .HasForeignKey<Payment>(p => p.OrderId) // Foreign Key: Payment.OrderId
                   .OnDelete(DeleteBehavior.Cascade); // Sipariş silindiğinde ödeme da silinir

            // Payment -> Customer (Bir ödeme bir müşteriye ait olabilir)
            builder.HasOne(p => p.Customer)
                   .WithMany(c => c.Payments) // Bir müşteri birden fazla ödeme yapabilir
                   .HasForeignKey(p => p.CustomerId) // Foreign Key: Payment.CustomerId
                   .OnDelete(DeleteBehavior.Restrict); // Müşteri silindiğinde ödeme silinmez
        }
    }
}

