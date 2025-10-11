namespace Forms
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            personaToolStripMenuItem = new ToolStripMenuItem();
            listadoPersona = new ToolStripMenuItem();
            detallePersona = new ToolStripMenuItem();
            inscripcionToolStripMenuItem = new ToolStripMenuItem();
            listadoInscripcion = new ToolStripMenuItem();
            crearInscripcion = new ToolStripMenuItem();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            listadoUsuario = new ToolStripMenuItem();
            crearUsuario = new ToolStripMenuItem();
            planToolStripMenuItem = new ToolStripMenuItem();
            listadoPlan = new ToolStripMenuItem();
            crearPlan = new ToolStripMenuItem();
            especialidadToolStripMenuItem = new ToolStripMenuItem();
            listadoEspecialidad = new ToolStripMenuItem();
            crearEspecialidad = new ToolStripMenuItem();
            materiaToolStripMenuItem = new ToolStripMenuItem();
            listadoMaterias = new ToolStripMenuItem();
            crearMaterias = new ToolStripMenuItem();
            comisiónToolStripMenuItem = new ToolStripMenuItem();
            listadoToolStripMenuItem5 = new ToolStripMenuItem();
            detalleToolStripMenuItem5 = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { personaToolStripMenuItem, inscripcionToolStripMenuItem, usuarioToolStripMenuItem, planToolStripMenuItem, especialidadToolStripMenuItem, materiaToolStripMenuItem, comisiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // personaToolStripMenuItem
            // 
            personaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoPersona, detallePersona });
            personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            personaToolStripMenuItem.Size = new Size(74, 24);
            personaToolStripMenuItem.Text = "Persona";
            // 
            // listadoPersona
            // 
            listadoPersona.Name = "listadoPersona";
            listadoPersona.Size = new Size(140, 26);
            listadoPersona.Text = "Listado";
            listadoPersona.Click += listadoPersona_Click;
            // 
            // detallePersona
            // 
            detallePersona.Name = "detallePersona";
            detallePersona.Size = new Size(140, 26);
            detallePersona.Text = "Crear";
            detallePersona.Click += detallePersona_Click;
            // 
            // inscripcionToolStripMenuItem
            // 
            inscripcionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoInscripcion, crearInscripcion });
            inscripcionToolStripMenuItem.Name = "inscripcionToolStripMenuItem";
            inscripcionToolStripMenuItem.Size = new Size(94, 24);
            inscripcionToolStripMenuItem.Text = "Inscripcion";
            // 
            // listadoInscripcion
            // 
            listadoInscripcion.Name = "listadoInscripcion";
            listadoInscripcion.Size = new Size(140, 26);
            listadoInscripcion.Text = "Listado";
            listadoInscripcion.Click += listadoInscripcion_Click;
            // 
            // crearInscripcion
            // 
            crearInscripcion.Name = "crearInscripcion";
            crearInscripcion.Size = new Size(140, 26);
            crearInscripcion.Text = "Crear";
            crearInscripcion.Click += crearInscripcion_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoUsuario, crearUsuario });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(73, 24);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // listadoUsuario
            // 
            listadoUsuario.Name = "listadoUsuario";
            listadoUsuario.Size = new Size(140, 26);
            listadoUsuario.Text = "Listado";
            listadoUsuario.Click += listadoUsuario_Click;
            // 
            // crearUsuario
            // 
            crearUsuario.Name = "crearUsuario";
            crearUsuario.Size = new Size(140, 26);
            crearUsuario.Text = "Crear";
            crearUsuario.Click += crearUsuario_Click;
            // 
            // planToolStripMenuItem
            // 
            planToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoPlan, crearPlan });
            planToolStripMenuItem.Name = "planToolStripMenuItem";
            planToolStripMenuItem.Size = new Size(51, 24);
            planToolStripMenuItem.Text = "Plan";
            // 
            // listadoPlan
            // 
            listadoPlan.Name = "listadoPlan";
            listadoPlan.Size = new Size(140, 26);
            listadoPlan.Text = "Listado";
            listadoPlan.Click += listadoPlan_Click;
            // 
            // crearPlan
            // 
            crearPlan.Name = "crearPlan";
            crearPlan.Size = new Size(140, 26);
            crearPlan.Text = "Crear";
            crearPlan.Click += crearPlan_Click;
            // 
            // especialidadToolStripMenuItem
            // 
            especialidadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoEspecialidad, crearEspecialidad });
            especialidadToolStripMenuItem.Name = "especialidadToolStripMenuItem";
            especialidadToolStripMenuItem.Size = new Size(107, 24);
            especialidadToolStripMenuItem.Text = "Especialidad";
            // 
            // listadoEspecialidad
            // 
            listadoEspecialidad.Name = "listadoEspecialidad";
            listadoEspecialidad.Size = new Size(140, 26);
            listadoEspecialidad.Text = "Listado";
            listadoEspecialidad.Click += listadoEspecialidad_Click;
            // 
            // crearEspecialidad
            // 
            crearEspecialidad.Name = "crearEspecialidad";
            crearEspecialidad.Size = new Size(140, 26);
            crearEspecialidad.Text = "Crear";
            crearEspecialidad.Click += crearEspecialidad_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoMaterias, crearMaterias });
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(74, 24);
            materiaToolStripMenuItem.Text = "Materia";
            // 
            // listadoMaterias
            // 
            listadoMaterias.Name = "listadoMaterias";
            listadoMaterias.Size = new Size(224, 26);
            listadoMaterias.Text = "Listado";
            listadoMaterias.Click += listadoMaterias_Click;
            // 
            // crearMaterias
            // 
            crearMaterias.Name = "crearMaterias";
            crearMaterias.Size = new Size(224, 26);
            crearMaterias.Text = "Crear";
            crearMaterias.Click += crearMaterias_Click;
            // 
            // comisiónToolStripMenuItem
            // 
            comisiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoToolStripMenuItem5, detalleToolStripMenuItem5 });
            comisiónToolStripMenuItem.Name = "comisiónToolStripMenuItem";
            comisiónToolStripMenuItem.Size = new Size(85, 24);
            comisiónToolStripMenuItem.Text = "Comisión";
            // 
            // listadoToolStripMenuItem5
            // 
            listadoToolStripMenuItem5.Name = "listadoToolStripMenuItem5";
            listadoToolStripMenuItem5.Size = new Size(140, 26);
            listadoToolStripMenuItem5.Text = "Listado";
            // 
            // detalleToolStripMenuItem5
            // 
            detalleToolStripMenuItem5.Name = "detalleToolStripMenuItem5";
            detalleToolStripMenuItem5.Size = new Size(140, 26);
            detalleToolStripMenuItem5.Text = "Crear";
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 30);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(914, 570);
            panelContenedor.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            Shown += FormPrincipal_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem personaToolStripMenuItem;
        private ToolStripMenuItem listadoPersona;
        private ToolStripMenuItem detallePersona;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem listadoUsuario;
        private ToolStripMenuItem crearUsuario;
        private ToolStripMenuItem planToolStripMenuItem;
        private ToolStripMenuItem listadoPlan;
        private ToolStripMenuItem crearPlan;
        private ToolStripMenuItem especialidadToolStripMenuItem;
        private ToolStripMenuItem listadoEspecialidad;
        private ToolStripMenuItem crearEspecialidad;
        private ToolStripMenuItem materiaToolStripMenuItem;
        private ToolStripMenuItem listadoToolStripMenuItem4;
        private ToolStripMenuItem crearMaterias;
        private ToolStripMenuItem comisiónToolStripMenuItem;
        private ToolStripMenuItem listadoToolStripMenuItem5;
        private ToolStripMenuItem detalleToolStripMenuItem5;
        private Panel panelContenedor;
        private ToolStripMenuItem inscripcionToolStripMenuItem;
        private ToolStripMenuItem listadoInscripcion;
        private ToolStripMenuItem crearInscripcion;
        private ToolStripMenuItem listadoMaterias;
    }
}