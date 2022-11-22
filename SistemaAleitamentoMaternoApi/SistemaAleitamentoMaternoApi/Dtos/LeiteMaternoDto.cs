using SistemaAleitamentoMaternoApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class LeiteMaternoDto : BaseDto
    {
        public bool Disponivel { get; set; } = true;
        [Required(ErrorMessage = "Você deve informar a pessoa que está realizando a doação.")]
        public Guid DoadorId { get; set; }
        [ForeignKey("BancoAleitamento")]
        public Guid? BancoAleitamentoId { get; set; }
        public Guid? ReceptorId { get; set; } = null;
        public DateTime? DataEntrada { get; set; } = DateTime.UtcNow;
        public DateTime? DataRetirada { get; set; } = DateTime.UtcNow;
    }
}
