using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoFinalProgInternet.Data.GestorProjetosMigrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataPrevista",
                table: "Projeto",
                newName: "DataInicialPrevista");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Projeto",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "Projeto",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinalPrevista",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinalPrevista",
                table: "Projeto");

            migrationBuilder.RenameColumn(
                name: "DataInicialPrevista",
                table: "Projeto",
                newName: "DataPrevista");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
