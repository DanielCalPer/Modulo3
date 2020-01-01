using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicios.Models;

    public class ServiciosContext : DbContext
    {
        public ServiciosContext (DbContextOptions<ServiciosContext> options)
            : base(options)
        {
        }

        public DbSet<Videojuego> Videojuegos { get; set; }
    }
