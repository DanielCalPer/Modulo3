using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoClub.Models;

namespace VideoClub.Controllers
{
    public class UserFilmsController : Controller
    {
        private readonly VideoClubContext _context;

        public UserFilmsController(VideoClubContext context)
        {
            _context = context;
        }

        // GET: UserFilms
        public async Task<IActionResult> Index(string pendiente)
        {
            List<UserFilm> alquileres = await _context.UserFilm.Include(u => u.Film)
                .Include(u => u.User)
                .Where(x => x.UserId == 1).ToListAsync();

            if (String.IsNullOrEmpty(pendiente))
            {
                return View(alquileres);
            }

            if (pendiente == "si")
            {
                alquileres = alquileres.Where(x => x.Returndate == null).ToList();
            }
            else
            {
                alquileres = alquileres.Where(x => x.Returndate != null).ToList();
            }

            return View(alquileres);
            
        }

        // GET: UserFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

      
        // GET: UserFilms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Daterental,Returndate")] UserFilm userFilm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFilm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userFilm);
        }

        // GET: UserFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilm.FindAsync(id);
            if (userFilm == null)
            {
                return NotFound();
            }
            return View(userFilm);
        }

        // POST: UserFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Daterental,Returndate")] UserFilm userFilm)
        {
            if (id != userFilm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFilm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFilmExists(userFilm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userFilm);
        }

        // GET: UserFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

        // POST: UserFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFilm = await _context.UserFilm.FindAsync(id);
            _context.UserFilm.Remove(userFilm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFilmExists(int id)
        {
            return _context.UserFilm.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ConfirmarAlquiler(int id)
        {
            Film film = await _context.Film.FindAsync(id); //localiza el film por id
            User user = await _context.User.FindAsync(1);

            UserFilm alquiler = new UserFilm
            {
                Film = film, // no hace falta filmid ni userid, al tener el user y el film los coge. 
                User = user,
                Daterental = DateTime.Now,
            };

            _context.Add(alquiler); // añadir objeto a tabla UserFilm
            film.Rented = "Si"; // cambiamos estado pelicula
            _context.Update(film); // actualizamos tabla film
            await _context.SaveChangesAsync(); // guardar cambios BBDD

            return RedirectToAction("index"); // redirige al metodo Index del controller. 
            //RedirectToAction(nameof(Index)); // lo mismo que el anterior 
            //RedirectToAction("Index","Films"); // Redirige al Index de otro controlador. UTIL. 
        }
        public async Task<IActionResult> DevolverPelicula(int id)
        {
            UserFilm alquiler = await _context.UserFilm.Include(x => x.Film).FirstOrDefaultAsync(x => x.Id == id); //Include para los datos d ela peli, y aqui no deja usar Find asi que usamos FirstOrDefault que es lo mismo. 
            return View(alquiler);
        }
        public async Task<IActionResult> ConfirmarDevolucion(int id)
        {
            UserFilm alquiler = await _context.UserFilm.Include(x => x.Film).FirstOrDefaultAsync(x => x.Id == id);
            alquiler.Returndate = DateTime.Now; // Le damos una fecha de devolucion
            Film film = alquiler.Film;
            film.Rented = "No"; // cambiamos estado pelicula
            _context.Update(alquiler);
            _context.Update(film);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", "Films");
        }
    }
}
