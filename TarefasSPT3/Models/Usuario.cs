using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TarefasSPT3.Models
{
    public class Usuario
    {
        [Column("NM_NOME", TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Column("DS_EMAIL", TypeName = "varchar(100)")]
        [Required]
        [MaxLength(100, ErrorMessage = "O email deve conter no máximo 100 caracteres.")]
        [EmailAddress]
        public string Email { get; }

        [Column("NR_CPF", TypeName = "number(12)")]
        [Required]
        [Range(100000000000, 999999999999, ErrorMessage = "O cpf deve estar entre 100000000000 e 999999999999")]
        public int Cpf { get; set; }

        [Column("DS_SENHA", TypeName = "varchar(20)")]
        [Required]
        [MaxLength(20, ErrorMessage = "A senha deve conter no máximo 20 caracteres.")]
        public string Senha { get; set; }

        [Column("NR_TELEFONE", TypeName = "number(16)")]
        [Required]
        [Range(1000000000000000, 9999999999999999, ErrorMessage = "O numero de telefone deve estar entre 1000000000000000 e 9999999999999999")]
        public int Telefone { get; set; }
        public object Produtos { get; internal set; }
    }
}
