namespace Forms
{
    partial class FormPutPlan
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
            buttonPut = new Button();
            richTextBoxDescripcion = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            TextBoxId = new TextBox();
            button1 = new Button();
            label1 = new Label();
            textBoxBuscar = new TextBox();
            label4 = new Label();
            comboBoxIdEspecialidad = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(187, 320);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(117, 23);
            buttonPut.TabIndex = 16;
            buttonPut.Text = "Confirmar cambio";
            buttonPut.UseVisualStyleBackColor = true;
            buttonPut.Click += buttonPut_Click;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(129, 155);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.Size = new Size(247, 86);
            richTextBoxDescripcion.TabIndex = 15;
            richTextBoxDescripcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 183);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 14;
            label3.Text = "Descripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 107);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 13;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(129, 107);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(100, 23);
            TextBoxId.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(674, 48);
            button1.Name = "button1";
            button1.Size = new Size(93, 23);
            button1.TabIndex = 11;
            button1.Text = "Buscar por Id";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(472, 51);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(514, 48);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(100, 23);
            textBoxBuscar.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 266);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 18;
            label4.Text = "Especialidad:";
            // 
            // comboBoxIdEspecialidad
            // 
            comboBoxIdEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIdEspecialidad.FormattingEnabled = true;
            comboBoxIdEspecialidad.Location = new Point(129, 263);
            comboBoxIdEspecialidad.Name = "comboBoxIdEspecialidad";
            comboBoxIdEspecialidad.Size = new Size(121, 23);
            comboBoxIdEspecialidad.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 52);
            label5.Name = "label5";
            label5.Size = new Size(110, 15);
            label5.TabIndex = 20;
            label5.Text = "Atributos de el plan";
            // 
            // FormPutPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(comboBoxIdEspecialidad);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxBuscar);
            Name = "FormPutPlan";
            Text = "FormPutPlan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonPut;
        private RichTextBox richTextBoxDescripcion;
        private Label label3;
        private Label label2;
        private TextBox TextBoxId;
        private Button button1;
        private Label label1;
        private TextBox textBoxBuscar;
        private Label label4;
        private ComboBox comboBoxIdEspecialidad;
        private Label label5;
    }
}