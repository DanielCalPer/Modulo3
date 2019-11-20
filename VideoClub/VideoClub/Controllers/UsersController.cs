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
    public class UsersController : Controller
    {
        private readonly VideoClubContext _context;

        public UsersController(VideoClubContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string alquiler)
        {
            var applicationDbContext = _context.User.Where(x => x.Id == 1).Include(x => x.UserFilms)
                .ThenInclude(x => x.Film); // entra dentro de otro modelo. 

            //var result = projects.Where(p => filtedTags.All(t => p.Tags.Contains(t)));
            //var result = _context.UserFilm.Where(p => p.Returndate.All(t => p.UserFilm.Contains(t)));

            if (String.IsNullOrEmpty(alquiler))
            {
                ViewData["alquileres"] = await _context.UserFilm.Where(x => x.UserId == 1).ToListAsync();

                return View(applicationDbContext);
            }

            if (alquiler == "Alquileres pasados")
            {
                ViewData["alquileres"] = await _context.UserFilm.Where(x => x.UserId == 1 && x.Returndate != null).ToListAsync();

                return View(applicationDbContext);

            }
            if (alquiler == "Alquileres vigentes")
            {
                ViewData["alquileres"] = await _context.UserFilm.Where(x => x.UserId==1 && x.Returndate == null).ToListAsync();

                return View(applicationDbContext);

            }

            return View(applicationDbContext);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            id = 1;
            
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id==1);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lastname,Email,ProfilePicture")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lastname,Email,ProfilePicture")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
