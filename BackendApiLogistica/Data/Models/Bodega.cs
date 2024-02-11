using System.ComponentModel.DataAnnotations;

namespace BackendApiLogistica.Data.Models
{
    public class Bodega
    {
        public int BodegaID { get; set; }

        [Required(ErrorMessage = "El nombre de la bodega es obligatorio.")]
        [StringLength(255, ErrorMessage = "La longitud del nombre de la bodega no puede exceder de 255 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La ubicación de la bodega es obligatoria.")]
        [StringLength(255, ErrorMessage = "La longitud de la ubicación no puede exceder de 255 caracteres.")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "La capacidad de la bodega es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad de la bodega debe ser al menos 1.")]
        public int Capacidad { get; set; }
    }
}
