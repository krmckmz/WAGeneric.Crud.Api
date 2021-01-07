using Crud.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Crud.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectDao>
    {
        public void Configure(EntityTypeBuilder<ProjectDao> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Projects");
        }
    }
}
