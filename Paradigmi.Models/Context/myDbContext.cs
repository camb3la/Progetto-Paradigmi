using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Models.Entities;

namespace Paradigmi.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet <Libro> Libro { get; set; }

        public DbSet <Utente> Utente { get; set; }

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }


    }
}
