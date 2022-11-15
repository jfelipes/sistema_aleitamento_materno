using System.ComponentModel;

namespace SistemaAleitamentoMaternoApi.Enumerations
{
    public enum ETipoOperacao
    {
        [Description("Atendimento")]
        Atendimento,
        [Description("Doação")]
        Doacao,
        [Description("Recebimento")]
        Recebimento
    }
}
