using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.ProductCatalogService.Database.EntityConfigurations;

internal class ProductCatalogCategoryConfiguration : IEntityTypeConfiguration<ProductCatalogCategory>
{
    public void Configure(EntityTypeBuilder<ProductCatalogCategory> builder)
    {
        builder.ToTable("product_catalog_category");
        builder.HasKey(x => x.ID).HasName("pk_product_catalog_category");
        builder.Property(x => x.ID).HasColumnName("id");
        builder.Property(x => x.ParentProductCatalogCategoryID).HasColumnName("parent_product_catalog_category_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(250).HasColumnName("name");
        builder.HasIndex(x => x.Name, "ui_product_catalog_category_name").IsUnique();
        builder.HasIndex(x => x.ParentProductCatalogCategoryID, "ix_product_catalog_category_parent");

        builder.HasOne(x => x.ParentProductCatalogCategory)
            .WithMany()
            .HasForeignKey(x => x.ParentProductCatalogCategoryID)
            .HasConstraintName("fk_product_catalog_category_parent");
    }
}
