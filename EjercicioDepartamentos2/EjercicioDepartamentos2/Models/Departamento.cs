using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioDepartamentos2.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public List<Empleado> Empleado { get; set; }
        public Empresa Empresa { get; set; }

        //public int EmpresaId { get; set; } mas adelante tenerlo fuera como atributo será util. Pero cuidado al hacer la migracion, que admita valores null en la columna. 
    }
}
