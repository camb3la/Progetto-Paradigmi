using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Abstractions
{
    public interface IUtenteService
    {
        public void CreaUtente(Utente utente);
    }
}
