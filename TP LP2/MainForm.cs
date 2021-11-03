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
            Global.TABLEROSMAX = 1;
            Global.FormUnicaSolucion_.Show();
            this.Hide();

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 5;
            Global.FormUnicaSolucion_.Show();
            this.Hide();

        }

        private void btn10_Click(object sender, EventArgs e)
        {
            Global.TABLEROSMAX = 10;
            Global.FormUnicaSolucion_.Show();
            this.Hide();

        }
    }
    

}
