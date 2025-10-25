namespace Forms.Inscripcion
{
    partial class FormAgregarInscripcion
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
            label1 = new Label();
            comboBoxCurso = new ComboBox();
            button1 = new Button();
            label2 = new Label();
            textBoxIdAlumno = new TextBox();
            labelIdAlumno = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateria.FormattingEnabled = true;
            comboBoxMateria.Location = new Point(99, 44);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(200, 23);
            comboBoxMateria.TabIndex = 0;
            comboBoxMateria.SelectedIndexChanged += comboBoxMateria_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 47);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Materia";
            // 
            // comboBoxCurso
            // 
            comboBoxCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCurso.FormattingEnabled = true;
            comboBoxCurso.Location = new Point(99, 121);
            comboBoxCurso.Name = "comboBoxCurso";
            comboBoxCurso.Size = new Size(200, 23);
            comboBoxCurso.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(200, 280);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Inscribirse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 124);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "Curso";
            // 
            // textBoxIdAlumno
            // 
            textBoxIdAlumno.Location = new Point(552, 44);
            textBoxIdAlumno.Name = "textBoxIdAlumno";
            textBoxIdAlumno.Size = new Size(121, 23);
            textBoxIdAlumno.TabIndex = 5;
            textBoxIdAlumno.Visible = false;
            // 
            // labelIdAlumno
            // 
            labelIdAlumno.AutoSize = true;
            labelIdAlumno.Location = new Point(466, 47);
            labelIdAlumno.Name = "labelIdAlumno";
            labelIdAlumno.Size = new Size(64, 15);
            labelIdAlumno.TabIndex = 6;
            labelIdAlumno.Text = "ID Alumno";
            labelIdAlumno.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 201);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 8;
            // 
            // FormAgregarInscripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(comboBoxComision);
            Controls.Add(labelIdAlumno);
            Controls.Add(textBoxIdAlumno);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(comboBoxCurso);
            Controls.Add(label1);
            Controls.Add(comboBoxMateria);
            Name = "FormAgregarInscripcion";
            Text = "Form1";
            Load += FormAgregarInscripcion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboBoxMateria;
        private Label label1;
        private ComboBox comboBoxCurso;
        private Button button1;
        private Label label2;
        private TextBox textBoxIdAlumno;
        private Label labelIdAlumno;
        private ComboBox comboBoxComision;
        private Label label3;
        #endregion
    }
}