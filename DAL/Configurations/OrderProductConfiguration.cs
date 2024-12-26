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
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)

        {
            builder.Ignore(x=>x.ID);
            builder.Ignore(x => x.GuidId);


            builder.HasKey(x => new {x.ProductId, x.OrderId});

            builder.HasOne(x => x.Product).WithMany(x => x.OrderProducts).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderProducts).HasForeignKey(x => x.OrderId);
        }
    }
}
