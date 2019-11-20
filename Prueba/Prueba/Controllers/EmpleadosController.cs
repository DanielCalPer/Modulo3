using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;


namespace Prueba.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index(string nombre)
        {
            List<Empleado> empleados = new List<Empleado>
            {
            new Empleado
            {
                Id = 1,
                Nombre = "Arrate",
                Apellido = "Ortiz de Zárate",
                FechaNacimiento = Convert.ToDateTime("25/06/1993"),
                Imagen = "https://e00-elmundo.uecdn.es/assets/multimedia/imagenes/2019/01/16/15476401681209.jpg",

            },
            new Empleado
            {
                Id = 2,
                Nombre = "Adrian",
                Apellido = "Rodriguez",
                FechaNacimiento = Convert.ToDateTime("20/04/1991"),
                Imagen = "https://a.espncdn.com/combiner/i?img=/i/headshots/nfl/players/full/10452.png",

            },
            new Empleado
            {
                Id = 3,
                Nombre = "Noelia",
                Apellido = "Minguez",
                FechaNacimiento = Convert.ToDateTime("20/10/1993"),
                Imagen = "https://laopinionla.files.wordpress.com/2019/08/noelia-candente.jpg?quality=80&strip=all&w=940",

            },
            new Empleado
            {
                Id = 4,
                Nombre = "Mauricio",
                Apellido = "Cavallini",
                FechaNacimiento = Convert.ToDateTime("20/04/1991"),
                Imagen = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Ochmann_1.jpg/220px-Ochmann_1.jpg",

            },
            new Empleado
            {
                Id = 5,
                Nombre = "Nagore",
                Apellido = "Reina",
                FechaNacimiento = Convert.ToDateTime("22/05/1995"),
                Imagen = "https://static.elnortedecastilla.es/www/multimedia/201810/11/media/cortadas/nagore-koVC-U601210592547yQ-624x385@El%20Norte.jpg",
            },

            };
            //Métodos Usaing System.Linq:
            // empleados.OrderBy(x => x.Apellido); //esto es una Lambda
            //empleados.Where(x => x.Nombre.Contains("l")).ToList();
            //empleados.Where(x => x.Nombre.Substring(0,1).Contains("N"));
            //empleados.Where(x => x.Nombre.Substring(0,1) =="N" && x.Nombre.Substring(1,1) == "o"); // con una segunda condicion
            //empleados.Where(x => x.Nombre[0] == 'N').ToList(); Otra manera de hacer lo anterior
            //Empleado empleado = empleados.FirstOrDefault(); Metodo vacio, saca el primero
            //Empleado empleado = empleados.FirstOrDefault(x => x.Nombre.Substring(0, 1) == "R"); lo anterior pero con más condiciones


            // return View(empleados.Where(x => x.Nombre.Substring(0, 1).Contains("N")).ToList());

            if (String.IsNullOrEmpty(nombre))
            {
                return View(empleados);
            }
            
            empleados = empleados.Where(x => x.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

            return View(empleados);

        }
        public IActionResult Detalle()
        {
            Empleado empleado = new Empleado
            {
                Id = 5,
                Nombre = "Nagore",
                Apellido = "Reina",
                FechaNacimiento = Convert.ToDateTime("22/05/1995"),
                Imagen = "https://static.elnortedecastilla.es/www/multimedia/201810/11/media/cortadas/nagore-koVC-U601210592547yQ-624x385@El%20Norte.jpg",
            };
            return View(empleado);
        }
    }
}