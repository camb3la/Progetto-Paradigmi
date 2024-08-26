using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Request
{
    public class CreaCategoriaRequest
    {
        public string Nome { get; set; } = string.Empty;

        public Categoria ToEntity()
        {
            return new Categoria { Nome = Nome };

        }
    }
}
