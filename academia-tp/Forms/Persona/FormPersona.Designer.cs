namespace Forms.Persona
{
    partial class FormPersona
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
            ButtonCrear = new Button();
            textBox1 = new TextBox();
            ButtonModificar = new Button();
            ButtonEliminar = new Button();
            ButtonBuscar = new Button();
            Grilla = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Grilla).BeginInit();
            SuspendLayout();
            // 
            // ButtonCrear
            // 
            ButtonCrear.Location = new Point(163, 348);
            ButtonCrear.Name = "ButtonCrear";
            ButtonCrear.Size = new Size(147, 23);
            ButtonCrear.TabIndex = 38;
            ButtonCrear.Text = "Crear";
            ButtonCrear.UseVisualStyleBackColor = true;
            ButtonCrear.Click += ButtonCrear_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(295, 269);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 23);
            textBox1.TabIndex = 37;
            // 
            // ButtonModificar
            // 
            ButtonModificar.Location = new Point(325, 348);
            ButtonModificar.Name = "ButtonModificar";
            ButtonModificar.Size = new Size(147, 23);
            ButtonModificar.TabIndex = 36;
            ButtonModificar.Text = "Modificar ";
            ButtonModificar.UseVisualStyleBackColor = true;
            ButtonModificar.Click += ButtonModificar_Click;
            // 
            // ButtonEliminar
            // 
            ButtonEliminar.Location = new Point(498, 348);
            ButtonEliminar.Name = "ButtonEliminar";
            ButtonEliminar.Size = new Size(147, 23);
            ButtonEliminar.TabIndex = 35;
            ButtonEliminar.Text = "Eliminar";
            ButtonEliminar.UseVisualStyleBackColor = true;
            ButtonEliminar.Click += ButtonEliminar_Click;
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.Location = new Point(498, 266);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(69, 27);
            ButtonBuscar.TabIndex = 34;
            ButtonBuscar.Text = "Buscar";
            ButtonBuscar.UseVisualStyleBackColor = true;
            ButtonBuscar.Click += ButtonBuscar_Click;
            // 
            // Grilla
            // 
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grilla.Location = new Point(50, 12);
            Grilla.Name = "Grilla";
            Grilla.Size = new Size(708, 187);
            Grilla.TabIndex = 33;
            // 
            // FormPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonCrear);
            Controls.Add(textBox1);
            Controls.Add(ButtonModificar);
            Controls.Add(ButtonEliminar);
            Controls.Add(ButtonBuscar);
            Controls.Add(Grilla);
            Name = "FormPersona";
            Text = "FormPersona";
            ((System.ComponentModel.ISupportInitialize)Grilla).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonCrear;
        private TextBox textBox1;
        private Button ButtonModificar;
        private Button ButtonEliminar;
        private Button ButtonBuscar;
        private DataGridView Grilla;
    }
}