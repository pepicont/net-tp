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
    public partial class FormCurso : Form
    {
        public FormCurso(string tipoUsuario)
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
            var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>("cursos");

            string id = textBox1.Text;

            if (!string.IsNullOrEmpty(id))
            {


                if (cursos != null)
                {
                    var cursosDescParcial = cursos.Where(c => c.Id.ToString() == id).ToList();
                    Grilla.DataSource = cursosDescParcial;
                    if (!cursosDescParcial.Any())
                    {
                        MessageBox.Show("No se encontraron cursos con esa descripción parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron cursos.");
                }
            }
            else
            {
                if (cursos != null)
                {
                    Grilla.DataSource = cursos;
                }
                else { MessageBox.Show("No se encontraron cursos."); }

            }

        }



        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una curso a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {


                int idToDelete = (int)Grilla.CurrentRow.Cells["Id"].Value;

                Form modal = new ModalDeleteCurso();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"cursos/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó el curso");
                        var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>("cursos");
                        Grilla.DataSource = cursos;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el curso seleccionado",
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
                MessageBox.Show("Debe seleccionar un curso a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {
                int id = (int)Grilla.CurrentRow.Cells["Id"].Value;
                int anioC = (int)Grilla.CurrentRow.Cells["Anio_calendario"].Value;
                int idMateria = (int)Grilla.CurrentRow.Cells["Id_materia"].Value;
                int cupo = (int)Grilla.CurrentRow.Cells["Cupo"].Value;
                Curso comision = new Curso(idMateria, anioC, cupo);
                Form modal = new ModalModificarCurso(id, comision);

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // Recargar los datos en la grilla
                    var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>("cursos");
                    Grilla.DataSource = cursos;
                }
                // Liberar recursos
                modal.Dispose();
            }


        }

        
    }






}






