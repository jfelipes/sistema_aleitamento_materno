namespace SistemaAleitamentoMaternoApi.Exceptions.LeiteMaterno
{
    public class LeiteMaternoIndisponivelException : Exception
    {
        public LeiteMaternoIndisponivelException() : base("Leite Materno informado não se encontra disponivel.")
        {
        }
    }
}
