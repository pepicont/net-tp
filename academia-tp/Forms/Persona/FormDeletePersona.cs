using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Persona
{
    public partial class FormDeletePersona : Form
    {
        public FormDeletePersona()
        {
            InitializeComponent();
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //no hacen falta
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //no hacen falta
        }
    }
}
