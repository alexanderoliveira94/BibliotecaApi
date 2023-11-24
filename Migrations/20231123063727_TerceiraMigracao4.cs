using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class TerceiraMigracao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprestimos",
                table: "Emprestimos");

            migrationBuilder.RenameTable(
                name: "Emprestimos",
                newName: "Emprestimo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprestimo",
                table: "Emprestimo",
                column: "IdTransacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprestimo",
                table: "Emprestimo");

            migrationBuilder.RenameTable(
                name: "Emprestimo",
                newName: "Emprestimos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprestimos",
                table: "Emprestimos",
                column: "IdTransacao");
        }
    }
}
