namespace SistemaAleitamentoMaternoApi.Exceptions
{
    public class IrregularidadeDatasException : Exception
    {
        public IrregularidadeDatasException(DateTime? primeiraData, DateTime? segundaData) : base($"Foi encontrado um problema referente às datas: {primeiraData.ToString()}, {segundaData.ToString()}.")
        {
        }
    }
}
