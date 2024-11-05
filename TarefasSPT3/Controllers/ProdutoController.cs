// Controllers/ProdutoController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TarefasSPT3.Data;
using TarefasSPT3.ML.Services;
using TarefasSPT3.Models;
using TarefasSPT3.Services;

namespace TarefasSPT3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly SistemasTarefasDBContext _dbContext;
        private readonly IRecommendationService _recommendationService;

        public ProdutoController(SistemasTarefasDBContext dbContext, IRecommendationService recommendationService)
        {
            _dbContext = dbContext;
            _recommendationService = recommendationService;
        }

        // Endpoint existente para Recomendar Produtos
        [HttpGet("Recomendar/{usuarioId}")]
        public ActionResult<List<Produto>> RecomendarProdutos(int usuarioId)
        {
            var recomendacoes = _recommendationService.RecommendProdutos(usuarioId, 5);
            return Ok(recomendacoes);
        }

        // (Opcional) Outros endpoints relacionados a produtos
    }
}