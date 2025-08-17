using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.ProductCatalogService.Database.EntityConfigurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.HasKey(x => x.ID).HasName("pk_product");
        builder.Property(x => x.ID).HasColumnName("id");
        builder.Property(x => x.ProductCatalogTypeID).IsRequired().HasColumnName("product_catalog_type_id");
        builder.Property(x => x.Price).IsRequired().HasColumnName("price");
        builder.Property(x => x.Count).IsRequired().HasColumnName("count");
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(250).HasColumnName("name");
        builder.HasIndex(x => x.Name, "ui_product_name").IsUnique();
        builder.HasIndex(x => x.ProductCatalogTypeID, "ui_product_product_catalog_type_id");

        builder.HasOne(x => x.ProductCatalogType)
            .WithMany()
            .HasForeignKey(x => x.ProductCatalogTypeID)
            .HasConstraintName("fk_product_product_catalog_type");
    }
}
