namespace Forms.Usuario
{
    partial class FormAgregarUsuario
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
            buttonPost = new Button();
            label1 = new Label();
            txtLegajo = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(473, 76);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 64;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(386, 79);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 63;
            label7.Text = "Email:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(228, 232);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 62;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(141, 235);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 61;
            label6.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(228, 176);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 60;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(141, 179);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 59;
            label5.Text = "Nombre:";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(228, 123);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(100, 23);
            txtClave.TabIndex = 58;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 126);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 57;
            label4.Text = "Clave:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(228, 76);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 56;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 34);
            label2.Name = "label2";
            label2.Size = new Size(206, 15);
            label2.TabIndex = 53;
            label2.Text = "Complete atributos del nuevo usuario";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(386, 200);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(187, 55);
            buttonPost.TabIndex = 52;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 79);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 51;
            label1.Text = "Nombre Usuario:";
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(473, 120);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(100, 23);
            txtLegajo.TabIndex = 73;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(386, 123);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 72;
            label3.Text = "Legajo:";
            // 
            // FormAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "FormAgregarUsuario";
            Text = "FormAgregarUsuario";
            Load += FormAgregarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Button buttonPost;
        private Label label1;
        private TextBox txtLegajo;
        private Label label3;
    }
}