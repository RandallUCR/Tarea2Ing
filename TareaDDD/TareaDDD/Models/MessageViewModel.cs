using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaDDD.Models
{
    public class MessageViewModel
    {
        public int result { set; get; }

        public MessageViewModel(int result)
        {
            this.result = result;
        }

        public string toString()
        {
            if (this.result == 0)
            {
                return "¡Operacion exitosa!";
            }
            else
            {
                return "¡Error en la operacion!";
            }
        }
    }
}
