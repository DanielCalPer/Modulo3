using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime AnoPublicacion { get; set; }
        public string Imagen { get; set; }

        public int AutorId { get; set; }//EntityFramework genera la F.K. auto, pero queremos tenerla como código para usarla. 
        public Autor Autor { get; set; }
        public List<ObraCategoria> ObraCategorias { get; set; }

    }
}
