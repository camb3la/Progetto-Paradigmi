using Microsoft.AspNetCore.Mvc;
using Paradigmi.Application.Abstractions;
using Paradigmi.Application.Models.DTOS;
using Paradigmi.Application.Models.Requests;
using Paradigmi.Application.Models.Responses;

namespace Progetto_Paradigmi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;
        
        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreaUtente(CreaUtenteRequest request)
        {
            var utente = request.ToEntity();
            _utenteService.CreaUtente(utente);

            var response = new CreaUtenteResponse();
            response.Utente = new UtenteDTO(utente);
            return Ok(response);
        }
    }
}
