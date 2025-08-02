namespace Forms
{
    partial class Form2
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
            textBoxBuscar = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            TextBoxId = new TextBox();
            label3 = new Label();
            richTextBoxDescripcion = new RichTextBox();
            buttonPut = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(506, 60);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(100, 23);
            textBoxBuscar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(470, 63);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 1;
            label1.Text = "Id";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(630, 60);
            button1.Name = "button1";
            button1.Size = new Size(146, 23);
            button1.TabIndex = 2;
            button1.Text = "Buscar una especialidad";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 124);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 4;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(121, 121);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(100, 23);
            TextBoxId.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 212);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 6;
            label3.Text = "Descripción";
            label3.Click += label3_Click;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(121, 179);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.Size = new Size(247, 86);
            richTextBoxDescripcion.TabIndex = 7;
            richTextBoxDescripcion.Text = "";
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(174, 296);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(122, 23);
            buttonPut.TabIndex = 8;
            buttonPut.Text = "Confirmar cambio";
            buttonPut.UseVisualStyleBackColor = true;
            buttonPut.Click += buttonPut_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 60);
            label4.Name = "label4";
            label4.Size = new Size(152, 15);
            label4.TabIndex = 9;
            label4.Text = "Atributos de la especialidad";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxBuscar);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxBuscar;
        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox TextBoxId;
        private Label label3;
        private RichTextBox richTextBoxDescripcion;
        private Button buttonPut;
        private Label label4;
    }
}