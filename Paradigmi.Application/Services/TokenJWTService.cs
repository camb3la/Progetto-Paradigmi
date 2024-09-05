using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Paradigmi.Application.Abstractions;
using Paradigmi.Application.Models.Requests;
using Paradigmi.Application.Options;
using Paradigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Services
{
    public class TokenJWTService : ITokenJWTService
    {
        private readonly JwtAuthenticationOption jwtAuthenticationOption;
        private readonly TokenJWTRepository _tokenJWTRepository;

        public TokenJWTService(IOptions<JwtAuthenticationOption> options, TokenJWTRepository tokenJWTRepository)
        {
            jwtAuthenticationOption = options.Value;
            _tokenJWTRepository = tokenJWTRepository;
        }

        public string CreaToken(CreaTokenJWTRequest request)
        {
            var utente = _tokenJWTRepository.GetUtente(request.Email, request.Password);

            var chiaveDiSicurezza = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthenticationOption.Key));
            var credenziali = new SigningCredentials(chiaveDiSicurezza, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(jwtAuthenticationOption.Issuer
                , null
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: credenziali
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;

        }
    }
}
