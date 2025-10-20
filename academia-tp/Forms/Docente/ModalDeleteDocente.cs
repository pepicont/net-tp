using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class ModalDeleteDocente : Form
    {
        public ModalDeleteDocente()
        {
            InitializeComponent();
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void ModalConfirmar_Load(object sender, EventArgs e)
        {

        }
    }
}
