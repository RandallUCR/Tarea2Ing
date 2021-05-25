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
        int eliminar(int id);
        IEnumerable<Curso> consultar(string filtro);
        Curso getById(int id);
    }
}
