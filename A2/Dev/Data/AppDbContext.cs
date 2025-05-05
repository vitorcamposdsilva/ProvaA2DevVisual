using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev.Data
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions options) : base(options) { }

         public DbSet<Usuario> Usuarios { get; set; }
         public DbSet<Evento> Eventos { get; set; }
    }
}