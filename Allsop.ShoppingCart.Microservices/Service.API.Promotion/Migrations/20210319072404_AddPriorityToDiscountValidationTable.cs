using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Promotion.Migrations
{
    public partial class AddPriorityToDiscountValidationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "DiscountValidation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "DiscountValidation");
        }
    }
}
