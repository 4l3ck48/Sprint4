// ML/Models/ProductRating.cs
using Microsoft.ML.Data;

namespace TarefasSPT3.ML.Models
{
    public class ProductRating
    {
        [LoadColumn(0)]
        public float UsuarioId { get; set; }

        [LoadColumn(1)]
        public float ProdutoId { get; set; }

        [LoadColumn(2)]
        public float Rating { get; set; }
    }

    public class ProductPrediction
    {
        public float Score { get; set; }
    }
}