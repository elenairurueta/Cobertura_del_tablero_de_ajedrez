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
    public partial class FormSoluciones : Form
    {
        List<PictureBox[,]> tablerosImprimir = new List<PictureBox[,]>();
        public FormSoluciones()
        {
            InitializeComponent();
            
        }

        private void FormSoluciones_Load(object sender, EventArgs e)
        {
            Pos posicion = new Pos(); string nombreImagen = "";
            int x = 100, y = 100; int contTablerosAgregados = 0; int contTag = 0; int filasTableros = 0;

            for (int i = 0; i < Global.TABLEROSMAX; i++)
            {
                Tablero tableroAux = (Tablero)Tablero.listaTablerosSolucion.GetValue(i);
                PictureBox[,] pictureBoxTablero = new PictureBox[8, 8];

                contTag = 0;
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        posicion.x = j; posicion.y = k;

                        pictureBoxTablero[posicion.x, posicion.y] = new PictureBox();
                        pictureBoxTablero[posicion.x, posicion.y].Text = "";
                        pictureBoxTablero[posicion.x, posicion.y].Name = string.Format("{0}{1}", j, k);
                        pictureBoxTablero[posicion.x, posicion.y].Tag = contTag;
                        pictureBoxTablero[posicion.x, posicion.y].Location = new Point(x, y);
                        pictureBoxTablero[posicion.x, posicion.y].Size = new Size(20, 20);
                        pictureBoxTablero[posicion.x, posicion.y].BackColor = Convert.ToInt32(pictureBoxTablero[posicion.x, posicion.y].Tag) % 2 == 0 ? Color.White : Color.Black;
                        pictureBoxTablero[posicion.x, posicion.y].BorderStyle = BorderStyle.FixedSingle;
                        this.Controls.Add(pictureBoxTablero[posicion.x, posicion.y]);
                        contTag++;

                        switch (tableroAux.getCaracter(posicion))
                        {
                            case 'Q':
                                nombreImagen = "Img\\Reina" + ((pictureBoxTablero[posicion.x, posicion.y].BackColor == Color.White) ? "N" : "B") + ".png";
                                break;
                            case 'T':
                                nombreImagen = "Img\\Torre" + ((pictureBoxTablero[posicion.x, posicion.y].BackColor == Color.White) ? "N" : "B") + ".png";
                                break;
                            case 'A':
                                nombreImagen = "Img\\Alfil" + ((pictureBoxTablero[posicion.x, posicion.y].BackColor == Color.White) ? "N" : "B") + ".png";
                                break;
                            case 'C':
                                nombreImagen = "Img\\Caballo" + ((pictureBoxTablero[posicion.x, posicion.y].BackColor == Color.White) ? "N" : "B") + ".png";
                                break;
                            case 'K':
                                nombreImagen = "Img\\Rey" + ((pictureBoxTablero[posicion.x, posicion.y].BackColor == Color.White) ? "N" : "B") + ".png";
                                break;
                            default:
                                break;
                        }
                        Image newImage = Image.FromFile(nombreImagen);
                        pictureBoxTablero[posicion.x, posicion.y].Image = newImage;
                        pictureBoxTablero[posicion.x, posicion.y].SizeMode = PictureBoxSizeMode.StretchImage;

                        x += 20;
                    }
                    y += 20;
                    if (contTablerosAgregados < 5)
                    {
                        x = 100 + contTablerosAgregados*260; 
                        y -= 160;
                    }
                    else if (contTablerosAgregados == 5)
                    {
                        contTablerosAgregados = 0; filasTableros++;
                        x = 100; 
                        y = 100 + filasTableros*260;
                    }

                }
                contTablerosAgregados++;
            }
        }

        private void btnVolverMain_Click(object sender, EventArgs e)
        {
            Global.FormInicio_.Show();
            this.Close();
        }
    }
}
