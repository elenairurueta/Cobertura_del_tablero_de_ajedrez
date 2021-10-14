using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Rey : Pieza
    {
        public Rey() : base('K')
        { }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            posAux.x++; 
            if (Global.tableroPiezas.getChar(posAux) != '0') 
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.y++;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);

            posAux = posicion;
            posAux.y++;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.x--;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);

            posAux = posicion;
            posAux.x--;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.y--;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);

            posAux = posicion;
            posAux.y--;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.x++;
            if (Global.tableroPiezas.getChar(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);


        }


    }
}
