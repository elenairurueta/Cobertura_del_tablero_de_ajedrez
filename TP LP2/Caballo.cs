using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Caballo : Pieza
    {
        public Caballo(ColorPieza color_) : base('C', color_) { }

        //recorre el ataque del Caballo si se colocara en esa posición y marca en el tableroAmenazas sus ataques leves y fatales
        public static void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            //Para arriba
            if (posAux.y > 1)
            {
                posAux.y--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    posAux.y--;
                    if (posAux.x < 7)
                    {
                        posAux.x++;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);

                        }
                    }
                    if (posAux.x > 1)
                    {
                        posAux.x -= 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F') 
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }

                }
                else
                {
                    posAux.y--;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        if (posAux.x < 7)
                        {
                            posAux.x++;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                        if (posAux.x > 1)
                        {
                            posAux.x -= 2;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                    }
                    else
                    {
                        if (posAux.x < 7)
                        {
                            posAux.x++;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                        if (posAux.x > 1)
                        {
                            posAux.x -= 2;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                    }
                }
            }
            //Para abajo
            posAux = posicion;
            if (posAux.y < 6)
            {
                posAux.y++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    posAux.y++;
                    if (posAux.x < 7)
                    {
                        posAux.x++;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    if (posAux.x > 1)
                    {
                        posAux.x -= 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                }
                else
                {
                    posAux.y++;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        if (posAux.x < 7)
                        {
                            posAux.x++;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                        if (posAux.x > 1)
                        {
                            posAux.x -= 2;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                    }
                    else
                    {
                        if (posAux.x < 7)
                        {
                            posAux.x++;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                        if (posAux.x > 1)
                        {
                            posAux.x -= 2;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                    }
                }
            }
            //Para derecha 
            posAux = posicion;
            if (posAux.x < 6)
            {
                posAux.x++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    posAux.x++;
                    if (posAux.y < 7)
                    {
                        posAux.y++;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    if (posAux.y > 1)
                    {
                        posAux.y -= 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                }
                else
                {
                    posAux.x++;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        if (posAux.y < 7)
                        {
                            posAux.y++;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                        if (posAux.y > 1)
                        {
                            posAux.y -= 2;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                    }
                    else
                    {
                        if (posAux.y < 7)
                        {
                            posAux.y++;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                        if (posAux.y > 1)
                        {
                            posAux.y -= 2;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                    }
                }
            }
            //Para izquierda
            posAux = posicion;
            if (posAux.x > 1)
            {
                posAux.x--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    posAux.x--;
                    if (posAux.y < 7)
                    {
                        posAux.y++;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                    if (posAux.y > 1)
                    {
                        posAux.y -= 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                        {
                            Global.tableroAmenazas.setCaracter('L', posAux);
                        }
                    }
                }
                else
                {
                    posAux.x--;
                    if (Global.tableroPiezas.getCaracter(posAux) != '0')
                    {
                        if (posAux.y < 7)
                        {
                            posAux.y++;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                        if (posAux.y > 1)
                        {
                            posAux.y -= 2;
                            if (Global.tableroAmenazas.getCaracter(posAux) != 'F')
                            {
                                Global.tableroAmenazas.setCaracter('L', posAux);
                            }
                        }
                    }
                    else
                    {
                        if (posAux.y < 7)
                        {
                            posAux.y++;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                        if (posAux.y > 1)
                        {
                            posAux.y -= 2;
                            if (Global.tableroPiezas.getCaracter(posAux) == '0')
                            {
                                Global.tableroAmenazas.setCaracter('F', posAux);
                            }
                        }
                    }
                }
            }
        }

        //contador de cuántas piezas amenazarían (que no estén ya amenazadas) si se colocara un Caballo en esa posición
        protected override int cuantasAmenaza(Pos posicion)
        {
            int contAmenazas = 0; Pos posAux = posicion;
            for (int i = 0; i < 8; i++)
            {
                if (posicion.x + 2 <= 7)
                {
                    if (posicion.y + 1 <= 7)
                    {
                        posAux.x = posicion.x + 2; posAux.y = posicion.y + 1;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                    if (posicion.y - 1 >= 0)
                    {
                        posAux.x = posicion.x + 2; posAux.y = posicion.y - 1;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                }
                if (posicion.x - 2 >= 0)
                {
                    if (posicion.y + 1 <= 7)
                    {
                        posAux.x = posicion.x - 2; posAux.y = posicion.y + 1;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                    if (posicion.y - 1 >= 0)
                    {
                        posAux.x = posicion.x - 2; posAux.y = posicion.y - 1;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                }
                if (posicion.y + 2 <= 7)
                {
                    if (posicion.x + 1 <= 7)
                    {
                        posAux.x = posicion.x + 1; posAux.y = posicion.y + 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                    if (posicion.x - 1 >= 0)
                    {
                        posAux.x = posicion.x - 1; posAux.y = posicion.y + 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                }
                if (posicion.y - 2 >= 0)
                {
                    if (posicion.x + 1 <= 7)
                    {
                        posAux.x = posicion.x + 1; posAux.y = posicion.y - 2;
                        if (Global.tableroAmenazas.getCaracter(posAux) == '0')
                            contAmenazas++;
                    }
                    if (posicion.x - 1 >= 0)
                    {
                        posAux.x = posicion.x - 1; posAux.y = posicion.y - 2;
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
            return Global.devolverNprimerasPos(Global.PODACABALLO, mejoresPos);

        }

        //devuelve las posiciones en las que se debería colocar un Caballo para atacar las posiciones pasadas por parámetro
        private Pos[] dondeColocarParaAtacar(Pos posAtacar)
        {
            Pos[] dondeColocar = new Pos[8];
            int cantAgregadas = 0;
            Pos colocar;
            if (posAtacar.x - 2 >= 0)
            {
                colocar.x = posAtacar.x - 2;
                if (posAtacar.y + 1 <= 7)
                {
                    colocar.y = posAtacar.y + 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
                if (posAtacar.y - 1 >= 0)
                {
                    colocar.y = posAtacar.y - 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
            }
            if (posAtacar.x + 2 <= 7)
            {
                colocar.x = posAtacar.x + 2;
                if (posAtacar.y + 1 <= 7)
                {
                    colocar.y = posAtacar.y + 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
                if (posAtacar.y - 1 >= 0)
                {
                    colocar.y = posAtacar.y - 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
            }
            if (posAtacar.y - 2 >= 0)
            {
                colocar.y = posAtacar.y - 2;
                if (posAtacar.x + 1 <= 7)
                {
                    colocar.x = posAtacar.x + 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
                if (posAtacar.x - 1 >= 0)
                {
                    colocar.x = posAtacar.x - 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
            }
            if (posAtacar.y + 2 <= 7)
            {
                colocar.y = posAtacar.y + 2;
                if (posAtacar.x + 1 <= 7)
                {
                    colocar.x = posAtacar.x + 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
                if (posAtacar.x - 1 >= 0)
                {
                    colocar.x = posAtacar.x - 1;
                    if (Global.tableroPiezas.getCaracter(colocar) == '0')
                    {
                        dondeColocar[cantAgregadas] = colocar;
                        cantAgregadas++;
                    }
                }
            }

            Pos[] ResizedArray = new Pos[cantAgregadas];
            for (int i = 0; i < cantAgregadas; i++)
                ResizedArray[i] = dondeColocar[i];
            return ResizedArray;
        }
    }
}
