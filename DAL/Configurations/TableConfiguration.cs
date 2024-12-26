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
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            // Table -> Reservation (Bir masaya birden fazla rezervasyon yapılabilir)
            builder.HasMany(t => t.Reservations)
                   .WithOne(r => r.Table)    // Bir rezervasyon bir masaya yapılır
                   .HasForeignKey(r => r.TableId) // Foreign Key: Reservation.TableId
                   .OnDelete(DeleteBehavior.Restrict); // Rezervasyon silindiğinde masa silinmez

            // Table -> Order (Bir masaya birden fazla sipariş verilebilir)
            builder.HasMany(t => t.Orders)
                   .WithOne(o => o.Table)    // Bir sipariş bir masaya verilir
                   .HasForeignKey(o => o.TableId) // Foreign Key: Order.TableId
                   .OnDelete(DeleteBehavior.Restrict); // Sipariş silindiğinde masa silinmez

            // Table -> Employee (Bir masaya bir çalışan atanabilir)
            builder.HasOne(t => t.Employee)
                   .WithMany(e => e.Tables) // Bir çalışan birden fazla masayı yönetebilir
                   .HasForeignKey(t => t.EmployeeId)  // Foreign Key: Table.EmployeeId
                   .OnDelete(DeleteBehavior.Restrict); // Çalışan silindiğinde masa silinmez
        }
    }
}
