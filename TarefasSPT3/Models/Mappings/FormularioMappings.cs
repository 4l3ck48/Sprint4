using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Models;

public class AppDbContext : DbContext
{
    public DbSet<Formulario> Formularios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.ToTable("Formulario"); // Define o nome da tabela no banco de dados

            // Define a chave primária
            entity.HasKey(e => e.Id_formulario);

            // Mapeia a propriedade Id_formulario para a coluna "Id_formulario"
            entity.Property(e => e.Id_formulario)
                .HasColumnName("Id_formulario");

            // Mapeia a propriedade StatusAlergia para a coluna "ST_ALERGIA"
            entity.Property(e => e.StatusAlergia)
                .HasColumnName("ST_ALERGIA")
                .HasColumnType("char(1)")
                .IsRequired();

            // Mapeia a propriedade DescricaoAlergia para a coluna "DS_ALERGIA"
            entity.Property(e => e.DescricaoAlergia)
                .HasColumnName("DS_ALERGIA")
                .HasColumnType("char(200)")
                .IsRequired();

            // Mapeia a propriedade DescricaoPele para a coluna "DS_PELE"
            entity.Property(e => e.DescricaoPele)
                .HasColumnName("DS_PELE")
                .HasColumnType("char(20)")
                .IsRequired();

            // Configura o relacionamento 1 para 1 com a entidade Usuario
            entity.HasOne(e => e.Usuario)
                .WithOne()
                .HasForeignKey<Formulario>(e => e.Id_usuario)
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão
        });

        // Configuração adicional para outras entidades, se necessário
    }
}
