using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NevronDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Persistence.Configurations
{
    public class NumberConfiguration : IEntityTypeConfiguration<Number>
    {
        public void Configure(EntityTypeBuilder<Number> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired();
        }
    }
}
