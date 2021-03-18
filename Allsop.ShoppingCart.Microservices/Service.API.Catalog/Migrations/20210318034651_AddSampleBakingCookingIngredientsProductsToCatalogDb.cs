using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Catalog.Migrations
{
    public partial class  AddSampleBakingCookingIngredientsProductsToCatalogDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "5e0b02d5-a25f-4617-9215-3c646f9b4ae8", "3786f39a-a229-4689-aed7-d851082cd87a", 4, "Plain Flour", null, "10 x 1kg", "GBP", 6.21m, "CI-000001" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "b0ad84dc-1df9-4e84-970e-d6e49dee87f3", "3786f39a-a229-4689-aed7-d851082cd87a", 6, "Icing Sugar", null, "12 x 500g", "GBP", 9.38m, "CI-000002" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "89090eed-5f8d-44bd-ac60-af45256c92ec", "3786f39a-a229-4689-aed7-d851082cd87a", 9, "Free-Range Eggs", null, "10 x 12 each", "GBP", 9.52m, "CI-000003" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "e337af6b-c746-4d04-9dac-f57cc52a6158", "3786f39a-a229-4689-aed7-d851082cd87a", 13, "Caster Sugar", null, "16 x 750g", "GBP", 12.76m, "CI-000004" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5e0b02d5-a25f-4617-9215-3c646f9b4ae8");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "89090eed-5f8d-44bd-ac60-af45256c92ec");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b0ad84dc-1df9-4e84-970e-d6e49dee87f3");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "e337af6b-c746-4d04-9dac-f57cc52a6158");
        }
    }
}
