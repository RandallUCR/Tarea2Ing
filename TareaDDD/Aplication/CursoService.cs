using System;
using System.Collections.Generic;
using Domain.Model.Abstractions;
using Domain.Model.Entities;
using Infrastructure.DataAccess.Repository;

namespace Aplication
{
    public class CursoService

    {
        readonly ICursoRepository cursoRepository;
        public CursoService()
        {
            cursoRepository = new CursoRepository();
        }

        public IEnumerable<Curso> consultar(string filtro)
        {
            return cursoRepository.consultar(filtro);
        }

        public int insertar(Curso curso)
        {
            return cursoRepository.insertar(curso);
        }

        public Curso consultarById(int id)
        {
            return cursoRepository.getById(id);
            //return new Curso { id = id, siglas = "", nombre = "", creditos = 1, cupos = 1 };
        }

        public int editar(Curso curso)
        {
            return cursoRepository.editar(curso);
        }

        public int eliminar(int id)
        {
            return cursoRepository.eliminar(id);
        }
    }
}
