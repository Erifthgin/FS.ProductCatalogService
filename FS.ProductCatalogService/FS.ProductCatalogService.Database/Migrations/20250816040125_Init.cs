using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS.ProductCatalogService.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_catalog_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    parent_product_catalog_category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_catalog_category", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_catalog_category_parent",
                        column: x => x.parent_product_catalog_category_id,
                        principalTable: "product_catalog_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_catalog_type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    product_catalog_category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_catalog_type", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_catalog_type_product_catalog_category",
                        column: x => x.product_catalog_category_id,
                        principalTable: "product_catalog_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    product_catalog_type_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_product_catalog_type",
                        column: x => x.product_catalog_type_id,
                        principalTable: "product_catalog_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ui_product_name",
                table: "product",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ui_product_product_catalog_type_id",
                table: "product",
                column: "product_catalog_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_catalog_category_parent",
                table: "product_catalog_category",
                column: "parent_product_catalog_category_id");

            migrationBuilder.CreateIndex(
                name: "ui_product_catalog_category_name",
                table: "product_catalog_category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_catalog_type_product_catalog_category",
                table: "product_catalog_type",
                column: "product_catalog_category_id");

            migrationBuilder.CreateIndex(
                name: "ui_product_catalog_type_name",
                table: "product_catalog_type",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "product_catalog_type");

            migrationBuilder.DropTable(
                name: "product_catalog_category");
        }
    }
}
