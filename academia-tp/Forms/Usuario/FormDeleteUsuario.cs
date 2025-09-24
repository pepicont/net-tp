using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Usuario
{
    public partial class FormDeleteUsuario : Form
    {
        public FormDeleteUsuario()
        {
            InitializeComponent();
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
