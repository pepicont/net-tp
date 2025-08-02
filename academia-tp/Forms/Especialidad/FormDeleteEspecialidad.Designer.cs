namespace Forms
{
    partial class FormDeleteEspecialidad
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
            buttonDelete = new Button();
            richTextBoxDescripcion = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            TextBoxId = new TextBox();
            button1 = new Button();
            label1 = new Label();
            textBoxBuscar = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(167, 267);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(147, 23);
            buttonDelete.TabIndex = 16;
            buttonDelete.Text = "Eliminar especialidad";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(125, 165);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.ReadOnly = true;
            richTextBoxDescripcion.Size = new Size(247, 86);
            richTextBoxDescripcion.TabIndex = 15;
            richTextBoxDescripcion.Text = "";
            richTextBoxDescripcion.TextChanged += richTextBoxDescripcion_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 198);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 14;
            label3.Text = "Descripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 124);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 13;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(125, 121);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(100, 23);
            TextBoxId.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(670, 50);
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
            label1.Location = new Point(468, 53);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(510, 50);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(100, 23);
            textBoxBuscar.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 50);
            label4.Name = "label4";
            label4.Size = new Size(146, 15);
            label4.TabIndex = 17;
            label4.Text = "Especialidad seleccionada:";
            // 
            // FormDeleteEspecialidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(buttonDelete);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxBuscar);
            Name = "FormDeleteEspecialidad";
            Text = "FormDeleteEspecialidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDelete;
        private RichTextBox richTextBoxDescripcion;
        private Label label3;
        private Label label2;
        private TextBox TextBoxId;
        private Button button1;
        private Label label1;
        private TextBox textBoxBuscar;
        private Label label4;
    }
}