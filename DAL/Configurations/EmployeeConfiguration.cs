using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using MODELS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Surname).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Adress).HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Title).HasMaxLength(50);

            builder.Property(x => x.Salary).HasColumnType("money");

            // Employee - Orders
            builder.HasMany(e => e.Orders)
                   .WithOne(o => o.Employee)
                   .HasForeignKey(o => o.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Employee - Tables
            builder.HasMany(e => e.Tables)
                   .WithOne(t => t.Employee)
                   .HasForeignKey(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Employee - Inventories
            builder.HasMany(e => e.Inventories)
                   .WithOne(i => i.Employee)
                   .HasForeignKey(i => i.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Employee - Reservations
            builder.HasMany(e => e.Reservations)
                   .WithOne(r => r.Employee)
                   .HasForeignKey(r => r.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Employee - Suppliers
            builder.HasMany(e => e.Suppliers)
                   .WithOne(s => s.Employee)
                   .HasForeignKey(s => s.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);



            builder.HasData(GetEmployee());


        }
        private List<Employee> GetEmployee()
        {
            return new List<Employee>
            {
                new Employee{ID=1,Name="Bora",Surname="Beken",Email="borabeken@sardırımrestaurant.com",Adress="İstanbul/Kadıköy",PhoneNumber="05555555555",Title="Chairman Of The Board",Salary=150000,HireDate=new DateTime(2005,11,15)},

                new Employee{ID=2,Name="Muammer",Surname="Altın",Email="muammeraltin@sardırımrestaurant.com",Adress="İstanbul/Maltepe",PhoneNumber="05555555554",Title="Waiter",Salary=30000,HireDate=new DateTime(2021,9,17)},

                new Employee{ID=3,Name="Cemil",Surname="Altun",Email="cemilaltun@sardırımrestaurant.com",Adress="İstanbul/Üsküdar",PhoneNumber="05555555553",Title="Chef",Salary=70000,HireDate=new DateTime(2018,3,21)},

                new Employee{ID=4,Name="Durmuş",Surname="Hasanoğlu",Email="durmushasanoglu@sardırımrestaurant.com",Adress="İstanbul/Kartal",PhoneNumber="05555555552",Title="Reservation Manager",Salary=60000,HireDate=new DateTime(2019,2,11)},

                new Employee{ID=5,Name="Bekir",Surname="Hakkıoğlu",Email="bekirhakkıoglu@sardırımrestaurant.com",Adress="İstanbul/Kadıköy",PhoneNumber="05555555551",Title="Cashier",Salary=60000,HireDate=new DateTime(2016,3,9)},

                new Employee{ID=6,Name="İsmail",Surname="Taşdelen",Email="ismailtasdelen@sardırımrestaurant.com",Adress="İstanbul/Pendik",PhoneNumber="05555555550",Title="Accounting Manager",Salary=90000,HireDate=new DateTime(2013,12,26)},

                new Employee{ID=7,Name="Hüseyin",Surname="Camlıgöz",Email="huseyincamligoz@sardırımrestaurant.com",Adress="İstanbul/Maltepe",PhoneNumber="05555555556",Title="IT Department Manager",Salary=100000,HireDate=new DateTime(2012,11,25)},
            };
        }





    }
}
