namespace Forms.Inscripcion
{
    partial class FormReporteAlumnos
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonCancelar = new Button();
            buttonCrearReporte = new Button();
            comboBoxMateria = new ComboBox();
            comboBoxCurso = new ComboBox();
            numericUpDownAño = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAño).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 29);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Materia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 90);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "Curso";
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 137);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 3;
            label4.Text = "Año ";
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(30, 199);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(104, 23);
            buttonCancelar.TabIndex = 4;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonCrearReporte
            // 
            buttonCrearReporte.Location = new Point(209, 199);
            buttonCrearReporte.Name = "buttonCrearReporte";
            buttonCrearReporte.Size = new Size(120, 23);
            buttonCrearReporte.TabIndex = 5;
            buttonCrearReporte.Text = "Crear reporte";
            buttonCrearReporte.UseVisualStyleBackColor = true;
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.FormattingEnabled = true;
            comboBoxMateria.Location = new Point(209, 29);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(121, 23);
            comboBoxMateria.TabIndex = 6;
            // 
            // comboBoxCurso
            // 
            comboBoxCurso.FormattingEnabled = true;
            comboBoxCurso.Location = new Point(209, 82);
            comboBoxCurso.Name = "comboBoxCurso";
            comboBoxCurso.Size = new Size(121, 23);
            comboBoxCurso.TabIndex = 7;
            // 
            // numericUpDownAño
            // 
            numericUpDownAño.Location = new Point(210, 135);
            numericUpDownAño.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownAño.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numericUpDownAño.Name = "numericUpDownAño";
            numericUpDownAño.Size = new Size(120, 23);
            numericUpDownAño.TabIndex = 9;
            numericUpDownAño.Value = new decimal(new int[] { 2020, 0, 0, 0 });
            // 
            // FormReporteAlumnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 238);
            Controls.Add(numericUpDownAño);
            Controls.Add(comboBoxCurso);
            Controls.Add(comboBoxMateria);
            Controls.Add(buttonCrearReporte);
            Controls.Add(buttonCancelar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormReporteAlumnos";
            Text = "Form1";
            Load += FormReporteAlumnos_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownAño).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonCancelar;
        private Button buttonCrearReporte;
        private ComboBox comboBoxMateria;
        private ComboBox comboBoxCurso;
        private NumericUpDown numericUpDownAño;
    }
}