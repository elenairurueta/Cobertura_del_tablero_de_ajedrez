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
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            bool seguirFatal = true;

            //Para arriba
            if (posicion.y > 0)
            {
                do
                {
                    posAux.y--;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                        seguirFatal = false;
                    if (seguirFatal == false)
                        Global.tableroAmenazas.agregarCaracter('L', posAux);
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
                } while (posAux.y > 0);
            }

            //Para abajo
            if (posicion.y < 7)
            {
                seguirFatal = true; posAux = posicion;
                do
                {
                    posAux.y++;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                        seguirFatal = false;
                    if (seguirFatal == false)
                        Global.tableroAmenazas.agregarCaracter('L', posAux);
                    else Global.tableroAmenazas.agregarCaracter('F', posAux);
                } while (posAux.y < 7);
            }
        }
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
        public override void colocarPieza()
        {
            Pos[] mejoresPos = new Pos[4];
            mejoresPos[0].x = 0; mejoresPos[0].y = 7;
            mejoresPos[1].x = 7; mejoresPos[1].y = 0;
            mejoresPos[2].x = 0; mejoresPos[2].y = 0;
            mejoresPos[3].x = 7; mejoresPos[3].y = 7;

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

            for (int i = 0; i < 4; i++)
            {
                if (i > 0)
                    Global.tableroPiezas.limpiarTablero(mejoresPos[i - 1], 'T'); //TODO: vaciar tablero de ataques también
                Global.tableroPiezas.agregarCaracter('T', mejoresPos[i]);
                colorearAtaque(mejoresPos[i]);

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
