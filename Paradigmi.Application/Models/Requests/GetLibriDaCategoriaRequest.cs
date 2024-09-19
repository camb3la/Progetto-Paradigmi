using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Requests
{
    public class GetLibriDaCategoriaRequest
    {
        public required string Categoria {  get; set; }
        public int NumeroPagina { get; set; } = 1; // numero pagina settada di default
        public int DimensionePagina { get; set; } = 10;  // dimesione pagina settada di default
    }
}
