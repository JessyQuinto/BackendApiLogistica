using System.ComponentModel.DataAnnotations;

namespace BackendApiLogistica.Data.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(255, ErrorMessage = "La longitud máxima del nombre es de 255 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(255, ErrorMessage = "La longitud máxima de la dirección es de 255 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud máxima del teléfono es de 20 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(255, ErrorMessage = "La longitud máxima del email es de 255 caracteres")]
        public string Email { get; set; }
    }
}
