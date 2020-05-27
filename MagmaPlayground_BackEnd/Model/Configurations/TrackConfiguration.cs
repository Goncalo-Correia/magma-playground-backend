using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagmaPlayground_BackEnd.Model.Configurations
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.order)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(prop => prop.name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.volume)
                .HasColumnType("decimal");

            builder.Property(prop => prop.pan)
                .HasColumnType("decimal");

            builder.Property(prop => prop.trackTypeId)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
