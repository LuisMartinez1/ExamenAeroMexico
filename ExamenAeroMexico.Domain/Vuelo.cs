using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAeroMexico.Domain
{
    public class Vuelo
    {
        [Key]
        public int VueloId { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede más de {1} caracteres")]
        public string NumeroVuelo { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [MaxLength(2, ErrorMessage = "El campo {0} no puede más de {1} caracteres")]
        public string Origen { get; set; }
        
        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [MaxLength(2, ErrorMessage = "El campo {0} no puede más de {1} caracteres")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        public DateTime FechaSalida { get; set; }

        public virtual ICollection<Reservacion> Reservaciones { get; set; }

    }
}
