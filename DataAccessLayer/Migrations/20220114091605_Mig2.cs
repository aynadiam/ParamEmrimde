using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kasas_Uyes_UyeId",
                schema: "pem",
                table: "Kasas");

            migrationBuilder.DropIndex(
                name: "IX_Kasas_UyeId",
                schema: "pem",
                table: "Kasas");

            migrationBuilder.DropColumn(
                name: "UyeId",
                schema: "pem",
                table: "Kasas");

            migrationBuilder.AddColumn<int>(
                name: "UyeId",
                schema: "pem",
                table: "Kats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kats_UyeId",
                schema: "pem",
                table: "Kats",
                column: "UyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kats_Uyes_UyeId",
                schema: "pem",
                table: "Kats",
                column: "UyeId",
                principalSchema: "pem",
                principalTable: "Uyes",
                principalColumn: "UyeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kats_Uyes_UyeId",
                schema: "pem",
                table: "Kats");

            migrationBuilder.DropIndex(
                name: "IX_Kats_UyeId",
                schema: "pem",
                table: "Kats");

            migrationBuilder.DropColumn(
                name: "UyeId",
                schema: "pem",
                table: "Kats");

            migrationBuilder.AddColumn<int>(
                name: "UyeId",
                schema: "pem",
                table: "Kasas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kasas_UyeId",
                schema: "pem",
                table: "Kasas",
                column: "UyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kasas_Uyes_UyeId",
                schema: "pem",
                table: "Kasas",
                column: "UyeId",
                principalSchema: "pem",
                principalTable: "Uyes",
                principalColumn: "UyeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
