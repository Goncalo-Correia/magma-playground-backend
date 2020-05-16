using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagmaPlayground_BackEnd.Model.Configurations
{
    public class RackConfiguration : IEntityTypeConfiguration<Rack>
    {
        public void Configure(EntityTypeBuilder<Rack> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.pluginName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
