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
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void CreaCategoria(Categoria categoria)
        {
            _categoriaRepository.CreaCategoria(categoria);
            _categoriaRepository.Save();
        }

        public void EliminaCategoria(int id)
        {
            _categoriaRepository.EliminaCategoria(id);
            _categoriaRepository.Save();
        }
    }
}
