using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAeroMexico.Domain
{
    public class Reservacion
    {
        [Key]
        public int RecervacionId { get; set; }

        [Display(Name = "Vuelo")]
        public int VueloId { get; set; }

        [Display(Name = "Pasajero")]
        public int PasajeroId { get; set; }
        
        public virtual Vuelo Vuelo { get; set; }
        public virtual Pasajero Pasajero { get; set; }
    }
}
