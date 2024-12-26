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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(50);
            builder.Property(x => x.ContactFullName).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);




            // Supplier -> Product (Bir tedarikçi birden fazla ürün sağlar)
            builder.HasMany(s => s.Products)
                   .WithOne(p => p.Supplier)   // Bir ürün bir tedarikçiden gelir
                   .HasForeignKey(p => p.SupplierId) // Foreign Key: Product.SupplierId
                   .OnDelete(DeleteBehavior.Restrict); // Tedarikçi silindiğinde ürün silinmez

            // Supplier -> Employee (Bir tedarikçi bir çalışan tarafından yönetilebilir)
            builder.HasOne(s => s.Employee)
                   .WithMany(e => e.Suppliers)  // Bir çalışan birden fazla tedarikçiyi yönetebilir
                   .HasForeignKey(s => s.EmployeeId)  // Foreign Key: Supplier.EmployeeId
                   .OnDelete(DeleteBehavior.Restrict); // Çalışan silindiğinde tedarikçi silinmez

            builder.HasData();

        }
        //private List<Supplier> GetSuppliers()
        //{
        //    return new List<Supplier>
        //    {

        //        new Supplier{ID=1,CompanyName="Horoz Lojistik",ContactFullName="Kerem Aktürk",PhoneNumber="05554447788",EmployeeId=1},
        //        new Supplier{ID=2,CompanyName="Aslan Lojistik",ContactFullName="Aslan Aktürk",PhoneNumber="05554447777",EmployeeId=1},

        //    };


        //}
    }
}
