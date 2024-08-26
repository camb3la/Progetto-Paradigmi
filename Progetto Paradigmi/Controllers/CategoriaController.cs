using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Paradigmi.Application.Abstractions;
using Paradigmi.Application.Models.Request;
using Paradigmi.Application.Models.DTOS;
using Paradigmi.Application.Models.Responses;

namespace Progetto_Paradigmi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;


        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreaCategoria(CreaCategoriaRequest request)
        {
            var categoria = request.ToEntity();
            _categoriaService.CreaCategoria(categoria);

            var response = new CreaCategoriaResponse();
            response.Categoria = new CategoriaDTO(categoria);
            return Ok(response);
        }


        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult DeleteCategoria(int id)
        {
            _categoriaService.DeleteCategoria(id);
            return Ok();
        }

    }
}
