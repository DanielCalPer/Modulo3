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
    public class BoxUserHorariosController : Controller
    {
        private readonly IBoxUserHorario _BoxUserHorarioServices;
        private readonly UserManager<BoxUser> _boxUser;
        

        public BoxUserHorariosController(IBoxUserHorario boxUserHorarioServices, UserManager<BoxUser> boxUser)
        {
            _BoxUserHorarioServices = boxUserHorarioServices;
            _boxUser = boxUser;
            
            
        }

        // GET: BoxUserHorarios
        public async Task<IActionResult> Index(string userName, string name,  DateTime hora)
        {
            List<BoxUserHorario> listaBoxUserHorarios = await _BoxUserHorarioServices.GetBoxUserHorarioAsync();

            if (String.IsNullOrEmpty(name) && hora.ToString("dd/MM/yyyy") == "01/01/0001" && String.IsNullOrEmpty(userName))
            {
                return View(listaBoxUserHorarios);
            }
            if (!String.IsNullOrEmpty(userName))
            {
                listaBoxUserHorarios = listaBoxUserHorarios.Where(x => x.BoxUser.FirstName == userName).ToList();
            }
            if (!String.IsNullOrEmpty(name))
            {
                listaBoxUserHorarios = listaBoxUserHorarios.Where(x => x.Horario.Clase.Nombre == name).ToList();
            }
            if (hora.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                listaBoxUserHorarios = listaBoxUserHorarios.Where(x => x.Horario.Dia == hora.Date).ToList();
                
            }


            return View(listaBoxUserHorarios);
        }

        // GET: BoxUserHorarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxUserHorario = await _BoxUserHorarioServices.GetBoxUserHorarioByIdAsync(id);


            if (boxUserHorario == null)
            {
                return NotFound();
            }

            return View(boxUserHorario);
        }

        // GET: BoxUserHorarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoxUserHorarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoxUserId,HorarioId")] BoxUserHorario boxUserHorario)
        {
            if (ModelState.IsValid)
            {
                await _BoxUserHorarioServices.CreateBoxUserHorarioAsync(boxUserHorario);

                return RedirectToAction(nameof(Index));
            }
            return View(boxUserHorario);
        }

        // GET: BoxUserHorarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxUserHorario = await _BoxUserHorarioServices.GetBoxUserHorarioByIdAsync(id);
            if (boxUserHorario == null)
            {
                return NotFound();
            }
            return View(boxUserHorario);
        }

        // POST: BoxUserHorarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoxUserId,HorarioId")] BoxUserHorario boxUserHorario)
        {
            if (id != boxUserHorario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _BoxUserHorarioServices.UpdateBoxUserHorarioAsync(boxUserHorario);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_BoxUserHorarioServices.BoxUserHorarioExist(boxUserHorario.Id))
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
            return View(boxUserHorario);
        }

        // GET: BoxUserHorarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxUserHorario = await _BoxUserHorarioServices.GetBoxUserHorarioByIdAsync(id);

            if (boxUserHorario == null)
            {
                return NotFound();
            }

            BoxUser user = await _boxUser.GetUserAsync(User);

            if (!await _boxUser.IsInRoleAsync(user, "Administrador"))
            {
                if (boxUserHorario.Horario.Hora <= DateTime.Now.AddMinutes(+30))
                {
                    return View("Listillo");
                }

            }

            
            return View(boxUserHorario);
        }

        // POST: BoxUserHorarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boxUserHorario = await _BoxUserHorarioServices.GetBoxUserHorarioByIdAsync(id);
            await _BoxUserHorarioServices.DeleteBoxUserHorarioAsync(boxUserHorario);

            
                BoxUser user = await _boxUser.GetUserAsync(User);

            if (await _boxUser.IsInRoleAsync(user, "Administrador"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(MisClases));
            }
                
            
        }


        
        [HttpPost]
        public async Task<IActionResult> ValidarClase(int Id)
        {
            BoxUser user = await _boxUser.GetUserAsync(User);

            BoxUserHorario boxUserHorario = new BoxUserHorario()
            {
                BoxUserId = user.Id,
                HorarioId = Id
            };

            List<BoxUserHorario> listaBoxUserHorario = await _BoxUserHorarioServices.GetBoxUserHorarioAsync();

            listaBoxUserHorario = listaBoxUserHorario.Where(x => x.BoxUserId == user.Id).ToList();

            foreach (BoxUserHorario item in listaBoxUserHorario)
            {
                if ((item.HorarioId == Id))
                {
                    return View("ClaseRepetida");
                }
                 
            }

            if (await _boxUser.IsInRoleAsync(user, "Terricola") && listaBoxUserHorario.Count >= 5)
            {
                return View("LimiteClasesExcedido");
            }
            if (await _boxUser.IsInRoleAsync(user, "Namekiano") && listaBoxUserHorario.Count >= 10)
            {
                return View("LimiteClasesExcedido");
            }
            if (await _boxUser.IsInRoleAsync(user, "Sayan") && listaBoxUserHorario.Count >= 15)
            {
                return View("LimiteClasesExcedido");
            }

            List<BoxUserHorario> listaBoxUserHorario2 = await _BoxUserHorarioServices.GetBoxUserHorarioAsync();

            listaBoxUserHorario2 = listaBoxUserHorario2.Where(x => x.HorarioId == Id).ToList();

            if(listaBoxUserHorario2.Count >= 3)
            {
                return View("LimiteClase");
            }

            await _BoxUserHorarioServices.CreateBoxUserHorarioAsync(boxUserHorario);

            return RedirectToAction("Index", "Clases");
        }

        [Authorize(Roles="Terricola, Namekiano, Sayan")]
        public async Task<IActionResult> MisClases()
        {
            
            BoxUser user = await _boxUser.GetUserAsync(User);

            List<BoxUserHorario> userHorario = await _BoxUserHorarioServices.GetBoxUserHorarioAsync();

            userHorario = userHorario.Where(x => x.BoxUserId == user.Id).OrderBy(x => x.Horario.Dia).ToList();


            return View(userHorario);
        }

    }
}
