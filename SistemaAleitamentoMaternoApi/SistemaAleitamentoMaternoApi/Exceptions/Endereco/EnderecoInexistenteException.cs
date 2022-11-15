using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace SistemaAleitamentoMaternoApi.Exceptions.Endereco
{
    public class EnderecoInexistenteException : Exception
    {
        public EnderecoInexistenteException() : base("Endereço não informado ou não encontrado.")
        {
        }
    }
}
