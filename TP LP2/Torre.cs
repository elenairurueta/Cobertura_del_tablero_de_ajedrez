using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Torre : Pieza
    {
        public Torre(Color color_) : base('T', color_){ }

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
                    if (Global.tableroPiezas.getCaracter(posAux) != '0') //si hay una pieza
                        seguirFatal = false; //todo el resto del ataque va a ser leve
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F') //pero si ya está siendo atacada de forma fatal, le gana al leve
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux); //sino, ataque fatal
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                    {
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    }
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
                } while (posAux.x > 0);
            }
        }

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara una Torre en esa posición
        public override int cuantasAmenaza(Pos posicion)
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

        //coloca la Torre y llama a la siguiente en ListaPiezas
        public override void colocarPieza()
        {
            //nuestras mejores posiciones para la torre: las esquinas (si queremos aumentar el número de tableros, esto se podría cambiar)
            Pos[] mejoresPos = new Pos[4];
            mejoresPos[0].x = 0; mejoresPos[0].y = 7;
            mejoresPos[1].x = 7; mejoresPos[1].y = 0;
            mejoresPos[2].x = 0; mejoresPos[2].y = 0;
            mejoresPos[3].x = 7; mejoresPos[3].y = 7;

            //ordenamos estas posiciones según cuántos casilleros amenazaría la torre si se colocara en cada una (de mayor -más conveniente- a menor)
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

            //para cada una de las 4 mejores posiciones (ya ordenadas):
            for (int i = 0; i < 4; i++)
            {
                
                if (Global.tableroPiezas.agregarCaracter('T', mejoresPos[i])) //agregamos la pieza
                {
                    actualizarAmenazas(); //actualizamos las amenazas de esta y todas las otras piezas

                    Global.tableroAmenazas.esSolucion(); //si es solución se agrega el tablero a la lista de tableros solución
                    
                    if (Global.piezasAgregadas < 8) //si todavía no se colocaron todas las piezas, se coloca la siguiente
                    {
                        Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
                    }
                    Global.tableroPiezas.limpiarTablero(mejoresPos[i], 'T');
                }
            }
            Global.piezasAgregadas--;
        }
    }
}
