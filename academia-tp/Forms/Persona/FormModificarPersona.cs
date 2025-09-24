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

namespace Forms.Persona
{
    public partial class FormModificarPersona : Form
    {
        public FormModificarPersona(Domain.model.Persona persona)
        {
            InitializeComponent();
            _persona = persona;
            txtNombre.Text = _persona.Nombre;
            txtApellido.Text = _persona.Apellido;
            txtDireccion.Text = _persona.Direccion;
            txtEmail.Text = _persona.Email;
            txtTelefono.Text = _persona.Telefono;
            txtLegajo.Text = _persona.Legajo.ToString();
            calendario.SetDate(DateTime.Parse(_persona.Fecha_nac));
            comboBoxPlan.SelectedValue = _persona.Id_plan;
            txtId.Text = _persona.Id.ToString();
            if (_persona.Tipo_persona == 1)
            {
                radioAlumno.Checked = true;
            }
            else if (_persona.Tipo_persona == 2)
            {
                radioProfesor.Checked = true;
            }

        }
        private readonly Domain.model.Persona _persona;
        
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void buttonPost_Click(object sender, EventArgs e) //buton Put
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            int plan = (int)comboBoxPlan.SelectedValue;
            DateTime fechaNacimiento = calendario.SelectionStart;
            int tipoPersona = 0;
            if (radioAlumno.Checked)
            {
                tipoPersona = 1;
            }
            else if (radioProfesor.Checked)
            {
                tipoPersona = 2;
            }
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido) || String.IsNullOrEmpty(direccion) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(telefono)
                 || tipoPersona == 0)
            {
                MessageBox.Show("Por favor, ingrese todos los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Domain.model.Persona persona = new Domain.model.Persona()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = direccion,
                    Email = email,
                    Telefono = telefono,
                    Fecha_nac = fechaNacimiento.ToString("yyyy-MM-dd"),
                    Tipo_persona = tipoPersona,
                    Id_plan = (int)comboBoxPlan.SelectedValue
                };
                var response = await _httpClient.PutAsJsonAsync($"personas/{_persona.Id.ToString()}", persona);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Persona modificada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Solo aquí
                    

                }
                else
                {
                    MessageBox.Show($"Error al modificar la persona. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        

        private async void FormModificarPersona_Load(object sender, EventArgs e)
        {
            try
            {
                var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                if (planes != null)
                {
                    comboBoxPlan.DataSource = planes.ToList();
                    comboBoxPlan.DisplayMember = "Desc";
                    comboBoxPlan.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los planes: {ex.Message}");
            }
        }
    }
}
