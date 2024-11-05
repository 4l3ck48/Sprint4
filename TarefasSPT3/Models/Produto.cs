// Models/Produto.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TarefasSPT3.Models
{
    public class Produto
    {
        [Key]
        [Column("Id_produto")]
        public int Id { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "O nome do produto deve conter no máximo 40 caracteres.")]
        [Column("NM_PRODUTO", TypeName = "varchar(40)")]
        public string Nome { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "O preço deve estar entre 1 e 99.")]
        [Column("VL_PRECO", TypeName = "number(4,2)")]
        public decimal Preco { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "A descrição deve conter no máximo 100 caracteres.")]
        [Column("DS_DESCRICAO", TypeName = "varchar(100)")]
        public string Descricao { get; set; }

        // Relacionamento N para 1 com Usuario
        [ForeignKey("Usuario")]
        [Column("Id_usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relacionamento 1 para N com Avaliacao
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
