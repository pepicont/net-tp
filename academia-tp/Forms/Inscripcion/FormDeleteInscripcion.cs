using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Inscripcion
{
    public partial class FormDeleteInscripcion : Form
    {
        public FormDeleteInscripcion()
        {
            InitializeComponent();
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // No hace falta implementar nada aquí
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // No hace falta implementar nada aquí
        }
    }
}