using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Rey : Pieza
    {
        public Rey(Color color_) : base('K', color_){ }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            posAux.x++; 
            if (Global.tableroPiezas.getCaracter(posAux) != '0') 
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.y++;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);

            posAux = posicion;
            posAux.y++;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.x--;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);

            posAux = posicion;
            posAux.x--;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.y--;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);

            posAux = posicion;
            posAux.y--;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);
            posAux.x++;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            else Global.tableroAmenazas.agregarCaracter('F', posAux);


        }
        public override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0;
            Pos posAux = posicion;
            if (posicion.x + 1 <= 7) {
                posAux.x = posicion.x + 1; posAux.y = posicion.y;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
                posAux.x = posicion.x + 1; posAux.y = posicion.y + 1;
                if(posicion.y + 1 <= 7)
                    if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                        contAmenazas++;
                posAux.x = posicion.x + 1; posAux.y = posicion.y - 1;
                if (posicion.y - 1 >= 0)
                    if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                        contAmenazas++;
            }
            if (posicion.x - 1 >= 0)
            {
                posAux.x = posicion.x - 1; posAux.y = posicion.y;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
                posAux.x = posicion.x - 1; posAux.y = posicion.y + 1;
                if (posicion.y + 1 <= 7)
                    if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                        contAmenazas++;
                posAux.x = posicion.x - 1; posAux.y = posicion.y - 1;
                if (posicion.y - 1 >= 0)
                    if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                        contAmenazas++;
            }
            if (posicion.y - 1 >= 0) {
                posAux.x = posicion.x; posAux.y = posicion.y - 1;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
            }
            if (posicion.y + 1 <= 7)
            {
                posAux.x = posicion.x; posAux.y = posicion.y + 1;
                if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                    contAmenazas++;
            }
            return contAmenazas;
        }
        public override void colocarPieza()
        {
            int cantAtacarPos = Global.tableroAmenazas.getCantPosVacias();
            Pos[] atacarPos = Global.tableroAmenazas.getPosVacias();

            Pos[] mejoresPos;
            for (int i = 0; i < cantAtacarPos; i++)
            {
                mejoresPos += dondeColocarParaAtacar(atacarPos[i]); //TODO: cómo solucionarlo, operator?
            }

            int contCambios;
            for (int i = 0; i < mejoresPos.Length; i++)
            {
                contCambios = 0;
                for (int j = 0; j < mejoresPos.Length - 1; j++)
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
            for (int i = 0; i < mejoresPos.Length; i++)
            {
                if (i > 0) Global.tableroPiezas.limpiarTablero(mejoresPos[i - 1], 'K');
                Global.tableroPiezas.agregarCaracter('K', mejoresPos[i]); //TODO: ACTUALIZAR TABLERO ATAQUES
                if (Global.tableroAmenazas.esSolucion())
                {
                    Global.listaTablerosSolucion[Global.tablerosSolucion] = Global.tableroPiezas; //TODO: imprimir también tablero ataques?
                    Global.tablerosSolucion++;
                }
                if (Global.piezasAgregadas < 7)
                    Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
            }
        }
        private Pos[] dondeColocarParaAtacar(Pos posAtacar)
        {
            Pos[] dondeColocar = new Pos[8]; 
            int cantAgregadas = 0;

            if(posAtacar.x - 1 >= 0)
            {
                dondeColocar[cantAgregadas].x = posAtacar.x - 1;
                dondeColocar[cantAgregadas].y = posAtacar.y;
                cantAgregadas++;

                if (posAtacar.y + 1 <= 7)
                {
                    dondeColocar[cantAgregadas].x = posAtacar.x - 1;
                    dondeColocar[cantAgregadas].y = posAtacar.y + 1;
                    cantAgregadas++;
                }
                if (posAtacar.y - 1 >= 0)
                {
                    dondeColocar[cantAgregadas].x = posAtacar.x - 1;
                    dondeColocar[cantAgregadas].y = posAtacar.y - 1;
                    cantAgregadas++;
                }
            }
            if (posAtacar.x + 1 <= 7)
            {
                dondeColocar[cantAgregadas].x = posAtacar.x + 1;
                dondeColocar[cantAgregadas].y = posAtacar.y;
                cantAgregadas++;

                if (posAtacar.y + 1 <= 7)
                {
                    dondeColocar[cantAgregadas].x = posAtacar.x + 1;
                    dondeColocar[cantAgregadas].y = posAtacar.y + 1;
                    cantAgregadas++;
                }
                if (posAtacar.y - 1 >= 0)
                {
                    dondeColocar[cantAgregadas].x = posAtacar.x + 1;
                    dondeColocar[cantAgregadas].y = posAtacar.y - 1;
                    cantAgregadas++;
                }
            }
            if (posAtacar.y - 1 >= 0)
            {
                dondeColocar[cantAgregadas].y = posAtacar.y - 1;
                dondeColocar[cantAgregadas].x = posAtacar.x;
                cantAgregadas++;
            }
            if (posAtacar.y + 1 >= 0)
            {
                dondeColocar[cantAgregadas].y = posAtacar.y + 1;
                dondeColocar[cantAgregadas].x = posAtacar.x;
                cantAgregadas++;
            }
            
            return dondeColocar;
        }
    }
}
