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
    public partial class FormFin : Form
    {
        public FormFin()
        {
            InitializeComponent();
        }

        private void btnSi_CheckedChanged(object sender, EventArgs e)
        {
            Global.FormSoluciones_ = new FormSoluciones();
            Global.FormSoluciones_.Show();
            this.Close();
        }

        private void btnNo_CheckedChanged(object sender, EventArgs e)
        {
            Global.FormInicio_.Show();
            Global.FormSoluciones_.Close();
            Global.FormUnicaSolucion_.Close();
            Global.MainForm_.Close();
            this.Close();
        }

        private void FormFin_Load(object sender, EventArgs e)
        {

        }
    }
}
