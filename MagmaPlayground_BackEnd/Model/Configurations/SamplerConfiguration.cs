using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagmaPlayground_BackEnd.Model.Configurations
{
    public class SamplerConfiguration : IEntityTypeConfiguration<Sampler>
    {
        public void Configure(EntityTypeBuilder<Sampler> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
