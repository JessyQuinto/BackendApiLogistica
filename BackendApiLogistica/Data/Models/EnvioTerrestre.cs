using System;
using System.ComponentModel.DataAnnotations;

public class EnvioTerrestre
{
    public int EnvioTerrestreID { get; set; }

    [Required]
    public int ClienteID { get; set; }

    [Required]
    public int ProductoID { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad del producto debe ser al menos 1")]
    public int CantidadProducto { get; set; }

    [Required]
    public DateTime FechaRegistro { get; set; }

    [Required]
    public DateTime FechaEntrega { get; set; }

    [Required]
    public int BodegaID { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio de envío debe ser mayor que 0")]
    public decimal PrecioEnvio { get; set; }

    [Required]
    [RegularExpression("^[A-Z]{3}[0-9]{3}$", ErrorMessage = "El formato de la placa del vehículo no es válido")]
    public string PlacaVehiculo { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El número de guía debe tener 10 caracteres")]
    public string NumeroGuia { get; set; }
}
