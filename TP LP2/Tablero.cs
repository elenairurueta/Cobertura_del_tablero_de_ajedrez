using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    public class Tablero
    {
        private char[,] tablero = new char[8, 8];

        public Tablero()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.tablero[i, j] = '0';
                }
            }
        }
        public bool agregarCaracter(char simbolo, Pos posicion)
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
            Tablero tableroAgregar = new Tablero();
            tableroAgregar = Global.tableroPiezas; //para que al cambiar tableroPiezas no se cambien los tableros solución

            Global.listaTablerosSolucion.Append(tableroAgregar).ToArray();
            Global.tablerosSolucion++;
            return true;
        }

        //imprime tableroPiezas
        public void imprimirTablero()
        {
            Console.WriteLine("\n----------\n");
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                    Console.Write(tablero[j, i] + " ");
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n----------\n");
        }
        //Devuelve una lista de las posiciones vacías ("0")
        public Pos[] getPosVacias()
        {
            if (esSolucion()) return null;

            Pos[] posVacias = new Pos[getCantPosVacias()];

            int idx = 0; Pos posAux;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (tablero[i, j] == '0') {
                        posAux.x = i; posAux.y = j;
                        posVacias[idx] = posAux;
                        idx++;
                    }
            return posVacias;
        }
        public int getCantPosVacias()
        {
            int contPosVacias = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (tablero[i, j] == '0') contPosVacias++;
            return contPosVacias;
        }

        //Si no recibe ninguna letra, vacía el tablero, sino elimina esa letra en la pos en el tablero
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

        
    }
}