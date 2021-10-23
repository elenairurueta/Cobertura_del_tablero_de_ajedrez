using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Reina : Pieza
    {
        public Reina(Color color_) : base('R', color_){ }

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
                    if (Global.tableroPiezas.getCaracter(posAux) != '0') //si en el camino nos encontramos con una pieza
                        seguirFatal = false; //todos los ataques restantes serán leves
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
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
                    {
                        seguirFatal = false;
                    }
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

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara una Reina en esa posición
        public override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0;
            Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                posAux.y = i; posAux.x = posicion.x;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
                posAux.x = i; posAux.y = posicion.y;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
                if (posicion.x + i <= 7)
                {
                    if (posicion.y + i <= 7) //derecha arriba
                    {
                        posAux.x = posicion.x + i; posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;

                    }
                    if (posicion.y - i >= 0) //derecha abajo
                    {
                        posAux.x = posicion.x + i; posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                }
                if (posicion.x - i >= 0)
                {
                    if (posicion.y + i <= 7) //izquierda arriba
                    {
                        posAux.x = posicion.x - i; posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;

                    }
                    if (posicion.y - i >= 0) //izquierda abajo
                    {
                        posAux.x = posicion.x - i; posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                }
            }
            return contAmenazas - 2; //porque al verificar fila y columna se cuenta posicion
        }

        //coloca la Reina y llama a la siguiente en ListaPiezas
        public override void colocarPieza()
        {
            //nuestras mejores posiciones para la Reina: el centro (si queremos aumentar el número de tableros, esto se podría cambiar)

            Pos[] mejoresPos = new Pos[4];
            mejoresPos[0].x = 3; mejoresPos[0].y = 3;
            mejoresPos[1].x = 3; mejoresPos[1].y = 4;
            mejoresPos[2].x = 4; mejoresPos[2].y = 3;
            mejoresPos[3].x = 4; mejoresPos[3].y = 4;

            //ordenamos estas posiciones según cuántos casilleros amenazaría la Reina si se colocara en cada una (de mayor -más conveniente- a menor)

            int contCambios;
            for (int i = 0; i < 4; i++)
            {
                contCambios = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (cuantasAmenaza(mejoresPos[j]) < cuantasAmenaza(mejoresPos[j + 1]))
                    {
                        Pos aux = mejoresPos[j];
                        mejoresPos[j] = mejoresPos[j + 1];
                        mejoresPos[j + 1] = aux;
                        contCambios++;
                    }
                }
                if (contCambios == 0)
                    break;
            }

            //para cada una de las mejores posiciones (ya ordenadas):

            for (int i = 0; i < 4; i++)
            {
                if (Global.tableroPiezas.agregarCaracter('Q', mejoresPos[i]))//agregamos la pieza
                {
                    actualizarAmenazas(); //actualizamos las amenazas de esta y todas las otras piezas

                    Global.tableroAmenazas.esSolucion();//si es solución se agrega el tablero a la lista de tableros solución

                    if (Global.piezasAgregadas < 8)//si todavía no se colocaron todas las piezas, se coloca la siguiente
                    {
                        Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
                    }
                    Global.tableroPiezas.limpiarTablero(mejoresPos[i], 'Q');
                }
            }
            Global.piezasAgregadas--;
        }
    }
}
