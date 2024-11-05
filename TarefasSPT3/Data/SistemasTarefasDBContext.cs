using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Data.Map;
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
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
