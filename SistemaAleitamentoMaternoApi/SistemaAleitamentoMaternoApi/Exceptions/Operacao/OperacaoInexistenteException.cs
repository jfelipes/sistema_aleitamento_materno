namespace SistemaAleitamentoMaternoApi.Exceptions.Operacao
{
    public class OperacaoInexistenteException : Exception
    {
        public OperacaoInexistenteException() : base("Operação informada não informada ou não encontrada.")
        {
        }
    }
}
