using BibliotecaApi.Data;
using BibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Services.Emprestimo
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly DataContext _context;

        public EmprestimoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmprestismoDeLivros>> ObterTodosEmprestimos()
        {
            return await _context.Emprestismos.ToListAsync();
        }

        public async Task<IEnumerable<EmprestismoDeLivros>> ObterEmprestimosPorUsuario(int idUsuario)
        {
            return await _context.Emprestismos
                .Where(e => e.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public async Task<EmprestismoDeLivros> RealizarEmprestimo(int idLivro, int idUsuario)
        {
            var livro = await _context.Livros.FindAsync(idLivro);

            if (livro == null)
            {

                throw new InvalidOperationException("Livro não Existe Cadastrado.");
            }

            if (!livro.EstaDisponivel)
            {

                throw new InvalidOperationException("Livro não está disponível para empréstimo.");
            }


            livro.EstaDisponivel = false;

            var emprestimo = new EmprestismoDeLivros
            {
                IdLivro = idLivro,
                IdUsuario = idUsuario,
                DataEmprestimo = DateTime.Now,
                DataDevolucaoPrevista = DateTime.Now.AddDays(7),
            };

            _context.Emprestismos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<bool> RealizarDevolucao(int idTransacao)
        {
            var emprestimo = await _context.Emprestismos.FindAsync(idTransacao);

            if (emprestimo == null || emprestimo.DataDevolucaoRealizada.HasValue)
            {
                
                return false;
            }

            emprestimo.DataDevolucaoRealizada = DateTime.Now;

            var livro = await _context.Livros.FindAsync(emprestimo.IdLivro);
            if (livro != null)
            {
                livro.EstaDisponivel = true;
            }

            await _context.SaveChangesAsync();

            return true;
        }

    }

}