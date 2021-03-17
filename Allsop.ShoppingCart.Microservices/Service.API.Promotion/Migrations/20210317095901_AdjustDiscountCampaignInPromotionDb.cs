using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Promotion.Migrations
{
    public partial class AdjustDiscountCampaignInPromotionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyOn",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "CampaignType",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "DiscountUnit",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "DiscountCampaigns");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "DiscountCampaigns");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "DiscountCampaigns",
                newName: "DiscountCampaignType");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountValue",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCampaignApplyOn",
                table: "DiscountCampaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCampaignApplyOn",
                table: "DiscountCampaigns");

            migrationBuilder.RenameColumn(
                name: "DiscountCampaignType",
                table: "DiscountCampaigns",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountValue",
                table: "DiscountCampaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplyOn",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignType",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscountUnit",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "DiscountCampaigns",
                type: "TEXT",
                nullable: true);
        }
    }
}
