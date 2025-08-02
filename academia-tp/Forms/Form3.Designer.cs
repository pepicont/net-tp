namespace Forms
{
    partial class Form3
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
            txtDesc = new RichTextBox();
            buttonPost = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBoxIdEspecialidad = new ComboBox();
            buttonRefresh = new Button();
            SuspendLayout();
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(155, 182);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(341, 96);
            txtDesc.TabIndex = 6;
            txtDesc.Text = "";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(94, 322);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(122, 23);
            buttonPost.TabIndex = 5;
            buttonPost.Text = "Confirmar";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 197);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 4;
            label1.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 78);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 7;
            label2.Text = "Id_especialidad: ";
            // 
            // comboBoxIdEspecialidad
            // 
            comboBoxIdEspecialidad.FormattingEnabled = true;
            comboBoxIdEspecialidad.Location = new Point(176, 75);
            comboBoxIdEspecialidad.Name = "comboBoxIdEspecialidad";
            comboBoxIdEspecialidad.Size = new Size(121, 23);
            comboBoxIdEspecialidad.TabIndex = 8;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(321, 74);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 9;
            buttonRefresh.Text = "Recargar";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // Form3
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 525);
            Controls.Add(buttonRefresh);
            Controls.Add(comboBoxIdEspecialidad);
            Controls.Add(label2);
            Controls.Add(txtDesc);
            Controls.Add(buttonPost);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox txtDesc;
        private Button buttonPost;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxIdEspecialidad;
        private Button buttonRefresh;
    }
}