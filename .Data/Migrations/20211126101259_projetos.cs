using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoFinalProgInternet.Data.Migrations
{
    public partial class projetos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProjeto_Colaborador_ColaboradorId",
                table: "ColaboradorProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProjeto_Projeto_ProjetoId",
                table: "ColaboradorProjeto");

            migrationBuilder.DropColumn(
                name: "DataDeFim",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "DataDeInicio",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "DataPrevista",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "Gestor",
                table: "Projeto");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ColaboradorId",
                table: "Projeto",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_TarefaProjetos_ProjetoId",
                table: "TarefaProjetos",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProjeto_Colaborador_ColaboradorId",
                table: "ColaboradorProjeto",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProjeto_Projeto_ProjetoId",
                table: "ColaboradorProjeto",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Colaborador_ColaboradorId",
                table: "Projeto",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Projeto_ProjetoId",
                table: "Tarefa",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProjeto_Colaborador_ColaboradorId",
                table: "ColaboradorProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProjeto_Projeto_ProjetoId",
                table: "ColaboradorProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Colaborador_ColaboradorId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Projeto_ProjetoId",
                table: "Tarefa");

            migrationBuilder.DropTable(
                name: "TarefaProjetos");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_ColaboradorId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Projeto");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeFim",
                table: "Tarefa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeInicio",
                table: "Tarefa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevista",
                table: "Tarefa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gestor",
                table: "Projeto",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProjeto_Colaborador_ColaboradorId",
                table: "ColaboradorProjeto",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProjeto_Projeto_ProjetoId",
                table: "ColaboradorProjeto",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Projeto_ProjetoId",
                table: "Tarefa",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
