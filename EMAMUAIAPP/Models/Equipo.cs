using System.ComponentModel.DataAnnotations;

namespace EMAMUAIAPP.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serial { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
