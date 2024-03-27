namespace 大作业
{
    partial class 主页
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(主页));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(696, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(705, 462);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(696, 534);
            button1.Name = "button1";
            button1.Size = new Size(163, 74);
            button1.TabIndex = 0;
            button1.Text = "获取数据";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(255, 128, 0);
            button2.Location = new Point(974, 534);
            button2.Name = "button2";
            button2.Size = new Size(163, 74);
            button2.TabIndex = 2;
            button2.Text = "验证网络I/O不冻结UI";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(456, 406);
            label1.Name = "label1";
            label1.Size = new Size(0, 24);
            label1.TabIndex = 3;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(1238, 534);
            button3.Name = "button3";
            button3.Size = new Size(163, 74);
            button3.TabIndex = 4;
            button3.Text = "清空数据";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // 主页
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1551, 785);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "主页";
            Text = "主页";
            FormClosed += 主页_FormClosed;
            Load += 大作业_Load;
            SizeChanged += 主页_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Button button3;
    }
}
