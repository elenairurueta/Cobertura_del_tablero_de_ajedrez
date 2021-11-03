using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_LP2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1()); 
            //TODO: descomentar
            
            //TODO: que se pueda elegir la cantidad de tableros en el forms (botones 1 5 10 ...)
            //TODO: que no falte NADA del enunciado
            //hasta 1 min 30 para las 10 soluciones (rotar, espejar, etc)
            //que los alfiles no puedan ir en las diagonales de la reina?
        }
    }
    public class Global
    {
        public static Pieza[] listaPiezas = new Pieza[8]{
                                                            new Reina(ColorPieza.NEGRO),
                                                            new Torre(ColorPieza.BLANCO),
                                                            new Torre(ColorPieza.NEGRO),
                                                            new Alfil(ColorPieza.BLANCO),
                                                            new Alfil(ColorPieza.NEGRO),
                                                            new Rey(ColorPieza.BLANCO),
                                                            new Caballo(ColorPieza.BLANCO),
                                                            new Caballo(ColorPieza.NEGRO)
                                                        };
        public static int piezasAgregadas = 0;
        public static Tablero tableroAmenazas = new Tablero();
        public static Tablero tableroPiezas = new Tablero();
        public static int TABLEROSMAX = 0;
        public const int PODAREY = 5;
        public const int PODACABALLO = 5;
        public const int PODAALFIL = 7;
        public static MainForm MainForm_ = new MainForm();
        public static FormUnicaSolucion FormUnicaSolucion_ = new FormUnicaSolucion();


        public static Pos[] sacarPosRepetidas(Pos[] arrayPos)
        {
            return arrayPos.Distinct().ToArray();
        }
        public static Pos[] devolverNprimerasPos(int N, Pos[] arrayPos)
        {
            if (N < arrayPos.Length)
            {
                Pos[] resultado = new Pos[N];
                for (int i = 0; i < N; i++)
                    resultado[i] = arrayPos[i];
                return resultado;
            }
            else
                return arrayPos;
        }
    }
    public struct Pos
    {
        public int x;
        public int y;
    }
    public enum ColorPieza { BLANCO, NEGRO };
}
