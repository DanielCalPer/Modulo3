using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EjercicioDepartamentos2.Models;

    public class EjercicioDepartamentos2Context : DbContext
    {
        public EjercicioDepartamentos2Context (DbContextOptions<EjercicioDepartamentos2Context> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Empresa> Empresa { get; set; }
    }
