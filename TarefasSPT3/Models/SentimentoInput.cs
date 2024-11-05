namespace TarefasSPT3.Models
{
    public class SentimentoInput
    {
        public string Texto { get; set; }
    }

    public class SentimentoPrediction
    {
        public bool Predicao { get; set; }
        public float Probabilidade { get; set; }
    }
}
