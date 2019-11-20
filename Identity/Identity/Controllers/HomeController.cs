using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager )
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Administrador()
        {
            if (_signInManager.IsSignedIn(User))
            {
                IdentityUser user = await _userManager.GetUserAsync(User); // metodo GetUser necesita el objeto usuario.(el método está así hecho).  

                if (await _userManager.IsInRoleAsync(user, "Administrador"))
                {
                    return View();
                }
            }
            return Error();
        }
        public IActionResult Privacy()
        {

            if (_signInManager.IsSignedIn(User)) //al anular el método, tb anulamos la entrada por URL 
            { 
            return View();
            }
            return NotFound(); // a veces Error() casa, puedes usar NotFound()
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
