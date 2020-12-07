using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verificado",
                table: "CheckOutHistoricos");

            migrationBuilder.DropColumn(
                name: "VerificarSaida",
                table: "CheckOutHistoricos");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedIn",
                table: "CheckOutHistoricos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedOut",
                table: "CheckOutHistoricos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedIn",
                table: "CheckOutHistoricos");

            migrationBuilder.DropColumn(
                name: "CheckedOut",
                table: "CheckOutHistoricos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Verificado",
                table: "CheckOutHistoricos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificarSaida",
                table: "CheckOutHistoricos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
