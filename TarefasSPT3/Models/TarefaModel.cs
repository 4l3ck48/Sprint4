// Models/TarefaModel.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TarefasSPT3.Enums;

namespace TarefasSPT3.Models
{
    public class TarefaModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "O nome da tarefa deve conter no máximo 255 caracteres.")]
        [Column("Nome", TypeName = "NVARCHAR2(255)")]
        public string Nome { get; set; }

        [MaxLength(1000, ErrorMessage = "A descrição da tarefa deve conter no máximo 1000 caracteres.")]
        [Column("Descricao", TypeName = "NVARCHAR2(1000)")]
        public string Descricao { get; set; }

        [Required]
        [Column("Status", TypeName = "NUMBER(10)")]
        public StatusTarefa Status { get; set; }
    }
}