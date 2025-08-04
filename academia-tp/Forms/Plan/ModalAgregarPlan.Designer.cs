namespace Forms
{
    partial class ModalAgregarPlan
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
            RichTextBoxDescripcion = new RichTextBox();
            buttonPost = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 39);
            label2.Name = "label2";
            label2.Size = new Size(240, 15);
            label2.TabIndex = 12;
            label2.Text = "Complete atributos de la nueva especialidad";
            // 
            // RichTextBoxDescripcion
            // 
            RichTextBoxDescripcion.Location = new Point(167, 89);
            RichTextBoxDescripcion.Name = "RichTextBoxDescripcion";
            RichTextBoxDescripcion.Size = new Size(341, 96);
            RichTextBoxDescripcion.TabIndex = 11;
            RichTextBoxDescripcion.Text = "";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(270, 262);
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
            label1.Location = new Point(89, 89);
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
            label3.Size = new Size(72, 15);
            label3.TabIndex = 14;
            label3.Text = "Especialidad";
            label3.Click += label3_Click;
            // 
            // ModalAgregarPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 368);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(RichTextBoxDescripcion);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "ModalAgregarPlan";
            Text = "ModalAgregarPlan";
            Load += ModalAgregarPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private RichTextBox RichTextBoxDescripcion;
        private Button buttonPost;
        private Label label1;
        private ComboBox comboBox1;
        private Label label3;
    }
}