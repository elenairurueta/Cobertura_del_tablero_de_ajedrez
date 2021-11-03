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
        public FormSoluciones()
        {
            InitializeComponent();
        }

        private void FormSoluciones_Load(object sender, EventArgs e)
        {

        }

        private void btnVolverMain_Click(object sender, EventArgs e)
        {
            Global.FormInicio_.Show();
            this.Close();
        }
    }
}
