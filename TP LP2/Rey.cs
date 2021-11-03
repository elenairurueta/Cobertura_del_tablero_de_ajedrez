using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Rey : Pieza
    {
        public Rey(ColorPieza color_) : base('K', color_){ }

        //recorre el ataque del Rey si se colocara en esa posición y marca en el tableroAmenazas sus ataques leves y fatales
        public static void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            if (posicion.x < 7)
            {
                posAux.x++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0') 
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.y < 7)
            {
                posAux.y++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.y < 7)
            {
                posAux = posicion;
                posAux.y++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.x > 0)
            {
                posAux.x--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.x > 0)
            {
                posAux = posicion;
                posAux.x--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.y > 0)
            {
                posAux.y--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.y > 0)
            {
                posAux = posicion;
                posAux.y--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
            if (posicion.x < 7)
            {
                posAux.x++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                    {
                        Global.tableroAmenazas.setCaracter('L', posAux);
                    }
                }
                else Global.tableroAmenazas.setCaracter('F', posAux);
            }
        }

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara un Rey en esa posición
        protected override int cuantasAmenaza(Pos posicion)
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

        //devuelve las mejores posiciones donde colocar la pieza ordenadas según cuantos casilleros amenazaría si se colocara
        public override Pos[] getMejoresPos()
        {
            //nos fijamos qué posiciones nos falta atacar:

            Pos[] atacarPos = Global.tableroAmenazas.getPosVacias();

            Pos[] mejoresPos = new Pos[] { };

            //por lo que nuestras mejores posiciones serán las que puedan atacar esos lugares vacíos:

            for (int i = 0; i < atacarPos.Length; i++)
            {
                mejoresPos = mejoresPos.Concat(dondeColocarParaAtacar(atacarPos[i])).ToArray();
            }
            mejoresPos = Global.sacarPosRepetidas(mejoresPos);
            mejoresPos = ordenarPosSegunCuantasAmenazan(mejoresPos);
            return Global.devolverNprimerasPos(Global.PODAREY, mejoresPos);

        }

        //devuelve las posiciones en las que se debería colocar un Rey para atacar las posiciones pasadas por parámetro
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
            if (posAtacar.y + 1 <= 7)
            {
                dondeColocar[cantAgregadas].y = posAtacar.y + 1;
                dondeColocar[cantAgregadas].x = posAtacar.x;
                cantAgregadas++;
            }
            
            return dondeColocar;
        } 
    }
}
