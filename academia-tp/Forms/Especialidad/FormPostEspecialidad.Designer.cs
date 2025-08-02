namespace Forms
{
    partial class FormPostEspecialidad
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
            label1 = new Label();
            buttonPost = new Button();
            RichTextBoxDescripcion = new RichTextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 170);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 1;
            label1.Text = "Descripción:";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(210, 262);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(114, 23);
            buttonPost.TabIndex = 2;
            buttonPost.Text = "Crear especialidad";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // RichTextBoxDescripcion
            // 
            RichTextBoxDescripcion.Location = new Point(107, 130);
            RichTextBoxDescripcion.Name = "RichTextBoxDescripcion";
            RichTextBoxDescripcion.Size = new Size(341, 96);
            RichTextBoxDescripcion.TabIndex = 3;
            RichTextBoxDescripcion.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 58);
            label2.Name = "label2";
            label2.Size = new Size(240, 15);
            label2.TabIndex = 4;
            label2.Text = "Complete atributos de la nueva especialidad";
            // 
            // FormPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(RichTextBoxDescripcion);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "FormPost";
            Text = "FormPost";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonPost;
        private RichTextBox RichTextBoxDescripcion;
        private Label label2;
    }
}