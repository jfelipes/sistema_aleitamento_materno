using System.ComponentModel.DataAnnotations;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class LeiteMaternoDto : BaseDto
    {
        public bool? Disponivel { get; set; } = true;
        [Required(ErrorMessage = "Deve ser informado a pessoa que está fazendo a doação.")]
        public Guid DoadorId { get; set; }
        public Guid? ReceptorId { get; set; }
        public DateTime? DataEntrada { get; set; } = DateTime.UtcNow;
        public DateTime? DataRetirada { get; set; }
    }
}
