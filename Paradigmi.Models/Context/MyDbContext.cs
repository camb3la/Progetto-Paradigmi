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

        public DbSet<Categoria> Categoria { get; set; }

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        //DESKTOP-1EL088M
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User Id=manager;Password=a;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(optionsBuilder);
        }




    }
}
