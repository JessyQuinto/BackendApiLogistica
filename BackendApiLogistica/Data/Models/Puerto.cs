using System.ComponentModel.DataAnnotations;

namespace BackendApiLogistica.Data.Models
{
    public class Puerto
    {
        public int PuertoID { get; set; }

        [Required(ErrorMessage = "El nombre del puerto es obligatorio")]
        [StringLength(255, ErrorMessage = "La longitud del nombre no debe exceder de 255 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La ubicación del puerto es obligatoria")]
        [StringLength(255, ErrorMessage = "La longitud de la ubicación no debe exceder de 255 caracteres")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "La capacidad del puerto es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad debe ser un número positivo")]
        public int Capacidad { get; set; }
    }
}
