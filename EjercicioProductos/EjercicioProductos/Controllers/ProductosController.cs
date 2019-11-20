using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EjercicioProductos.Models;

namespace EjercicioProductos.Controllers
{
    public class ProductosController : Controller
    {
        public List<Producto> Productos { get; set; }

        public ProductosController()
        {
            Productos = new List<Producto>() // para meter la lista cuando acceda al controller directamente

            {
            new Producto
            {
                Id = 1,
                Nombre = "Mandarina",
                Descripcion = "Clementina",
                Tipo = "Alimentacion",
                Precio = 1,
                FechaCaducidad = Convert.ToDateTime("31/12/2019"),
                Imagen = "https://comefruta.es/wp-content/uploads/mandarina-orri.jpg",

            },
            new Producto
            {
                Id = 2,
                Nombre = "Manzana",
                Descripcion = "Golden",
                Tipo = "Alimentacion",
                Precio = 2,
                FechaCaducidad = Convert.ToDateTime("31/10/2019"),
                Imagen = "https://static.biit.es/public/frontend/FontDeVida/img/catalog/items/manzana-juliet.jpg",
            },
            new Producto
            {
                Id = 3,
                Nombre = "Platano",
                Descripcion = "Canarias",
                Tipo = "Alimentacion",
                Precio = 3,
                FechaCaducidad = Convert.ToDateTime("31/10/2019"),
                Imagen = "http://innatia.info/images/galeria/platano-2.jpg",
            },
            new Producto
            {
                Id = 4,
                Nombre = "Cuchillo",
                Descripcion = "Acero Valirio",
                Tipo = "Menaje",
                Precio = 4,
                FechaCaducidad = Convert.ToDateTime("31/12/2030"),
                Imagen = "https://www.lecreuset.es/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/u/cuchillo-mango-olivo-chef-20cm-le-creuset.jpg",
            },
            new Producto
            {
                Id = 5,
                Nombre = "Tenedor",
                Descripcion = "Acero Forjado",
                Tipo = "Menaje",
                Precio = 5,
                FechaCaducidad = Convert.ToDateTime("31/12/2030"),
                Imagen = "https://sanluis.cl/3752-large_default/tenedor-mesa-acero-inoxidable-jenny.jpg"
            },
            new Producto
            {
                Id = 6,
                Nombre = "Cuchara",
                Descripcion = "Madera",
                Tipo = "Menaje",
                Precio = 6,
                FechaCaducidad = Convert.ToDateTime("31/12/2035"),
                Imagen = "https://www.moven.com.mx/wp-content/uploads/2018/06/maya-cuchara-sopera.jpg"
            }
        };
            
        }

        public IActionResult Index( string tipo, string nombre)
        {
           
            //ViewData["productos"] = Productos.OrderBy(x => x.Nombre).ToList(); // viewData no tiene tipado. 
            //ViewBag.Nombre = "Arrate";

            ViewData["tipos"] = Productos.Select(x => x.Tipo).Distinct().ToList();

            if (String.IsNullOrEmpty(tipo) && String.IsNullOrEmpty(nombre))
            {
               
                return View(Productos);
            }
            if (!String.IsNullOrEmpty(tipo))
            {

                Productos = Productos.Where(x => x.Tipo == tipo).ToList(); 
            }
            if (!String.IsNullOrEmpty(nombre)) 
            {
                Productos = Productos.Where(x => x.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
            }

            //return View(Productos.Where(x=>x.Tipo == tipo).ToList());
            //productos = productos.Where(x => x.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

            //return View(Productos.Where(x => x.Nombre.ToLower().Contains(nombre.ToLower()) 
            //&& x.Tipo.ToLower().Contains(tipo.ToLower())).ToList());

            return View(Productos);
        }
        public IActionResult ProductosPrecio()
        {
            return View(Productos.OrderByDescending(x => x.Precio).ToList());
        }
        public IActionResult ProductosTipo()
        {
            
            return View(Productos.OrderBy(x => x.Tipo).ToList());
        }
    }
}