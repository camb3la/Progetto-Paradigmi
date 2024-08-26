using Paradigmi.Application.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Responses
{
    public class CreaLibroResponse
    {
        public LibroDTO Libro { get; set; } = null!;
    }
}
