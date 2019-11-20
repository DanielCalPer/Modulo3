using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class AutoBiografia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Imagen { get; set; }
        public int NumeroPaginas { get; set; }

        public Autor Autor { get; set; }


    }
}
