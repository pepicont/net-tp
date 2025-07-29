namespace getEspecialidad
{
    partial class formGetEspecialidad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            buttonGetAll = new Button();
            buttonGetOne = new Button();
            textBoxID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(328, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(431, 305);
            dataGridView1.TabIndex = 0;
            // 
            // buttonGetAll
            // 
            buttonGetAll.Location = new Point(43, 12);
            buttonGetAll.Name = "buttonGetAll";
            buttonGetAll.Size = new Size(240, 60);
            buttonGetAll.TabIndex = 1;
            buttonGetAll.Text = "buscarTodos";
            buttonGetAll.UseVisualStyleBackColor = true;
            buttonGetAll.Click += button1_Click;
            // 
            // buttonGetOne
            // 
            buttonGetOne.Location = new Point(103, 96);
            buttonGetOne.Name = "buttonGetOne";
            buttonGetOne.Size = new Size(180, 23);
            buttonGetOne.TabIndex = 2;
            buttonGetOne.Text = "buscarPorID";
            buttonGetOne.UseVisualStyleBackColor = true;
            buttonGetOne.Click += buttonGetOne_Click;
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(43, 96);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(40, 23);
            textBoxID.TabIndex = 3;
            textBoxID.TextChanged += textBoxID_TextChanged;
            // 
            // formGetEspecialidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxID);
            Controls.Add(buttonGetOne);
            Controls.Add(buttonGetAll);
            Controls.Add(dataGridView1);
            Name = "formGetEspecialidad";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonGetAll;
        private Button buttonGetOne;
        private TextBox textBoxID;
    }
}
