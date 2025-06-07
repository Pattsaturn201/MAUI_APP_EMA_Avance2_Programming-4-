using System.ComponentModel.DataAnnotations;

namespace APISEMA.Models
{
    public class Pagos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public int VentaId { get; set; }

        [Required]
        [StringLength(50)]
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }

        // Nueva propiedad para identificar la entidad externa
        [Required]
        [StringLength(100)]
        public string EntidadExterna { get; set; }

        // Nueva propiedad para el método de pago
        [Required]
        [StringLength(50)]
        public string MetodoPago { get; set; }

        // Nueva propiedad para detalles de la cuenta bancaria
        [StringLength(100)]
        public string DetallesCuenta { get; set; }

        public class ProcesarPagos
        {
            public bool ProcesarPago(Pagos pago)
            {
                // Aquí puedes integrar con un proveedor de pagos externo
                if (string.IsNullOrEmpty(pago.EntidadExterna) || pago.Monto <= 0)
                {
                    throw new ArgumentException("Datos de pago inválidos.");
                }
                // Simulación de procesamiento de pago
                Console.WriteLine($"Procesando pago de {pago.Monto} a {pago.EntidadExterna} usando {pago.MetodoPago}.");
                return true; // Retorna true si el pago fue exitoso
            }
        }

        // Navigation properties
        public virtual OrdenTrabajo OrdenTrabajo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}
