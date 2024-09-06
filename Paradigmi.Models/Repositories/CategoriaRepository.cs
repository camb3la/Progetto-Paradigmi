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
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext ctx) : base(ctx) 
        {
            
        }

        public void CreaCategoria(Categoria categoria)
        {
            if (_ctx.Categoria.Any(c => c.Nome == categoria.Nome))
            {
                throw new InvalidOperationException("Esiste una categoria con questo nome");
            }
            else
            {
                Add(categoria);
            }
        }

        
        public void EliminaCategoria(int id)
        {
            if (CategoriaHaLibri(id))
            {
                throw new Exception("La categoria che si vuole eliminare ha dei libri associati");
            }


            var categoria = _ctx.Categoria.FirstOrDefault(c => c.Id == id); // Errore se CategorieId non è un nome di colonna valido
            if (categoria != null)
            {
                _ctx.Categoria.Remove(categoria);
                _ctx.SaveChanges();
            }

        }


        public bool CategoriaHaLibri(int id)
        {
            var categoria = _ctx.Categoria.Include(c => c.Libri).FirstOrDefault(c => c.Id == id);
            return categoria != null && categoria.Libri.Any();
        }


    }
}
