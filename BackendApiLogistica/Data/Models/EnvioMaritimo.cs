using BackendApiLogistica.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class EnvioMaritimo
{
    public int EnvioMaritimoID { get; set; }

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
    public int PuertoID { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio de envío debe ser mayor que 0")]
    public decimal PrecioEnvio { get; set; }

    [Required]
    [RegularExpression("^[A-Z]{3}[0-9]{4}[A-Z]$", ErrorMessage = "El formato del número de flota no es válido")]
    public string NumeroFlota { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El número de guía debe tener 10 caracteres")]
    public string NumeroGuia { get; set; }

    // Relaciones
    public Cliente Cliente { get; set; }
    public Producto Producto { get; set; }
    public Puerto Puerto { get; set; }
}
