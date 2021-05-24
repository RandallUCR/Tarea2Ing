using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Entities
{
    public class Curso
    {
        public int id { set; get; }
        public string siglas { set; get; }
        public string nombre { set; get; }
        public int creditos { set; get; }
        public int cupos { set; get; }

        public Curso()
        {

        }

        public Curso(string siglas, string nombre, int creditos, int cupos)
        {
            this.siglas = siglas;
            this.nombre = nombre;
            this.creditos = creditos;
            this.cupos = cupos;
        }
    }
}
