using SQLite;

namespace EMAMUAIAPP.Models
{
    public class Clientes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), NotNull]
        public string NombreCompleto { get; set; }

        [MaxLength(50), NotNull]
        public string ApellidoCompleto { get; set; }

        [MaxLength(100), NotNull]
        public string Correo { get; set; }

        [MaxLength(20), NotNull]
        public string Telefono { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }

        // Guardamos métodos de pago como texto CSV
        [MaxLength(200)]
        public string MetodosPagoCSV { get; set; }

        // Propiedad no mapeada: convierte CSV a lista
        [Ignore]
        public List<string> MetodosDePago
        {
            get => string.IsNullOrWhiteSpace(MetodosPagoCSV)
                ? new List<string>()
                : MetodosPagoCSV.Split(',').Select(m => m.Trim()).ToList();
            set => MetodosPagoCSV = string.Join(", ", value);
        }

        // Propiedad auxiliar para mostrar métodos de pago
        [Ignore]
        public string MetodosDePagoString => string.Join(", ", MetodosDePago);
    }
}
