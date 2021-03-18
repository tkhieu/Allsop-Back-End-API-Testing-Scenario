using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Catalog.Migrations
{
    public partial class SeedingProductsBatch01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OldPriceValue",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "48d5553e-a450-4523-a143-73263766b62b", "5beff28e-bba2-4b1b-9f06-126d6365d4cf", 12, "Chicken Fillets", null, "6 x 100g", "GBP", 4.50m, "MP-000001" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "e547f80c-55ff-4541-81e7-d84f55cfdae2", "5beff28e-bba2-4b1b-9f06-126d6365d4cf", 6, "Sirloin Steaks", null, "4 x 6-8oz", "GBP", 45.70m, "MP-000002" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "34f98921-e46a-4937-872b-e2c57e705f3f", "fd6055d7-08a3-4351-8195-7da47e50f028", 5, "Cauliflower Florets", 6.75m, "10 x 500g", "GBP", 5.00m, "FV-000001" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "34f98921-e46a-4937-872b-e2c57e705f3f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "48d5553e-a450-4523-a143-73263766b62b");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "e547f80c-55ff-4541-81e7-d84f55cfdae2");

            migrationBuilder.AlterColumn<decimal>(
                name: "OldPriceValue",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
