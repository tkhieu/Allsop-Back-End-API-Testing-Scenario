using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Promotion.Migrations
{
    public partial class AddMaxRedeemToDiscountCodeInPromotionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxRedeem",
                table: "DiscountCodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxRedeem",
                table: "DiscountCodes");
        }
    }
}
