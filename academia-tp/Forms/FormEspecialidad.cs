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
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
namespace Forms
{
    public partial class FormEspecialidad : Form
    {
        public FormEspecialidad()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void ButtonBuscar_Click(object sender, EventArgs e)
        {
            var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");

            string descParcial = textBox1.Text;

            if (!string.IsNullOrEmpty(descParcial))
            {


                if (especialidades != null)
                {
                    var especialidadesDescParcial = especialidades.Where(esp => esp.Desc.Contains(descParcial, StringComparison.OrdinalIgnoreCase)).ToList();
                    Grilla.DataSource = especialidadesDescParcial;
                    if (!especialidadesDescParcial.Any())
                    {
                        MessageBox.Show("No se encontraron especialidades con esa descripción parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron especialidades.");
                }
            }
            else
            {
                if (especialidades != null)
                {
                    Grilla.DataSource = especialidades;
                }
                else { MessageBox.Show("No se encontraron especialidades."); }

            }

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

                Form modal = new ModalDeleteEspecialidad();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"especialidades/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó la especialidad");
                        var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                        Grilla.DataSource = especialidades;


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
                string desc = Grilla.CurrentRow.Cells["Desc"].Value.ToString();
                Especialidad especialidad = new Especialidad (id, desc);
                Form modal = new ModalModificarEspecialidad(especialidad);

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    try
                    {

                        // Realizar el PUT request
                        var response = await _httpClient.PutAsJsonAsync($"especialidades/{id}", especialidad);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Se modificó la especialidad");

                            // Recargar los datos en la grilla
                            var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                            Grilla.DataSource = especialidades;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar la especialidad: {ex.Message}");
                    }
                    


                    }
                    
                // Liberar recursos
                modal.Dispose();
            }
                
            }

                

                


            }
        }
    
        


       