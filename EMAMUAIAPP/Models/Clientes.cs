using System.ComponentModel.DataAnnotations;

namespace EMAMUAIAPP.Models
{
    public class Clientes
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
        public string Telefono { get; set; }
        [StringLength(200)]
        public string Direccion { get; set; }
        [Required]
        public List<string> MetodosDePago { get; set; } = new();
    }
}
