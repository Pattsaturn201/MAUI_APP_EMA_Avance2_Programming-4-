using System.ComponentModel.DataAnnotations;

namespace APISEMA.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEmpresa { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Correo { get; set; }
    }
}
