using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoFinalProgInternet.Data.GestorProjetosMigrations
{
    public partial class colaboradortarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId1",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ColaboradorId",
                table: "Tarefa",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_ColaboradorId1",
                table: "Colaborador",
                column: "ColaboradorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Colaborador_ColaboradorId1",
                table: "Colaborador",
                column: "ColaboradorId1",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Colaborador_ColaboradorId",
                table: "Tarefa",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Colaborador_ColaboradorId1",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Colaborador_ColaboradorId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ColaboradorId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_ColaboradorId1",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ColaboradorId1",
                table: "Colaborador");
        }
    }
}
