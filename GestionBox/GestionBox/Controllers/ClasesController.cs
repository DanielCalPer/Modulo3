using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionBox.Models;
using GestionBox.Models.ViewModel;
using GestionBox.Services;
using Microsoft.AspNetCore.Authorization;

namespace GestionBox.Controllers
{
    //[Authorize(Roles = "Administrador")] // con esto restringimos el controlador entero. :)
    public class ClasesController : Controller
    {
        private readonly IClase _ClaseServices;
        private readonly IHorario _HorarioServices;
        

        public ClasesController(IClase ClasesServices, IHorario HorarioServices)
        {
            _ClaseServices = ClasesServices;
            _HorarioServices = HorarioServices;

        }

        // GET: Clases
        public async Task<IActionResult> Index(string name, string tipo, DateTime dia)
        {
 
            List<Clase> clase = await _ClaseServices.GetClaseAsync();

            HorarioClaseVM hcvm = new HorarioClaseVM()
            {
                Horarios = await _HorarioServices.GetHorarioAsync(),
                Clases = await _ClaseServices.GetClaseAsync()
            };

            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(tipo) && dia.ToString("dd/MM/yyyy") == "01/01/0001")
            {
                return View(hcvm);
            }
            if (!String.IsNullOrEmpty(name))
            {
                hcvm.Clases = hcvm.Clases.Where(x => x.Nombre.ToLower().Contains(name.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(tipo))
            {
                hcvm.Clases = hcvm.Clases.Where(x => x.Tipo == tipo).ToList();
            }
            if (dia.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                
                hcvm.Horarios = hcvm.Horarios.Where(x => x.Dia.ToString() == dia.ToString()).ToList();
                hcvm.Clases = hcvm.Horarios.Select(x => x.Clase).Distinct().ToList();
            }
            return View(hcvm);
        }

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _ClaseServices.GetClaseByIdAsync(id);
                
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clases/Create
        [Authorize(Roles="Administrador")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        // POST: Clases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Tipo,Imagen")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                await _ClaseServices.CreateClaseAsync(clase);
                
                return RedirectToAction(nameof(Index));
            }
            return View(clase);
        }

        // GET: Clases/Edit/5

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _ClaseServices.GetClaseByIdAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Clases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Tipo,Imagen")] Clase clase)
        {
            if (id != clase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ClaseServices.UpdateClaseAsync(clase);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ClaseServices.ClaseExist(clase.Id)) // como lo metemos aquí, podemos borrar el Método ClaseExist del final. 
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
            return View(clase);
        }

        // GET: Clases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _ClaseServices.GetClaseByIdAsync(id);
                
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _ClaseServices.GetClaseByIdAsync(id);
            await _ClaseServices.DeleteClaseAsync(clase);
            
            return RedirectToAction(nameof(Index));
        }
        

    }
}
