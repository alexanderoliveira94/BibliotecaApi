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

        var livroExistente = await _context.Livros
            .FirstOrDefaultAsync(x => x.Titulo == livro.Titulo);

        if (livroExistente != null)
        {

            throw new InvalidOperationException("Já existe um livro deste em nosso registro.");
        }

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<bool> AtualizarLivro(int IdLivro, Livro livro)
    {
        if (IdLivro != livro.IdLivro)
            return false;

        _context.Entry(livro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LivroExists(IdLivro))
                return false;

            throw;
        }

        return true;
    }

    public async Task<bool> DeletarLivro(int IdLivro)
    {
        var livro = await _context.Livros.FindAsync(IdLivro);
        if (livro == null)
            return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();

        return true;
    }

    private bool LivroExists(int IdLivro)
    {
        return _context.Livros.Any(e => e.IdLivro == IdLivro);
    }
}