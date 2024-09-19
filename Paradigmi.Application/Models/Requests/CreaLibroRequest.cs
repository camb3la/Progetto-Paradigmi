using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.Requests
{
    public class CreaLibroRequest
    {
        public string Nome {  get; set; } = string.Empty;

        public string Autore {  get; set; } = string.Empty;

        public DateTime DataPubblicazione { get; set; }

        public string Editore { get; set; } = string.Empty;

        public ICollection<string>? Categorie {  get; set; }

        public Libro ToEntity()
        {
            var libro = new Libro
            {
                Nome = Nome,
                Autore = Autore,
                DataPubblicazione = DataPubblicazione,
                Editore = Editore,
                Categorie = new List<Categoria>()
            };

            return libro;
        }
    }
}
