namespace Forms
{
    partial class ModalModificarCurso
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
            label2 = new Label();
            TextBoxId = new TextBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            txtCupo = new TextBox();
            label5 = new Label();
            txtAnioEsp = new TextBox();
            label1 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 24);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 21;
            label4.Text = "Atributos del curso";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(384, 145);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 29;
            label6.Text = "Comision";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(441, 142);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(165, 23);
            comboBox2.TabIndex = 28;
            // 
            // txtCupo
            // 
            txtCupo.Location = new Point(469, 198);
            txtCupo.Name = "txtCupo";
            txtCupo.Size = new Size(100, 23);
            txtCupo.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(363, 201);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 26;
            label5.Text = "Cupo";
            // 
            // txtAnioEsp
            // 
            txtAnioEsp.Location = new Point(235, 193);
            txtAnioEsp.Name = "txtAnioEsp";
            txtAnioEsp.Size = new Size(100, 23);
            txtAnioEsp.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 196);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 24;
            label1.Text = "Anio Calendario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 145);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 23;
            label3.Text = "Materia";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(186, 142);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 22;
            // 
            // ModalModificarCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(txtCupo);
            Controls.Add(label5);
            Controls.Add(txtAnioEsp);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Name = "ModalModificarCurso";
            Text = "ModalModificarPlan";
            Load += ModalModificarComision_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Button buttonPut;
        private Label label2;
        private TextBox TextBoxId;
        private Label label6;
        private ComboBox comboBox2;
        private TextBox txtCupo;
        private Label label5;
        private TextBox txtAnioEsp;
        private Label label1;
        private Label label3;
        private ComboBox comboBox1;
    }
}