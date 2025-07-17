using System.Text.Json.Serialization;

namespace EMAMUAIAPP.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum EstadoDeOrden
    {
        Pendiente,
        EnProceso,
        Finalizado,
        Cancelado
    }
}