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
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {


            // Inventory -> Product (Bire-Bir ya da Bire-Çok)
            builder.HasOne(i => i.Product)       // Inventory, bir Product ile ilişkilidir.
                   .WithMany()                   // Product birden fazla Inventory ile ilişkili olabilir.
                   .HasForeignKey(i => i.ProductId)
                   .OnDelete(DeleteBehavior.Restrict); // Ürün silinirse, Inventory etkilenmez.

            // Inventory -> Supplier (Bire-Bir ya da Bire-Çok)
            builder.HasOne(i => i.Supplier)      // Inventory, bir Supplier ile ilişkilidir.
                   .WithMany()                   // Supplier birden fazla Inventory ile ilişkili olabilir.
                   .HasForeignKey(i => i.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict); // Tedarikçi silinirse, Inventory etkilenmez.

            // Inventory -> Employee (Bire-Bir ya da Bire-Çok)
            builder.HasOne(i => i.Employee)      // Inventory, bir Employee ile ilişkilidir.
                   .WithMany(e => e.Inventories) // Employee birden fazla Inventory ile ilişkili olabilir.
                   .HasForeignKey(i => i.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict); // Çalışan silinirse, Inventory etkilenmez.


        }
    }
}
