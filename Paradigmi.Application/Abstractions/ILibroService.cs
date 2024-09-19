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

        void CreaLibro(Libro libro, ICollection<string> categorie);

        void AggiornaLibro(int id, Libro libro);

        void EliminaLibro(int id);

        Libro GetLibroNome(string nome);

        Task<List<Libro>> GetLibroDaAutore(string autore, int numeroPagina, int dimensionePagina);

        Task<List<Libro>> GetLibroDaCategoria(string categoria, int numeroPagina, int dimensionePagina);

        Task<List<Libro>> GetLibroDaDataPubblicazione(DateTime dataPubblicazione, int numeroPagina, int dimensionePagina);
    }
}
