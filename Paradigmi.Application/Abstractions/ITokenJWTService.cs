using Paradigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Abstractions
{
    public interface ITokenJWTService
    {
        string CreaToken(CreaTokenJWTRequest request);
    }
}
