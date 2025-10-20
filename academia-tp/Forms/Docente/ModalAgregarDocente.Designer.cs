namespace Forms
{
    partial class ModalAgregarDocente
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
            label2 = new Label();
            buttonPost = new Button();
            txtCargo = new TextBox();
            label1 = new Label();
            label6 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(204, 61);
            label2.Name = "label2";
            label2.Size = new Size(211, 15);
            label2.TabIndex = 8;
            label2.Text = "Complete atributos del nuevo Docente";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(257, 300);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(114, 23);
            buttonPost.TabIndex = 6;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(144, 208);
            txtCargo.Margin = new Padding(3, 2, 3, 2);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(110, 23);
            txtCargo.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 211);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 44;
            label1.Text = "Cargo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(341, 162);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 43;
            label6.Text = "Curso";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(398, 159);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(165, 23);
            comboBox2.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 162);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 41;
            label3.Text = "Docente";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(144, 159);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 40;
            // 
            // ModalAgregarDocente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 363);
            Controls.Add(txtCargo);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(buttonPost);
            Name = "ModalAgregarDocente";
            Text = "ModalAgregarEspecialidad";
            Load += ModalAgregarDocente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button buttonPost;
        private TextBox txtCargo;
        private Label label1;
        private Label label6;
        private ComboBox comboBox2;
        private Label label3;
        private ComboBox comboBox1;
    }
}