namespace SistemaAleitamentoMaternoApi.Exceptions.Pessoa
{
    public class PessoaInativaException : Exception
    {
        public PessoaInativaException() : base("Não é permitido operações com pessoas com status inativo.")
        {
        }
    }
}
