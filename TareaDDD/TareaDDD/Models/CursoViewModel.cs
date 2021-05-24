using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaDDD.Models
{
    public class CursoViewModel
    {
        public int id { set; get; }
        public string siglas { set; get; }
        public string nombre { set; get; }
        public int creditos { set; get; }
        public int cupos { set; get; }

        //Validaciones
    }
}
