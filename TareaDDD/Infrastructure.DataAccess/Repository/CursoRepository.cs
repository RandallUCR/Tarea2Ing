﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain.Model.Abstractions;
using Domain.Model.Entities;

namespace Infrastructure.DataAccess.Repository
{
    public class CursoRepository : ConnectionSQL, ICursoRepository
    {
        public int editar(Curso curso)
        {
            throw new NotImplementedException();
        }

        public int eliminar(Curso curso)
        {
            throw new NotImplementedException();
        }

        public int insertar(Curso curso)
        {
            int result = 1;
            try
            {

                SqlDataReader dr = consultar($"EXEC insertar '{curso.siglas}','{curso.nombre}',{curso.creditos},{curso.cupos}");
                if (dr != null)
                {
                    dr.Read();
                    
                    result = int.Parse(dr[0].ToString());
                }
            }
            catch (SqlException e)
            {
                result = 1;
            }
            return result;
        }

        IEnumerable<Curso> ICursoRepository.consultar(string filtro)
        {
            List<Curso> data = new List<Curso>();
            try
            {

                SqlDataReader dr = consultar($"EXEC consultar '%{filtro}%'");
                if (dr != null)
                {

                    while (dr.Read())
                    {

                        Curso curso = new Curso();                    
                        curso.id = int.Parse(dr[0].ToString());
                        curso.siglas = dr[1].ToString();
                        curso.nombre = dr[2].ToString();
                        curso.creditos = int.Parse(dr[3].ToString());
                        curso.cupos = int.Parse(dr[4].ToString());

                        data.Add(curso);
                    }
                }
                else
                {
                    data.Add(null);
                }
            }
            catch (SqlException e)
            {
                data.Add(null);
            }
            return data;
        }
    }
}
