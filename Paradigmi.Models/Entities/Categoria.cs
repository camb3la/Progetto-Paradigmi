using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Paradigmi.Models.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Libro>? Libri { get; set; }

    }
}
