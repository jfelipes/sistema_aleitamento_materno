namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class BancoAleitamentoDto : BaseDto
    {
        public IEnumerable<LeiteMaternoDto> Estoque { get; set; }
    }
}
