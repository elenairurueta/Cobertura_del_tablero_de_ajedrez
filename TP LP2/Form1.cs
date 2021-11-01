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

        int x = 100;
        int y = 50;
        readonly string btnName = "btnTablero";
        private void Form1_Load(object sender, EventArgs e)
        {
            int nBoton = 0;
            for (int i = 0; i < 8; i++)
            {
                nBoton++;
                for (int j = 0; j < 8; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}{1}{2}", i, j, btnName);
                    btn.Tag = nBoton;
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackColor = Convert.ToInt32(btn.Tag) % 2 == 0 ? Color.White : Color.Black;

                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;

                }
                y += 50;
                x = 100;
            }
        }
    }
    

}
