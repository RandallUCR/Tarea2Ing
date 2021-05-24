using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model.Entities;

namespace Domain.Model.Abstractions
{
    public interface ICursoRepository
    {
        int insertar(Curso curso);
        int editar(Curso curso);
        int eliminar(Curso curso);
        IEnumerable<Curso> consultar(string filtro);
    }
}
