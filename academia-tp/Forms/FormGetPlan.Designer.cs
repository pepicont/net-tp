namespace Forms
{
    partial class FormGetPlan
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
            buttonGetOne = new Button();
            buttonGetAll = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(68, 144);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(46, 23);
            textBox1.TabIndex = 7;
            // 
            // buttonGetOne
            // 
            buttonGetOne.Location = new Point(141, 144);
            buttonGetOne.Name = "buttonGetOne";
            buttonGetOne.Size = new Size(127, 23);
            buttonGetOne.TabIndex = 6;
            buttonGetOne.Text = "Buscar un plan";
            buttonGetOne.UseVisualStyleBackColor = true;
            buttonGetOne.Click += buttonGetOne_Click;
            // 
            // buttonGetAll
            // 
            buttonGetAll.Location = new Point(35, 45);
            buttonGetAll.Name = "buttonGetAll";
            buttonGetAll.Size = new Size(250, 57);
            buttonGetAll.TabIndex = 5;
            buttonGetAll.Text = "Todos los planes";
            buttonGetAll.UseVisualStyleBackColor = true;
            buttonGetAll.Click += buttonGetAll_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(353, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(394, 283);
            dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 126);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 8;
            label1.Text = "Id";
            // 
            // FormGetPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(buttonGetOne);
            Controls.Add(buttonGetAll);
            Controls.Add(dataGridView1);
            Name = "FormGetPlan";
            Text = "FormGetPlan";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonGetOne;
        private Button buttonGetAll;
        private DataGridView dataGridView1;
        private Label label1;
    }
}