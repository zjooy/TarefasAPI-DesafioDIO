using System.Text.Json.Serialization;

namespace agendamentoTarefas.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusTarefaEnum
    {
        Pendente,
        Finalizado
    }
}
