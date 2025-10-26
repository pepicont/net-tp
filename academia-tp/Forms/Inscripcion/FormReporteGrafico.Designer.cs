namespace Forms.Inscripcion
{
    partial class FormReporteGrafico
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
            comboBoxMateria = new ComboBox();
            numericUpDownAño = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btnCancelar = new Button();
            btnGenerarGrafico = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAño).BeginInit();
            SuspendLayout();
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.FormattingEnabled = true;
            comboBoxMateria.Location = new Point(134, 40);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(121, 23);
            comboBoxMateria.TabIndex = 0;
            // 
            // numericUpDownAño
            // 
            numericUpDownAño.Location = new Point(135, 91);
            numericUpDownAño.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownAño.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numericUpDownAño.Name = "numericUpDownAño";
            numericUpDownAño.Size = new Size(120, 23);
            numericUpDownAño.TabIndex = 1;
            numericUpDownAño.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 43);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Materia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 91);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 3;
            label2.Text = "Año";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(34, 146);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(106, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGenerarGrafico
            // 
            btnGenerarGrafico.Location = new Point(170, 146);
            btnGenerarGrafico.Name = "btnGenerarGrafico";
            btnGenerarGrafico.Size = new Size(113, 23);
            btnGenerarGrafico.TabIndex = 5;
            btnGenerarGrafico.Text = "Generar Gráfico";
            btnGenerarGrafico.UseVisualStyleBackColor = true;
            btnGenerarGrafico.Click += btnGenerarGrafico_Click;
            // 
            // FormReporteGrafico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 202);
            Controls.Add(btnGenerarGrafico);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownAño);
            Controls.Add(comboBoxMateria);
            Name = "FormReporteGrafico";
            Text = "Reporte Gráfico de Alumnos";
            Load += FormReporteGrafico_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownAño).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxMateria;
        private NumericUpDown numericUpDownAño;
        private Label label1;
        private Label label2;
        private Button btnCancelar;
        private Button btnGenerarGrafico;
    }
}