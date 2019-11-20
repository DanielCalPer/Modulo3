using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EjercicioDepartamentos.Models;

    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext (DbContextOptions<DepartamentosContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Departamento> Departamento { get; set; }
    }
