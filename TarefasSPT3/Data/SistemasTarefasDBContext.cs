// Data/SistemasTarefasDBContext.cs
using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Models;

namespace TarefasSPT3.Data
{
    public class SistemasTarefasDBContext : DbContext
    {
        public SistemasTarefasDBContext(DbContextOptions<SistemasTarefasDBContext> options)
            : base(options)
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações Fluent API podem ser adicionadas aqui se necessário
            base.OnModelCreating(modelBuilder);
        }
    }
}