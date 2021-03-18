using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Catalog.Migrations
{
    public partial class AddMoreSampleProductsToCatalogDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "74ae8b23-2e53-4fb2-a4a8-143a79d7c3a5", "5beff28e-bba2-4b1b-9f06-126d6365d4cf", 8, "Whole Free-Range Turkey", 48.25m, "1 x 16-18lbs", "GBP", 43.20m, "MP-000003" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "cab06749-c2ed-4671-992a-939f95dc41e6", "fd6055d7-08a3-4351-8195-7da47e50f028", 0, "Granny Smith Apples", null, "4 x 16 each", "GBP", 3.75m, "FV-000002" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "b81fe919-e701-4f11-b776-c57eda4cb321", "fd6055d7-08a3-4351-8195-7da47e50f028", 2, "Loose Carrots", null, "4 x 20 each", "GBP", 2.67m, "FV-000003" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "a1821ad4-1821-4080-ae73-93359d9df11e", "fd6055d7-08a3-4351-8195-7da47e50f028", 8, "Mandarin Oranges", null, "6 x 10 x 12", "GBP", 12.23m, "FV-000004" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "8a7af7e8-b644-4abe-aea7-bd869f116d8b", "bae52764-af07-4043-8586-52816594ee86", 4, "Mars Bar", null, "6 x 24 x 50g", "GBP", 42.82m, "CD-000001" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "f761a566-37b6-43a2-84cb-e9a36ab42f33", "bae52764-af07-4043-8586-52816594ee86", 6, "Peppermint Chewing Gum", null, "6 x 50 x 30g", "GBP", 35.70m, "CD-000002" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "16aab369-9e83-49a4-9832-f85b295c58f6", "bae52764-af07-4043-8586-52816594ee86", 0, "Strawberry Cheesecake,", null, "4 x 12 portions", "GBP", 8.52m, "CD-000003" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "00f5a6e8-7440-44ae-af92-3e3f04e5ca9d", "bae52764-af07-4043-8586-52816594ee86", 2, "Vanilla Ice Cream", null, "6 x 4L", "GBP", 3.80m, "CD-000004" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "3a8af515-a1cc-454a-99f2-fcdaef554d6c", "b5901197-4899-4a22-ad39-7f1f4cdcb84b", 19, "Kitchen Roll", null, "100 x 300 sheets", "GBP", 43.92m, "MI-000001" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InventoryQuantity", "Name", "OldPriceValue", "Packaging", "PriceUnit", "PriceValue", "Sku" },
                values: new object[] { "4bc78c44-14c7-46a5-a877-12debfdd65b5", "b5901197-4899-4a22-ad39-7f1f4cdcb84b", 7, "Paper Plates", null, "10 x 200 each", "GBP", 16.19m, "MI-000002" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "00f5a6e8-7440-44ae-af92-3e3f04e5ca9d");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "16aab369-9e83-49a4-9832-f85b295c58f6");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3a8af515-a1cc-454a-99f2-fcdaef554d6c");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4bc78c44-14c7-46a5-a877-12debfdd65b5");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "74ae8b23-2e53-4fb2-a4a8-143a79d7c3a5");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8a7af7e8-b644-4abe-aea7-bd869f116d8b");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "a1821ad4-1821-4080-ae73-93359d9df11e");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b81fe919-e701-4f11-b776-c57eda4cb321");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "cab06749-c2ed-4671-992a-939f95dc41e6");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f761a566-37b6-43a2-84cb-e9a36ab42f33");
        }
    }
}
