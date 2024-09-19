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
            _libroService.CreaLibro(libro, request.Categorie!);

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


        [HttpPut]
        [Route("update")]
        public IActionResult AggiornaLibro(AggiornaLibroRequest request)
        {
            var libro = request.ToEntity();
            _libroService.AggiornaLibro(request.Id, libro);

            var response = new AggiornaLibroResponse();
            response.Libro = new LibroDTO(libro);
            return Ok(response);
        }


        [HttpGet]
        [Route("get/nome")]
        public Libro GetLibroDaNome(string nome)
        {
            return _libroService.GetLibroNome(nome);
        }

        [HttpPost]
        [Route("get/autore")]
        public async Task<IActionResult> GetLibriDaAutore(GetLibriDaAutoreRequest request)
        {
            var libri = await _libroService.GetLibroDaAutore(request.Autore!, request.NumeroPagina, request.DimensionePagina);
            return Ok(libri);
        }

        [HttpPost]
        [Route("get/categoria")]
        public async Task<IActionResult> GetLibriDaCategoria(GetLibriDaCategoriaRequest request)
        {
            var libri = await _libroService.GetLibroDaCategoria(request.Categoria, request.NumeroPagina, request.DimensionePagina);
            return Ok(libri);
        }

        [HttpPost]
        [Route("get/data")]
        public async Task<IActionResult> GetLibriDaDataPubblicazioneAsync(GetLibriDaDataPubblicazioneRequest request)
        {
            var libri = await _libroService.GetLibroDaDataPubblicazione(request.DataPubblicazione, request.NumeroPagina, request.DimensionePagina);
            return Ok(libri);
        }


    }
}

