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
            var categoria = _ctx.Categoria.Include(c => c.Libri).FirstOrDefault(c => c.Id == id);

            if (categoria == null)
            {
                throw new Exception("Categoria con ID: " + id + " non trovata");
            }
            else if(categoria.Libri.Count > 0)
            {
                throw new InvalidOperationException("Questa categoria ha dei libri associati e non puo essere eliminata");
            }
            else
            {
                Delete(categoria);
            }

        }
    }
}
