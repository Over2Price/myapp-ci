using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posetitels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Familiya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datebirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posetitels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vistavkis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistavkis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bilets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posetitel = table.Column<int>(type: "int", nullable: true),
                    Vistavka = table.Column<int>(type: "int", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    PosetitelNavigationId = table.Column<int>(type: "int", nullable: true),
                    VistavkaNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bilets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bilets_posetitels_PosetitelNavigationId",
                        column: x => x.PosetitelNavigationId,
                        principalTable: "posetitels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_bilets_vistavkis_VistavkaNavigationId",
                        column: x => x.VistavkaNavigationId,
                        principalTable: "vistavkis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bilets_PosetitelNavigationId",
                table: "bilets",
                column: "PosetitelNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_bilets_VistavkaNavigationId",
                table: "bilets",
                column: "VistavkaNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bilets");

            migrationBuilder.DropTable(
                name: "posetitels");

            migrationBuilder.DropTable(
                name: "vistavkis");
        }
    }
}
