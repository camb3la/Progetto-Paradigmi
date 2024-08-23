﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Models.Entities
{
    public class Libro
    {
        public int id {  get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Autore { get; set; } = string.Empty;

        public string Editore { get; set; } = string.Empty;

        public DateTime DataPubblicazione { get; set; }

    }
}
