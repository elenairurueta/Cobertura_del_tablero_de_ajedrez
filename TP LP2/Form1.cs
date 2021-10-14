using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TP_LP2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class Global
    {
        public static Pieza[] listaPiezas = new Pieza[8]{
                                                            new Reina(),
                                                            new Torre(),
                                                            new Torre(),
                                                            new Alfil(),
                                                            new Alfil(),
                                                            new Caballo(),
                                                            new Caballo(),
                                                            new Rey()
                                                        };
        public static int piezasAgregadas = 0;
        public static Tablero tableroAmenazas = new Tablero();
        public static Tablero tableroPiezas = new Tablero();
        public const int TABLEROSMAX = 10;
        public static Tablero[] listaTablerosSolucion = new Tablero[TABLEROSMAX];
        public static int tablerosSolucion = 0;

    }
    public struct Pos
    {
        public int x;
        public int y;
    }
    public enum Color { BLANCO, NEGRO };

}
