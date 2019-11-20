using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public List<Obra>Obras { get; set; }

        //public AutoBiografia AutoBiografia { get; set; } No hace falta ya que el otro es dominante. Así la F.K. estará solo en AutoBiografía. 
    }
}
