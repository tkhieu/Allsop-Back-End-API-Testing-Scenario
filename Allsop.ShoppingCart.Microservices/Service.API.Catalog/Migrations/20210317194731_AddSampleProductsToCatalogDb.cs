using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Catalog.Migrations
{
    public partial class AddSampleProductsToCatalogDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "77e63e97-b41a-4882-9574-52a3738fd93f", "737c9710-e069-436a-a236-660e8277dedf", 6, "Coca-Cola", 8.50m, "6 x 2L", "GBP", 8.30m, "DR-000001" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "d2fb685f-86dd-47ac-bb23-8ffd8ce84941", "737c9710-e069-436a-a236-660e8277dedf", 9, "Still Mineral Water", null, "6 x 24 x 500ml", "GBP", 21.75m, "DR-000002" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "bf7b5f89-a569-4e3d-acb8-04a07e1e1130", "737c9710-e069-436a-a236-660e8277dedf", 16, "Sparkling Mineral Water", null, "6 x 24 x 500ml", "GBP", 25.83m, "DR-000003" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "77e63e97-b41a-4882-9574-52a3738fd93f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "bf7b5f89-a569-4e3d-acb8-04a07e1e1130");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d2fb685f-86dd-47ac-bb23-8ffd8ce84941");
        }
    }
}
