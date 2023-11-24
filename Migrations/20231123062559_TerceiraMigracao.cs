using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class TerceiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoDeEmprestimo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmprestismoDeLivros",
                table: "EmprestismoDeLivros");

            migrationBuilder.RenameTable(
                name: "EmprestismoDeLivros",
                newName: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "DataDevolucao",
                table: "Emprestimos",
                newName: "DataDevolucaoRealizada");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprestimos",
                table: "Emprestimos",
                column: "IdTransacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprestimos",
                table: "Emprestimos");

            migrationBuilder.RenameTable(
                name: "Emprestimos",
                newName: "EmprestismoDeLivros");

            migrationBuilder.RenameColumn(
                name: "DataDevolucaoRealizada",
                table: "EmprestismoDeLivros",
                newName: "DataDevolucao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmprestismoDeLivros",
                table: "EmprestismoDeLivros",
                column: "IdTransacao");

            migrationBuilder.CreateTable(
                name: "HistoricoDeEmprestimo",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoricoEmprestimoIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDeEmprestimo", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_HistoricoDeEmprestimo_HistoricoDeEmprestimo_HistoricoEmprestimoIdUsuario",
                        column: x => x.HistoricoEmprestimoIdUsuario,
                        principalTable: "HistoricoDeEmprestimo",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDeEmprestimo_HistoricoEmprestimoIdUsuario",
                table: "HistoricoDeEmprestimo",
                column: "HistoricoEmprestimoIdUsuario");
        }
    }
}
