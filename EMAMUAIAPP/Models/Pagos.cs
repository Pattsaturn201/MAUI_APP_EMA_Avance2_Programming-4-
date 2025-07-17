namespace EMAMUAIAPP.Models
{
    public class Pagos
    {
        public int Id { get; set; } = 0;

        public int VentaId { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string EntidadExterna { get; set; }

        public string MetodoPago { get; set; }

        public string DetallesCuenta { get; set; }
    }
}

