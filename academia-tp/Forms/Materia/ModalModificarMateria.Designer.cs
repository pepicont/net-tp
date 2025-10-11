namespace Forms
{
    partial class ModalModificarMateria
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
            label4 = new Label();
            buttonPut = new Button();
            richTextBoxDescripcion = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            TextBoxId = new TextBox();
            txtBoxHsTotales = new TextBox();
            txtBoxHsSemanales = new TextBox();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(267, 44);
            label4.Name = "label4";
            label4.Size = new Size(195, 20);
            label4.TabIndex = 15;
            label4.Text = "Atributos de la especialidad";
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(267, 396);
            buttonPut.Margin = new Padding(3, 4, 3, 4);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(139, 31);
            buttonPut.TabIndex = 14;
            buttonPut.Text = "Confirmar cambio";
            buttonPut.UseVisualStyleBackColor = true;
            buttonPut.Click += buttonPut_Click_1;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(221, 149);
            richTextBoxDescripcion.Margin = new Padding(3, 4, 3, 4);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.Size = new Size(241, 59);
            richTextBoxDescripcion.TabIndex = 13;
            richTextBoxDescripcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 152);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 12;
            label3.Text = "Descripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 98);
            label2.Name = "label2";
            label2.Size = new Size(22, 20);
            label2.TabIndex = 11;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(221, 98);
            TextBoxId.Margin = new Padding(3, 4, 3, 4);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(101, 27);
            TextBoxId.TabIndex = 10;
            // 
            // txtBoxHsTotales
            // 
            txtBoxHsTotales.Location = new Point(248, 281);
            txtBoxHsTotales.Name = "txtBoxHsTotales";
            txtBoxHsTotales.Size = new Size(125, 27);
            txtBoxHsTotales.TabIndex = 19;
            // 
            // txtBoxHsSemanales
            // 
            txtBoxHsSemanales.Location = new Point(248, 235);
            txtBoxHsSemanales.Name = "txtBoxHsSemanales";
            txtBoxHsSemanales.Size = new Size(125, 27);
            txtBoxHsSemanales.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 288);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 17;
            label1.Text = "Horas Totales";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(107, 238);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 16;
            label5.Text = "Horas Semanales";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(114, 343);
            label6.Name = "label6";
            label6.Size = new Size(37, 20);
            label6.TabIndex = 21;
            label6.Text = "Plan";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(203, 339);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 28);
            comboBox1.TabIndex = 20;
            // 
            // ModalModificarMateria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 457);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(txtBoxHsTotales);
            Controls.Add(txtBoxHsSemanales);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ModalModificarMateria";
            Text = "ModalModificar1";
            Load += ModalModificarMateria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Button buttonPut;
        private RichTextBox richTextBoxDescripcion;
        private Label label3;
        private Label label2;
        private TextBox TextBoxId;
        private TextBox txtBoxHsTotales;
        private TextBox txtBoxHsSemanales;
        private Label label1;
        private Label label5;
        private Label label6;
        private ComboBox comboBox1;
    }
}