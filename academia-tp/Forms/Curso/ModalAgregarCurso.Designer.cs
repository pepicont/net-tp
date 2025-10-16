namespace Forms
{
    partial class ModalAgregarCurso
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
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txtAnioEsp = new TextBox();
            txtCupo = new TextBox();
            label5 = new Label();
            label6 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 39);
            label2.Name = "label2";
            label2.Size = new Size(196, 15);
            label2.TabIndex = 12;
            label2.Text = "Complete atributos del nuevo curso";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(264, 271);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(114, 23);
            buttonPost.TabIndex = 10;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(147, 121);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 124);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 14;
            label3.Text = "Materia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 175);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 15;
            label4.Text = "Anio Calendario";
            // 
            // txtAnioEsp
            // 
            txtAnioEsp.Location = new Point(196, 172);
            txtAnioEsp.Name = "txtAnioEsp";
            txtAnioEsp.Size = new Size(100, 23);
            txtAnioEsp.TabIndex = 16;
            // 
            // txtCupo
            // 
            txtCupo.Location = new Point(430, 177);
            txtCupo.Name = "txtCupo";
            txtCupo.Size = new Size(100, 23);
            txtCupo.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(324, 180);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 17;
            label5.Text = "Cupo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(345, 124);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 20;
            label6.Text = "Comision";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(402, 121);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(165, 23);
            comboBox2.TabIndex = 19;
            // 
            // ModalAgregarCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 368);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(txtCupo);
            Controls.Add(label5);
            Controls.Add(txtAnioEsp);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(buttonPost);
            Name = "ModalAgregarCurso";
            Text = "ModalAgregarPlan";
            Load += ModalAgregarPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button buttonPost;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private TextBox txtAnioEsp;
        private TextBox txtCupo;
        private Label label5;
        private Label label6;
        private ComboBox comboBox2;
    }
}