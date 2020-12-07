using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BibliotecaCartaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Honorarios = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataEmissaoCartao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotecaCartaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BibliotecaFilias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: true),
                    Dataabertura = table.Column<DateTime>(nullable: false),
                    ImagemUrl = table.Column<string>(type: "varchar(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotecaFilias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAtivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAtivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilialHoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilialId = table.Column<int>(nullable: true),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    HoradeAbertura = table.Column<int>(nullable: false),
                    HoraDeFechar = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilialHoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilialHoras_BibliotecaFilias_FilialId",
                        column: x => x.FilialId,
                        principalTable: "BibliotecaFilias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patronos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    SobreNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: true),
                    Genero = table.Column<string>(type: "varchar(15)", nullable: true),
                    BibliotecaCartaoId = table.Column<int>(nullable: false),
                    BibliotecaFilialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patronos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patronos_BibliotecaCartaos_BibliotecaCartaoId",
                        column: x => x.BibliotecaCartaoId,
                        principalTable: "BibliotecaCartaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patronos_BibliotecaFilias_BibliotecaFilialId",
                        column: x => x.BibliotecaFilialId,
                        principalTable: "BibliotecaFilias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BibliotecaAtivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    EstatoId = table.Column<int>(nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "varchar(120)", nullable: true),
                    NumeroDeCopia = table.Column<int>(nullable: false),
                    LocalizacaoId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(type: "varchar(15)", nullable: true),
                    Autor = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeweyIndex = table.Column<string>(type: "varchar(15)", nullable: true),
                    Diretor = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotecaAtivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibliotecaAtivos_Estatos_EstatoId",
                        column: x => x.EstatoId,
                        principalTable: "Estatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibliotecaAtivos_BibliotecaFilias_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "BibliotecaFilias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Esperas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaAtivoId = table.Column<int>(nullable: true),
                    BibliotecaCartaoId = table.Column<int>(nullable: true),
                    DataEspera = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esperas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Esperas_BibliotecaAtivos_BibliotecaAtivoId",
                        column: x => x.BibliotecaAtivoId,
                        principalTable: "BibliotecaAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Esperas_BibliotecaCartaos_BibliotecaCartaoId",
                        column: x => x.BibliotecaCartaoId,
                        principalTable: "BibliotecaCartaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VerificarHistoricos",
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaAtivoId = table.Column<int>(nullable: true),
                    BibliotecaCartaoId = table.Column<int>(nullable: true),
                    Desde = table.Column<DateTime>(nullable: false),
                    Ate = table.Column<DateTime>(nullable: false)
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
                name: "IX_BibliotecaAtivos_EstatoId",
                table: "BibliotecaAtivos",
                column: "EstatoId");

            migrationBuilder.CreateIndex(
                name: "IX_BibliotecaAtivos_LocalizacaoId",
                table: "BibliotecaAtivos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Esperas_BibliotecaAtivoId",
                table: "Esperas",
                column: "BibliotecaAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Esperas_BibliotecaCartaoId",
                table: "Esperas",
                column: "BibliotecaCartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialHoras_FilialId",
                table: "FilialHoras",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Patronos_BibliotecaCartaoId",
                table: "Patronos",
                column: "BibliotecaCartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Patronos_BibliotecaFilialId",
                table: "Patronos",
                column: "BibliotecaFilialId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Esperas");

            migrationBuilder.DropTable(
                name: "FilialHoras");

            migrationBuilder.DropTable(
                name: "Patronos");

            migrationBuilder.DropTable(
                name: "TipoAtivos");

            migrationBuilder.DropTable(
                name: "VerificarHistoricos");

            migrationBuilder.DropTable(
                name: "VerificarSaidas");

            migrationBuilder.DropTable(
                name: "BibliotecaAtivos");

            migrationBuilder.DropTable(
                name: "BibliotecaCartaos");

            migrationBuilder.DropTable(
                name: "Estatos");

            migrationBuilder.DropTable(
                name: "BibliotecaFilias");
        }
    }
}
