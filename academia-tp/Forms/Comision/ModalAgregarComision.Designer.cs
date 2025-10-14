namespace Forms
{
    partial class ModalAgregarComision
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            RichTextBoxDescripcion = new RichTextBox();
            label4 = new Label();
            txtAnioEsp = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 39);
            label2.Name = "label2";
            label2.Size = new Size(224, 15);
            label2.TabIndex = 12;
            label2.Text = "Complete atributos de la nueva comision";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(270, 299);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(114, 23);
            buttonPost.TabIndex = 10;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 73);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 9;
            label1.Text = "Descripción:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(167, 202);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 205);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 14;
            label3.Text = "Plan";
            // 
            // RichTextBoxDescripcion
            // 
            RichTextBoxDescripcion.Location = new Point(167, 73);
            RichTextBoxDescripcion.Name = "RichTextBoxDescripcion";
            RichTextBoxDescripcion.Size = new Size(341, 96);
            RichTextBoxDescripcion.TabIndex = 11;
            RichTextBoxDescripcion.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 256);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 15;
            label4.Text = "Anio Especialidad";
            // 
            // txtAnioEsp
            // 
            txtAnioEsp.Location = new Point(195, 253);
            txtAnioEsp.Name = "txtAnioEsp";
            txtAnioEsp.Size = new Size(100, 23);
            txtAnioEsp.TabIndex = 16;
            // 
            // ModalAgregarComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 368);
            Controls.Add(txtAnioEsp);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(RichTextBoxDescripcion);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "ModalAgregarComision";
            Text = "ModalAgregarPlan";
            Load += ModalAgregarPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button buttonPost;
        private Label label1;
        private ComboBox comboBox1;
        private Label label3;
        private RichTextBox RichTextBoxDescripcion;
        private Label label4;
        private TextBox txtAnioEsp;
    }
}