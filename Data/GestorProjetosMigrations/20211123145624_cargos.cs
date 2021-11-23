using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoFinalProgInternet.Data.GestorProjetosMigrations
{
    public partial class cargos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cargo",
                table: "Cargo",
                newName: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cargo",
                newName: "cargo");
        }
    }
}
