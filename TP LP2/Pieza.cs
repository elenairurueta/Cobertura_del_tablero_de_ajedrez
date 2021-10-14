using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{

    abstract class Pieza
    {
        char simbolo;
        Color color;
        protected Pieza(char simbolo_) {
            this.simbolo = simbolo_;
        }
        public abstract void colorearAtaque(Pos posicion);

        //analiza, de las mejores posiciones definidas para cada pieza, cuál es la mejor
        public abstract void colocarPieza();

        //hace un conteo de las posibles amenazas de la pieza en la posición (x,y)
        public abstract int cuantasAmenaza(Pos posicion);
    }
}
