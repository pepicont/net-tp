namespace Forms.Usuario
{
    partial class FormModificarUsuario
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
            txtLegajo = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtApellido = new TextBox();
            label6 = new Label();
            txtNombre = new TextBox();
            label5 = new Label();
            txtClave = new TextBox();
            label4 = new Label();
            txtNombreUsuario = new TextBox();
            label2 = new Label();
            buttonPut = new Button();
            label1 = new Label();
            label8 = new Label();
            radioSi = new RadioButton();
            radioNo = new RadioButton();
            SuspendLayout();
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(497, 131);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(100, 23);
            txtLegajo.TabIndex = 87;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(410, 134);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 86;
            label3.Text = "Legajo:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(497, 87);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 85;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(410, 90);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 84;
            label7.Text = "Email:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(252, 243);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 83;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(165, 246);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 82;
            label6.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(252, 187);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 81;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(165, 190);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 80;
            label5.Text = "Nombre:";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(252, 134);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(100, 23);
            txtClave.TabIndex = 79;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(149, 137);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 78;
            label4.Text = "Clave:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(252, 87);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 77;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 45);
            label2.Name = "label2";
            label2.Size = new Size(206, 15);
            label2.TabIndex = 76;
            label2.Text = "Complete atributos del nuevo usuario";
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(410, 211);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(187, 55);
            buttonPut.TabIndex = 75;
            buttonPut.Text = "Modificar";
            buttonPut.UseVisualStyleBackColor = true;
            buttonPut.Click += buttonPut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 90);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 74;
            label1.Text = "Nombre Usuario:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(410, 172);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 88;
            label8.Text = "Habilitado:";
            // 
            // radioSi
            // 
            radioSi.AutoSize = true;
            radioSi.Location = new Point(497, 172);
            radioSi.Name = "radioSi";
            radioSi.Size = new Size(34, 19);
            radioSi.TabIndex = 89;
            radioSi.TabStop = true;
            radioSi.Text = "Si";
            radioSi.UseVisualStyleBackColor = true;
            // 
            // radioNo
            // 
            radioNo.AutoSize = true;
            radioNo.Location = new Point(556, 172);
            radioNo.Name = "radioNo";
            radioNo.Size = new Size(41, 19);
            radioNo.TabIndex = 90;
            radioNo.TabStop = true;
            radioNo.Text = "No";
            radioNo.UseVisualStyleBackColor = true;
            // 
            // FormModificarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radioNo);
            Controls.Add(radioSi);
            Controls.Add(label8);
            Controls.Add(txtLegajo);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(txtApellido);
            Controls.Add(label6);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(txtClave);
            Controls.Add(label4);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label2);
            Controls.Add(buttonPut);
            Controls.Add(label1);
            Name = "FormModificarUsuario";
            Text = "FormModificarUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLegajo;
        private Label label3;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtApellido;
        private Label label6;
        private TextBox txtNombre;
        private Label label5;
        private TextBox txtClave;
        private Label label4;
        private TextBox txtNombreUsuario;
        private Label label2;
        private Button buttonPut;
        private Label label1;
        private Label label8;
        private RadioButton radioSi;
        private RadioButton radioNo;
    }
}