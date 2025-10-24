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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 128);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(463, 64);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido a la Academia!\r\nPor favor digite su información de Ingreso";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 237);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(228, 32);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(193, 341);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(139, 32);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(376, 335);
            txtPass.Margin = new Padding(6, 6, 6, 6);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(348, 39);
            txtPass.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(376, 230);
            txtUsuario.Margin = new Padding(6, 6, 6, 6);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(348, 39);
            txtUsuario.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(583, 422);
            btnIngresar.Margin = new Padding(6, 6, 6, 6);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(139, 49);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // InkOlvidaPass
            // 
            InkOlvidaPass.AutoSize = true;
            InkOlvidaPass.Location = new Point(319, 431);
            InkOlvidaPass.Margin = new Padding(6, 0, 6, 0);
            InkOlvidaPass.Name = "InkOlvidaPass";
            InkOlvidaPass.Size = new Size(240, 32);
            InkOlvidaPass.TabIndex = 6;
            InkOlvidaPass.TabStop = true;
            InkOlvidaPass.Text = "Olvidé mi contraseña";
            InkOlvidaPass.LinkClicked += InkOlvidaPass_LinkClicked;
            // 
            // FormLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(InkOlvidaPass);
            Controls.Add(btnIngresar);
            Controls.Add(txtUsuario);
            Controls.Add(txtPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(6, 6, 6, 6);
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
    }
}