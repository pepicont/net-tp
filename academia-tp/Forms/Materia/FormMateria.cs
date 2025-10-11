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
    public partial class FormMateria : Form
    {
        public FormMateria(string tipoUsuario)
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
            var materias = await _httpClient.GetFromJsonAsync<IEnumerable<Materia>>("materias");

            string descParcial = textBox1.Text;

            if (!string.IsNullOrEmpty(descParcial))
            {


                if (materias != null)
                {
                    var materiasDescParcial = materias.Where(esp => esp.Desc.Contains(descParcial, StringComparison.OrdinalIgnoreCase)).ToList();
                    Grilla.DataSource = materiasDescParcial;
                    if (!materiasDescParcial.Any())
                    {
                        MessageBox.Show("No se encontraron materias con esa descripción parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron Materias.");
                }
            }
            else
            {
                if (materias != null)
                {
                    Grilla.DataSource = materias;
                }
                else { MessageBox.Show("No se encontraron materias."); }

            }

        }

        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una materia a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {


                int idToDelete = (int)Grilla.CurrentRow.Cells["Id"].Value;

                Form modal = new ModalDeleteMateria();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"materias/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó la materia");
                        var materias = await _httpClient.GetFromJsonAsync<IEnumerable<Materia>>("materias");
                        Grilla.DataSource = materias;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar la materia seleccionada",
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
                MessageBox.Show("Debe seleccionar una materia a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {   
                int id = (int)Grilla.CurrentRow.Cells["Id"].Value;
                string? desc = Grilla.CurrentRow.Cells["Desc"].Value?.ToString();
                if (string.IsNullOrEmpty(desc))
                {
                    MessageBox.Show("La descripción de la materia no puede estar vacía.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }

                int hs_semanales = (int)Grilla.CurrentRow.Cells["Hs_semanales"].Value;
                int hs_totales = (int)Grilla.CurrentRow.Cells["Hs_totales"].Value;
                int id_plan = (int)Grilla.CurrentRow.Cells["Id_plan"].Value;

                Materia materia = new Materia(id, desc, hs_semanales, hs_totales, id_plan);
                Form modal = new ModalModificarMateria(materia);

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // Recargar los datos en la grilla
                    var materias = await _httpClient.GetFromJsonAsync<IEnumerable<Materia>>("materias");
                    Grilla.DataSource = materias;
                }
                // Liberar recursos
                modal.Dispose();
            }
        }

    }

}






        
    
        


       