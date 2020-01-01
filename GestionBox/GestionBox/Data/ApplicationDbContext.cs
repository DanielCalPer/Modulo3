using System;
using System.Collections.Generic;
using System.Text;
using GestionBox.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionBox.Data
{
    public class ApplicationDbContext : IdentityDbContext<BoxUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BoxUser> BoxUsers { get; set; }
        public DbSet<BoxUserHorario> BoxUserHorarios { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Horario> Horarios { get; set; }
    }
}
