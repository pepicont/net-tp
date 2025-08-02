namespace Forms
{
    partial class FormGetEspecialidad
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
            textBox1 = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(357, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(394, 283);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonGetAll
            // 
            buttonGetAll.Location = new Point(34, 51);
            buttonGetAll.Name = "buttonGetAll";
            buttonGetAll.Size = new Size(250, 57);
            buttonGetAll.TabIndex = 1;
            buttonGetAll.Text = "Todas las especialidades";
            buttonGetAll.UseVisualStyleBackColor = true;
            buttonGetAll.Click += buttonGetAll_Click;
            // 
            // buttonGetOne
            // 
            buttonGetOne.Location = new Point(124, 159);
            buttonGetOne.Name = "buttonGetOne";
            buttonGetOne.Size = new Size(160, 23);
            buttonGetOne.TabIndex = 2;
            buttonGetOne.Text = "Buscar una especialidad";
            buttonGetOne.UseVisualStyleBackColor = true;
            buttonGetOne.Click += buttonGetOne_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(46, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 142);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 4;
            label1.Text = "Id";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(buttonGetOne);
            Controls.Add(buttonGetAll);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonGetAll;
        private Button buttonGetOne;
        private TextBox textBox1;
        private Label label1;
    }
}
