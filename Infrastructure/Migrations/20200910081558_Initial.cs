using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    title = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ingredients = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true),
                    grams = table.Column<int>(nullable: true),
                    calories = table.Column<decimal>(type: "numeric(5, 4)", nullable: true),
                    cooking_time = table.Column<int>(nullable: true)
                },
                constraints: table => 
                {
                    table.PrimaryKey("PK_MenuItem", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__MenuItem__E52A1BB3DCEEF5D2",
                table: "MenuItem",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");
        }
    }
}
