using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.DTOS
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public CategoriaDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nome = categoria.Nome;
        }

    }
}
