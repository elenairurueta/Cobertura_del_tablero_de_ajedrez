using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Torre : Pieza
    {
        public Torre(ColorPieza color_) : base('T', color_){ }

        //recorre el ataque de la Torre si se colocara en esa posición y marca en el tableroAmenazas sus ataques leves y fatales
        public static void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            bool seguirFatal = true;

            //Para arriba
            if (posicion.y > 0) //si no está en la primera fila
            {
                do
                {
                    posAux.y--; //vamos para arriba
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {//si hay una pieza
                        seguirFatal = false;
                    } //todo el resto del ataque va a ser leve
                    if (seguirFatal == false)
                    {
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        { //pero si ya está siendo atacada de forma fatal, le gana al leve
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    else Global.tableroAmenazas.setCaracter('F', posAux); //sino, ataque fatal
                } while (posAux.y > 0); //mientras que no nos pasemos del tablero
            }

            //Para abajo
            posAux = posicion;
            if (posicion.y < 7) //si no está en la última fila
            {
                seguirFatal = true; 
                do
                {
                    posAux.y++;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        seguirFatal = false;
                    }
                    if (seguirFatal == false)
                    {
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    else Global.tableroAmenazas.setCaracter('F', posAux);
                } while (posAux.y < 7);
            }

            //Para derecha
            posAux = posicion;
            if (posicion.x < 7) //si no está en la última columna
            {
                seguirFatal = true;
                do
                {
                    posAux.x++;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        seguirFatal = false;
                    }
                    if (seguirFatal == false)
                    {
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    else Global.tableroAmenazas.setCaracter('F', posAux);
                } while (posAux.x < 7);
            }

            //Para izquierda
            posAux = posicion;
            if (posicion.x > 0) //si no está en la primera columna
            {
                seguirFatal = true;
                do
                {
                    posAux.x--;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        seguirFatal = false;
                    }
                    if (seguirFatal == false)
                    {
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    else Global.tableroAmenazas.setCaracter('F', posAux);
                } while (posAux.x > 0);
            }
        }

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara una Torre en esa posición
        protected override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0; Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                posAux.x = posicion.x; posAux.y = i;
                if(Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
                posAux.x = i; posAux.y = posicion.y;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
            }
            return contAmenazas - 2; //porque al recorrer la fila y columna se cuenta (x,y)
        }

        //devuelve las mejores posiciones donde colocar la pieza ordenadas según cuantos casilleros amenazaría si se colocara
        public override Pos[] getMejoresPos()
        {
            //nuestras mejores posiciones para la torre: las esquinas (si queremos aumentar el número de tableros, esto se podría cambiar)
            Pos[] mejoresPos = new Pos[6];
            mejoresPos[0].x = 0; mejoresPos[0].y = 7;
            mejoresPos[1].x = 7; mejoresPos[1].y = 0;
            mejoresPos[2].x = 0; mejoresPos[2].y = 0;
            mejoresPos[3].x = 7; mejoresPos[3].y = 7;
            mejoresPos[4].x = 6; mejoresPos[4].y = 0;
            mejoresPos[5].x = 0; mejoresPos[5].y = 6;

            //ordenamos estas posiciones según cuántos casilleros amenazaría la torre si se colocara en cada una (de mayor -más conveniente- a menor)
            mejoresPos = ordenarPosSegunCuantasAmenazan(mejoresPos);
            return Global.devolverNprimerasPos(Global.PODATORRE, mejoresPos);

        }
    }
}
