using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using Turbo.Az.Models.Entities;


namespace Turbo.Az.Models.Configurations
{
    internal class ModelEntityConfiguration
    : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").IsRequired();
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.BrandId).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedBy).HasColumnType("int");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");


            builder.HasKey(m => m.Id);
            builder.ToTable("Model");

            builder.HasOne<Brand>()
               .WithMany()
               .HasForeignKey(m => m.BrandId)
               .HasPrincipalKey(m => m.Id)
               .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
