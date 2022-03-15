using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "KasaTutar",
                schema: "pem",
                table: "Kasas",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "KasaTutar",
                schema: "pem",
                table: "Kasas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
