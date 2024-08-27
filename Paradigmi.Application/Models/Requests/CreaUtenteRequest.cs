using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Requests
{
    public class CreaUtenteRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Utente ToEntity()
        {
            var utente = new Utente
            {
                Email = Email,
                Nome = Nome,
                Cognome = Cognome,
                Password = Password
            };

            return utente;
        }
    }
}
