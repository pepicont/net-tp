namespace Forms
{
    partial class ModalModificarEspecialidad
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
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(234, 33);
            label4.Name = "label4";
            label4.Size = new Size(152, 15);
            label4.TabIndex = 15;
            label4.Text = "Atributos de la especialidad";
            // 
            // buttonPut
            // 
            buttonPut.Location = new Point(246, 274);
            buttonPut.Name = "buttonPut";
            buttonPut.Size = new Size(122, 23);
            buttonPut.TabIndex = 14;
            buttonPut.Text = "Confirmar cambio";
            buttonPut.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(193, 157);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.Size = new Size(247, 86);
            richTextBoxDescripcion.TabIndex = 13;
            richTextBoxDescripcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 190);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 12;
            label3.Text = "Descripción";
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
            // ModalModificarEspecialidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 343);
            Controls.Add(label4);
            Controls.Add(buttonPut);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Name = "ModalModificarEspecialidad";
            Text = "ModalModificar1";
            Load += ModalModificarEspecialidad_Load;
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
    }
}