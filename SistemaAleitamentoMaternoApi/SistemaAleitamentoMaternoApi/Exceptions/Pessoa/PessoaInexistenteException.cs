namespace SistemaAleitamentoMaternoApi.Exceptions.Pessoa
{
    public class PessoaInexistenteException : Exception
    {
        public PessoaInexistenteException() : base("Pessoa informada não informada ou não encontrada.")
        {
        }
    }
}
