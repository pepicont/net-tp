namespace Forms.Inscripcion
{
    partial class FormInscripcion
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
            dataGridView1 = new DataGridView();
            textBoxBuscar = new TextBox();
            buttonBuscar = new Button();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonReporteAlumnos = new Button();
            buttonReporteGrafico = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(699, 172);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(289, 249);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(147, 23);
            textBoxBuscar.TabIndex = 1;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(456, 249);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(75, 23);
            buttonBuscar.TabIndex = 2;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(157, 313);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(120, 23);
            buttonModificar.TabIndex = 3;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(505, 313);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(124, 23);
            buttonEliminar.TabIndex = 4;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonReporteAlumnos
            // 
            buttonReporteAlumnos.Location = new Point(158, 387);
            buttonReporteAlumnos.Name = "buttonReporteAlumnos";
            buttonReporteAlumnos.Size = new Size(119, 23);
            buttonReporteAlumnos.TabIndex = 5;
            buttonReporteAlumnos.Text = "Listado curso";
            buttonReporteAlumnos.UseVisualStyleBackColor = true;
            buttonReporteAlumnos.Click += buttonReporteAlumnos_Click;
            // 
            // buttonReporteGrafico
            // 
            buttonReporteGrafico.Location = new Point(505, 387);
            buttonReporteGrafico.Name = "buttonReporteGrafico";
            buttonReporteGrafico.Size = new Size(124, 23);
            buttonReporteGrafico.TabIndex = 6;
            buttonReporteGrafico.Text = "Grafico inscriptos";
            buttonReporteGrafico.UseVisualStyleBackColor = true;
            buttonReporteGrafico.Click += buttonReporteGrafico_Click;
            // 
            // FormInscripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonReporteGrafico);
            Controls.Add(buttonReporteAlumnos);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonBuscar);
            Controls.Add(textBoxBuscar);
            Controls.Add(dataGridView1);
            Name = "FormInscripcion";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBoxBuscar;
        private Button buttonBuscar;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonReporteAlumnos;
        private Button buttonReporteGrafico;
    }
}