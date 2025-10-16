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
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            CursoToolStripMenuItem = new ToolStripMenuItem();
            listadoCursos = new ToolStripMenuItem();
            crearCurso = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { personaToolStripMenuItem, inscripcionToolStripMenuItem, usuarioToolStripMenuItem, planToolStripMenuItem, especialidadToolStripMenuItem, materiaToolStripMenuItem, toolStripMenuItem1, CursoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // personaToolStripMenuItem
            // 
            personaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoPersona, detallePersona });
            personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            personaToolStripMenuItem.Size = new Size(61, 20);
            personaToolStripMenuItem.Text = "Persona";
            // 
            // listadoPersona
            // 
            listadoPersona.Name = "listadoPersona";
            listadoPersona.Size = new Size(112, 22);
            listadoPersona.Text = "Listado";
            listadoPersona.Click += listadoPersona_Click;
            // 
            // detallePersona
            // 
            detallePersona.Name = "detallePersona";
            detallePersona.Size = new Size(112, 22);
            detallePersona.Text = "Crear";
            detallePersona.Click += detallePersona_Click;
            // 
            // inscripcionToolStripMenuItem
            // 
            inscripcionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoInscripcion, crearInscripcion });
            inscripcionToolStripMenuItem.Name = "inscripcionToolStripMenuItem";
            inscripcionToolStripMenuItem.Size = new Size(77, 20);
            inscripcionToolStripMenuItem.Text = "Inscripcion";
            // 
            // listadoInscripcion
            // 
            listadoInscripcion.Name = "listadoInscripcion";
            listadoInscripcion.Size = new Size(112, 22);
            listadoInscripcion.Text = "Listado";
            listadoInscripcion.Click += listadoInscripcion_Click;
            // 
            // crearInscripcion
            // 
            crearInscripcion.Name = "crearInscripcion";
            crearInscripcion.Size = new Size(112, 22);
            crearInscripcion.Text = "Crear";
            crearInscripcion.Click += crearInscripcion_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoUsuario, crearUsuario });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(59, 20);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // listadoUsuario
            // 
            listadoUsuario.Name = "listadoUsuario";
            listadoUsuario.Size = new Size(112, 22);
            listadoUsuario.Text = "Listado";
            listadoUsuario.Click += listadoUsuario_Click;
            // 
            // crearUsuario
            // 
            crearUsuario.Name = "crearUsuario";
            crearUsuario.Size = new Size(112, 22);
            crearUsuario.Text = "Crear";
            crearUsuario.Click += crearUsuario_Click;
            // 
            // planToolStripMenuItem
            // 
            planToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoPlan, crearPlan });
            planToolStripMenuItem.Name = "planToolStripMenuItem";
            planToolStripMenuItem.Size = new Size(42, 20);
            planToolStripMenuItem.Text = "Plan";
            // 
            // listadoPlan
            // 
            listadoPlan.Name = "listadoPlan";
            listadoPlan.Size = new Size(112, 22);
            listadoPlan.Text = "Listado";
            listadoPlan.Click += listadoPlan_Click;
            // 
            // crearPlan
            // 
            crearPlan.Name = "crearPlan";
            crearPlan.Size = new Size(112, 22);
            crearPlan.Text = "Crear";
            crearPlan.Click += crearPlan_Click;
            // 
            // especialidadToolStripMenuItem
            // 
            especialidadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoEspecialidad, crearEspecialidad });
            especialidadToolStripMenuItem.Name = "especialidadToolStripMenuItem";
            especialidadToolStripMenuItem.Size = new Size(84, 20);
            especialidadToolStripMenuItem.Text = "Especialidad";
            // 
            // listadoEspecialidad
            // 
            listadoEspecialidad.Name = "listadoEspecialidad";
            listadoEspecialidad.Size = new Size(112, 22);
            listadoEspecialidad.Text = "Listado";
            listadoEspecialidad.Click += listadoEspecialidad_Click;
            // 
            // crearEspecialidad
            // 
            crearEspecialidad.Name = "crearEspecialidad";
            crearEspecialidad.Size = new Size(112, 22);
            crearEspecialidad.Text = "Crear";
            crearEspecialidad.Click += crearEspecialidad_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoMaterias, crearMaterias });
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(59, 20);
            materiaToolStripMenuItem.Text = "Materia";
            // 
            // listadoMaterias
            // 
            listadoMaterias.Name = "listadoMaterias";
            listadoMaterias.Size = new Size(112, 22);
            listadoMaterias.Text = "Listado";
            listadoMaterias.Click += listadoMaterias_Click;
            // 
            // crearMaterias
            // 
            crearMaterias.Name = "crearMaterias";
            crearMaterias.Size = new Size(112, 22);
            crearMaterias.Text = "Crear";
            crearMaterias.Click += crearMaterias_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(70, 20);
            toolStripMenuItem1.Text = "Comisión";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(112, 22);
            toolStripMenuItem2.Text = "Listado";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(112, 22);
            toolStripMenuItem3.Text = "Crear";
            // 
            // CursoToolStripMenuItem
            // 
            CursoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoCursos, crearCurso });
            CursoToolStripMenuItem.Name = "CursoToolStripMenuItem";
            CursoToolStripMenuItem.Size = new Size(50, 20);
            CursoToolStripMenuItem.Text = "Curso";
            // 
            // listadoCursos
            // 
            listadoCursos.Name = "listadoCursos";
            listadoCursos.Size = new Size(180, 22);
            listadoCursos.Text = "Listado";
            listadoCursos.Click += listadoCursos_Click;
            // 
            // crearCurso
            // 
            crearCurso.Name = "crearCurso";
            crearCurso.Size = new Size(180, 22);
            crearCurso.Text = "Crear";
            crearCurso.Click += crearCurso_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 24);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(800, 426);
            panelContenedor.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
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
        private ToolStripMenuItem CursoToolStripMenuItem;
        private ToolStripMenuItem listadoCursos;
        private ToolStripMenuItem detalleToolStripMenuItem5;
        private Panel panelContenedor;
        private ToolStripMenuItem inscripcionToolStripMenuItem;
        private ToolStripMenuItem listadoInscripcion;
        private ToolStripMenuItem crearInscripcion;
        private ToolStripMenuItem listadoMaterias;
        private ToolStripMenuItem crearCurso;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
    }
}