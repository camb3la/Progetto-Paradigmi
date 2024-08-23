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

        
    }
}
