using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicios.Models;

namespace Servicios.Services
{
    public class VideojuegosServices : IVideojuegos

    {
        private readonly ServiciosContext _context;

        public VideojuegosServices(ServiciosContext context) // Constructor: ahora ya podemos usar la BBDD context
        {
            _context = context;
        }
        public async Task<List<Videojuego>> GetVideojuegosAsync()
        {
            return await _context.Videojuegos.ToListAsync();
        }
        public async Task<Videojuego> GetVideojuegoByIdAsync(int? id)
        {
            return await _context.Videojuegos.FindAsync(id);
        }

        public async Task CreateVideojuegoAsync(Videojuego videojuego)
        {
           await _context.AddAsync(videojuego);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVideojuegoAsync(Videojuego videojuego)
        {
            _context.Videojuegos.Remove(videojuego);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVideojuegoAsync(Videojuego videojuego)
        {
            _context.Update(videojuego);
            await _context.SaveChangesAsync();
        }

        public bool VideojuegoExist(int? id)
        {
            return _context.Videojuegos.Any(x => x.Id == id);
        }

        

       
    }
}
