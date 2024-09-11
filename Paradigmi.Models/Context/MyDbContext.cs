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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
        .HasMany(l => l.Categorie)
        .WithMany(c => c.Libri)
        .UsingEntity<Dictionary<string, object>>(
            "LibroCategoria",  // Nome della tabella di join
            j => j.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId"), // Configurazione della chiave esterna per Categoria
            j => j.HasOne<Libro>().WithMany().HasForeignKey("LibroId"), // Configurazione della chiave esterna per Libro
            j =>
            {
                j.ToTable("LibroCategoria");
                j.Property<int>("LibroId").HasColumnName("LibroId"); 
                j.Property<int>("CategoriaId").HasColumnName("CategoriaId");
            }
        );
        }




    }
}
