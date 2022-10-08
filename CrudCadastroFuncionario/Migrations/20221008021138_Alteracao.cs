using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCadastroFuncionario.Migrations
{
    public partial class Alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FucnionarioId",
                table: "Funcionario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Endereco",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Funcionario",
                newName: "FucnionarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Endereco",
                newName: "EnderecoId");
        }
    }
}
