using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Promotion.Migrations
{
    public partial class AdjustDiscountValidationInPromotionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DiscountValidation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DiscountValidation");

            migrationBuilder.DropColumn(
                name: "Rule",
                table: "DiscountValidation");

            migrationBuilder.AlterColumn<int>(
                name: "ValueType",
                table: "DiscountValidation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Operator",
                table: "DiscountValidation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "DiscountValidation",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "DiscountValidation",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DiscountValidation",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DiscountValidation",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rule",
                table: "DiscountValidation",
                type: "TEXT",
                nullable: true);
        }
    }
}
