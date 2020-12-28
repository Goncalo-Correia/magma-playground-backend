using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagmaPlayground_BackEnd.Model.Configurations
{
    public class PluginConfiguration : IEntityTypeConfiguration<Plugin>
    {
        public void Configure(EntityTypeBuilder<Plugin> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.order)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(prop => prop.pluginName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.pluginType)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
