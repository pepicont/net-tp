namespace Forms.Inscripcion
{
    partial class formModificarInscripcion
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
            btnCancelar = new Button();
            btnModificar = new Button();
            label1 = new Label();
            Nota = new Label();
            label2 = new Label();
            comboBoxCondicion = new ComboBox();
            numericUpDownNota = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNota).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(83, 374);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(276, 46);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(411, 374);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(295, 46);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 37);
            label1.Name = "label1";
            label1.Size = new Size(177, 32);
            label1.TabIndex = 2;
            label1.Text = "Estado alumno:";
            // 
            // Nota
            // 
            Nota.AutoSize = true;
            Nota.Location = new Point(91, 121);
            Nota.Name = "Nota";
            Nota.Size = new Size(66, 32);
            Nota.TabIndex = 3;
            Nota.Text = "Nota";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 223);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 4;
            label2.Text = "Condicion";
            // 
            // comboBoxCondicion
            // 
            comboBoxCondicion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCondicion.FormattingEnabled = true;
            comboBoxCondicion.Location = new Point(341, 223);
            comboBoxCondicion.Name = "comboBoxCondicion";
            comboBoxCondicion.Size = new Size(242, 40);
            comboBoxCondicion.TabIndex = 5;
            // 
            // numericUpDownNota
            // 
            numericUpDownNota.Location = new Point(341, 114);
            numericUpDownNota.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownNota.Name = "numericUpDownNota";
            numericUpDownNota.Size = new Size(240, 39);
            numericUpDownNota.TabIndex = 6;
            // 
            // formModificarInscripcion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDownNota);
            Controls.Add(comboBoxCondicion);
            Controls.Add(label2);
            Controls.Add(Nota);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(btnCancelar);
            Name = "formModificarInscripcion";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNota).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnModificar;
        private Label label1;
        private Label Nota;
        private Label label2;
        private ComboBox comboBoxCondicion;
        private NumericUpDown numericUpDownNota;
    }
}