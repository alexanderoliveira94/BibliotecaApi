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

        public async Task<EmprestismoDeLivros> RealizarEmprestimo(int IdLivro, int IdUsuario)
        {
            try
            {
                var livro = await _context.Livros.FindAsync(IdLivro);

                Console.WriteLine($"ID Livro: {IdLivro}, ID Usuário: {IdUsuario}");

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
                    IdLivro = IdLivro,
                    IdUsuario = IdUsuario,
                    DataEmprestimo = DateTime.Now,
                    DataDevolucaoPrevista = DateTime.Now.AddDays(7),
                };

                _context.Emprestismos.Add(emprestimo);
                await _context.SaveChangesAsync();

                return emprestimo;
            }

            catch (Exception ex)
            {
                // Adicione logs para registrar exceções
                Console.WriteLine($"Erro ao realizar o empréstimo: {ex.Message}");
                throw; // Rejogue a exceção para manter o comportamento original
            }
        }

        public async Task<bool> RealizarDevolucao(int IdTransacao)
        {
            var emprestimo = await _context.Emprestismos.FindAsync(IdTransacao);

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