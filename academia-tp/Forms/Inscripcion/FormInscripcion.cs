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

namespace Forms.Inscripcion
{
    public partial class FormInscripcion : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        public string TipoUsuario { get; set; }  // Admin o Usuario
        public int TipoPersona { get; set; }     // 1=Alumno, 2=Profesor
        public int IdPersona { get; set; }

        public FormInscripcion()
        {
            InitializeComponent();
        }

        private async void FormInscripcion_Load(object sender, EventArgs e)
        {
            await CargarInscripciones();
        }

        private async Task CargarInscripciones()
        {
            try
            {
                IEnumerable<DTOs.InscripcionDTO> inscripciones;

                // La lógica de filtrado:
                if (TipoUsuario == "Admin" || TipoPersona == 2) // Admin o Profesor
                {
                    inscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<DTOs.InscripcionDTO>>("inscripciones/search");
                }
                else // Alumno (TipoPersona == 1)
                {
                    inscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<DTOs.InscripcionDTO>>($"inscripciones/alumno/{IdPersona}");
                }

                if (inscripciones != null)
                {
                    dataGridView1.DataSource = inscripciones.ToList();
                    ConfigurarGridPorRol();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inscripciones: {ex.Message}");
            }
        }

        private async void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = textBoxBuscar.Text;
                IEnumerable<DTOs.InscripcionDTO> inscripciones;

                if (TipoUsuario == "Admin" || TipoPersona == 2) // Admin o Profesor
                {
                    inscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<DTOs.InscripcionDTO>>(
                        $"inscripciones/search?searchTerm={Uri.EscapeDataString(searchTerm)}"
                    );
                }
                else // Alumno
                {
                    // Para alumnos, primero obtener sus inscripciones y luego filtrar
                    var todasSusInscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<DTOs.InscripcionDTO>>($"inscripciones/alumno/{IdPersona}");

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        var searchTermLower = searchTerm.ToLower();
                        inscripciones = todasSusInscripciones?.Where(i =>
                            i.DescMateria.ToLower().Contains(searchTermLower) ||
                            i.Condicion.ToLower().Contains(searchTermLower)
                        );
                    }
                    else
                    {
                        inscripciones = todasSusInscripciones;
                    }
                }

                if (inscripciones != null && inscripciones.Any())
                {
                    dataGridView1.DataSource = inscripciones.ToList();
                    ConfigurarGridPorRol();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
                    {
                        dataGridView1.DataSource = inscripciones?.ToList();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron inscripciones con ese criterio de búsqueda.");
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar inscripciones: {ex.Message}");
            }
        }

        private void ConfigurarGridPorRol()
        {
            if (TipoUsuario == "Admin")
            {
                // Admin ve todo
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns["Id"].Visible = true;
                dataGridView1.Columns["Id_alumno"].Visible = true;
                dataGridView1.Columns["Id_curso"].Visible = true;
                dataGridView1.Columns["Fecha_inscripcion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            else // Usuario (Profesor o Alumno)
            {
                // Usuarios no ven IDs
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Id_alumno"].Visible = false;
                dataGridView1.Columns["Id_curso"].Visible = false;
                dataGridView1.Columns["Fecha_inscripcion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            // Implementación pendiente
        }


        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una inscripción a borrar primero",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                int idToDelete = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                Form modal = new FormDeleteInscripcion();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    try
                    {
                        var response = await _httpClient.DeleteAsync($"inscripciones/{idToDelete}");
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Se eliminó la inscripción");
                            // Recargar datos según el tipo de usuario
                            await CargarInscripciones();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo borrar la inscripción seleccionada",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la inscripción: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

                // Liberar recursos
                modal.Dispose();
            }
        }

        private void buttonReporteAlumnos_Click(object sender, EventArgs e)
        {
            FormReporteAlumnos formReporte = new FormReporteAlumnos();
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

        private void buttonReporteGrafico_Click(object sender, EventArgs e)
        {
            FormReporteGrafico formReporte = new FormReporteGrafico();
            formReporte.ShowDialog();
            formReporte.Dispose();
        }
    }
}
