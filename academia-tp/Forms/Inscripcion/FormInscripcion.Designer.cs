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
            comboBoxFiltrarCondicion = new ComboBox();
            buttonFiltrar = new Button();
            numericUpDownFiltrarAnio = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFiltrarAnio).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(80, 62);
            dataGridView1.Margin = new Padding(6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1298, 367);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(152, 672);
            textBoxBuscar.Margin = new Padding(6);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(353, 39);
            textBoxBuscar.TabIndex = 1;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(632, 662);
            buttonBuscar.Margin = new Padding(6);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(139, 49);
            buttonBuscar.TabIndex = 2;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(964, 498);
            buttonModificar.Margin = new Padding(6);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(223, 49);
            buttonModificar.TabIndex = 3;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(957, 672);
            buttonEliminar.Margin = new Padding(6);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(230, 49);
            buttonEliminar.TabIndex = 4;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonReporteAlumnos
            // 
            buttonReporteAlumnos.Location = new Point(550, 826);
            buttonReporteAlumnos.Margin = new Padding(6);
            buttonReporteAlumnos.Name = "buttonReporteAlumnos";
            buttonReporteAlumnos.Size = new Size(221, 49);
            buttonReporteAlumnos.TabIndex = 5;
            buttonReporteAlumnos.Text = "Listado curso";
            buttonReporteAlumnos.UseVisualStyleBackColor = true;
            buttonReporteAlumnos.Click += buttonReporteAlumnos_Click;
            // 
            // buttonReporteGrafico
            // 
            buttonReporteGrafico.Location = new Point(957, 826);
            buttonReporteGrafico.Margin = new Padding(6);
            buttonReporteGrafico.Name = "buttonReporteGrafico";
            buttonReporteGrafico.Size = new Size(230, 49);
            buttonReporteGrafico.TabIndex = 6;
            buttonReporteGrafico.Text = "Grafico inscriptos";
            buttonReporteGrafico.UseVisualStyleBackColor = true;
            buttonReporteGrafico.Click += buttonReporteGrafico_Click;
            // 
            // comboBoxFiltrarCondicion
            // 
            comboBoxFiltrarCondicion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltrarCondicion.Location = new Point(117, 498);
            comboBoxFiltrarCondicion.Margin = new Padding(6);
            comboBoxFiltrarCondicion.Name = "comboBoxFiltrarCondicion";
            comboBoxFiltrarCondicion.Size = new Size(219, 40);
            comboBoxFiltrarCondicion.TabIndex = 7;
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(632, 497);
            buttonFiltrar.Margin = new Padding(6);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(139, 40);
            buttonFiltrar.TabIndex = 9;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // numericUpDownFiltrarAnio
            // 
            numericUpDownFiltrarAnio.Location = new Point(415, 499);
            numericUpDownFiltrarAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numericUpDownFiltrarAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numericUpDownFiltrarAnio.Name = "numericUpDownFiltrarAnio";
            numericUpDownFiltrarAnio.Size = new Size(100, 39);
            numericUpDownFiltrarAnio.TabIndex = 0;
            numericUpDownFiltrarAnio.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 460);
            label1.Name = "label1";
            label1.Size = new Size(122, 32);
            label1.TabIndex = 10;
            label1.Text = "Condicion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(428, 460);
            label2.Name = "label2";
            label2.Size = new Size(57, 32);
            label2.TabIndex = 11;
            label2.Text = "Año";
            // 
            // FormInscripcion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonReporteGrafico);
            Controls.Add(buttonReporteAlumnos);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonBuscar);
            Controls.Add(textBoxBuscar);
            Controls.Add(dataGridView1);
            Controls.Add(comboBoxFiltrarCondicion);
            Controls.Add(buttonFiltrar);
            Controls.Add(numericUpDownFiltrarAnio);
            Margin = new Padding(6);
            Name = "FormInscripcion";
            Text = "Inscripciones";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFiltrarAnio).EndInit();
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
        private ComboBox comboBoxFiltrarCondicion;
        private Button buttonFiltrar;
        private NumericUpDown numericUpDownFiltrarAnio;
        private Label label1;
        private Label label2;
    }
}