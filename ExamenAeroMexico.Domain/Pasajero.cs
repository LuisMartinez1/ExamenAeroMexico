using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAeroMexico.Domain
{
    public class Pasajero
    {
        [Key]
        public int PasajeroId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string ApellidoMaterno { get; set; }
        public virtual ICollection<Reservacion> Reservaciones { get; set; }
    }
}
