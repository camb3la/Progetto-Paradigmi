using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.DTOS
{
    public class UtenteDTO
    {

        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Cognome { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        
        public UtenteDTO(Utente utente)
        {
            Id = utente.Id;
            Email = utente.Email;
            Nome = utente.Nome; 
            Cognome = utente.Cognome;
            Password = utente.Password;
        }

    }
}
