using System.ComponentModel.DataAnnotations;

namespace APISEMA.Models
{
    public class OrdenTrabajo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEquipo { get; set; }

        [Required]
        [StringLength(50)]
        public string CodigoEquipo { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoMantenimiento { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

        public DateTime? FechaEntrega { get; set; }

        [StringLength(500)]
        public string DescripcionProblema { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }

        [StringLength(20)]
        [Required]
        public EstadoDeOrden Estado { get; set; }
    }
}
