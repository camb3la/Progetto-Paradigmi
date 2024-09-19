using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Models.Context;
using Paradigmi.Models.Entities;

namespace Paradigmi.Models.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public LibroRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public void CreaLibro(Libro libro, ICollection<string> nomicategorie)
        {
            var categorie = _ctx.Categoria.Where(c => nomicategorie.Contains(c.Nome)).ToList();

            // Verifica che tutte le categorie siano state trovate
            if (categorie.Count != nomicategorie.Count)
            {
                throw new Exception("Una o più categorie non sono state trovate.");
            }

            libro.Categorie = categorie;

            _ctx.Libro.Add(libro);

            _ctx.SaveChanges();
        }

        public void AggiornaLibro(int id, Libro libro)
        {
            var libroDaAggiornare = _ctx.Libro.Find(id);
            if (libroDaAggiornare == null)
            {
                return;
            }

            libroDaAggiornare.Nome = libro.Nome;
            libroDaAggiornare.Autore = libro.Autore;
            libroDaAggiornare.DataPubblicazione = libro.DataPubblicazione;
            libroDaAggiornare.Editore = libro.Editore;

            Update(libroDaAggiornare);
        }


        public Libro GetLibroNome(string nome)
        {
            return _ctx.Libro.First(l => l.Nome == nome);
        }

        public async Task<List<Libro>> GetLibroDaAutore(string autore, int numeroPagina, int dimensionePagina)
        {
            var query = _ctx.Libro.Where(b => b.Autore == autore);

            var libri = await query
                .Skip((numeroPagina - 1) * dimensionePagina)
                .Take(dimensionePagina)
                .ToListAsync();

            return libri;
        }


        public async Task<List<Libro>> GetLibriDaCategoria(string categoria, int numeroPagina, int dimensionePagina)
        {
            var query = _ctx.Libro.Where(l => l.Categorie!.Any(c => c.Nome == categoria));

            var libri = await query
                .Skip((numeroPagina - 1) * dimensionePagina)
                .Take(dimensionePagina)
                .ToListAsync();

            return libri;
        }

        public async Task<List<Libro>> GetLibriDaDataPubblicazione(DateTime dataPubblicazione, int numeroPagina, int dimensionePagina)
        {
            var query = _ctx.Libro.Where(b => b.DataPubblicazione == dataPubblicazione);

            var libri = await query
                .Skip((numeroPagina - 1) * dimensionePagina)
                .Take(dimensionePagina)
                .ToListAsync();

            return libri;
        }





        



    }
}
