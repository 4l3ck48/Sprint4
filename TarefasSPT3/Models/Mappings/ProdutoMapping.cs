using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Models;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>(entity =>
        {
            // Define o nome da tabela no banco de dados
            entity.ToTable("Produto");

            // Define a chave primária
            entity.HasKey(e => e.Id_produto);

            // Mapeia a propriedade Id_produto para a coluna "Id_produto"
            entity.Property(e => e.Id_produto)
                .HasColumnName("Id_produto");

            // Mapeia a propriedade Nome para a coluna "NM_PRODUTO"
            entity.Property(e => e.Nome)
                .HasColumnName("NM_PRODUTO")
                .HasColumnType("varchar(40)")
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("O nome do produto deve conter no máximo 40 caracteres.");

            // Mapeia a propriedade Preco para a coluna "VL_PRECO"
            entity.Property(e => e.Preco)
                .HasColumnName("VL_PRECO")
                .HasColumnType("number(4,2)")
                .IsRequired()
                .HasComment("O preço deve estar entre 1 e 99.");

            // Mapeia a propriedade Descricao para a coluna "DS_DESCRICAO"
            entity.Property(e => e.Descricao)
                .HasColumnName("DS_DESCRICAO")
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("A descrição deve conter no máximo 100 caracteres.");

            // Configura o relacionamento 1 para N com a entidade Usuario
            entity.HasOne(e => e.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(e => e.Id_usuario)
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão
        });

        // Configuração adicional para outras entidades, se necessário
    }
}
