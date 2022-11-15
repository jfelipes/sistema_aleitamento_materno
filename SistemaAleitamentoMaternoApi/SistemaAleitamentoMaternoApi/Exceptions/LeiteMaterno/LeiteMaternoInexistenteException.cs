namespace SistemaAleitamentoMaternoApi.Exceptions.LeiteMaterno
{
    public class LeiteMaternoInexistenteException : Exception
    {
        public LeiteMaternoInexistenteException() : base("Leite Materno informado não informado ou não encontrado.")
        {
        }
    }
}
