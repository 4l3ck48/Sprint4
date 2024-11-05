// Models/Usuario.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasSPT3.Models
{
    public class Usuario
    {
        [Key]
        [Column("Id_usuario")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres.")]
        [Column("NM_NOME", TypeName = "varchar(50)")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O email deve conter no máximo 100 caracteres.")]
        [EmailAddress]
        [Column("DS_EMAIL", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Range(100000000000, 999999999999, ErrorMessage = "O CPF deve estar entre 100000000000 e 999999999999.")]
        [Column("NR_CPF", TypeName = "number(12)")]
        public long Cpf { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "A senha deve conter no máximo 20 caracteres.")]
        [Column("DS_SENHA", TypeName = "varchar(20)")]
        public string Senha { get; set; }

        [Required]
        [Range(1000000000000000, 9999999999999999, ErrorMessage = "O número de telefone deve estar entre 1000000000000000 e 9999999999999999.")]
        [Column("NR_TELEFONE", TypeName = "number(16)")]
        public long Telefone { get; set; }

        // Relacionamento 1 para N com Produto
        public ICollection<Produto> Produtos { get; set; }
    }
}