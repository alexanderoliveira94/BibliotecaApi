
using BibliotecaApi.Models;

namespace BibliotecaApi.Services.Emprestimo
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<EmprestismoDeLivros>> ObterTodosEmprestimos();
        Task<IEnumerable<EmprestismoDeLivros>> ObterEmprestimosPorUsuario(int idUsuario);
        Task<EmprestismoDeLivros> RealizarEmprestimo(int idLivro, int idUsuario);
        Task<bool> RealizarDevolucao(int idEmprestimo);
    }
}