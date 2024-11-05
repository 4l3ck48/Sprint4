// Models/Avaliacao.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasSPT3.Models
{
    public class Avaliacao
    {
        [Key]
        [Column("Id_Avaliacao")]
        public int Id { get; set; }

        [Required]
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        [Column("ProdutoId")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "A avaliação deve ser entre 1 e 5.")]
        [Column("Rating")]
        public float Rating { get; set; }
    }
}