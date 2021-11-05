using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LP2
{
    public abstract class Pieza
    {
        #region ATRIBUTOS
        protected char simbolo;
        protected ColorPieza color;
        #endregion

        #region CONSTRUCTOR
        protected Pieza(char simbolo_, ColorPieza color_) {
            this.simbolo = simbolo_;
            this.color = color_;
        }
        #endregion

        //devuelve las mejores posiciones para colocar una pieza ordenada según cuántos casilleros (nuevos) amenaza en esa posición
        public abstract Pos[] getMejoresPos();

        //hace un conteo de las posibles amenazas (nuevas) de la pieza en la posición
        protected abstract int cuantasAmenaza(Pos posicion);

        //coloca una pieza en las mejores posiciones y llama a que se coloquen las posteriores de listaPiezas
        public void colocarPieza()
        {
            Pos[] mejoresPos = getMejoresPos();

            //para cada una de las mejores posiciones (ya ordenadas):

            for (int i = 0; i < mejoresPos.Length; i++)
            {
                if (Global.tableroPiezas.setCaracter(simbolo, mejoresPos[i]))//agregamos la pieza
                {
                    actualizarAmenazas(); //actualizamos las amenazas de esta y todas las otras piezas

                    Global.tableroAmenazas.esSolucion();//si es solución se agrega el tablero a la lista de tableros solución
                    
                    if ((Global.piezasAgregadas < Global.listaPiezas.Length)&&(Tablero.tablerosSolucion < Global.TABLEROSMAX))//si todavía no se colocaron todas las piezas y no se generaron todos los tableros, se coloca la siguiente
                    {
                        Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
                        Global.FormUnicaSolucion_.setProgressBar(5, true);
                    }
                    Global.tableroPiezas.limpiarTablero(mejoresPos[i], simbolo);
                }
            }
            Global.piezasAgregadas--;
        }

        //vacía el tablero y llama a colorearAtaque() de todas las piezas ya colocadas
        protected void actualizarAmenazas()
        {
            Pos posicion;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posicion.x = i; posicion.y = j;
                    Global.tableroAmenazas.vaciarTablero();
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posicion.x = i; posicion.y = j;
                    switch (Global.tableroPiezas.getCaracter(posicion))
                    {
                        case 'Q':
                            Reina.colorearAtaque(posicion);
                            break;
                        case 'T':
                            Torre.colorearAtaque(posicion);
                            break;
                        case 'A':
                            Alfil.colorearAtaque(posicion);
                            break;
                        case 'C':
                            Caballo.colorearAtaque(posicion);
                            break;
                        case 'K':
                            Rey.colorearAtaque(posicion);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //ordena el array de posiciones pasado por parámetro según cuántos casilleros (no amenazados) amenazaría en esa posición (en orden descendiente)
        protected Pos[] ordenarPosSegunCuantasAmenazan(Pos[] listaPos)
        {
            int contCambios;
            for (int i = 0; i < listaPos.Length; i++)
            {
                contCambios = 0;
                for (int j = 0; j < listaPos.Length - 1; j++)
                {
                    if (cuantasAmenaza(listaPos[j]) < cuantasAmenaza(listaPos[j + 1]))
                    {
                        Pos aux = listaPos[j];
                        listaPos[j] = listaPos[j + 1];
                        listaPos[j + 1] = aux;
                        contCambios++;
                    }
                }
                if (contCambios == 0)
                    break;
            }
            return listaPos;
        }
    }
}
