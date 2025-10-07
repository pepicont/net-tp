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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms.Persona
{
    public partial class ModalAgregarPersona : Form
    {
        public ModalAgregarPersona()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private  void ModalAgregarPersona_Load(object sender, EventArgs e)
        {
            //ignorar
        }

        private async void buttonPost_Click(object sender, EventArgs e)
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

                var response = await _httpClient.PostAsJsonAsync("personas", persona);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Persona cargada con éxito");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error al cargar la persona");

                }
            }
        }

        private async void ModalAgregarPersona_Load_1(object sender, EventArgs e)
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
