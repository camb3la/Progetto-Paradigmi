using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Requests
{
    public class GetLibriDaAutoreRequest
    {
        public string? Autore { get; set; }
        public int NumeroPagina { get; set; } = 1; // numero pagina settata di default
        public int DimensionePagina { get; set; } = 10;  // dimesione pagina settata di default

    }
}
