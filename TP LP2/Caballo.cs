using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    class Caballo : Pieza
    {
        public Caballo(Color color_) : base('C', color_) { }
        public override void colorearAtaque(Pos posicion)
        {
            Pos posAux = posicion;
            //Para arriba

            posAux.y--;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
            {

                posAux.y--;

                posAux.x++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);


                posAux.x -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);


            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);

                posAux.y--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {

                    posAux.x++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);


                    posAux.x -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);

                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);

                    posAux.x++;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);


                    posAux.x -= 2;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);

                }
            }

            //Para abajo

            posAux.y++;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
            {

                posAux.y++;

                posAux.x++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);


                posAux.x -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);


            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);

                posAux.y++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {

                    posAux.x++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);


                    posAux.x -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);

                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);

                    posAux.x++;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);


                    posAux.x -= 2;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }
            }

            //Para derecha

            posAux.x++;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
            {
                posAux.x++;
                posAux.y++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
                posAux.y -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);

            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);
                posAux.x++;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    posAux.y++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                    posAux.y -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x++;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x -= 2;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }
            }

            //Para izquierda
            posAux.x--;
            if (Global.tableroPiezas.getCaracter(posAux) != '0')
            {
                posAux.x--;
                posAux.y++;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
                posAux.y -= 2;
                Global.tableroAmenazas.agregarCaracter('L', posAux);
            }
            else
            {
                Global.tableroAmenazas.agregarCaracter('F', posAux);
                posAux.x--;
                if (Global.tableroPiezas.getCaracter(posAux) != '0')
                {
                    posAux.y++;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                    posAux.y -= 2;
                    Global.tableroAmenazas.agregarCaracter('L', posAux);
                }
                else
                {
                    Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x++;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                    posAux.x -= 2;
                    if (Global.tableroPiezas.getCaracter(posAux) == '0')
                        Global.tableroAmenazas.agregarCaracter('F', posAux);
                }
            }
        }
        public override int cuantasAmenaza(Pos posicion)
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
        public override void colocarPieza()
        {
            Pos[] atacarPos = Global.tableroAmenazas.getPosVacias();

            Pos[] mejoresPos = new Pos[] { };
            for (int i = 0; i < Global.tableroAmenazas.getCantPosVacias(); i++)
            {
                mejoresPos.Concat(dondeColocarParaAtacar(atacarPos[i])).ToArray();
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
                if (i > 0) Global.tableroPiezas.limpiarTablero(mejoresPos[i - 1], 'C');
                Global.tableroPiezas.agregarCaracter('C', mejoresPos[i]);
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

            return dondeColocar;
        }
    }
}
