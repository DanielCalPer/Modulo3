using GestionBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GestionBox.Services
{
    public interface IHorario
    {
        public Task<List<Horario>> GetHorarioAsync();
        public Task<Horario> GetHorarioByIdAsync(int? id);
        public Task CreateHorarioAsync(Horario horario);
        public Task UpdateHorarioAsync(Horario horario);
        public Task DeleteHorarioAsync(Horario horario);
        public bool HorarioExist(int? id);
    }
}
