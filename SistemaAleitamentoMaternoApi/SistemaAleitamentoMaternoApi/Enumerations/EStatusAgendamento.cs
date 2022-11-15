using System.ComponentModel;

namespace SistemaAleitamentoMaternoApi.Enumerations
{
    public enum EStatusAgendamento
    {
        [Description("Cadastrado")]
        Cadastrado,
        [Description("Cancelado")]
        Cancelado,
        [Description("Realizado")]
        Realizado
    }
}
