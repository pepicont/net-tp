using Domain.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.model;

namespace Forms
{
    public partial class FormLogin : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        public FormLogin()
        {
            InitializeComponent();        }

        public string Id { get; set; }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string clave = txtPass.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.");
                return;
            }

            try
            {
                var response = await _httpClient.PostAsync(
                    $"auth/login?username={nombreUsuario}&password={clave}",
                    null);

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<Domain.model.Usuario>();

                    if (usuario != null)
                    {
                        MessageBox.Show("Inicio de sesión exitoso");
                        Id = usuario.Id.ToString();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}");
            }



        }

        private void InkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperacionContrasenia recuperar = new FormRecuperacionContrasenia();
            recuperar.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //pulsé sin querer
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            //lógica de crear cuenta, al 
        }
    }
}
