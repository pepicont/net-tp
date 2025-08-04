namespace Forms
{
    partial class ModalAgregarEspecialidad
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
            label2 = new Label();
            RichTextBoxDescripcion = new RichTextBox();
            buttonPost = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 75);
            label2.Name = "label2";
            label2.Size = new Size(240, 15);
            label2.TabIndex = 8;
            label2.Text = "Complete atributos de la nueva especialidad";
            // 
            // RichTextBoxDescripcion
            // 
            RichTextBoxDescripcion.Location = new Point(166, 132);
            RichTextBoxDescripcion.Name = "RichTextBoxDescripcion";
            RichTextBoxDescripcion.Size = new Size(341, 96);
            RichTextBoxDescripcion.TabIndex = 7;
            RichTextBoxDescripcion.Text = "";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(269, 264);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(114, 23);
            buttonPost.TabIndex = 6;
            buttonPost.Text = "Crear";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 172);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 5;
            label1.Text = "Descripción:";
            // 
            // ModalAgregarEspecialidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 363);
            Controls.Add(label2);
            Controls.Add(RichTextBoxDescripcion);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "ModalAgregarEspecialidad";
            Text = "ModalAgregarEspecialidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private RichTextBox RichTextBoxDescripcion;
        private Button buttonPost;
        private Label label1;
    }
}