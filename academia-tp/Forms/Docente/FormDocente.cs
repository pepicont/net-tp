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
    public partial class FormDocente : Form
    {
        public FormDocente(string tipoUsuario)
        {
            InitializeComponent();
            if (tipoUsuario == "Usuario")
            {
                ButtonEliminar.Visible = false;
                ButtonModificar.Visible = false;
            }
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void ButtonBuscar_Click(object sender, EventArgs e)
        {
            var docentes = await _httpClient.GetFromJsonAsync<IEnumerable<Docente>>("docentes");

            string descParcial = textBox1.Text;

            if (docentes != null)
            {
                Grilla.DataSource = docentes;
            }
            else { MessageBox.Show("No se encontraron docentes."); }

        }

        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {


                int idToDelete = (int)Grilla.CurrentRow.Cells["Id"].Value;

                Form modal = new ModalDeleteDocente();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"docentes/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó la especialidad");
                        var docentes = await _httpClient.GetFromJsonAsync<IEnumerable<Docente>>("docentes");
                        Grilla.DataSource = docentes;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar la especialidad seleccionada",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                    }
                }

                // Liberar recursos
                modal.Dispose();


            }
        }

        private async void ButtonModificar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {
                int id = (int)Grilla.CurrentRow.Cells["Id"].Value;
                int idDocente = (int)Grilla.CurrentRow.Cells["Id_docente"].Value;
                int idCurso = (int)Grilla.CurrentRow.Cells["Id_curso"].Value;
                string cargo = Grilla.CurrentRow.Cells["Cargo"].Value.ToString();

                Docente especialidad = new Docente(idDocente, idCurso, cargo);
                Form modal = new ModalModificarDocente(id, especialidad);

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // Recargar los datos en la grilla
                    var docentes = await _httpClient.GetFromJsonAsync<IEnumerable<Docente>>("docentes");
                    Grilla.DataSource = docentes;
                }
                // Liberar recursos
                modal.Dispose();
            }


        }

    }
}
