using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Alfil : Pieza
    {
        public Alfil(Color color_) : base('A', color_) { }

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
                    if (Global.tableroPiezas.getCaracter(posAux) != '0') //si en el camino nos encontramos con una pieza
                        seguirFatal = false; //todos los ataques restantes serán leves
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
                } while (posAux.y > 0 && posAux.x > 0);
            }
        }

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara un Alfil en esa posición
        public override int cuantasAmenaza(Pos posicion)
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

        //coloca el Alfil y llama a la siguiente en ListaPiezas
        public override void colocarPieza()
        {
            //nuestras mejores posiciones para el Alfil: el centro (si queremos aumentar el número de tableros, esto se podría cambiar)

            Pos[] mejoresPos = new Pos[2];
            if (this.color == Color.NEGRO)
            {
                mejoresPos[0].x = 3; mejoresPos[0].y = 3;
                mejoresPos[1].x = 4; mejoresPos[1].y = 4;
            }
            else if (this.color == Color.BLANCO)
            {
                mejoresPos[0].x = 3; mejoresPos[0].y = 4;
                mejoresPos[1].x = 4; mejoresPos[1].y = 3;
            }

            //ordenamos estas posiciones según cuántos casilleros amenazaría el alfil si se colocara en cada una (de mayor -más conveniente- a menor)

            if (cuantasAmenaza(mejoresPos[0]) < cuantasAmenaza(mejoresPos[1]))
            {
                Pos aux = mejoresPos[0];
                mejoresPos[0] = mejoresPos[1];
                mejoresPos[1] = aux;
            }

            //para cada una de las mejores posiciones (ya ordenadas):

            for (int i = 0; i < 2; i++)
            {
                if (Global.tableroPiezas.agregarCaracter('A', mejoresPos[i])) //agregamos la pieza
                {
                    actualizarAmenazas(); //actualizamos las amenazas de esta y todas las otras piezas

                    Global.tableroAmenazas.esSolucion(); //si es solución se agrega el tablero a la lista de tableros solución

                    if (Global.piezasAgregadas < 8) //si todavía no se colocaron todas las piezas, se coloca la siguiente
                    {
                        Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
                    }
                    Global.tableroPiezas.limpiarTablero(mejoresPos[i], 'A');
                }
            }
            Global.piezasAgregadas--;
        }
    }
}
