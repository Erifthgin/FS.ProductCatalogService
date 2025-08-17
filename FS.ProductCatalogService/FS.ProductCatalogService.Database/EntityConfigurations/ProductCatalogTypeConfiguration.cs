using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.ProductCatalogService.Database.EntityConfigurations;

internal class ProductCatalogTypeConfiguration : IEntityTypeConfiguration<ProductCatalogType>
{
    public void Configure(EntityTypeBuilder<ProductCatalogType> builder)
    {
        builder.ToTable("product_catalog_type");
        builder.HasKey(x => x.ID).HasName("pk_product_catalog_type");
        builder.Property(x => x.ID).HasColumnName("id");
        builder.Property(x => x.ProductCatalogCategoryID).IsRequired().HasColumnName("product_catalog_category_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(250).HasColumnName("name");
        builder.HasIndex(x => x.Name, "ui_product_catalog_type_name").IsUnique();
        builder.HasIndex(x => x.ProductCatalogCategoryID, "ix_product_catalog_type_product_catalog_category");

        builder.HasOne(x => x.ProductCatalogCategory)
            .WithMany()
            .HasForeignKey(x => x.ProductCatalogCategoryID)
            .HasConstraintName("fk_product_catalog_type_product_catalog_category");
    }
}
