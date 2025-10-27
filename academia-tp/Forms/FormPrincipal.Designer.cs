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
            listadoMateria = new ToolStripMenuItem();
            crearMateria = new ToolStripMenuItem();
            cursoToolStripMenuItem = new ToolStripMenuItem();
            listadoCurso = new ToolStripMenuItem();
            crearCurso = new ToolStripMenuItem();
            docenteToolStripMenuItem = new ToolStripMenuItem();
            listadoDocente = new ToolStripMenuItem();
            crearDocente = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { personaToolStripMenuItem, inscripcionToolStripMenuItem, usuarioToolStripMenuItem, planToolStripMenuItem, especialidadToolStripMenuItem, materiaToolStripMenuItem, cursoToolStripMenuItem, docenteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 4, 0, 4);
            menuStrip1.Size = new Size(1486, 44);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // personaToolStripMenuItem
            // 
            personaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoPersona, detallePersona });
            personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            personaToolStripMenuItem.Size = new Size(117, 36);
            personaToolStripMenuItem.Text = "Persona";
            // 
            // listadoPersona
            // 
            listadoPersona.Name = "listadoPersona";
            listadoPersona.Size = new Size(222, 44);
            listadoPersona.Text = "Listado";
            listadoPersona.Click += listadoPersona_Click;
            // 
            // detallePersona
            // 
            detallePersona.Name = "detallePersona";
            detallePersona.Size = new Size(222, 44);
            detallePersona.Text = "Crear";
            detallePersona.Click += detallePersona_Click;
            // 
            // inscripcionToolStripMenuItem
            // 
            inscripcionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoInscripcion, crearInscripcion });
            inscripcionToolStripMenuItem.Name = "inscripcionToolStripMenuItem";
            inscripcionToolStripMenuItem.Size = new Size(148, 36);
            inscripcionToolStripMenuItem.Text = "Inscripcion";
            // 
            // listadoInscripcion
            // 
            listadoInscripcion.Name = "listadoInscripcion";
            listadoInscripcion.Size = new Size(222, 44);
            listadoInscripcion.Text = "Listado";
            listadoInscripcion.Click += listadoInscripcion_Click;
            // 
            // crearInscripcion
            // 
            crearInscripcion.Name = "crearInscripcion";
            crearInscripcion.Size = new Size(222, 44);
            crearInscripcion.Text = "Crear";
            crearInscripcion.Click += crearInscripcion_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoUsuario, crearUsuario });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(114, 36);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // listadoUsuario
            // 
            listadoUsuario.Name = "listadoUsuario";
            listadoUsuario.Size = new Size(222, 44);
            listadoUsuario.Text = "Listado";
            listadoUsuario.Click += listadoUsuario_Click;
            // 
            // crearUsuario
            // 
            crearUsuario.Name = "crearUsuario";
            crearUsuario.Size = new Size(222, 44);
            crearUsuario.Text = "Crear";
            crearUsuario.Click += crearUsuario_Click;
            // 
            // planToolStripMenuItem
            // 
            planToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoPlan, crearPlan });
            planToolStripMenuItem.Name = "planToolStripMenuItem";
            planToolStripMenuItem.Size = new Size(79, 36);
            planToolStripMenuItem.Text = "Plan";
            // 
            // listadoPlan
            // 
            listadoPlan.Name = "listadoPlan";
            listadoPlan.Size = new Size(222, 44);
            listadoPlan.Text = "Listado";
            listadoPlan.Click += listadoPlan_Click;
            // 
            // crearPlan
            // 
            crearPlan.Name = "crearPlan";
            crearPlan.Size = new Size(222, 44);
            crearPlan.Text = "Crear";
            crearPlan.Click += crearPlan_Click;
            // 
            // especialidadToolStripMenuItem
            // 
            especialidadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoEspecialidad, crearEspecialidad });
            especialidadToolStripMenuItem.Name = "especialidadToolStripMenuItem";
            especialidadToolStripMenuItem.Size = new Size(164, 36);
            especialidadToolStripMenuItem.Text = "Especialidad";
            // 
            // listadoEspecialidad
            // 
            listadoEspecialidad.Name = "listadoEspecialidad";
            listadoEspecialidad.Size = new Size(222, 44);
            listadoEspecialidad.Text = "Listado";
            listadoEspecialidad.Click += listadoEspecialidad_Click;
            // 
            // crearEspecialidad
            // 
            crearEspecialidad.Name = "crearEspecialidad";
            crearEspecialidad.Size = new Size(222, 44);
            crearEspecialidad.Text = "Crear";
            crearEspecialidad.Click += crearEspecialidad_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoMateria, crearMateria });
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(115, 36);
            materiaToolStripMenuItem.Text = "Materia";
            // 
            // listadoMateria
            // 
            listadoMateria.Name = "listadoMateria";
            listadoMateria.Size = new Size(222, 44);
            listadoMateria.Text = "Listado";
            listadoMateria.Click += listadoMateria_Click;
            // 
            // crearMateria
            // 
            crearMateria.Name = "crearMateria";
            crearMateria.Size = new Size(222, 44);
            crearMateria.Text = "Crear";
            crearMateria.Click += crearMateria_Click;
            // 
            // cursoToolStripMenuItem
            // 
            cursoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoCurso, crearCurso });
            cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            cursoToolStripMenuItem.Size = new Size(95, 36);
            cursoToolStripMenuItem.Text = "Curso";
            // 
            // listadoCurso
            // 
            listadoCurso.Name = "listadoCurso";
            listadoCurso.Size = new Size(222, 44);
            listadoCurso.Text = "Listado";
            // 
            // crearCurso
            // 
            crearCurso.Name = "crearCurso";
            crearCurso.Size = new Size(222, 44);
            crearCurso.Text = "Crear";
            // 
            // docenteToolStripMenuItem
            // 
            docenteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoDocente, crearDocente });
            docenteToolStripMenuItem.Name = "docenteToolStripMenuItem";
            docenteToolStripMenuItem.Size = new Size(124, 36);
            docenteToolStripMenuItem.Text = "Docente";
            // 
            // listadoDocente
            // 
            listadoDocente.Name = "listadoDocente";
            listadoDocente.Size = new Size(222, 44);
            listadoDocente.Text = "Listado";
            listadoDocente.Click += listadoDocente_Click;
            // 
            // crearDocente
            // 
            crearDocente.Name = "crearDocente";
            crearDocente.Size = new Size(222, 44);
            crearDocente.Text = "Crear";
            crearDocente.Click += crearDocente_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(32, 19);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(32, 19);
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 44);
            panelContenedor.Margin = new Padding(6);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1486, 916);
            panelContenedor.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6);
            Name = "FormPrincipal";
            Text = "La Academia";
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
        private ToolStripMenuItem crearMateria;
        private ToolStripMenuItem docenteToolStripMenuItem;
        private ToolStripMenuItem listadoDocente;
        private ToolStripMenuItem detalleToolStripMenuItem5;
        private Panel panelContenedor;
        private ToolStripMenuItem inscripcionToolStripMenuItem;
        private ToolStripMenuItem listadoInscripcion;
        private ToolStripMenuItem crearInscripcion;
        private ToolStripMenuItem listadoMateria;
        private ToolStripMenuItem crearDocente;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem cursoToolStripMenuItem;
        private ToolStripMenuItem listadoCurso;
        private ToolStripMenuItem crearCurso;
    }
}