using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AlteredCalories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<decimal>(
                name: "calories",
                table: "MenuItem",
                nullable: true,
                oldNullable: true,
                oldType: "numeric(5, 4)",
                type: "numeric(8, 2)"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "calories",
                table: "MenuItem",
                nullable: true,
                oldNullable: true,
                oldType: "numeric(8, 2)",
                type: "numeric(5, 4)"
            );
        }
    }
}
