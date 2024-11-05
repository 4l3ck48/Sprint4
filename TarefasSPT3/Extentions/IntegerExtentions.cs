// Extensions/IntegerExtensions.cs
namespace TarefasSPT3.Extensions
{
    public static class IntegerExtensions
    {
        public static string ToCurrency(this int value)
        {
            return value.ToString("C");
        }
    }
}