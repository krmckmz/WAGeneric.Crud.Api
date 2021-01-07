using Crud.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Data.Configurations
{
    public class PluginConfiguration : IEntityTypeConfiguration<PluginDao>
    {
        public void Configure(EntityTypeBuilder<PluginDao> builder)
        {
            builder
                 .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Size)
               .IsRequired();
             
            builder
                    .HasOne(m => m.LocatedProject)
                    .WithMany(a=> a.Plugins)
                    .HasForeignKey(m=>m.ProjectId);

            builder.ToTable("Plugins");
        }
    }
}
