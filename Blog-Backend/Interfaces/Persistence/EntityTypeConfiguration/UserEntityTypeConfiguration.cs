using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.EntityTypeConfiguration
{
    public sealed class UserEntityTypeConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.LastActivity).IsRequired();
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.Status).IsRequired();
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.ThumbnailUrl).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
        }
    }
}
