﻿using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Models.DTOS
{
    public class LibroDTO
    {
        public LibroDTO()
        {
        }

        public LibroDTO(Libro libro)
        {
            Id = libro.id;
            Nome = libro.Nome;
            Autore = libro.Autore;
            DataPubblicazione = libro.DataPubblicazione;
            Editore = libro.Editore;

            Categorie = libro.Categorie;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; }
        public string Editore { get; set; } = string.Empty;

        public virtual ICollection<Categoria> Categorie { get; set; }
    }
}
