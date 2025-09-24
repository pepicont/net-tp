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
using DTOs;

namespace Forms
{
    public partial class FormPlan : Form
    {
        public FormPlan(string tipoUsuario)
        {
            InitializeComponent();
            if (tipoUsuario == "Usuario")
            {
                ButtonEliminar.Visible = false;
                ButtonModificar.Visible = false;
                ButtonCrear.Visible = false;
            }
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void ButtonBuscar_Click(object sender, EventArgs e)
        {
            var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");

            string descParcial = textBox1.Text;

            if (!string.IsNullOrEmpty(descParcial))
            {


                if (planes != null)
                {
                    var planesDescParcial = planes.Where(pln => pln.Desc.Contains(descParcial, StringComparison.OrdinalIgnoreCase)).ToList();
                    Grilla.DataSource = planesDescParcial;
                    if (!planesDescParcial.Any())
                    {
                        MessageBox.Show("No se encontraron planes con esa descripción parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron planes.");
                }
            }
            else
            {
                if (planes != null)
                {
                    Grilla.DataSource = planes;
                }
                else { MessageBox.Show("No se encontraron planes."); }

            }

        }

        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un plan a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {


                int idToDelete = (int)Grilla.CurrentRow.Cells["Id"].Value;

                Form modal = new ModalDeletePlan();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"planes/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó el plan");
                        var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                        Grilla.DataSource = planes;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el plan seleccionado",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                    }
                }

                // Liberar recursos
                modal.Dispose();


            }
        }

        private async void ButtonCrear_Click(object sender, EventArgs e)
        {
            Form modal = new ModalAgregarPlan();

            // Mostrar como modal (bloquea la ventana padre)
            DialogResult result = modal.ShowDialog();

            // Procesar el resultado si es necesario
            if (result == DialogResult.OK)
            {
                // Recargar los datos en la grilla
                var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                Grilla.DataSource = planes;
            }
            // Liberar recursos
            modal.Dispose();
        }

        private async void ButtonModificar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un plan a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {
                int id = (int)Grilla.CurrentRow.Cells["Id"].Value;
                string desc = Grilla.CurrentRow.Cells["Desc"].Value.ToString();
                int id_especialidad = (int)Grilla.CurrentRow.Cells["Id_especialidad"].Value;
                Plan plan = new Plan(id, desc,id_especialidad);
                Form modal = new ModalModificarPlan(plan);

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // Recargar los datos en la grilla
                    var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                    Grilla.DataSource = planes;
                }
                // Liberar recursos
                modal.Dispose();
            }

        }
    }
}

        
 