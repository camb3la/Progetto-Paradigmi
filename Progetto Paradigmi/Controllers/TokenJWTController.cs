using Microsoft.AspNetCore.Mvc;
using Paradigmi.Application.Abstractions;
using Paradigmi.Application.Models.Requests;
using Paradigmi.Application.Models.Responses;

namespace Progetto_Paradigmi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenJWTService _tokenService;

        public TokenController(ITokenJWTService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreaTokenJWTRequest request)
        {
            string token = _tokenService.CreaToken(request);
            return Ok(new CreaTokenJWTResponse(token));
        }
    }
}

