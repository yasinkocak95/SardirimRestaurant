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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {




            builder.HasOne(u => u.Employee)    // User, bir Employee'ye sahip
               .WithOne()                  // Bir User sadece bir Employee ile ilişkilendirilir
               .HasForeignKey<User>(u => u.EmployeeId) // User tablosunda EmployeeId Foreign Key olacak
               .OnDelete(DeleteBehavior.Cascade); // Employee silindiğinde User da silinir

        }
    }
}
