namespace Forms
{
    partial class FormEspecialidad
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
            textBox1 = new TextBox();
            ButtonModificar = new Button();
            ButtonEliminar = new Button();
            ButtonBuscar = new Button();
            Grilla = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Grilla).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(57, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 23);
            textBox1.TabIndex = 31;
            // 
            // ButtonModificar
            // 
            ButtonModificar.Location = new Point(57, 150);
            ButtonModificar.Name = "ButtonModificar";
            ButtonModificar.Size = new Size(147, 23);
            ButtonModificar.TabIndex = 30;
            ButtonModificar.Text = "Modificar ";
            ButtonModificar.UseVisualStyleBackColor = true;
            ButtonModificar.Click += ButtonModificar_Click;
            // 
            // ButtonEliminar
            // 
            ButtonEliminar.Location = new Point(57, 238);
            ButtonEliminar.Name = "ButtonEliminar";
            ButtonEliminar.Size = new Size(147, 23);
            ButtonEliminar.TabIndex = 29;
            ButtonEliminar.Text = "Eliminar";
            ButtonEliminar.UseVisualStyleBackColor = true;
            ButtonEliminar.Click += ButtonEliminar_Click;
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.Location = new Point(260, 60);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(69, 27);
            ButtonBuscar.TabIndex = 28;
            ButtonBuscar.Text = "Buscar";
            ButtonBuscar.UseVisualStyleBackColor = true;
            ButtonBuscar.Click += ButtonBuscar_Click;
            // 
            // Grilla
            // 
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grilla.Location = new Point(351, 44);
            Grilla.Name = "Grilla";
            Grilla.Size = new Size(394, 283);
            Grilla.TabIndex = 27;
            // 
            // FormEspecialidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(ButtonModificar);
            Controls.Add(ButtonEliminar);
            Controls.Add(ButtonBuscar);
            Controls.Add(Grilla);
            Name = "FormEspecialidad";
            Text = "FormEspecialidad";
            ((System.ComponentModel.ISupportInitialize)Grilla).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button ButtonModificar;
        private Button ButtonEliminar;
        private Button ButtonBuscar;
        private DataGridView Grilla;
    }
}