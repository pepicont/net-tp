namespace Forms.Persona
{
    partial class FormPersonaNoAdmin
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
            ButtonModificar = new Button();
            Grilla = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Grilla).BeginInit();
            SuspendLayout();
            // 
            // ButtonModificar
            // 
            ButtonModificar.Location = new Point(321, 274);
            ButtonModificar.Name = "ButtonModificar";
            ButtonModificar.Size = new Size(146, 52);
            ButtonModificar.TabIndex = 38;
            ButtonModificar.Text = "Modificar\rPersona\r\n";
            ButtonModificar.UseVisualStyleBackColor = true;
            ButtonModificar.Click += ButtonModificar_Click;
            // 
            // Grilla
            // 
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grilla.Location = new Point(42, 125);
            Grilla.Name = "Grilla";
            Grilla.Size = new Size(716, 123);
            Grilla.TabIndex = 37;
            // 
            // FormPersonaNoAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonModificar);
            Controls.Add(Grilla);
            Name = "FormPersonaNoAdmin";
            Text = "FormPersonaNoAdmin";
            Load += FormPersonaNoAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)Grilla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonModificar;
        private DataGridView Grilla;
    }
}