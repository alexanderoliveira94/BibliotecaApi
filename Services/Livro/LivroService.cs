using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaApi.Models;
using BibliotecaApi.Data;

public class LivroService : ILivroService
{
    private readonly DataContext _context;

    public LivroService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Livro>> ObterTodosLivros()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<Livro> ObterLivroPorId(int id)
    {
        return await _context.Livros.FindAsync(id);
    }

    public async Task<IEnumerable<Livro>> BuscarLivros(string termoBusca)
    {
        return await _context.Livros
            .Where(livro =>
                livro.Titulo.Contains(termoBusca) ||
                livro.Autor.Contains(termoBusca) ||
                livro.Categoria.Contains(termoBusca))
            .ToListAsync();
    }

    public async Task<Livro> AdicionarLivro(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<bool> AtualizarLivro(int id, Livro livro)
    {
        if (id != livro.IdLivro)
            return false;

        _context.Entry(livro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LivroExists(id))
                return false;

            throw;
        }

        return true;
    }

    public async Task<bool> DeletarLivro(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null)
            return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();

        return true;
    }

    private bool LivroExists(int id)
    {
        return _context.Livros.Any(e => e.IdLivro == id);
    }
}