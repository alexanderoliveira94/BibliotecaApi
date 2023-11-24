using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;


namespace BibliotecaApi.Data
{

    public class DataContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EmprestismoDeLivros> Emprestismos { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro);

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

            });

           
            modelBuilder.Entity<EmprestismoDeLivros>(entity =>
                {
                    entity.HasKey(e => e.IdTransacao);
                    entity.Property(e => e.DataEmprestimo).IsRequired();
                    entity.Property(e => e.DataDevolucaoPrevista).IsRequired();
                    entity.ToTable("EmprestismoDeLivros");
                    
                });

        }
    }
}
