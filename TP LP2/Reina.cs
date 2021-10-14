﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Reina : Pieza
    {
        public Reina() : base('R')
        {

        }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            //Para arriba
            bool seguirFatal = true;
            do
            {
                posAux.y--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if(seguirFatal == false)
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

            //Para la derecha
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.x++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.x < 7);

            //Para la izquierda
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.x--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.x > 0);

            //Diagonal abajo derecha
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y++; posAux.x++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y < 7 && posAux.x < 7);

            //Diagonal arriba derecha
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y--; posAux.x++;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y > 0 && posAux.x < 7);

            //Diagonal abajo izquierda
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y++; posAux.x--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y < 7 && posAux.x > 0);

            //Diagonal arriba izquierda
            seguirFatal = true; posAux = posicion;
            do
            {
                posAux.y--; posAux.x--;
                if (Global.tableroPiezas.getChar(posAux) != '0')
                    seguirFatal = false;
                if (seguirFatal == false)
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                else Global.tableroAmenazas.agregarCaracter('F', posAux);
            } while (posAux.y > 0 && posAux.x > 0);
        }

        public override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0;
            Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                posAux.y = i; posAux.x = posicion.x;
                if (Global.tableroAmenazas.getChar(posAux) == '0')
                    contAmenazas++;
                posAux.x = i; posAux.y = posicion.y;
                if (Global.tableroAmenazas.getChar(posAux) == '0')
                    contAmenazas++;
                if (posicion.x + i <= 7)
                {
                    if (posicion.y + i <= 7) //derecha arriba
                    {
                        posAux.x = posicion.x + i; posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getChar(posAux) == '0')
                            contAmenazas++;

                    }
                    if (posicion.y - i >= 0) //derecha abajo
                    {
                        posAux.x = posicion.x + i; posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getChar(posAux) == '0')
                            contAmenazas++;
                    }
                }
                if (posicion.x - i >= 0)
                {
                    if (posicion.y + i <= 7) //izquierda arriba
                    {
                        posAux.x = posicion.x - i; posAux.y = posicion.y + i;
                        if (Global.tableroAmenazas.getChar(posAux) == '0')
                            contAmenazas++;

                    }
                    if (posicion.y - i >= 0) //izquierda abajo
                    {
                        posAux.x = posicion.x - i; posAux.y = posicion.y - i;
                        if (Global.tableroAmenazas.getChar(posAux) == '0')
                            contAmenazas++;
                    }
                }
            }
            return contAmenazas - 2; //porque al verificar fila y columna se cuenta posicion
        }
        public override void colocarPieza()
        {
            Pos[] mejoresPos = new Pos[4];
			int contAmenazas = 0;
            mejoresPos[0].x = 3; mejoresPos[0].y = 3;
            mejoresPos[1].x = 3; mejoresPos[1].y = 4;
            mejoresPos[2].x = 4; mejoresPos[2].y = 3;
            mejoresPos[3].x = 4; mejoresPos[3].y = 4;

            int contCambios;
            for (int i = 0; i < 3; i++)
            {
                contCambios = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (cuantasAmenaza(mejoresPos[i]) < cuantasAmenaza(mejoresPos[i + 1]))
                    {
                        Pos aux = mejoresPos[i];
                        mejoresPos[i] = mejoresPos[i + 1];
                        mejoresPos[i + 1] = aux;
                        contCambios++;
                    }
                }
                if (contCambios == 0)
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                if (i > 0)
                    Global.tableroPiezas.vaciarTablero(mejoresPos[i - 1]); //TODO: vaciar tablero de ataques también
                Global.tableroPiezas.agregarCaracter('Q', mejoresPos[i]);
                if (Global.tableroAmenazas.esSolucion())
                {
                    for (int j = 0; j < Global.tablerosSolucion; j++)
                    {
                        Global.listaTablerosSolucion[Global.tablerosSolucion] = Global.tableroPiezas; //TODO: imprimir también tablero ataques?
                        Global.tablerosSolucion++;
                    }
                }
                if (Global.piezasAgregadas < 7)
                    Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
            }
    }
    }
}
