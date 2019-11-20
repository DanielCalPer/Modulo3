using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburgueseria.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        
        public double PrecioTotal { get; set; }
        

        public Principal? Principal { get; set; }
        public int? PrincipalId { get; set; }
        public Entrante? Entrante { get; set; }
        public int? EntranteId { get; set; }
        public Postre? Postre { get; set; }
        public int? PostreId { get; set; }


    }
}
