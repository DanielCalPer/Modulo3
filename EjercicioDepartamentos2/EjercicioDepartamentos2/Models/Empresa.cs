using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioDepartamentos2.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Cif { get; set; }
        public string Pais { get; set; }

        public List<Departamento> Departamentos { get; set; }

    }
}
