using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Servicios.Models;
using Servicios.Services;

namespace Servicios.Controllers
{
    public class VideojuegosController : Controller
    {
        private readonly IVideojuegos _videojuegosServices; // ya no recibimos en el constructor el context, la BBDD.

        public VideojuegosController(IVideojuegos videojuegosServices)
        {
            _videojuegosServices = videojuegosServices;
        }

        // GET: Videojuegos
        public async Task<IActionResult> Index()
        {
            return View(await _videojuegosServices.GetVideojuegosAsync());
        }

        // GET: Videojuegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuegos = await _videojuegosServices.GetVideojuegoByIdAsync(id);
                
            if (videojuegos == null)
            {
                return NotFound();
            }

            return View(videojuegos);
        }

        // GET: Videojuegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videojuegos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaPublicacion,Genero")] Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                await _videojuegosServices.CreateVideojuegoAsync(videojuego);
                
                return RedirectToAction(nameof(Index));
            }
            return View(videojuego);
        }

        // GET: Videojuegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuegos = await _videojuegosServices.GetVideojuegoByIdAsync(id);
            if (videojuegos == null)
            {
                return NotFound();
            }
            return View(videojuegos);
        }

        // POST: Videojuegos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaPublicacion,Genero")] Videojuego videojuego)
        {
            if (id != videojuego.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _videojuegosServices.UpdateVideojuegoAsync(videojuego);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_videojuegosServices.VideojuegoExist(videojuego.Id))
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
            return View(videojuego);
        }

        // GET: Videojuegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _videojuegosServices.GetVideojuegoByIdAsync(id);
                
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // POST: Videojuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videojuegos = await _videojuegosServices.GetVideojuegoByIdAsync(id);
            await _videojuegosServices.DeleteVideojuegoAsync(videojuegos);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
