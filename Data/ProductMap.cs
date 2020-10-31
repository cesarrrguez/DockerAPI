using DockerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DockerApi.Data
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", DataContext.DEFAULT_SCHEMA);

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(product => product.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(product => product.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
