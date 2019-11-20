using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioDepartamentos.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; internal set; }
    }
}
