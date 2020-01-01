using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionBox.Data;
using GestionBox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



namespace GestionBox.Services
{
    public class HorarioServices : IHorario
    {
        private readonly ApplicationDbContext _context;
        

        public HorarioServices(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<List<Horario>> GetHorarioAsync()
        {
            return await _context.Horarios.Include(x => x.Clase).Include(x=>x.BoxUserHorarios).ToListAsync();
        }

        public async Task<Horario> GetHorarioByIdAsync(int? id)
        {
            return await _context.Horarios.Include(x => x.Clase).Include(x => x.BoxUserHorarios).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateHorarioAsync(Horario horario)
        {
            await _context.AddAsync(horario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHorarioAsync(Horario horario)
        {
            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateHorarioAsync(Horario horario)
        {
            _context.Update(horario);
            await _context.SaveChangesAsync();

        }
        public bool HorarioExist(int? id)
        {
            return _context.Horarios.Any(x => x.Id == id);
        }

    }
}
