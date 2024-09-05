using Paradigmi.Models.Context;
using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Models.Repositories
{
    public class TokenJWTRepository
    {
        private MyDbContext _ctx;

        public TokenJWTRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public Utente GetUtente(string email, string password)
        {
            var utente = _ctx.Utente.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return utente;
        }

    }
}
