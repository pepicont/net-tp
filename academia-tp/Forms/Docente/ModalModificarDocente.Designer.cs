namespace Forms
{
    partial class ModalModificarDocente
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
            label3 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            txtCargo = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(234, 33);
            label4.Name = "label4";
            label4.Size = new Size(122, 15);
            label4.TabIndex = 15;
            label4.Text = "Atributos del Docente";
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(246, 274);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(122, 23);
            buttonPut.TabIndex = 14;
            buttonPut.Text = "Confirmar cambio";
            buttonPut.UseVisualStyleBackColor = true;
            buttonPut.Click += buttonPut_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 102);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 11;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(193, 99);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(89, 23);
            TextBoxId.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(354, 146);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 33;
            label6.Text = "Curso";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(410, 142);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(165, 23);
            comboBox2.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 146);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 31;
            label3.Text = "Docente";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(156, 142);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 194);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 34;
            label1.Text = "Cargo";
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(156, 192);
            txtCargo.Margin = new Padding(3, 2, 3, 2);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(110, 23);
            txtCargo.TabIndex = 35;
            // 
            // ModalModificarDocente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 378);
            Controls.Add(txtCargo);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Name = "ModalModificarDocente";
            Text = "ModalModificar1";
            Load += ModalModificarDocente_Load;
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
        private Label label3;
        private ComboBox comboBox1;
        private Label label1;
        private TextBox txtCargo;
    }
}