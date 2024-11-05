using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TarefasSPT3.Models
{
    public class Formulario
    {
        public int Id_formulario { get; set; }


        [Column("ST_ALERGIA", TypeName = "char(1)")]
        [Required]
        [MinLength(1)]
        [MaxLength(1, ErrorMessage = "O status da alergia deve conter no maximo 1 caracter.")]
        public string StatusAlergia { get; set; }


        [Column("DS_ALERGIA", TypeName = "char(200)")]
        [Required]
        [MaxLength(200, ErrorMessage = "A descricao da alergia deve conter no maximo 200 caracteres.")]
        public string DescricaoAlergia { get; set; }

        [Column("DS_PELE", TypeName = "char(20)")]
        [Required]
        [MaxLength(20, ErrorMessage = "A descricao da pele deve conter no maximo 20 caracteres.")]
        public string DescricaoPele { get; set; }


        //1 PARA 1
        [ForeignKey("Usuario")]
        public int Id_usuario { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
