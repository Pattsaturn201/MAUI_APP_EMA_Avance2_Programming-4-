using System.ComponentModel.DataAnnotations;

namespace EMAMUAIAPP.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(100)]
        public string Serial { get; set; }

        [Required]
        public DateTime FechaAdquisicion { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}

