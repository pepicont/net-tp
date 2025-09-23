namespace Forms.Persona
{
    partial class ModalAgregarPersona
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
            calendario = new MonthCalendar();
            radioAlumno = new RadioButton();
            radioProfesor = new RadioButton();
            label9 = new Label();
            label8 = new Label();
            txtTelefono = new TextBox();
            label7 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            txtDireccion = new TextBox();
            label5 = new Label();
            txtApellido = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            comboBoxPlan = new ComboBox();
            label2 = new Label();
            buttonPost = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // calendario
            // 
            calendario.Location = new Point(405, 119);
            calendario.Name = "calendario";
            calendario.TabIndex = 50;
            // 
            // radioAlumno
            // 
            radioAlumno.AutoSize = true;
            radioAlumno.Location = new Point(497, 298);
            radioAlumno.Name = "radioAlumno";
            radioAlumno.Size = new Size(68, 19);
            radioAlumno.TabIndex = 49;
            radioAlumno.TabStop = true;
            radioAlumno.Text = "Alumno";
            radioAlumno.UseVisualStyleBackColor = true;
            // 
            // radioProfesor
            // 
            radioProfesor.AutoSize = true;
            radioProfesor.Location = new Point(589, 298);
            radioProfesor.Name = "radioProfesor";
            radioProfesor.Size = new Size(69, 19);
            radioProfesor.TabIndex = 48;
            radioProfesor.TabStop = true;
            radioProfesor.Text = "Profesor";
            radioProfesor.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(414, 300);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 47;
            label9.Text = "Tipo Persona";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(468, 95);
            label8.Name = "label8";
            label8.Size = new Size(122, 15);
            label8.TabIndex = 46;
            label8.Text = "Fecha de Nacimiento:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(229, 296);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 45;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(142, 299);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 44;
            label7.Text = "Teléfono:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(229, 251);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 43;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(142, 254);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 42;
            label6.Text = "Email:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(229, 195);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 41;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(142, 198);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 40;
            label5.Text = "Dirección:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(229, 142);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(142, 145);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 38;
            label4.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(229, 95);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(145, 346);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 36;
            label3.Text = "Plan";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(194, 343);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(159, 23);
            comboBoxPlan.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(267, 53);
            label2.Name = "label2";
            label2.Size = new Size(217, 15);
            label2.TabIndex = 34;
            label2.Text = "Complete atributos de la nueva persona";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(493, 343);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(160, 55);
            buttonPost.TabIndex = 33;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 98);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 32;
            label1.Text = "Nombre:";
            // 
            // ModalAgregarPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(calendario);
            Controls.Add(radioAlumno);
            Controls.Add(radioProfesor);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtTelefono);
            Controls.Add(label7);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(txtDireccion);
            Controls.Add(label5);
            Controls.Add(txtApellido);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(comboBoxPlan);
            Controls.Add(label2);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "ModalAgregarPersona";
            Text = "ModalAgregarPersona";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar calendario;
        private RadioButton radioAlumno;
        private RadioButton radioProfesor;
        private Label label9;
        private Label label8;
        private TextBox txtTelefono;
        private Label label7;
        private TextBox txtEmail;
        private Label label6;
        private TextBox txtDireccion;
        private Label label5;
        private TextBox txtApellido;
        private Label label4;
        private TextBox txtNombre;
        private Label label3;
        private ComboBox comboBoxPlan;
        private Label label2;
        private Button buttonPost;
        private Label label1;
    }
}