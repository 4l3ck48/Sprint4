using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Models;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            // Define o nome da tabela no banco de dados
            entity.ToTable("Usuario");

            // Define a chave primária
            entity.HasKey(e => e.Id_usuario);

            // Mapeia a propriedade Nome para a coluna "NM_NOME"
            entity.Property(e => e.Nome)
                .HasColumnName("NM_NOME")
                .HasColumnType("varchar(50)")
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("O nome deve conter no máximo 50 caracteres.");

            // Mapeia a propriedade Email para a coluna "DS_EMAIL"
            entity.Property(e => e.Email)
                .HasColumnName("DS_EMAIL")
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("O email deve conter no máximo 100 caracteres.");

            // Mapeia a propriedade Cpf para a coluna "NR_CPF"
            entity.Property(e => e.Cpf)
                .HasColumnName("NR_CPF")
                .HasColumnType("number(12)")
                .IsRequired()
                .HasComment("O CPF deve estar entre 100000000000 e 999999999999.");

            // Mapeia a propriedade Senha para a coluna "DS_SENHA"
            entity.Property(e => e.Senha)
                .HasColumnName("DS_SENHA")
                .HasColumnType("varchar(20)")
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("A senha deve conter no máximo 20 caracteres.");

            // Mapeia a propriedade Telefone para a coluna "NR_TELEFONE"
            entity.Property(e => e.Telefone)
                .HasColumnName("NR_TELEFONE")
                .HasColumnType("number(16)")
                .IsRequired()
                .HasComment("O número de telefone deve estar entre 1000000000000000 e 9999999999999999.");

            // Configura o relacionamento 1 para N com a entidade Produto
            entity.HasMany(u => u.Produtos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id_usuario)
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão
        });

        // Configuração adicional para outras entidades, se necessário
    }
}
