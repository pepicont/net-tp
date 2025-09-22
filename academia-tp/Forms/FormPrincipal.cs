using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load_1(object sender, EventArgs e)
        { //para agregar las pestañas dinámicamente
            AgregarPestañaEntidad("Especialidad");
            AgregarPestañaEntidad("Plan");
        }
        private void AgregarPestañaEntidad(string entidad)
        {
            // Crear la pestaña
            TabPage tab = new TabPage(entidad);

            // Panel donde se mostrarán los formularios o usercontrols. Es básicamente un container
            Panel panelContenedor = new Panel { Dock = DockStyle.Fill };

            CargarFormulario(panelContenedor, entidad);

            /*string[] acciones = { "Buscar", "Agregar", "Modificar", "Borrar" };
            //Crea dinámicamente los botones de acciones para cada entidad

            foreach (string accion in acciones)
            {
                Button btn = new Button
                {
                    Text = accion,
                    Tag = entidad + "_" + accion
                };

                // Evento del botón
                btn.Click += (s, e) =>
                {
                    string tag = ((Button)s).Tag.ToString(); //s abreviación de sender (Boton que envió el evento)
                    CargarFormulario(panelContenedor, tag); //lo que dice el nombre.
                };

                menu.Controls.Add(btn); //agregar boton al menu de botones
            }*/

            // Agregar los controles a la pestaña (menu y debajo panel-container). 
            tab.Controls.Add(panelContenedor);

            tabControl1.TabPages.Add(tab);
        }
        private void CargarFormulario(Panel contenedor, string tag)
        {
            contenedor.Controls.Clear(); //borra el anterior si hay un form cargado
            Form form = null; //lo hace null para poder cargar por la validación de debajo

            // Mapear cada botón a su formulario
            switch (tag) //asigna el formulario a cargar según el tag del botón
            {
                case "Especialidad":
                    form = new FormEspecialidad();
                    break;
                case "Plan":
                    form = new FormPlan();
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

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin();
            appLogin.ShowDialog();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
