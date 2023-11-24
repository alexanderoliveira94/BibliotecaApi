using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Models;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ObterTodosUsuarios();
    Task<Usuario> ObterUsuarioPorId(int id);
    Task<Usuario> AdicionarUsuario(Usuario usuario);
    Task<bool> AtualizarUsuario(int id, Usuario usuario);
    Task<bool> DeletarUsuario(int id);
}
