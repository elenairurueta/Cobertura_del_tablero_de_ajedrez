using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Alfil : Pieza
    {
        public Alfil() : base('A')
        {

        }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            bool seguirFatal = true;

            //Diagonal abajo derecha
            do
            {
                posAux.y++; posAux.x++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y < 7 && posAux.x < 7);

            //Diagonal arriba derecha
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y--; posAux.x++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y > 0 && posAux.x < 7);

            //Diagonal abajo izquierda
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y++; posAux.x--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y < 7 && posAux.x > 0);

            //Diagonal arriba izquierda
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y--; posAux.x--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y > 0 && posAux.x > 0);
        }
    }
}
