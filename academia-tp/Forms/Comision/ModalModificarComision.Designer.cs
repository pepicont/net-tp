namespace Forms
{
    partial class ModalModificarComision
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            txtAnioEsp = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 24);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 21;
            label4.Text = "Atributos de la comision";
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(268, 316);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(122, 23);
            buttonPut.TabIndex = 20;
            buttonPut.Text = "Confirmar cambio";
            buttonPut.UseVisualStyleBackColor = true;
            buttonPut.Click += buttonPut_Click;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(223, 111);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.Size = new Size(247, 86);
            richTextBoxDescripcion.TabIndex = 19;
            richTextBoxDescripcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 144);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 18;
            label3.Text = "Descripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 66);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 17;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(223, 63);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(89, 23);
            TextBoxId.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 228);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 22;
            label1.Text = "Plan";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(223, 220);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 23;
            // 
            // txtAnioEsp
            // 
            txtAnioEsp.Location = new Point(230, 274);
            txtAnioEsp.Name = "txtAnioEsp";
            txtAnioEsp.Size = new Size(100, 23);
            txtAnioEsp.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(124, 277);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 24;
            label5.Text = "Anio Especialidad";
            // 
            // ModalModificarComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtAnioEsp);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Name = "ModalModificarComision";
            Text = "ModalModificarPlan";
            Load += ModalModificarComision_Load_1;
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
        private Label label1;
        private ComboBox comboBox1;
        private TextBox txtAnioEsp;
        private Label label5;
    }
}