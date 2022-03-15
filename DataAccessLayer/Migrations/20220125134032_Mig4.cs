using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KasaTutarDolar",
                schema: "pem",
                table: "Kasas",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KasaTutarEuro",
                schema: "pem",
                table: "Kasas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KasaTutarDolar",
                schema: "pem",
                table: "Kasas");

            migrationBuilder.DropColumn(
                name: "KasaTutarEuro",
                schema: "pem",
                table: "Kasas");
        }
    }
}
