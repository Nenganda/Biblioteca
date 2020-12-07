using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificarHistoricos");

            migrationBuilder.DropTable(
                name: "VerificarSaidas");

            migrationBuilder.CreateTable(
                name: "CheckOutHistoricos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaAtivoId = table.Column<int>(nullable: false),
                    BibliotecaCartaoId = table.Column<int>(nullable: false),
                    VerificarSaida = table.Column<DateTime>(nullable: false),
                    Verificado = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutHistoricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOutHistoricos_BibliotecaAtivos_BibliotecaAtivoId",
                        column: x => x.BibliotecaAtivoId,
                        principalTable: "BibliotecaAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckOutHistoricos_BibliotecaCartaos_BibliotecaCartaoId",
                        column: x => x.BibliotecaCartaoId,
                        principalTable: "BibliotecaCartaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckOuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaAtivoId = table.Column<int>(nullable: true),
                    BibliotecaCartaoId = table.Column<int>(nullable: true),
                    Desde = table.Column<DateTime>(nullable: false),
                    Ate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOuts_BibliotecaAtivos_BibliotecaAtivoId",
                        column: x => x.BibliotecaAtivoId,
                        principalTable: "BibliotecaAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOuts_BibliotecaCartaos_BibliotecaCartaoId",
                        column: x => x.BibliotecaCartaoId,
                        principalTable: "BibliotecaCartaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutHistoricos_BibliotecaAtivoId",
                table: "CheckOutHistoricos",
                column: "BibliotecaAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutHistoricos_BibliotecaCartaoId",
                table: "CheckOutHistoricos",
                column: "BibliotecaCartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_BibliotecaAtivoId",
                table: "CheckOuts",
                column: "BibliotecaAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_BibliotecaCartaoId",
                table: "CheckOuts",
                column: "BibliotecaCartaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckOutHistoricos");

            migrationBuilder.DropTable(
                name: "CheckOuts");

            migrationBuilder.CreateTable(
                name: "VerificarHistoricos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaAtivoId = table.Column<int>(type: "int", nullable: false),
                    BibliotecaCartaoId = table.Column<int>(type: "int", nullable: false),
                    Verificado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerificarSaida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificarHistoricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificarHistoricos_BibliotecaAtivos_BibliotecaAtivoId",
                        column: x => x.BibliotecaAtivoId,
                        principalTable: "BibliotecaAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificarHistoricos_BibliotecaCartaos_BibliotecaCartaoId",
                        column: x => x.BibliotecaCartaoId,
                        principalTable: "BibliotecaCartaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificarSaidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BibliotecaAtivoId = table.Column<int>(type: "int", nullable: true),
                    BibliotecaCartaoId = table.Column<int>(type: "int", nullable: true),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificarSaidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificarSaidas_BibliotecaAtivos_BibliotecaAtivoId",
                        column: x => x.BibliotecaAtivoId,
                        principalTable: "BibliotecaAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VerificarSaidas_BibliotecaCartaos_BibliotecaCartaoId",
                        column: x => x.BibliotecaCartaoId,
                        principalTable: "BibliotecaCartaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerificarHistoricos_BibliotecaAtivoId",
                table: "VerificarHistoricos",
                column: "BibliotecaAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificarHistoricos_BibliotecaCartaoId",
                table: "VerificarHistoricos",
                column: "BibliotecaCartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificarSaidas_BibliotecaAtivoId",
                table: "VerificarSaidas",
                column: "BibliotecaAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificarSaidas_BibliotecaCartaoId",
                table: "VerificarSaidas",
                column: "BibliotecaCartaoId");
        }
    }
}
