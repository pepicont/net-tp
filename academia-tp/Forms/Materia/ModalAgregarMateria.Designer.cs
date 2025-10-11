namespace Forms
{
    partial class ModalAgregarMateria
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
            label3 = new Label();
            label4 = new Label();
            txtBoxHsSemanales = new TextBox();
            txtBoxHsTotales = new TextBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 100);
            label2.Name = "label2";
            label2.Size = new Size(272, 20);
            label2.TabIndex = 8;
            label2.Text = "Complete atributos de la nueva materia";
            // 
            // RichTextBoxDescripcion
            // 
            RichTextBoxDescripcion.Location = new Point(197, 167);
            RichTextBoxDescripcion.Margin = new Padding(3, 4, 3, 4);
            RichTextBoxDescripcion.Name = "RichTextBoxDescripcion";
            RichTextBoxDescripcion.Size = new Size(317, 76);
            RichTextBoxDescripcion.TabIndex = 7;
            RichTextBoxDescripcion.Text = "";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(304, 431);
            buttonPost.Margin = new Padding(3, 4, 3, 4);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(130, 31);
            buttonPost.TabIndex = 6;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 190);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 5;
            label1.Text = "Descripción:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 270);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 9;
            label3.Text = "Horas Semanales";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(101, 320);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 10;
            label4.Text = "Horas Totales";
            // 
            // txtBoxHsSemanales
            // 
            txtBoxHsSemanales.Location = new Point(242, 267);
            txtBoxHsSemanales.Name = "txtBoxHsSemanales";
            txtBoxHsSemanales.Size = new Size(125, 27);
            txtBoxHsSemanales.TabIndex = 11;
            // 
            // txtBoxHsTotales
            // 
            txtBoxHsTotales.Location = new Point(242, 313);
            txtBoxHsTotales.Name = "txtBoxHsTotales";
            txtBoxHsTotales.Size = new Size(125, 27);
            txtBoxHsTotales.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(108, 373);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 16;
            label5.Text = "Plan";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(197, 369);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 28);
            comboBox1.TabIndex = 15;
            // 
            // ModalAgregarMateria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 484);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(txtBoxHsTotales);
            Controls.Add(txtBoxHsSemanales);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(RichTextBoxDescripcion);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ModalAgregarMateria";
            Text = "ModalAgregarEspecialidad";
            Load += ModalAgregarMateria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private RichTextBox RichTextBoxDescripcion;
        private Button buttonPost;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtBoxHsSemanales;
        private TextBox txtBoxHsTotales;
        private Label label5;
        private ComboBox comboBox1;
    }
}