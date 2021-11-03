using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TP_LP2
{
    public class Tablero
    {
        #region ATRIBUTOS
        private char[,] tablero = new char[8, 8];
        private static Tablero[] listaTablerosSolucion = new Tablero[] { };
        public static int tablerosSolucion = 0;
        #endregion

        #region CONSTRUCTOR
        public Tablero()
        {
            vaciarTablero();
        }
        #endregion

        #region GETTERS_SETTERS
        public bool setCaracter(char simbolo, Pos posicion)
        {
            /* Si puede colocar el símbolo (no hay otra pieza) al tablero en la posición, 
			devuelve true. En el caso en que en esa posición hubiere una Torre ("T") y se
			quiera agregar el rey ("K") se pueden apilar y colocar una "X" */
            if (posicion.x <= 7 && posicion.x >= 0 && posicion.y <= 7 && posicion.y >= 0)
            {

                if (tablero[posicion.x, posicion.y] == '0')
                {
                    tablero[posicion.x, posicion.y] = simbolo;
                }
                else if (tablero[posicion.x, posicion.y] == 'T' && simbolo == 'K')
                {
                    tablero[posicion.x, posicion.y] = 'X';
                }
                else if (tablero[posicion.x, posicion.y] == 'K' && simbolo == 'T')
                {
                    tablero[posicion.x, posicion.y] = 'X';
                }
                else
                    return false;
                return true;
            }
            else return false;

        }
        public char getCaracter(Pos posicion)
        {
            return tablero[posicion.x, posicion.y];
        }

        #endregion

        public static void agregarSolucion(Tablero tableroPiezas, Tablero tableroAmenazas, bool rotarEspejar = true)
        {
            Tablero tableroAgregar = new Tablero(); tableroAgregar = tableroPiezas; //para que al cambiar tableroPiezas no se cambien los tableros solución

            if (!tableroAgregar.yaSeEncuentraEnLista())
            {
                listaTablerosSolucion = listaTablerosSolucion.Append(tableroAgregar).ToArray();
                tablerosSolucion++;
                Tablero.imprimirTableros();
                if (rotarEspejar) tableroPiezas.rotarEspejarSolucion();
            }
        }

        //si todos los casilleros del tableroAmenazas tienen 1, devuelve true.
        public bool esSolucion()
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (tablero[i, j] == '0')
                        return false;
                }
            }
            agregarSolucion(Global.tableroPiezas, Global.tableroAmenazas);
            return true;
        }

        //rota y espeja el tablero solución generando la mayor cantidad de soluciones posibles a partir de esta
        private void rotarEspejarSolucion()
        {
            Tablero nuevaSolucionPiezas; Tablero nuevaSolucionAmenazas;

            #region ROTACIÓN_DERECHA

            char[,] tableroAuxAmenazas = this.tablero;
            char[,] tableroAuxPiezas = Global.tableroPiezas.tablero;

            for (int i = 0; i < 3; i++)
            {
                nuevaSolucionPiezas = new Tablero();
                nuevaSolucionAmenazas = new Tablero();

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        nuevaSolucionPiezas.tablero[y, 8 - 1 - x] = tableroAuxPiezas[x, y];
                        nuevaSolucionAmenazas.tablero[y, 8 - 1 - x] = tableroAuxAmenazas[x, y];
                    }
                }
                agregarSolucion(nuevaSolucionAmenazas, nuevaSolucionAmenazas, false);
                tableroAuxAmenazas = nuevaSolucionAmenazas.tablero;
                tableroAuxPiezas = nuevaSolucionPiezas.tablero;
            }
            #endregion

            #region ESPEJADO_DIAGONAL_ArIzq_AbDer

            nuevaSolucionPiezas = new Tablero();
            nuevaSolucionAmenazas = new Tablero();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    nuevaSolucionPiezas.tablero[x, y] = Global.tableroPiezas.tablero[y, x];
                    nuevaSolucionAmenazas.tablero[x, y] = this.tablero[y, x];
                }
            }
            agregarSolucion(nuevaSolucionAmenazas, nuevaSolucionAmenazas, false);

            #endregion

            #region ESPEJADO_DIAGONAL_ArDer_AbIzq

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    nuevaSolucionPiezas.tablero[x, y] = Global.tableroPiezas.tablero[7 - y, 7 - x];
                    nuevaSolucionAmenazas.tablero[x, y] = this.tablero[7 - y, 7 - x];
                }
            }
            agregarSolucion(nuevaSolucionAmenazas, nuevaSolucionAmenazas, false);

            #endregion
        }

        //si el tablero ya se encuentra en la lista de tableros solución, devuelve true
        public bool yaSeEncuentraEnLista()
        {
            bool igual = true;
            for (int i = 0; i < tablerosSolucion; i++) //TODO: TRES FORS ANIDADOS!!!!
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (tablero[j, k] != listaTablerosSolucion[i].tablero[j, k])
                        {
                            igual = false;
                            break;
                        }
                    }
                    if (!igual)
                        break;
                }
                if (igual)
                    return true;
            }
            return false;

        }

        public static void imprimirTableros()
        {

            string nombreImagen; Pos posicion;
            Global.FormUnicaSolucion_.vaciarTableros();

            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    posicion.x = i; posicion.y = j;
                    switch (Global.tableroPiezas.tablero[i, j])
                    {
                        case 'Q':
                            nombreImagen = "Img\\Reina" + ((Global.FormUnicaSolucion_.getColor(posicion) == Color.White) ? "N" : "B") + ".png";
                            Global.FormUnicaSolucion_.setImagen(nombreImagen, posicion);
                            break;
                        case 'T':
                            nombreImagen = "Img\\Torre" + ((Global.FormUnicaSolucion_.getColor(posicion) == Color.White) ? "N" : "B") + ".png";
                            Global.FormUnicaSolucion_.setImagen(nombreImagen, posicion);
                            break;
                        case 'A':
                            nombreImagen = "Img\\Alfil" + ((Global.FormUnicaSolucion_.getColor(posicion) == Color.White) ? "N" : "B") + ".png";
                            Global.FormUnicaSolucion_.setImagen(nombreImagen, posicion);
                            break;
                        case 'C':
                            nombreImagen = "Img\\Caballo" + ((Global.FormUnicaSolucion_.getColor(posicion) == Color.White) ? "N" : "B") + ".png";
                            Global.FormUnicaSolucion_.setImagen(nombreImagen, posicion);
                            break;
                        case 'K':
                            nombreImagen = "Img\\Rey" + ((Global.FormUnicaSolucion_.getColor(posicion) == Color.White) ? "N" : "B") + ".png";
                            Global.FormUnicaSolucion_.setImagen(nombreImagen, posicion);
                            break;
                        default:
                            break;
                    }
                    switch (Global.tableroAmenazas.tablero[i, j])
                    {
                        case 'L':
                            Global.FormUnicaSolucion_.setBackgroundColor(Color.Yellow, posicion);
                            break;
                        case 'F':
                            Global.FormUnicaSolucion_.setBackgroundColor(Color.Red, posicion);
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        //Devuelve una lista de las posiciones vacías ("0")
        public Pos[] getPosVacias()
        {
            if (esSolucion()) return null;

            Pos[] posVacias = new Pos[] { };

            Pos posAux;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (tablero[i, j] == '0')
                    {
                        posAux.x = i; posAux.y = j;
                        posVacias = posVacias.Append(posAux).ToArray();
                    }
            return posVacias;
        }

        //Devuelve la cantidad de posiciones vacías
        public int getCantPosVacias()
        {
            int contPosVacias = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (tablero[i, j] == '0') contPosVacias++;
            return contPosVacias;
        }

        //Elimina esa letra en la pos en el tablero
        public void limpiarTablero(Pos pos, char letra = ' ')
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j] == letra || letra == ' ')
                        tablero[i, j] = '0';
                }
            }
        }

        //Vacía el tablero
        public void vaciarTablero()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tablero[i, j] = '0';
                }
            }
        }
    }
}