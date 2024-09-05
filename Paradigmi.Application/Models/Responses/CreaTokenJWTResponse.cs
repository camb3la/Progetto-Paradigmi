using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Responses
{
    public class CreaTokenJWTResponse
    {
        public string Token { get; set; } = string.Empty;

        public CreaTokenJWTResponse(string token)
        {
            Token = token;
        }
        
    }
}
