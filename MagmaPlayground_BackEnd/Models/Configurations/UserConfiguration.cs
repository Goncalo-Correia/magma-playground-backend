using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagmaPlayground_BackEnd.Model.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.lastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.password)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.createdOn)
                .HasColumnType("datetime");

            builder.Property(prop => prop.updatedOn)
                .HasColumnType("datetime");
        }
    }
}
