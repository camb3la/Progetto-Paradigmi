using Paradigmi.Application.Abstractions;
using Paradigmi.Models.Entities;
using Paradigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _libroRepository;
        public LibroService(LibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public void CreaLibro(Libro libro)
        {
            _libroRepository.Add(libro);
            _libroRepository.Save();
        }

        public void EliminaLibro(int id)
        {
            var libro = _libroRepository.Get(id);
            _libroRepository.Delete(libro);
            _libroRepository.Save();
        }

        public void AggiornaLibro(int id, Libro libro)
        {
            _libroRepository.AggiornaLibro(id, libro);
            _libroRepository.Save();
        }

        public Libro GetLibro(int id)
        {
            return _libroRepository.Get(id);
        }

        public Libro GetLibroNome(string nome)
        {
            return _libroRepository.GetLibroNome(nome);
        }

        public async Task<List<Libro>> GetLibroDaAutore(string autore, int numeroPagina, int dimensionePagina)
        {
            return await _libroRepository.GetLibroDaAutore(autore, numeroPagina, dimensionePagina);
        }

        public async Task<List<Libro>> GetLibroDaCategoria(string categoria, int numeroPagina, int dimensionePagina)
        {
            return await _libroRepository.GetLibriDaCategoria(categoria, numeroPagina, dimensionePagina);
        }

        public async Task<List<Libro>> GetLibroDaDataPubblicazione(DateTime dataPubblicazione, int numeroPagina, int dimensionePagina)
        {
            return await _libroRepository.GetLibriDaDataPubblicazione(dataPubblicazione, numeroPagina, dimensionePagina);
        }

     
    }
}
