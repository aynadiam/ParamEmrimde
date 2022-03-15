using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pem");

            migrationBuilder.CreateTable(
                name: "Kalems",
                schema: "pem",
                columns: table => new
                {
                    KalemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalemAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalems", x => x.KalemId);
                });

            migrationBuilder.CreateTable(
                name: "Uyes",
                schema: "pem",
                columns: table => new
                {
                    UyeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeEposta = table.Column<string>(nullable: true),
                    UyeSifre = table.Column<string>(nullable: true),
                    UyeAdi = table.Column<string>(nullable: true),
                    UyeSoyadi = table.Column<string>(nullable: true),
                    UyeOnay = table.Column<bool>(nullable: false),
                    UyeSil = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyes", x => x.UyeId);
                });

            migrationBuilder.CreateTable(
                name: "Kats",
                schema: "pem",
                columns: table => new
                {
                    KatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KatAdi = table.Column<string>(nullable: true),
                    KalemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kats", x => x.KatId);
                    table.ForeignKey(
                        name: "FK_Kats_Kalems_KalemId",
                        column: x => x.KalemId,
                        principalSchema: "pem",
                        principalTable: "Kalems",
                        principalColumn: "KalemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kasas",
                schema: "pem",
                columns: table => new
                {
                    KasaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaTutar = table.Column<double>(nullable: false),
                    KasaTarih = table.Column<DateTime>(nullable: false),
                    KasaAciklama = table.Column<string>(nullable: true),
                    KasaBorcOde = table.Column<bool>(nullable: false),
                    KasaKrediKarti = table.Column<bool>(nullable: false),
                    KatId = table.Column<int>(nullable: false),
                    UyeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasas", x => x.KasaId);
                    table.ForeignKey(
                        name: "FK_Kasas_Kats_KatId",
                        column: x => x.KatId,
                        principalSchema: "pem",
                        principalTable: "Kats",
                        principalColumn: "KatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kasas_Uyes_UyeId",
                        column: x => x.UyeId,
                        principalSchema: "pem",
                        principalTable: "Uyes",
                        principalColumn: "UyeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kasas_KatId",
                schema: "pem",
                table: "Kasas",
                column: "KatId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasas_UyeId",
                schema: "pem",
                table: "Kasas",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kats_KalemId",
                schema: "pem",
                table: "Kats",
                column: "KalemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kasas",
                schema: "pem");

            migrationBuilder.DropTable(
                name: "Kats",
                schema: "pem");

            migrationBuilder.DropTable(
                name: "Uyes",
                schema: "pem");

            migrationBuilder.DropTable(
                name: "Kalems",
                schema: "pem");
        }
    }
}
