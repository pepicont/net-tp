using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.services;

namespace Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();        }

        public string tipoUsuario { get; set; }
        public string Tipo { get; set; }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string clave = txtPass.Text;
            var usuario = AuthService.Login(nombreUsuario, clave);
            if (usuario == null)
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                tipoUsuario = "";
            }
            else
            {
                MessageBox.Show("Inicio de sesión exitoso");
                tipoUsuario = usuario; // Asignar el usuario
                Tipo = usuario.Tipo;
                DialogResult = DialogResult.OK;
                this.Close();
            }



        }

        private void InkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //recuperación de contraseña
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //pulsé sin querer
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            //lógica de crear cuenta
        }
    }
}
