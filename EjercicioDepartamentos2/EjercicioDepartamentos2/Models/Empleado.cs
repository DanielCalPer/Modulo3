using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioDepartamentos2.Models
{
    public class Empleado
    {
        public static IEnumerable<object> Departamentos { get; internal set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }

        public Departamento Departamento { get; set; }

        
    }
}
