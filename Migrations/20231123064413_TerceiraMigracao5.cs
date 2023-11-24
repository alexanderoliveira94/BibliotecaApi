using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class TerceiraMigracao5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprestimo",
                table: "Emprestimo");

            migrationBuilder.RenameTable(
                name: "Emprestimo",
                newName: "EmprestismoDeLivros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmprestismoDeLivros",
                table: "EmprestismoDeLivros",
                column: "IdTransacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmprestismoDeLivros",
                table: "EmprestismoDeLivros");

            migrationBuilder.RenameTable(
                name: "EmprestismoDeLivros",
                newName: "Emprestimo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprestimo",
                table: "Emprestimo",
                column: "IdTransacao");
        }
    }
}
