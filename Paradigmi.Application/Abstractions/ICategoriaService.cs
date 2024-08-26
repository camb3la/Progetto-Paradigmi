using Paradigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Abstractions
{
    public interface ICategoriaService
    {
        void CreaCategoria(Categoria categoria);
        void DeleteCategoria(int id);
    }
}
