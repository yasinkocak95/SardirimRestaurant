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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);



            builder.HasOne(r => r.Customer)
              .WithMany(c => c.Reservations)  // Bir müşteri birden fazla rezervasyon yapabilir
              .HasForeignKey(r => r.CustomerId) // Foreign Key: Reservation.CustomerId
              .OnDelete(DeleteBehavior.Restrict); // Müşteri silindiğinde rezervasyon silinmez

            // Reservation -> Employee (Bir rezervasyon bir çalışan tarafından işlenir)
            builder.HasOne(r => r.Employee)
                   .WithMany(e => e.Reservations)  // Bir çalışan birden fazla rezervasyonu işleyebilir
                   .HasForeignKey(r => r.EmployeeId) // Foreign Key: Reservation.EmployeeId
                   .OnDelete(DeleteBehavior.Restrict); // Çalışan silindiğinde rezervasyon silinmez

            // Reservation -> Table (Her rezervasyonun bir masası olur)
            builder.HasOne(r => r.Table)
                   .WithMany(t => t.Reservations)  // Bir masa birden fazla rezervasyona sahip olabilir
                   .HasForeignKey(r => r.TableId)  // Foreign Key: Reservation.TableId
                   .OnDelete(DeleteBehavior.Restrict); // Masa silindiğinde rezervasyon silinmez



        }
    }
}
