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

        }
        private async Task CargarFormulario(Panel contenedor, string tag)
        {
            contenedor.Controls.Clear(); //borra el anterior si hay un form cargado
            Form form = null; //lo hace null para poder cargar por la validación de debajo



            // Mapear cada botón a su formulario
            switch (tag) //asigna el formulario a cargar según el tag del botón
            {
                case "Especialidad":
                    if (Usuario.Tipo == "Admin")
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
                    if (Usuario.Tipo == "Admin")
                        form = new FormUsuario();
                    else if (Usuario.Tipo == "Usuario")
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
                ConfigurarMenuPorRol();
                this.Show();
            }
            else
            {
                this.Dispose();
            }
        }

        private void ConfigurarMenuPorRol()
        {
            if (Usuario.Tipo == "Usuario")
            {
                ConfigurarMenuSoloListado(personaToolStripMenuItem, listadoPersona, detallePersona, menuPrincipal_Click);

                ConfigurarMenuSoloListado(usuarioToolStripMenuItem, listadoUsuario, crearUsuario, menuPrincipal_Click);

                ConfigurarMenuSoloListado(planToolStripMenuItem, listadoPlan, crearPlan, menuPrincipal_Click);

                ConfigurarMenuSoloListado(especialidadToolStripMenuItem, listadoEspecialidad, crearEspecialidad, menuPrincipal_Click);

                
            }
            else
            {
                ConfigurarMenuAdmin(personaToolStripMenuItem, listadoPersona, detallePersona, menuPrincipal_Click);

                ConfigurarMenuAdmin(usuarioToolStripMenuItem, listadoUsuario, crearUsuario, menuPrincipal_Click);

                ConfigurarMenuAdmin(planToolStripMenuItem, listadoPlan, crearPlan, menuPrincipal_Click);

                ConfigurarMenuAdmin(especialidadToolStripMenuItem, listadoEspecialidad, crearEspecialidad, menuPrincipal_Click);

                
            }
        }

        private void ConfigurarMenuSoloListado(ToolStripMenuItem menuPrincipal, ToolStripMenuItem subMenuListado, ToolStripMenuItem subMenuCrear, EventHandler handlerListado) 
        {
            subMenuCrear.Visible = false;
            menuPrincipal.DropDownItems.Clear();    // Elimina los submenús y asigna el click directo al menú principal
            menuPrincipal.Click -= handlerListado; // Limpia handlers previos para que no se subscriba dos veces al metodo en caso de logout
            menuPrincipal.Click += handlerListado;
        }
        private void ConfigurarMenuAdmin(ToolStripMenuItem menuPrincipal,ToolStripMenuItem subMenuListado, ToolStripMenuItem subMenuCrear, EventHandler handlerListado)
        {
            menuPrincipal.DropDownItems.Clear();
            menuPrincipal.DropDownItems.Add(subMenuListado);
            menuPrincipal.DropDownItems.Add(subMenuCrear);
            menuPrincipal.Click -= handlerListado;
            subMenuCrear.Visible = true;
        }
        private void menuPrincipal_Click(object sender, EventArgs e)
        {
            if (sender == personaToolStripMenuItem)
                listadoPersona_Click(sender, e);
            else if (sender == usuarioToolStripMenuItem)
                listadoUsuario_Click(sender, e);
            else if (sender == planToolStripMenuItem)
                listadoPlan_Click(sender, e);
            else if (sender == especialidadToolStripMenuItem)
                listadoEspecialidad_Click(sender, e);
        }

        private void MostrarEnPanel(Form form)
        {
            panelContenedor.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(form);
            form.Show();
        }
        private void InicializarTabs()
        {
            //Obsoleta
        }

        private void listadoPersona_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            Form form = null;
            if (Usuario.Tipo == "Admin")
                form = new FormPersona();
            else if (Usuario.Tipo == "Usuario")
                form = new FormPersonaNoAdmin(Persona.Id.ToString(), Usuario.Tipo);

            if (form != null)
            {
                MostrarEnPanel(form);
            }
        }

        private void detallePersona_Click(object sender, EventArgs e) //ME OLVIDE DE CAMBIARLE EL NOMBRE SERIA CREAR :( 
        {
            panelContenedor.Controls.Clear();          //IMPORTANTE: no hace falta validar si es usuario porque no le aparece, en web se deberia validad igual por los endpoints pero como aca en winforms no hace falta
            var form = new ModalAgregarPersona();
            MostrarEnPanel(form);
           
        }

        private void listadoUsuario_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            Form form = null;
            if (Usuario.Tipo == "Admin")
                form = new FormUsuario();
            else if (Usuario.Tipo == "Usuario")
                form = new FormUsuarioNoAdmin(Usuario.Id.ToString());

            if (form != null)
            {
                MostrarEnPanel(form);
            }
        }

        private void crearUsuario_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            var form = new FormAgregarUsuario();
            MostrarEnPanel(form);
        }

        private void listadoPlan_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            Form form = null;
            if (Usuario.Tipo == "Admin")
                form = new FormPlan("Admin");
            else if (Usuario.Tipo == "Usuario")
                form = new FormPlan("Usuario");

            if (form != null)
            {
                MostrarEnPanel(form);
            }
        }

        private void crearPlan_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            var form = new ModalAgregarPlan();
            MostrarEnPanel(form);
        }

        private void listadoEspecialidad_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            Form form = null;
            if (Usuario.Tipo == "Admin")
                form = new FormEspecialidad("Admin"); 
            else if (Usuario.Tipo == "Usuario")
                form = new FormEspecialidad("Usuario");

            if (form != null)
            {
                MostrarEnPanel(form);
            }
        }

        private void crearEspecialidad_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            var form = new ModalAgregarEspecialidad();
            MostrarEnPanel(form);
        }
    }
}
