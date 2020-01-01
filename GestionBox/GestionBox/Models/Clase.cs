using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBox.Models
{
    public class Clase
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Imagen { get; set; }
        public List<Horario> Horarios { get; set; }
    }
}
