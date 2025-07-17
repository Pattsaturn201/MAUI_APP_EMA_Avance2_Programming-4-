using System.Text.Json.Serialization;

namespace APISEMA.Models
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