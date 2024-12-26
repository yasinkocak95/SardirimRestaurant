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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {



            // Order -> Customer (Bir sipariş bir müşteriye ait)
            builder.HasOne(o => o.Customer)
                   .WithMany(c => c.Orders)       // Bir müşteri birden fazla sipariş verebilir
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade); // Müşteri silindiğinde ilişkili siparişler de silinir

            // Order -> Employee (Sipariş bir çalışan tarafından işlenmiş olabilir)
            builder.HasOne(o => o.Employee)
                   .WithMany(e => e.Orders)      // Bir çalışan birden fazla sipariş işleyebilir
                   .HasForeignKey(o => o.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict); // Çalışan silindiğinde siparişler etkilenmez

            // Order -> OrderProduct (Çoktan çoğa ilişki: Sipariş ile ürünler arasındaki ilişki)
            builder.HasMany(o => o.OrderProducts)
                   .WithOne(op => op.Order)
                   .HasForeignKey(op => op.OrderId)
                   .OnDelete(DeleteBehavior.Cascade); // Sipariş silindiğinde ilişkilendirilmiş OrderProduct'lar da silinir

            // Order -> Table (Bir sipariş bir masaya aittir)
            builder.HasOne(o => o.Table)
                   .WithMany(t => t.Orders)      // Bir masa birden fazla sipariş alabilir
                   .HasForeignKey(o => o.TableId)
                   .OnDelete(DeleteBehavior.Restrict); // Masa silindiğinde siparişler etkilenmez

            // Order -> Payment (Bir ödeme bir siparişle ilişkilidir)
            builder.HasOne(o => o.Payment)
                   .WithOne(p => p.Order)         // Bir ödeme bir siparişle ilişkilidir (Bir ödeme bir sipariş için yapılır)
                   .HasForeignKey<Order>(o => o.PaymentId)
                   .OnDelete(DeleteBehavior.SetNull); // Sipariş silindiğinde ödeme null olur
        }
    }
}
