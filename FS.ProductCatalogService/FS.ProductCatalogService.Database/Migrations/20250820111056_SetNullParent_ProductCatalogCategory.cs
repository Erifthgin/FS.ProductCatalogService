using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS.ProductCatalogService.Database.Migrations
{
    /// <inheritdoc />
    public partial class SetNullParent_ProductCatalogCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_catalog_category_parent",
                table: "product_catalog_category");

            migrationBuilder.AlterColumn<Guid>(
                name: "parent_product_catalog_category_id",
                table: "product_catalog_category",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_product_catalog_category_parent",
                table: "product_catalog_category",
                column: "parent_product_catalog_category_id",
                principalTable: "product_catalog_category",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_catalog_category_parent",
                table: "product_catalog_category");

            migrationBuilder.AlterColumn<Guid>(
                name: "parent_product_catalog_category_id",
                table: "product_catalog_category",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_product_catalog_category_parent",
                table: "product_catalog_category",
                column: "parent_product_catalog_category_id",
                principalTable: "product_catalog_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
