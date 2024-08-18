using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x=>x.ID).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.Property(x=>x.Name).HasMaxLength(100).IsRequired();
            builder.HasQueryFilter(x => x.Status);
        }
    }
}
