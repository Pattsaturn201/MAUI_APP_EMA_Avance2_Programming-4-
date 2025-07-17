using System.ComponentModel.DataAnnotations;

public class Pagos
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VentaId { get; set; }

    [Required]
    public decimal Monto { get; set; }

    public DateTime FechaPago { get; set; }

    [Required]
    [StringLength(100)]
    public string EntidadExterna { get; set; }

    [Required]
    [StringLength(50)]
    public string MetodoPago { get; set; }

    [StringLength(100)]
    public string DetallesCuenta { get; set; }

}
