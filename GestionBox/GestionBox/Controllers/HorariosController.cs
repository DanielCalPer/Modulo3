using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionBox.Data;
using GestionBox.Models;
using GestionBox.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GestionBox.Controllers
{
    
    public class HorariosController : Controller
    {
        private readonly IHorario _HorarioServices;
        private readonly UserManager<BoxUser> _boxUser;


        public HorariosController(IHorario horarioServices, UserManager<BoxUser> boxUser)
        {
            _HorarioServices = horarioServices;
            _boxUser = boxUser;


        }

        [Authorize(Roles = "Administrador")]
        // GET: Horarios
        public async Task<IActionResult> Index(int dia, int mes)
        {
            List<Horario> horario = await _HorarioServices.GetHorarioAsync();


            if (dia == 0 && mes == 0)
            {
                return View(horario);
            }
            
            if (dia != 0)
            {
                horario = horario.Where(x => x.Dia.Day == dia).ToList();
            }
            if (mes != 0)
            {
                horario = horario.Where(x => x.Dia.Month == mes).ToList();
            }


            return View(horario);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _HorarioServices.GetHorarioByIdAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Horarios/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Horario horario)
        {
            if (ModelState.IsValid)
            {
                await _HorarioServices.CreateHorarioAsync(horario);

                return RedirectToAction(nameof(Index));
            }
            return View(horario);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _HorarioServices.GetHorarioByIdAsync(id);

            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Horario horario)
        {
            if (id != horario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _HorarioServices.UpdateHorarioAsync(horario);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_HorarioServices.HorarioExist(horario.Id))
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
            return View(horario);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _HorarioServices.GetHorarioByIdAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _HorarioServices.GetHorarioByIdAsync(id);
            await _HorarioServices.DeleteHorarioAsync(horario);

            return RedirectToAction(nameof(Index));
        }

        //private bool HorarioExists(int id)
        //{
        //    return _HorarioServices.Horarios.Any(e => e.Id == id);
        //}

        public async Task<IActionResult> Reservar(int id)
        {

            Horario horario = await _HorarioServices.GetHorarioByIdAsync(id);

            return View(horario);
        }
    }
}
