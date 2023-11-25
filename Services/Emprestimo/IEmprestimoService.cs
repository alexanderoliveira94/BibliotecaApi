
using BibliotecaApi.Models;

namespace BibliotecaApi.Services.Emprestimo
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<EmprestismoDeLivros>> ObterTodosEmprestimos();
        Task<IEnumerable<EmprestismoDeLivros>> ObterEmprestimosPorUsuario(int IdUsuario);
        Task<EmprestismoDeLivros> RealizarEmprestimo(int IdLivro, int IdUsuario);
        Task<bool> RealizarDevolucao(int IdEmprestimo);
    }
}