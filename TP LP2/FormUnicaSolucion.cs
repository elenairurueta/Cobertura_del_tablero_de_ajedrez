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
        public FormUnicaSolucion()
        {
            InitializeComponent();
            Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
        }

        int x = 100;
        int y = 50;
        string pctBoxName = "pctBox";
        private void FormUnicaSolucion_Load(object sender, EventArgs e)
        {
            int pctBoxN = 0;
            for (int i = 0; i < 8; i++)
            {
                pctBoxN++;
                for (int j = 0; j < 8; j++)
                {
                    var pctBox = new PictureBox();
                    pctBox.Text = "";
                    pctBox.Name = string.Format("{0}{1}{2}", i, j, pctBoxName);
                    pctBox.Tag = pctBoxN;
                    pctBox.Location = new Point(x, y);
                    pctBox.Size = new Size(50, 50);
                    pctBox.BackColor = Convert.ToInt32(pctBox.Tag) % 2 == 0 ? Color.White : Color.Black;
                    this.Controls.Add(pctBox);
                    x += 50;
                    pctBoxN++;
                }
            }
            y += 50;
            x = 100;
        }

        public void setImagen(string imagen)
        {
            Image newImage = Image.FromFile(imagen);
            //pctBox.Image = newImage;
            //pctBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public Color getColor(Pos posicion)
        {
            return Color.White;
            return Color.Black;
        }
    }
}
