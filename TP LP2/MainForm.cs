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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 1; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 5; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();

        }

        private void btn10_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 10; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();

        }

        private void btn15_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 15; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 20; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 25; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 30; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 35; Global.piezasAgregadas = 0; Tablero.vaciarLista(); Tablero.tablerosSolucion = 0;
            Global.FormUnicaSolucion_ = new FormUnicaSolucion();
            Global.FormUnicaSolucion_.Show();
            this.Hide();
        }
    }
    

}
