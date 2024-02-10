namespace BackendApiLogistica.Data.Models
{
    public class EnvioMaritimo
    {
        public int EnvioMaritimoID { get; set; }
        public int ClienteID { get; set; }
        public int ProductoID { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int PuertoID { get; set; }
        public decimal PrecioEnvio { get; set; }
        public string NumeroFlota { get; set; }
        public string NumeroGuia { get; set; }

        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
        public Puerto Puerto { get; set; }
    }

}
