using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenParcialPrograIX.Models;

namespace ExamenParcialPrograIX.Data
{
    public class ExamenParcialPrograIXContext : DbContext
    {
        public ExamenParcialPrograIXContext (DbContextOptions<ExamenParcialPrograIXContext> options)
            : base(options)
        {
        }

        public DbSet<ExamenParcialPrograIX.Models.Estudiante> Estudiante { get; set; }
    }
}
