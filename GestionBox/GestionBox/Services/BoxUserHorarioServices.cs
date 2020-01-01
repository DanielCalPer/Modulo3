using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionBox.Data;
using GestionBox.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionBox.Services
{
    public class BoxUserHorarioServices : IBoxUserHorario
    {
        private readonly ApplicationDbContext _context;
        public BoxUserHorarioServices(ApplicationDbContext context) // Constructor: ahora ya podemos usar la BBDD context
        {
            _context = context;
        }
        public async Task<List<BoxUserHorario>> GetBoxUserHorarioAsync()
        {
            return await _context.BoxUserHorarios.Include(x=>x.BoxUser).Include(x => x.Horario).ThenInclude(x => x.Clase).ToListAsync();
        }

        public async Task<BoxUserHorario> GetBoxUserHorarioByIdAsync(int? id)
        {
            return await _context.BoxUserHorarios.Include(x => x.BoxUser).Include(x => x.Horario).ThenInclude(x=>x.Clase).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateBoxUserHorarioAsync(BoxUserHorario boxUserHorario)
        {
            await _context.AddAsync(boxUserHorario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBoxUserHorarioAsync(BoxUserHorario boxUserHorario)
        {
            _context.BoxUserHorarios.Remove(boxUserHorario);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateBoxUserHorarioAsync(BoxUserHorario boxUserHorario)
        {
            _context.Update(boxUserHorario);
            await _context.SaveChangesAsync();
        }
        public bool BoxUserHorarioExist(int? id)
        {
            return _context.BoxUserHorarios.Any(x => x.Id == id);
        }

       
    }
}
