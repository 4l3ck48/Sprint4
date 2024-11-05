namespace TarefasSPT3.Extentions
{
    public static class IntegerExtentions //NOME DA CLASSE
    {
        public static string ToCurrency(this int value)
        {
            return value.ToString("C");
        }
    }
}
