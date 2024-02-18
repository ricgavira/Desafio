namespace Desafio.Application.Utils
{
    public static class Utilitarios
    {
        public static DateTime CalcularDataNascimentoPelaIdade(int idade)
        {
            return DateTime.Today.AddYears(-idade);
        }
    }
}
