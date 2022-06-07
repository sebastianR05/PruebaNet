using DataConnection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        //Tablas
        public DbSet<Persona> persona { get; set; }
        public DbSet<InformacionContacto> informacionContacto { get; set; }
    }
}
