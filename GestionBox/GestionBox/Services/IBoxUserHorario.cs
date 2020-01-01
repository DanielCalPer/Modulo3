using GestionBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBox.Services
{
    public interface IBoxUserHorario
    {
        public Task<List<BoxUserHorario>> GetBoxUserHorarioAsync();
        public Task<BoxUserHorario> GetBoxUserHorarioByIdAsync(int? id);
        public Task CreateBoxUserHorarioAsync(BoxUserHorario boxUserHorario);
        public Task UpdateBoxUserHorarioAsync(BoxUserHorario boxUserHorario);
        public Task DeleteBoxUserHorarioAsync(BoxUserHorario boxUserHorario);
        public bool BoxUserHorarioExist(int? id);
    }
}
