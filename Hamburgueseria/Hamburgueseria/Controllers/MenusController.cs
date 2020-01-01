using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hamburgueseria.Models;
using Hamburgueseria.Models.ViewModel;
using System;

namespace Hamburgueseria.Controllers
{
    public class MenusController : Controller
    {
        private readonly HamburgueseriaContext _context;

        public MenusController(HamburgueseriaContext context)// constructor une MenusController con HamburgeseriaContxt, osea el objeto Menu con la BBDD. 
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            EleccionMenuVM emvm = new EleccionMenuVM // instanciamos el objeto del ViewModel, y lo llenamos son los Objetos sacados de la BBDD.
            {
                Entrantes = await _context.Entrantes.ToListAsync(),    
                Principales = await _context.Principales.ToListAsync(),
                Postres = await _context.Postres.ToListAsync(),
                //objeto Menu vacío, ya que lo vamos a construir.
                
            };
            return View(emvm);
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,PrecioTotal")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,PrecioTotal")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarMenu(EleccionMenuVM emvm)// no seria mas correcto decir que lo que recibe son los 3 Ids? y el menu?, porque no le da error?
        {
            Entrante entrante = await _context.Entrantes.FindAsync(emvm.Menu.EntranteId); // buscamos objetos en funcion ID recibido
            Principal principal = await _context.Principales.FindAsync(emvm.Menu.EntranteId);
            Postre postre = await _context.Postres.FindAsync(emvm.Menu.EntranteId);



            Menu menu = new Menu
            {
                Entrante = entrante,
                Principal = principal,
                Postre = postre,
                Fecha = DateTime.Now,
                //PrecioTotal = entrante.Precio + principal.Precio + postre.Precio

            };

            double precio = 0; 
            if (entrante!= null)
            {
                precio += entrante.Precio;
            }
            if (principal != null)
            {
                precio += principal.Precio;
            }
            if (postre != null)
            {
                precio += postre.Precio;
            }
            menu.PrecioTotal = precio; 
            return View(menu);
        }

            [HttpPost]
        public async Task<IActionResult> EleccionMenu(Menu menu)
        {
            await _context.AddAsync(menu);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}
