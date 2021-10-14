using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Caballo : Pieza
    {
        public Caballo() : base('C')
        { }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            //Para arriba
            posAux.y--;
            if (Global.tableroPiezas.getChar(posAux) != '0')
            {
                posAux.y--;
                posAux.x++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
                posAux.x -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);
                posAux.y--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                {
                    posAux.x++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                    posAux.x -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x++;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x -= 2;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }

            }
            //Para abajo
            posAux.y++;
            if (Global.tableroPiezas.getChar(posAux) != '0')
            {
                posAux.y++;
                posAux.x++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
                posAux.x -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);
                posAux.y++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                {
                    posAux.x++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                    posAux.x -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x++;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x -= 2;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }
            }

            //Para derecha
            posAux.x++;
            if (Global.tableroPiezas.getChar(posAux) != '0')
            {
                posAux.x++;
                posAux.y++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
                posAux.y -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);
                posAux.x++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                {
                    posAux.y++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                    posAux.y -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x++;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x -= 2;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }
            }
            //Para izquierda
            posAux.x--;
            if (Global.tableroPiezas.getChar(posAux) != '0')
            {
                posAux.x--;
                posAux.y++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
                posAux.y -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);
                posAux.x--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                {
                    posAux.y++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                    posAux.y -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x++;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x -= 2;
                    if (Global.tableroPiezas.getChar(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }
            }
        }
    }
}
