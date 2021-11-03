using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Reina : Pieza
    {
        public Reina(ColorPieza color_) : base('Q', color_){ }

        //recorre el ataque de la Reina si se colocara en esa posición y marca en el tableroAmenazas sus ataques leves y fatales
        public static void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            //Para arriba
            bool seguirFatal = true;
            if (posAux.y > 0)
            {
                do
                {
                    posAux.y--;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    { //si en el camino nos encontramos con una pieza
                        seguirFatal = false; //todos los ataques restantes serán leves
                    }
                    if (seguirFatal == false)
                    {
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    else Global.tableroAmenazas.setCaracter('F', posAux);
                } while (posAux.y > 0);
            }

            //Para abajo
            posAux = posicion;
            if (posAux.y < 7)
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

            //Para la derecha
            posAux = posicion;
            if (posAux.x < 7)
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

            //Para la izquierda
            posAux = posicion;
            if (posAux.x > 0)
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

            //Diagonal abajo derecha
            posAux = posicion;
            if (posAux.y < 7 && posAux.x < 7)
            {
                seguirFatal = true; 
                do
                {
                    posAux.y++; posAux.x++;
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
                } while (posAux.y < 7 && posAux.x < 7);
            }

            //Diagonal arriba derecha
            posAux = posicion;
            if (posAux.y > 0 && posAux.x < 7)
            {
                seguirFatal = true;
                do
                {
                    posAux.y--; posAux.x++;
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
                } while (posAux.y > 0 && posAux.x < 7);
            }

            //Diagonal abajo izquierda
            posAux = posicion;
            if (posAux.y < 7 && posAux.x > 0)
            {
                seguirFatal = true;
                do
                {
                    posAux.y++; posAux.x--;
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
                } while (posAux.y < 7 && posAux.x > 0);
            }

            //Diagonal arriba izquierda
            posAux = posicion;
            if (posAux.y > 0 && posAux.x > 0)
            {
                seguirFatal = true;
                do
                {
                    posAux.y--; posAux.x--;
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
                } while (posAux.y > 0 && posAux.x > 0);
            }
        }

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara una Reina en esa posición
        protected override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0;
            Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                posAux.y = i; posAux.x = posicion.x;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0' && !Array.Equals(posAux, posicion))
                    contAmenazas++;
                posAux.x = i; posAux.y = posicion.y;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0' && !Array.Equals(posAux, posicion))
                    contAmenazas++;
                if (posicion.x + i <= 7)
                {
                    if (posicion.y + i <= 7) //derecha arriba
                    {
                        posAux.x = posicion.x + i; posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0' && !Array.Equals(posAux, posicion))
                            contAmenazas++;

                    }
                    if (posicion.y - i >= 0) //derecha abajo
                    {
                        posAux.x = posicion.x + i; posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0' && !Array.Equals(posAux, posicion))
                            contAmenazas++;
                    }
                }
                if (posicion.x - i >= 0)
                {
                    if (posicion.y + i <= 7) //izquierda arriba
                    {
                        posAux.x = posicion.x - i; posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0' && !Array.Equals(posAux, posicion))
                            contAmenazas++;

                    }
                    if (posicion.y - i >= 0) //izquierda abajo
                    {
                        posAux.x = posicion.x - i; posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0' && !Array.Equals(posAux, posicion))
                            contAmenazas++;
                    }
                }
            }
            return contAmenazas - 2; //porque al verificar fila y columna se cuenta posicion
        }

        //devuelve las mejores posiciones donde colocar la pieza ordenadas según cuantos casilleros amenazaría si se colocara
        public override Pos[] getMejoresPos()
        {
            //nuestras mejores posiciones para la Reina: el centro (si queremos aumentar el número de tableros, esto se podría cambiar)

            Pos[] mejoresPos = new Pos[4];
            mejoresPos[0].x = 3; mejoresPos[0].y = 3;
            mejoresPos[1].x = 3; mejoresPos[1].y = 4;
            mejoresPos[2].x = 4; mejoresPos[2].y = 3;
            mejoresPos[3].x = 4; mejoresPos[3].y = 4;

            //ordenamos estas posiciones según cuántos casilleros amenazaría la Reina si se colocara en cada una (de mayor -más conveniente- a menor)
            return ordenarPosSegunCuantasAmenazan(mejoresPos);
            
        }
    }
}
