namespace SistemaAleitamentoMaternoApi.Exceptions.BancoAleitamento
{
    public class BancoAleitamentoInexistenteException : Exception
    {
        public BancoAleitamentoInexistenteException() : base("Banco de Aleitamento informado não informado ou não encontrado.")
        {
        }
    }
}
