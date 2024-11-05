using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TarefasSPT3.Models
{
    public class Produto
    {
    
        public int Id_produto { get; set; }

        [Column("NM_PRODUTO", TypeName = "varchar(40)")]
        [Required]
        [MaxLength(40, ErrorMessage = "O nome do produto deve conter no máximo 40 caracteres.")]
        public string Nome { get; set; }

        [Column("VL_PRECO", TypeName = "number(4,2)")]
        [Required]
        [Range(1, 99, ErrorMessage = "O preco deve estar entre 1 e 99")]
        public int Preco { get; set; }

        [Column("DS_DESCRICAO", TypeName = "varchar(100)")]
        [Required]
        [MaxLength(100, ErrorMessage = "A descricao deve conter no máximo 100 caracteres.")]
        public string Descricao { get; set; }


        //1 PARA N
        [ForeignKey("Usuario")]
        public int Id_usuario { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
