namespace screener3
{
    partial class FormTool
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTool));
            gboxNewSize = new GroupBox();
            tbHeight = new TextBox();
            lbTest = new Label();
            tbWidth = new TextBox();
            lblInfo = new Label();
            toolTipTool = new ToolTip(components);
            picboxGuidlineColorSample = new PictureBox();
            panel1 = new Panel();
            btnOK = new Button();
            gboxGuidlines = new GroupBox();
            panel3 = new Panel();
            rbGuidType03 = new RadioButton();
            rbGuidType02 = new RadioButton();
            rbGuidType01 = new RadioButton();
            panel2 = new Panel();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            colorDialogGlines = new ColorDialog();
            dataGridSize = new DataGridView();
            colWidth = new DataGridViewTextBoxColumn();
            colHeight = new DataGridViewTextBoxColumn();
            gboxSizes = new GroupBox();
            gboxNewSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).BeginInit();
            panel1.SuspendLayout();
            gboxGuidlines.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).BeginInit();
            gboxSizes.SuspendLayout();
            SuspendLayout();
            // 
            // gboxNewSize
            // 
            gboxNewSize.Controls.Add(tbHeight);
            gboxNewSize.Controls.Add(lbTest);
            gboxNewSize.Controls.Add(tbWidth);
            gboxNewSize.Dock = DockStyle.Top;
            gboxNewSize.Location = new Point(0, 0);
            gboxNewSize.Name = "gboxNewSize";
            gboxNewSize.Size = new Size(384, 56);
            gboxNewSize.TabIndex = 0;
            gboxNewSize.TabStop = false;
            gboxNewSize.Text = "New Size";
            // 
            // tbHeight
            // 
            tbHeight.Location = new Point(72, 24);
            tbHeight.Margin = new Padding(8);
            tbHeight.MaxLength = 4;
            tbHeight.Name = "tbHeight";
            tbHeight.PlaceholderText = "Height";
            tbHeight.Size = new Size(50, 23);
            tbHeight.TabIndex = 2;
            toolTipTool.SetToolTip(tbHeight, "Set screenshot height");
            tbHeight.WordWrap = false;
            tbHeight.TextChanged += tbHeight_TextChanged;
            // 
            // lbTest
            // 
            lbTest.AutoSize = true;
            lbTest.Location = new Point(128, 24);
            lbTest.Name = "lbTest";
            lbTest.Size = new Size(52, 15);
            lbTest.TabIndex = 5;
            lbTest.Text = "labelTest";
            // 
            // tbWidth
            // 
            tbWidth.CharacterCasing = CharacterCasing.Lower;
            tbWidth.Location = new Point(8, 24);
            tbWidth.Margin = new Padding(8);
            tbWidth.MaxLength = 4;
            tbWidth.Name = "tbWidth";
            tbWidth.PlaceholderText = "Width";
            tbWidth.Size = new Size(50, 23);
            tbWidth.TabIndex = 1;
            toolTipTool.SetToolTip(tbWidth, "Set sreenshot width");
            tbWidth.WordWrap = false;
            tbWidth.TextChanged += tbWidth_TextChanged;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.DarkSeaGreen;
            lblInfo.Dock = DockStyle.Top;
            lblInfo.Location = new Point(3, 19);
            lblInfo.Margin = new Padding(8);
            lblInfo.Name = "lblInfo";
            lblInfo.Padding = new Padding(2);
            lblInfo.Size = new Size(88, 19);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Maximum size";
            lblInfo.Click += lblInfo_Click;
            // 
            // picboxGuidlineColorSample
            // 
            picboxGuidlineColorSample.BackColor = Color.White;
            picboxGuidlineColorSample.BorderStyle = BorderStyle.FixedSingle;
            picboxGuidlineColorSample.Location = new Point(8, 88);
            picboxGuidlineColorSample.Name = "picboxGuidlineColorSample";
            picboxGuidlineColorSample.Size = new Size(24, 24);
            picboxGuidlineColorSample.TabIndex = 4;
            picboxGuidlineColorSample.TabStop = false;
            toolTipTool.SetToolTip(picboxGuidlineColorSample, "Set guidlines color");
            picboxGuidlineColorSample.Click += picboxGuidlineColorSample_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 376);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 48);
            panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(297, 13);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // gboxGuidlines
            // 
            gboxGuidlines.Controls.Add(panel3);
            gboxGuidlines.Controls.Add(panel2);
            gboxGuidlines.Dock = DockStyle.Top;
            gboxGuidlines.Location = new Point(0, 56);
            gboxGuidlines.Name = "gboxGuidlines";
            gboxGuidlines.Size = new Size(384, 152);
            gboxGuidlines.TabIndex = 2;
            gboxGuidlines.TabStop = false;
            gboxGuidlines.Text = "Guidlines";
            // 
            // panel3
            // 
            panel3.Controls.Add(rbGuidType03);
            panel3.Controls.Add(rbGuidType02);
            panel3.Controls.Add(rbGuidType01);
            panel3.Controls.Add(picboxGuidlineColorSample);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(3, 19);
            panel3.Name = "panel3";
            panel3.Size = new Size(173, 130);
            panel3.TabIndex = 8;
            // 
            // rbGuidType03
            // 
            rbGuidType03.AutoSize = true;
            rbGuidType03.Location = new Point(8, 56);
            rbGuidType03.Name = "rbGuidType03";
            rbGuidType03.Size = new Size(67, 19);
            rbGuidType03.TabIndex = 7;
            rbGuidType03.Text = "Custom";
            rbGuidType03.UseVisualStyleBackColor = true;
            // 
            // rbGuidType02
            // 
            rbGuidType02.AutoSize = true;
            rbGuidType02.Location = new Point(8, 32);
            rbGuidType02.Name = "rbGuidType02";
            rbGuidType02.Size = new Size(43, 19);
            rbGuidType02.TabIndex = 6;
            rbGuidType02.Text = "4x4";
            rbGuidType02.UseVisualStyleBackColor = true;
            // 
            // rbGuidType01
            // 
            rbGuidType01.AutoSize = true;
            rbGuidType01.Checked = true;
            rbGuidType01.Location = new Point(8, 8);
            rbGuidType01.Name = "rbGuidType01";
            rbGuidType01.Size = new Size(43, 19);
            rbGuidType01.TabIndex = 5;
            rbGuidType01.TabStop = true;
            rbGuidType01.Text = "3x3";
            rbGuidType01.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox3);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(184, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(197, 130);
            panel2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(8, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(8, 101);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(8, 37);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(8, 69);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // dataGridSize
            // 
            dataGridSize.AllowUserToAddRows = false;
            dataGridSize.AllowUserToDeleteRows = false;
            dataGridSize.AllowUserToResizeColumns = false;
            dataGridSize.AllowUserToResizeRows = false;
            dataGridSize.BackgroundColor = SystemColors.Control;
            dataGridSize.BorderStyle = BorderStyle.None;
            dataGridSize.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSize.Columns.AddRange(new DataGridViewColumn[] { colWidth, colHeight });
            dataGridSize.Dock = DockStyle.Bottom;
            dataGridSize.Location = new Point(3, 40);
            dataGridSize.Name = "dataGridSize";
            dataGridSize.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridSize.RowTemplate.Height = 25;
            dataGridSize.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridSize.Size = new Size(378, 125);
            dataGridSize.TabIndex = 5;
            dataGridSize.CellContentClick += dataGridView1_CellContentClick;
            dataGridSize.CellValidating += dataGridSize_CellValidating;
            dataGridSize.KeyPress += dataGridSize_KeyPress;
            // 
            // colWidth
            // 
            colWidth.HeaderText = "Width, px";
            colWidth.Name = "colWidth";
            // 
            // colHeight
            // 
            colHeight.HeaderText = "Height, px";
            colHeight.Name = "colHeight";
            // 
            // gboxSizes
            // 
            gboxSizes.Controls.Add(lblInfo);
            gboxSizes.Controls.Add(dataGridSize);
            gboxSizes.Dock = DockStyle.Top;
            gboxSizes.Location = new Point(0, 208);
            gboxSizes.Name = "gboxSizes";
            gboxSizes.Size = new Size(384, 168);
            gboxSizes.TabIndex = 6;
            gboxSizes.TabStop = false;
            gboxSizes.Text = "Sizes";
            // 
            // FormTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 424);
            Controls.Add(gboxSizes);
            Controls.Add(gboxGuidlines);
            Controls.Add(panel1);
            Controls.Add(gboxNewSize);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTool";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            Activated += FormTool_Activated;
            Deactivate += FormTool_Deactivate;
            gboxNewSize.ResumeLayout(false);
            gboxNewSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).EndInit();
            panel1.ResumeLayout(false);
            gboxGuidlines.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).EndInit();
            gboxSizes.ResumeLayout(false);
            gboxSizes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gboxNewSize;
        private ToolTip toolTipTool;
        private TextBox tbWidth;
        private TextBox tbHeight;
        private Panel panel1;
        private Button btnOK;
        private Label lblInfo;
        private GroupBox gboxGuidlines;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private ColorDialog colorDialogGlines;
        private PictureBox picboxGuidlineColorSample;
        private DataGridView dataGridSize;
        private GroupBox gboxSizes;
        private Label lbTest;
        private Panel panel2;
        private Panel panel3;
        private RadioButton rbGuidType03;
        private RadioButton rbGuidType02;
        private RadioButton rbGuidType01;
        private DataGridViewTextBoxColumn colWidth;
        private DataGridViewTextBoxColumn colHeight;
    }
}