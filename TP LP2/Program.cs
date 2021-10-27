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
            
            Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
            //TODO: que se pueda elegir la cantidad de tableros en el forms (botones 1 5 10 ...)
            //TODO: que no falte NADA del enunciado
            //hasta 1 min 30 para las 10 soluciones (rotar, espejar, etc)
            //que los alfiles no puedan ir en las diagonales de la reina
        }
    }
    public class Global
    {
        public static Pieza[] listaPiezas = new Pieza[8]{
                                                            new Reina(Color.NEGRO),
                                                            new Torre(Color.BLANCO),
                                                            new Torre(Color.NEGRO),
                                                            new Alfil(Color.BLANCO),
                                                            new Alfil(Color.NEGRO),
                                                            new Caballo(Color.BLANCO),
                                                            new Caballo(Color.NEGRO),
                                                            new Rey(Color.BLANCO)
                                                        };
        public static int piezasAgregadas = 0;
        public static Tablero tableroAmenazas = new Tablero();
        public static Tablero tableroPiezas = new Tablero();
        public const int TABLEROSMAX = 10;
        public static Pos[] sacarPosRepetidas(Pos[] arrayPos)
        {
            arrayPos = arrayPos.Distinct().ToArray();
            return arrayPos;
        }

    }
    public struct Pos
    {
        public int x;
        public int y;
    }
    public enum Color { BLANCO, NEGRO };
}
