using Paradigmi.Models.Entities;
using Paradigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Services
{
    public class LibroService
    {
        private readonly LibroRepository _libroRepository;
        public LibroService(LibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public void CreaLibro(Libro libro)
        {
            _libroRepository.Add(libro);
        }

        public void EliminaLibro(Libro libro)
        {
            _libroRepository.Delete(libro);
        }

        public Libro GetLibroNome(string nome)
        {
            return _libroRepository.GetLibroNome(nome);
        }
    }
}
