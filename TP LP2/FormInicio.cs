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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Global.MainForm_ = new MainForm();
            Global.MainForm_.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nuestro algoritmo se basa en backtracking...");
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
