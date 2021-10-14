using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Torre : Pieza
    {
        public Torre() : base('T')
        {

        }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            bool seguirFatal = true;

            //Para arriba
            do
            {
                posAux.y--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y > 0);

            //Para abajo
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y < 7);
        }
    }
}
