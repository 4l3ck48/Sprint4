using Microsoft.ML;
using Microsoft.ML.Trainers;
using System.Collections.Generic;
using System.Linq;
using TarefasSPT3.Data;
using TarefasSPT3.Models;
using TarefasSPT3.ML.Models;
using TarefasSPT3.Services;

namespace TarefasSPT3.ML.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;
        private readonly SistemasTarefasDBContext _dbContext;

        public RecommendationService(SistemasTarefasDBContext dbContext)
        {
            _mlContext = new MLContext();
            _dbContext = dbContext;

            // Carregar ou treinar o modelo
            if (System.IO.File.Exists("model.zip"))
            {
                _model = LoadModel();
            }
            else
            {
                _model = TrainModel();
                SaveModel(_model);
            }
        }

        private ITransformer TrainModel()
        {
            var data = _dbContext.Avaliacoes
                .Select(a => new ProductRating
                {
                    UsuarioId = a.UsuarioId,
                    ProdutoId = a.ProdutoId,
                    Rating = a.Rating
                })
                .ToList();

            if (data.Count == 0)
            {
                throw new InvalidOperationException("Não há dados suficientes para treinar o modelo de recomendação.");
            }

            var dataView = _mlContext.Data.LoadFromEnumerable(data);

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = nameof(ProductRating.UsuarioId),
                MatrixRowIndexColumnName = nameof(ProductRating.ProdutoId),
                LabelColumnName = nameof(ProductRating.Rating),
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var pipeline = _mlContext.Recommendation().Trainers.MatrixFactorization(options);

            return pipeline.Fit(dataView);
        }

        private void SaveModel(ITransformer model)
        {
            _mlContext.Model.Save(model, null, "model.zip");
        }

        private ITransformer LoadModel()
        {
            DataViewSchema modelSchema;
            return _mlContext.Model.Load("model.zip", out modelSchema);
        }

        public float PredictRating(int usuarioId, int produtoId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductRating, ProductPrediction>(_model);
            var prediction = predictionEngine.Predict(new ProductRating { UsuarioId = usuarioId, ProdutoId = produtoId });
            return prediction.Score;
        }

        public List<Produto> RecommendProdutos(int usuarioId, int topN)
        {
            var produtos = _dbContext.Produtos.ToList();
            var recomendacoes = produtos
                .Select(p => new { Produto = p, Score = PredictRating(usuarioId, p.Id) })
                .OrderByDescending(p => p.Score)
                .Take(topN)
                .Select(p => p.Produto)
                .ToList();

            return recomendacoes;
        }
    }
}
