using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Promotion.Migrations
{
    public partial class AdjustDiscountCodeInPromotionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "DiscountCodes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DiscountCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DiscountCodes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "DiscountCodes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DiscountCodes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "DiscountCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "DiscountCodes",
                type: "TEXT",
                nullable: true);
        }
    }
}
