using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBox.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public DateTime Hora { get; set; }
        public int ClaseId { get; set; }
        
       
        public Clase Clase { get; set; }
        public List<BoxUserHorario> BoxUserHorarios { get; set; }
    }
}
