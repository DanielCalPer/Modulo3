using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionBox.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionBox.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class BoxUsersController : Controller
    {
        private readonly UserManager<BoxUser> _boxUser;


        public BoxUsersController(UserManager<BoxUser> boxUser)
        {
            _boxUser = boxUser;

        }
        public async Task<IActionResult> Index(string role, string name)
        {
            
            IEnumerable<BoxUser> users = _boxUser.Users.ToList(); // todos los usuarios logeados en una lista

            if (!String.IsNullOrEmpty(role))
            {
                users = users.Where(x => x.Tarifa == role);
            }

            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(x => x.FirstName.ToLower().Contains(name.ToLower()));
            }

            return View(users);

        }
        public async Task<IActionResult> Edit(string id, string role)
        {

            BoxUser user = await _boxUser.FindByIdAsync(id);

            if (String.IsNullOrEmpty(role))
            {
                role = "Terricola";
                return View(user);
            }
            if (!String.IsNullOrEmpty(role))
            {
                await _boxUser.RemoveFromRoleAsync(user, "Sayan");
                await _boxUser.RemoveFromRoleAsync(user, "Terricola");
                await _boxUser.RemoveFromRoleAsync(user, "Namekiano");

                user.Tarifa = role;

                await _boxUser.AddToRoleAsync(user, role);
                await _boxUser.UpdateAsync(user);
            }

            return RedirectToAction("index", "BoxUsers");
        }

    }
}