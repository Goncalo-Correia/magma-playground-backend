using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagmaPlayground_BackEnd.Model.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.createdOn)
                .HasColumnType("datetime");

            builder.Property(prop => prop.updatedOn)
                .HasColumnType("datetime");  
        }
    }
}
