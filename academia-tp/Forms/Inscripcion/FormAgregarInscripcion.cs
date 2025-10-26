using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.model;

namespace Forms.Inscripcion
{
    public partial class FormAgregarInscripcion : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        public int IdPersona { get; set; }
        public string TipoUsuario { get; set; } = "Usuario";
        public int TipoPersona { get; set; } = 1;

        private bool PuedeInscribirOtros => TipoUsuario == "Admin" || TipoPersona == 2;

        public FormAgregarInscripcion()
        {
            InitializeComponent();
        }

        public FormAgregarInscripcion(int idPersona) : this()
        {
            IdPersona = idPersona;
        }

        public FormAgregarInscripcion(int idPersona, string tipoUsuario, int tipoPersona) : this()
        {
            IdPersona = idPersona;
            TipoUsuario = tipoUsuario ?? "Usuario";
            TipoPersona = tipoPersona;
        }

        private async void FormAgregarInscripcion_Load(object sender, EventArgs e)
        {
            ConfigurarFormularioPorRol();
            comboBoxCurso.Enabled = false;
            await CargarMaterias();
        }

        private void ConfigurarFormularioPorRol()
        {
            var puedeInscribirOtros = PuedeInscribirOtros;

            textBoxIdAlumno.Visible = puedeInscribirOtros;
            labelIdAlumno.Visible = puedeInscribirOtros;
            button1.Text = puedeInscribirOtros ? "Inscribir Alumno" : "Inscribirse";

            if (!puedeInscribirOtros)
            {
                textBoxIdAlumno.Text = IdPersona.ToString();
            }
        }

        private async Task CargarMaterias()
        {
            try
            {
                var materias = await _httpClient.GetFromJsonAsync<IEnumerable<Materia>>("materias");

                if (materias?.Any() == true)
                {
                    comboBoxMateria.DataSource = materias.ToList();
                    comboBoxMateria.DisplayMember = "Desc";
                    comboBoxMateria.ValueMember = "Id";
                    comboBoxMateria.SelectedIndex = -1;
                }
                else
                {
                    MostrarError("No hay materias disponibles.");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar materias: {ex.Message}");
            }
        }

        private async void comboBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMateria.SelectedValue is int materiaId)
            {
                await CargarCursosPorMateria(materiaId);
                comboBoxCurso.Enabled = true;
            }
            else
            {
                LimpiarCursos();
                comboBoxCurso.Enabled = false;
  
            }
        }

        private async Task CargarCursosPorMateria(int materiaId)
        {
            try
            {
                var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>($"cursos/materia/{materiaId}");

                if (cursos?.Any() == true)
                {
                    var cursosDisplay = cursos.Select(c => new
                    {
                        Id = c.Id,
                        Display = $"Año {c.Anio_calendario} - Cupo: {c.Cupo}"
                    }).ToList();

                    comboBoxCurso.DataSource = cursosDisplay;
                    comboBoxCurso.DisplayMember = "Display";
                    comboBoxCurso.ValueMember = "Id";
                    comboBoxCurso.SelectedIndex = -1;
                }
                else
                {
                    LimpiarCursos();
                    MostrarError("No hay cursos disponibles para esta materia.");
                }
            }
            catch (Exception ex)
            {
                LimpiarCursos();
                MostrarError($"Error al cargar cursos: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones()) return;

            var idAlumnoAInscribir = await ObtenerIdAlumnoParaInscripcion();
            if (idAlumnoAInscribir <= 0) return;

            await RealizarInscripcion(idAlumnoAInscribir);
        }

        private bool ValidarSelecciones()
        {
            if (comboBoxMateria.SelectedValue == null)
            {
                MostrarError("Debe seleccionar una materia.");
                return false;
            }

            if (comboBoxCurso.SelectedValue == null)
            {
                MostrarError("Debe seleccionar un curso.");
                return false;
            }
            return true;
        }

        private async Task<int> ObtenerIdAlumnoParaInscripcion()
        {
            if (!PuedeInscribirOtros)
            {
                return IdPersona > 0 ? IdPersona : 0;
            }

            if (string.IsNullOrWhiteSpace(textBoxIdAlumno.Text))
            {
                MostrarError("Debe ingresar el ID del alumno.");
                return 0;
            }

            if (!int.TryParse(textBoxIdAlumno.Text.Trim(), out int idAlumno) || idAlumno <= 0)
            {
                MostrarError("El ID del alumno debe ser un número válido mayor a 0.");
                return 0;
            }

            try
            {
                var persona = await _httpClient.GetFromJsonAsync<Domain.model.Persona>($"personas/{idAlumno}");

                if (persona == null)
                {
                    MostrarError("No se encontró una persona con ese ID.");
                    return 0;
                }

                if (persona.Tipo_persona != 1)
                {
                    MostrarError("El ID ingresado no corresponde a un alumno válido.");
                    return 0;
                }

                return idAlumno;
            }
            catch (Exception)
            {
                MostrarError("No se pudo validar el alumno.");
                return 0;
            }
        }

        private async Task RealizarInscripcion(int idAlumno)
        {
            try
            {
                int idCursoSeleccionado = (int)comboBoxCurso.SelectedValue;

                var inscripcion = new Domain.model.Inscripcion
                {
                    Id_alumno = idAlumno,
                    Id_curso = idCursoSeleccionado,
                    Condicion = "Inscripto",
                    Nota = null,
                    Fecha_inscripcion = DateTime.Now
                };

                var response = await _httpClient.PostAsJsonAsync("inscripciones", inscripcion);

                if (response.IsSuccessStatusCode)
                {
                    // Actualizar el cupo del curso
                    var curso = await _httpClient.GetFromJsonAsync<Curso>($"cursos/{idCursoSeleccionado}");
                    if (curso != null)
                    {
                        curso.Cupo = Math.Max(0, curso.Cupo - 1); // Evita cupo negativo
                        await _httpClient.PutAsJsonAsync($"cursos/{curso.Id}", curso);
                    }

                    MessageBox.Show("Inscripción realizada exitosamente!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MostrarError($"Error al realizar la inscripción: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }
        }

        private void LimpiarCursos()
        {
            comboBoxCurso.DataSource = null;
        }


        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}