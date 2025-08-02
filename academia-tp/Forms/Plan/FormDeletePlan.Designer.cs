namespace Forms
{
    partial class FormDeletePlan
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
            txtIdEspecialidad = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(182, 343);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(141, 23);
            buttonDelete.TabIndex = 24;
            buttonDelete.Text = "Eliminar plan";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Location = new Point(131, 174);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.ReadOnly = true;
            richTextBoxDescripcion.Size = new Size(247, 86);
            richTextBoxDescripcion.TabIndex = 23;
            richTextBoxDescripcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 186);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 22;
            label3.Text = "Descripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 123);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 21;
            label2.Text = "Id";
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(131, 123);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.ReadOnly = true;
            TextBoxId.Size = new Size(100, 23);
            TextBoxId.TabIndex = 20;
            // 
            // button1
            // 
            button1.Location = new Point(677, 67);
            button1.Name = "button1";
            button1.Size = new Size(93, 23);
            button1.TabIndex = 19;
            button1.Text = "Buscar por Id";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(476, 71);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 18;
            label1.Text = "Id";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(521, 67);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(100, 23);
            textBoxBuscar.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 298);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 25;
            label4.Text = "Especialidad:";
            // 
            // txtIdEspecialidad
            // 
            txtIdEspecialidad.Location = new Point(131, 295);
            txtIdEspecialidad.Name = "txtIdEspecialidad";
            txtIdEspecialidad.ReadOnly = true;
            txtIdEspecialidad.Size = new Size(233, 23);
            txtIdEspecialidad.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 67);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 27;
            label5.Text = "Plan seleccionado:";
            // 
            // FormDeletePlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(txtIdEspecialidad);
            Controls.Add(label4);
            Controls.Add(buttonDelete);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxId);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxBuscar);
            Name = "FormDeletePlan";
            Text = "FormDeletePlan";
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
        private TextBox txtIdEspecialidad;
        private Label label5;
    }
}