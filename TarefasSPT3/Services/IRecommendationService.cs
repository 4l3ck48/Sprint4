// Services/IRecommendationService.cs
using TarefasSPT3.Models;

namespace TarefasSPT3.Services
{
    public interface IRecommendationService
    {
        List<Produto> RecommendProdutos(int usuarioId, int topN);
    }
}