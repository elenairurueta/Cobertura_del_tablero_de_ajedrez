using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Alfil : Pieza
    {
        public Alfil(ColorPieza color_) : base('A', color_) { }

        //recorre el ataque del Alfil si se colocara en esa posición y marca en el tableroAmenazas sus ataques leves y fatales
        public static void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            bool seguirFatal = true;

            //Diagonal abajo derecha
            if (posAux.y < 7 && posAux.x < 7)
            {
                do
                {
                    posAux.y++; posAux.x++;
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

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara un Alfil en esa posición
        protected override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0; Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                if (posicion.x + i <= 7)
                {
                    posAux.x = posicion.x + i;
                    if (posicion.y + i <= 7)
                    {
                        posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                    if (posicion.y - i >= 0)
                    {
                        posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }

                }
                if (posicion.x - i >= 0)
                {
                    posAux.x = posicion.x - i;
                    if (posicion.y + i <= 7)
                    {
                        posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                    if (posicion.y - i >= 0)
                    {
                        posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }

                }
            }
            return contAmenazas;
        }

        //devuelve las mejores posiciones donde colocar la pieza ordenadas según cuantos casilleros amenazaría si se colocara
        public override Pos[] getMejoresPos()
        {
            //nuestras mejores posiciones para el Alfil: el centro (si queremos aumentar el número de tableros, esto se podría cambiar)

            Pos[] mejoresPos = new Pos[8];
            if (this.color == ColorPieza.NEGRO)
            {
                mejoresPos[0].x = 3; mejoresPos[0].y = 3;
                mejoresPos[1].x = 4; mejoresPos[1].y = 4;
                mejoresPos[2].x = 2; mejoresPos[0].y = 2;
                mejoresPos[3].x = 5; mejoresPos[3].y = 5;
                mejoresPos[4].x = 2; mejoresPos[4].y = 4;
                mejoresPos[5].x = 4; mejoresPos[5].y = 2;
                mejoresPos[6].x = 5; mejoresPos[6].y = 3;
                mejoresPos[7].x = 3; mejoresPos[7].y = 5;
            }
            else if (this.color == ColorPieza.BLANCO)
            {
                mejoresPos[0].x = 3; mejoresPos[0].y = 4;
                mejoresPos[1].x = 4; mejoresPos[1].y = 3;
                mejoresPos[2].x = 2; mejoresPos[0].y = 5;
                mejoresPos[3].x = 2; mejoresPos[3].y = 3;
                mejoresPos[4].x = 3; mejoresPos[4].y = 2;
                mejoresPos[5].x = 5; mejoresPos[5].y = 2;
                mejoresPos[6].x = 5; mejoresPos[6].y = 4;
                mejoresPos[7].x = 4; mejoresPos[7].y = 5;
            }

            //ordenamos estas posiciones según cuántos casilleros amenazaría el alfil si se colocara en cada una (de mayor -más conveniente- a menor)

            mejoresPos = ordenarPosSegunCuantasAmenazan(mejoresPos);
            return Global.devolverNprimerasPos(Global.PODAALFIL, mejoresPos);
        }
    }
}
