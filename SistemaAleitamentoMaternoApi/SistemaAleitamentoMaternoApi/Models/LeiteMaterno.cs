﻿namespace SistemaAleitamentoMaternoApi.Models
{
    public class LeiteMaterno : BaseEntity
    {
        public bool Disponivel { get; set; } = true;
        public Guid DoadorId { get; set; }
        public Guid? BancoAleitamentoId { get; set; }
        public Guid? ReceptorId { get; set; }
        public DateTime? DataEntrada { get; set; } = DateTime.UtcNow;
        public DateTime? DataRetirada { get; set; }
    }
}
