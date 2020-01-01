using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBox.Models
{
    public class BoxUserHorario
    {
        public int Id { get; set; }

        public BoxUser? BoxUser { get; set; }
        public string? BoxUserId { get; set; }
        public Horario? Horario { get; set; }
        public int? HorarioId { get; set; }
    }
}
