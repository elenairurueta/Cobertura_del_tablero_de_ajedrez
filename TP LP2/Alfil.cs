using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Alfil : Pieza
    {
        public Alfil(Color color_) : base('A', color_){ }
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
                        seguirFatal = false;
                    if (seguirFatal == false)
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
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
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
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
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
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
                        if (Global.tableroPiezas.getCaracter(posAux) != 'F')
                            Global.tableroAmenazas.agregarCaracter('L', posAux);
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
                } while (posAux.y > 0 && posAux.x > 0);
            }
        }
        public override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0; Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                if (posicion.x + i <= 7) {
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
        public override void colocarPieza()
        {
            Pos[] mejoresPos = new Pos[2];
            if (this.color == Color.NEGRO) {
                mejoresPos[0].x = 3; mejoresPos[0].y = 3;
                mejoresPos[1].x = 4; mejoresPos[1].y = 4;
            }else if (this.color == Color.BLANCO)
            {
                mejoresPos[0].x = 3; mejoresPos[0].y = 4;
                mejoresPos[1].x = 4; mejoresPos[1].y = 3;
            }
            
            if (cuantasAmenaza(mejoresPos[0]) < cuantasAmenaza(mejoresPos[1]))
            {
                Pos aux = mejoresPos[0];
                mejoresPos[0] = mejoresPos[1];
                mejoresPos[1] = aux;
            }

            for (int i = 0; i < 2; i++)
            {
                if (i > 0)
                {
                    Global.tableroPiezas.limpiarTablero(mejoresPos[i - 1], 'A');
                    Global.piezasAgregadas--;
                }
                if (Global.tableroPiezas.agregarCaracter('A', mejoresPos[i]))
                {
                    actualizarAmenazas();

                    if (Global.tableroAmenazas.esSolucion())
                    {
                        Global.tableroPiezas.imprimirTablero();
                        Global.tableroAmenazas.imprimirTablero();
                    }
                    if (Global.piezasAgregadas < 7)
                        Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
                }
            }
        }
    }
}
