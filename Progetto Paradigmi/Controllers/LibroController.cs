using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Application.Services;
using Paradigmi.Application.Abstractions;
using Paradigmi.Models.Entities;
using Paradigmi.Application.Models.Requests;
using Paradigmi.Application.Models.DTOS;
using Paradigmi.Application.Models.Responses;

namespace Progetto_Paradigmi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }


        [HttpPost]
        [Route("new")]
        public IActionResult CreateLibro(CreaLibroRequest request)
        {
            var libro = request.ToEntity();
            _libroService.CreaLibro(libro);

            var response = new CreaLibroResponse();
            response.Libro = new LibroDTO(libro);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult DeleteLibro(int id)
        {
            _libroService.EliminaLibro(id);
            return Ok();
        }



        [HttpGet]
        [Route("get/nome")]
        public Libro GetLibroDaNome(string nome)
        {
            return _libroService.GetLibroNome(nome);
        }


    }
}

