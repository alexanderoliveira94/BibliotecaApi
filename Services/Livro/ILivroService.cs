using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Models;

public interface ILivroService
{
    Task<IEnumerable<Livro>> ObterTodosLivros();
    Task<Livro> ObterLivroPorId(int id);
    Task<IEnumerable<Livro>> BuscarLivros(string termoBusca);
    Task<Livro> AdicionarLivro(Livro livro);
    Task<bool> AtualizarLivro(int id, Livro livro);
    Task<bool> DeletarLivro(int id);
}
