using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionBox.Data;
using GestionBox.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionBox.Services
{
    public class ClaseServices : IClase
    {
        private readonly ApplicationDbContext _context;

        public ClaseServices(ApplicationDbContext context) // Constructor: ahora ya podemos usar la BBDD context
        {
            _context = context;
        }
        public async Task<List<Clase>> GetClaseAsync()
        {
            return await _context.Clases.Include(x => x.Horarios).ToListAsync();
        }

        public async Task<Clase> GetClaseByIdAsync(int? id)
        {
            return await _context.Clases.Include(x => x.Horarios).FirstOrDefaultAsync(x => x.Id == id); // si tienes que hacer un Include, FIndAsync no deja, usar FirstOrDefault.
        }


        public async Task CreateClaseAsync(Clase clase)
        {
            await _context.AddAsync(clase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClaseAsync(Clase clase)
        {
            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateClaseAsync(Clase clase)
        {
            _context.Update(clase);
            await _context.SaveChangesAsync();
        }
        public bool ClaseExist(int? id)
        {
            return _context.Clases.Any(x => x.Id == id);
        }

       
    }
}
