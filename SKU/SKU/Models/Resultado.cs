using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKU.Models
{
    public class Resultado
    {
        public int resultado { get; set; }
        public string mensajeResultado { get; set; }

        public void OperacionExitosa() {
            resultado = 0;
            mensajeResultado = "Operacion Exitosa";
        }
        public void OperacionFallida()
        {
            resultado = -1;
            mensajeResultado = "La operacion no se pudo realizar";
        }
    }
}
