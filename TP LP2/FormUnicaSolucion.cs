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
    public partial class FormUnicaSolucion : Form
    {
        private PictureBox[,] tableroPiezas;
        private PictureBox[,] tableroAmenazas;
        private ArgsTableros[] tablerosImprimir = new ArgsTableros[] { };
        private int contadorImpresos = 0;
        public FormUnicaSolucion()
        {
            InitializeComponent();
            tableroPiezas = new PictureBox[8, 8];
            tableroAmenazas = new PictureBox[8, 8];
        }

        public string pctBoxNamePiezas = "pctBoxPiezas";
        public string pctBoxNameAmenazas = "pctBoxAmenazas";

        private void FormUnicaSolucion_Load(object sender, EventArgs e)
        {
            int x = 100;
            int y = 50;
            int pctBoxPiezas = 0;
            int pctBoxAmenazas = 0; 

            for (int j = 0; j < 8; j++)
            {
                pctBoxAmenazas++; pctBoxPiezas++;
                for (int i = 0; i < 8; i++)
                {
                    tableroPiezas[i, j] = new PictureBox(); tableroAmenazas[i, j] = new PictureBox();
                    tableroPiezas[i, j].Text = ""; tableroAmenazas[i, j].Text = "";
                    tableroPiezas[i, j].Name = string.Format("{0}{1}{2}", i, j, pctBoxNamePiezas); tableroAmenazas[i, j].Name = string.Format("{0}{1}{2}", i, j, pctBoxNameAmenazas);
                    tableroPiezas[i, j].Tag = pctBoxPiezas; tableroAmenazas[i, j].Tag = pctBoxAmenazas;
                    tableroPiezas[i, j].Location = new Point(x, y); tableroAmenazas[i, j].Location = new Point(x + 500, y);
                    tableroPiezas[i, j].Size = new Size(50, 50); tableroAmenazas[i, j].Size = new Size(50, 50);
                    tableroPiezas[i, j].BackColor = Convert.ToInt32(tableroPiezas[i, j].Tag) % 2 == 0 ? Color.White : Color.Black; tableroAmenazas[i, j].BackColor = Color.White;
                    tableroAmenazas[i, j].BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(tableroPiezas[i, j]); this.Controls.Add(tableroAmenazas[i, j]);
                    x += 50;
                    pctBoxAmenazas++; pctBoxPiezas++;
                }
                y += 50;
                x = 100;
            }
        }
        public void setImagen(string imagen, Pos posicion)
        {
            Image newImage = Image.FromFile(imagen);

            tableroPiezas[posicion.x, posicion.y].Image = newImage;
            tableroPiezas[posicion.x, posicion.y].SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public Color getColor(Pos posicion)
        {
            if(tableroPiezas[posicion.x, posicion.y].BackColor == Color.White)
                return Color.White;
            else
                return Color.Black;
        }
        public void setBackgroundColor(Color color, Pos posicion)
        {
            tableroAmenazas[posicion.x, posicion.y].BackColor = color;
        }
        public void vaciarTableros()
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    tableroPiezas[i, j].BackColor = Convert.ToInt32(tableroPiezas[i, j].Tag) % 2 == 0 ? Color.White : Color.Black;
                    tableroPiezas[i, j].Image = null;
                    tableroAmenazas[i, j].BackColor = Color.White;
                }
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Tablero.imprimirTableros(tablerosImprimir[0].tableroPiezas_, tablerosImprimir[0].tableroAmenazas_); contadorImpresos++;

            ArgsTableros[] tableroQuitar = new ArgsTableros[1] { tablerosImprimir[0] }; this.tablerosImprimir = tablerosImprimir.Except(tableroQuitar).ToArray();

            if (tablerosImprimir.Length == 0)
            {
                btnSiguiente.Enabled = false; setProgressBar(0);
            }
            if (contadorImpresos == Global.TABLEROSMAX)
            {
                btnSiguiente.Visible = false; btnFinalizar.Visible = true;

            }
        }

        private void TableroAmenazas_OnSolution(object sender, ArgsTableros tablerosSolucion)
        {
            ArgsTableros tablerosImprimirAux = new ArgsTableros { tableroAmenazas_ = new Tablero(), tableroPiezas_ = new Tablero() };
            tablerosImprimirAux.tableroPiezas_.copyFrom(tablerosSolucion.tableroPiezas_);
            tablerosImprimirAux.tableroAmenazas_.copyFrom(tablerosSolucion.tableroAmenazas_);

            this.tablerosImprimir = tablerosImprimir.Append(tablerosImprimirAux).ToArray();
            btnSiguiente.Enabled = true; setProgressBar(100);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Global.tableroAmenazas.OnSolution += TableroAmenazas_OnSolution;
            btnIniciar.Visible = false;
            btnSiguiente.Visible = true; btnSiguiente.Enabled = false;
            setProgressBar(0);
            Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
            
        }

        public void setProgressBar(int value, bool sumar = false)
        {
            if (sumar)
            {
                if (progressBar.Value < 90)
                {
                    progressBar.Value += value;
                }
            }
            else
            {
                progressBar.Value = value;
            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Global.FormFin_ = new FormFin();
            Global.FormFin_.Show();
            this.Close();
        }
    }
}
