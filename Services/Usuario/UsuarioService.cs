using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaApi.Data;
using BibliotecaApi.Models;

public class UsuarioService : IUsuarioService
{
    private readonly DataContext _context;

    public UsuarioService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> ObterUsuarioPorId(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> AdicionarUsuario(Usuario usuario)
    {
        try
        {
            if (_context.Usuarios.Any(u => u.NomeUsuario == usuario.NomeUsuario))
            {
                throw new InvalidOperationException("Usuário já cadastrado.");
            }

            usuario.DataRegistro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao adicionar usuário: {ex.Message}");
            throw;
        }
    }


    public async Task<bool> AtualizarUsuario(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
            return false;

        _context.Entry(usuario).State = EntityState.Modified;

        if (_context.Usuarios.Any(u => u.NomeUsuario == usuario.NomeUsuario))
            {
                throw new InvalidOperationException("Usuário já cadastrado.");
            }
            
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
                return false;

            throw;
        }

        return true;
    }

    public async Task<bool> DeletarUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return true;
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.IdUsuario == id);
    }
}