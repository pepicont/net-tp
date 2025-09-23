namespace Forms
{
    partial class FormLogin
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
            txtPass = new TextBox();
            txtUsuario = new TextBox();
            btnIngresar = new Button();
            InkOlvidaPass = new LinkLabel();
            label4 = new Label();
            btnCrearCuenta = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 60);
            label1.Name = "label1";
            label1.Size = new Size(229, 30);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido a la Academia!\r\nPor favor digite su información de Ingreso";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 111);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 160);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(200, 157);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(189, 23);
            txtPass.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(200, 108);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(189, 23);
            txtUsuario.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(314, 198);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // InkOlvidaPass
            // 
            InkOlvidaPass.AutoSize = true;
            InkOlvidaPass.Location = new Point(172, 202);
            InkOlvidaPass.Name = "InkOlvidaPass";
            InkOlvidaPass.Size = new Size(119, 15);
            InkOlvidaPass.TabIndex = 6;
            InkOlvidaPass.TabStop = true;
            InkOlvidaPass.Text = "Olvidé mi contraseña";
            InkOlvidaPass.LinkClicked += InkOlvidaPass_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 277);
            label4.Name = "label4";
            label4.Size = new Size(189, 15);
            label4.TabIndex = 7;
            label4.Text = "No tienes una cuenta? Creala aquí:";
            label4.Click += label4_Click;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(291, 273);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(86, 23);
            btnCrearCuenta.TabIndex = 8;
            btnCrearCuenta.Text = "Crear Cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrearCuenta);
            Controls.Add(label4);
            Controls.Add(InkOlvidaPass);
            Controls.Add(btnIngresar);
            Controls.Add(txtUsuario);
            Controls.Add(txtPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPass;
        private TextBox txtUsuario;
        private Button btnIngresar;
        private LinkLabel InkOlvidaPass;
        private Label label4;
        private Button btnCrearCuenta;
    }
}