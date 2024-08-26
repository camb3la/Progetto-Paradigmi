using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Abstractions
{
    public interface ILibroService
    {

        void CreaLibro(int id);

        void CreaLibro(Libro libro);

        void AggiornaLibro(int id, Libro libro);

        void EliminaLibro(int id);

        Libro GetLibro(int id);

        Libro GetLibroNome(string nome);

        List<Libro> GetLibroCategoria(string  categoria);

        List<Libro> GetLibroAutore(string autore);

        List<Libro> GetLibroDataPubblicazione(DateTime dataPublicazione);
    }
}
