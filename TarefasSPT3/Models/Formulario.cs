// Models/Formulario.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasSPT3.Models
{
    public class Formulario
    {
        [Key]
        [Column("Id_formulario")]
        public int Id { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "O status da alergia deve conter no máximo 1 caractere.")]
        [Column("ST_ALERGIA", TypeName = "char(1)")]
        public string StatusAlergia { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "A descrição da alergia deve conter no máximo 200 caracteres.")]
        [Column("DS_ALERGIA", TypeName = "char(200)")]
        public string DescricaoAlergia { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "A descrição da pele deve conter no máximo 20 caracteres.")]
        [Column("DS_PELE", TypeName = "char(20)")]
        public string DescricaoPele { get; set; }

        // Relacionamento 1 para 1 com Usuario
        [ForeignKey("Usuario")]
        [Column("Id_usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}