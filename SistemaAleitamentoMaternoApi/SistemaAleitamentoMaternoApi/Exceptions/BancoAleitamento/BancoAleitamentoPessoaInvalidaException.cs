namespace SistemaAleitamentoMaternoApi.Exceptions.BancoAleitamento
{
    public class BancoAleitamentoPessoaInvalidaException : Exception
    {
        public BancoAleitamentoPessoaInvalidaException() : base("A pessoa informada já é responsável por outro banco de aleitamento.")
        {
        }
    }
}
