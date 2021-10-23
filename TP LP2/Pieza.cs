using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{

    public abstract class Pieza
    {
        char simbolo;
        protected Color color; //protected? no podíamos acceder sino
        protected Pieza(char simbolo_, Color color_) {
            this.simbolo = simbolo_;
            this.color = color_;
        }

        //analiza, de las mejores posiciones definidas para cada pieza, cuál es la mejor
        public abstract void colocarPieza();

        //hace un conteo de las posibles amenazas de la pieza en la posición
        public abstract int cuantasAmenaza(Pos posicion);

        protected void actualizarAmenazas()
        {
            Pos posicion;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posicion.x = i; posicion.y = j;
                    Global.tableroAmenazas.vaciarTablero();
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posicion.x = i; posicion.y = j;
                    switch (Global.tableroPiezas.getCaracter(posicion))
                    {
                        case 'Q':
                            Reina.colorearAtaque(posicion);
                            break;
                        case 'T':
                            Torre.colorearAtaque(posicion);
                            break;
                        case 'A':
                            Alfil.colorearAtaque(posicion);
                            break;
                        case 'C':
                            Caballo.colorearAtaque(posicion);
                            break;
                        case 'K':
                            Rey.colorearAtaque(posicion);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
