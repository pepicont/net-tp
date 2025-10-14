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
    public partial class FormComision : Form
    {
        public FormComision(string tipoUsuario)
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
            var comisiones = await _httpClient.GetFromJsonAsync<IEnumerable<Comision>>("comisiones");

            string descParcial = textBox1.Text;

            if (!string.IsNullOrEmpty(descParcial))
            {


                if (comisiones != null)
                {
                    var comisionesDescParcial = comisiones.Where(esp => esp.Desc.Contains(descParcial, StringComparison.OrdinalIgnoreCase)).ToList();
                    Grilla.DataSource = comisionesDescParcial;
                    if (!comisionesDescParcial.Any())
                    {
                        MessageBox.Show("No se encontraron comisiones con esa descripción parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron comisiones.");
                }
            }
            else
            {
                if (comisiones != null)
                {
                    Grilla.DataSource = comisiones;
                }
                else { MessageBox.Show("No se encontraron comisiones."); }

            }

        }

        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una comision a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {


                int idToDelete = (int)Grilla.CurrentRow.Cells["Id"].Value;

                Form modal = new ModalDeleteComision();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"comisiones/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó la comision");
                        var comisiones = await _httpClient.GetFromJsonAsync<IEnumerable<Comision>>("comisiones");
                        Grilla.DataSource = comisiones;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar la comision seleccionada",
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
                MessageBox.Show("Debe seleccionar una comision a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {
                int id = (int)Grilla.CurrentRow.Cells["Id"].Value;
                string desc = Grilla.CurrentRow.Cells["Desc"].Value.ToString();
                int anio_especialidad = (int)Grilla.CurrentRow.Cells["Anio_especialidad"].Value;
                int id_plan = (int)Grilla.CurrentRow.Cells["Id_plan"].Value;
                Comision comision = new Comision(desc, anio_especialidad, id_plan);
                Form modal = new ModalModificarComision(id,comision);

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // Recargar los datos en la grilla
                    var comisiones = await _httpClient.GetFromJsonAsync<IEnumerable<Comision>>("comisiones");
                    Grilla.DataSource = comisiones;
                }
                // Liberar recursos
                modal.Dispose();
            }


        }

    }






}





