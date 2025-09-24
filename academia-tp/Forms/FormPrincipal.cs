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
using Forms.Persona;
using Forms.Usuario;

namespace Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        public Domain.model.Usuario Usuario { get; set; }
        public Domain.model.Persona Persona { get; set; }

        private void FormPrincipal_Load_1(object sender, EventArgs e)
        { //para agregar las pestañas dinámicamente. migrado a shown
            
        }
        private void AgregarPestañaEntidad(string entidad)
        {
            // Crear la pestaña
            TabPage tab = new TabPage(entidad);

            // Panel donde se mostrarán los formularios o usercontrols. Es básicamente un container
            Panel panelContenedor = new Panel { Dock = DockStyle.Fill };

            CargarFormulario(panelContenedor, entidad);


            // Agregar los controles a la pestaña (menu y debajo panel-container). 
            tab.Controls.Add(panelContenedor);

            tabControl1.TabPages.Add(tab);
        }
        private async Task CargarFormulario(Panel contenedor, string tag)
        {
            contenedor.Controls.Clear(); //borra el anterior si hay un form cargado
            Form form = null; //lo hace null para poder cargar por la validación de debajo

            

            // Mapear cada botón a su formulario
            switch (tag) //asigna el formulario a cargar según el tag del botón
            {
                case "Especialidad":
                    if(Usuario.Tipo == "Admin")
                        form = new FormEspecialidad("Admin");
                    else if (Usuario.Tipo == "Usuario")
                        form = new FormEspecialidad("Usuario");
                    break;
                case "Plan":
                    if (Usuario.Tipo == "Admin")
                        form = new FormPlan("Admin");
                    else if (Usuario.Tipo == "Usuario")
                        form = new FormPlan("Usuario");
                    break;
                case "Usuario":
                    if(Usuario.Tipo == "Admin")
                        form = new FormUsuario();
                    else if(Usuario.Tipo == "Usuario")
                        form = new FormUsuarioNoAdmin(Usuario.Id.ToString());
                    break;
                case "Persona":
                    if (Usuario.Tipo == "Admin")
                        form = new FormPersona();
                    else if (Usuario.Tipo == "Usuario")
                        form = new FormPersonaNoAdmin(Persona.Id.ToString(), Usuario.Tipo);
                    break;
            }


            if (form != null) //cuando se elige una opción, agrega al panel y muestra el formulario
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                contenedor.Controls.Add(form);
                form.Show();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void FormPrincipal_Shown(object sender, EventArgs e)
        {
            this.Hide(); //oculta formPrincipal antes de login
            FormLogin appLogin = new FormLogin();
            appLogin.StartPosition = FormStartPosition.Manual; //para que se abra en el mismo lugar
            appLogin.Size = this.Size;
            appLogin.Location = this.Location;
            if (appLogin.ShowDialog() == DialogResult.OK) 
            {
                string id = appLogin.Id;
                try
                {

                    Usuario = await _httpClient.GetFromJsonAsync<Domain.model.Usuario>($"usuarios/{id}");
                    Persona = await _httpClient.GetFromJsonAsync<Domain.model.Persona>($"personas/{Usuario.Id_persona}");
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el usuario: {ex.Message}");
                    return;
                }
                this.Show();
                InicializarTabs();
                

            }
            else
            {
                this.Dispose();
            }

        }
        private void InicializarTabs()
        {
            AgregarPestañaEntidad("Especialidad");
            AgregarPestañaEntidad("Plan");
            AgregarPestañaEntidad("Usuario");
            AgregarPestañaEntidad("Persona");
        }
    }
}
