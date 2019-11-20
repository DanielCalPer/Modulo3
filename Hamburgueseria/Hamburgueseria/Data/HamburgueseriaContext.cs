using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hamburgueseria.Models;

public class HamburgueseriaContext : DbContext
{
    public HamburgueseriaContext(DbContextOptions<HamburgueseriaContext> options)
        : base(options)
    {
    }

    public DbSet<Menu> Menu { get; set; }
    public DbSet<Principal> Principales { get; set; }
    public DbSet<Entrante> Entrantes { get; set; }
    public DbSet<Postre> Postres { get; set; }
}
