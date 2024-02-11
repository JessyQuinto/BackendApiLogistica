using System.ComponentModel.DataAnnotations;

namespace BackendApiLogistica.Data.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }
    }
}