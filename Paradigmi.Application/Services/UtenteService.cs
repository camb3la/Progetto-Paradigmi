using Paradigmi.Application.Abstractions;
using Paradigmi.Models.Entities;
using Paradigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        public void CreaUtente(Utente utente)
        {
            _utenteRepository.Add(utente);
            _utenteRepository.Save();
        }
    }
}
