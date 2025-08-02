namespace Forms
{
    partial class FormPostPlan
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
            label3 = new Label();
            SuspendLayout();
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(146, 200);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(341, 96);
            txtDesc.TabIndex = 6;
            txtDesc.Text = "";
            // 
            // buttonPost
            // 
            buttonPost.Location = new Point(240, 340);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(122, 23);
            buttonPost.TabIndex = 5;
            buttonPost.Text = "Crear plan";
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += buttonPost_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 231);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 4;
            label1.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 120);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 7;
            label2.Text = "Especialidad:";
            // 
            // comboBoxIdEspecialidad
            // 
            comboBoxIdEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIdEspecialidad.FormattingEnabled = true;
            comboBoxIdEspecialidad.Location = new Point(146, 117);
            comboBoxIdEspecialidad.Name = "comboBoxIdEspecialidad";
            comboBoxIdEspecialidad.Size = new Size(243, 23);
            comboBoxIdEspecialidad.TabIndex = 8;
            comboBoxIdEspecialidad.SelectedIndexChanged += comboBoxIdEspecialidad_SelectedIndexChanged;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(412, 117);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 9;
            buttonRefresh.Text = "Recargar";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 40);
            label3.Name = "label3";
            label3.Size = new Size(199, 15);
            label3.TabIndex = 10;
            label3.Text = "Complete atributos de el nuevo plan";
            label3.Click += label3_Click;
            // 
            // Form3
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 525);
            Controls.Add(label3);
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
        private Label label3;
    }
}