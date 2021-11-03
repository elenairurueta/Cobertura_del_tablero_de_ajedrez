using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_LP2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInicio());
        }
    }

    public static class Global
    {
        #region ATRIBUTOS

        public static Pieza[] listaPiezas;
        public static int piezasAgregadas;

        public static Tablero tableroAmenazas;
        public static Tablero tableroPiezas;

        public static int TABLEROSMAX;

        public static int PODAREY;
        public static int PODACABALLO;
        public static int PODAALFIL;
        public static int PODATORRE;

        public static MainForm MainForm_;
        public static FormUnicaSolucion FormUnicaSolucion_;
        public static FormSoluciones FormSoluciones_;
        public static FormFin FormFin_;
        public static FormInicio FormInicio_;

        #endregion

        #region CONSTRUCTOR
        static Global()
        {
            listaPiezas = new Pieza[8]{
                                                            new Reina(ColorPieza.NEGRO),
                                                            new Torre(ColorPieza.BLANCO),
                                                            new Alfil(ColorPieza.BLANCO),
                                                            new Torre(ColorPieza.NEGRO),
                                                            new Alfil(ColorPieza.NEGRO),
                                                            new Caballo(ColorPieza.NEGRO),
                                                            new Rey(ColorPieza.BLANCO),
                                                            new Caballo(ColorPieza.BLANCO),
                                                        };
            piezasAgregadas = 0;

            tableroAmenazas = new Tablero();
            tableroPiezas = new Tablero();

            TABLEROSMAX = 0;

            PODAREY = 5;
            PODACABALLO = 4;
            PODAALFIL = 5;
            PODATORRE = 4;

            MainForm_ = new MainForm();
            FormUnicaSolucion_ = new FormUnicaSolucion();
            FormSoluciones_ = new FormSoluciones();
            FormFin_ = new FormFin();
            FormInicio_ = new FormInicio();
        }

        #endregion

        #region MÉTODOS_POS
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
        #endregion
    }
    public struct Pos
    {
        public int x;
        public int y;
    }
    public enum ColorPieza { BLANCO, NEGRO };
}
