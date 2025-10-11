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
    public partial class ModalDeleteMateria : Form
    {
        public ModalDeleteMateria()
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
