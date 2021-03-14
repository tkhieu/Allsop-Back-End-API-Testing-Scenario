using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.API.Catalog.Migrations
{
    public partial class CreateCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                }, constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.UniqueConstraint("UQ_Category_Code", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
