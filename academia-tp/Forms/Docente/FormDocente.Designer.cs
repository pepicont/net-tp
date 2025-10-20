namespace Forms
{
    partial class FormDocente
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
            textBox1.Location = new Point(41, 100);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 27);
            textBox1.TabIndex = 36;
            // 
            // ButtonModificar
            // 
            ButtonModificar.Location = new Point(41, 216);
            ButtonModificar.Margin = new Padding(3, 4, 3, 4);
            ButtonModificar.Name = "ButtonModificar";
            ButtonModificar.Size = new Size(168, 31);
            ButtonModificar.TabIndex = 35;
            ButtonModificar.Text = "Modificar ";
            ButtonModificar.UseVisualStyleBackColor = true;
            ButtonModificar.Click += ButtonModificar_Click;
            // 
            // ButtonEliminar
            // 
            ButtonEliminar.Location = new Point(41, 333);
            ButtonEliminar.Margin = new Padding(3, 4, 3, 4);
            ButtonEliminar.Name = "ButtonEliminar";
            ButtonEliminar.Size = new Size(168, 31);
            ButtonEliminar.TabIndex = 34;
            ButtonEliminar.Text = "Eliminar";
            ButtonEliminar.UseVisualStyleBackColor = true;
            ButtonEliminar.Click += ButtonEliminar_Click;
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.Location = new Point(273, 96);
            ButtonBuscar.Margin = new Padding(3, 4, 3, 4);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(79, 36);
            ButtonBuscar.TabIndex = 33;
            ButtonBuscar.Text = "Buscar";
            ButtonBuscar.UseVisualStyleBackColor = true;
            ButtonBuscar.Click += ButtonBuscar_Click;
            // 
            // Grilla
            // 
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grilla.Location = new Point(377, 75);
            Grilla.Margin = new Padding(3, 4, 3, 4);
            Grilla.Name = "Grilla";
            Grilla.RowHeadersWidth = 51;
            Grilla.Size = new Size(450, 377);
            Grilla.TabIndex = 32;
            // 
            // FormDocente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 532);
            Controls.Add(textBox1);
            Controls.Add(ButtonModificar);
            Controls.Add(ButtonEliminar);
            Controls.Add(ButtonBuscar);
            Controls.Add(Grilla);
            Name = "FormDocente";
            Text = "FormDocente";
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