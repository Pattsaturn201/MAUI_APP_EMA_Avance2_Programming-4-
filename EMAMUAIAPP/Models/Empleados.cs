using System.ComponentModel.DataAnnotations;

namespace EMAMUAIAPP.Models
{
    public class Empleados
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidoCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime datebirth { get; set; }

        [Required]
        [StringLength(200)]
        public string Puesto { get; set; }

        [Required]
        public string Cargo { get; set; }

    }
}
