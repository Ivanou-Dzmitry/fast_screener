namespace screener3
{
    partial class FormSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSet));
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
            pnlGMargin = new Panel();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            colorDialogGlines = new ColorDialog();
            dataGridSize = new DataGridView();
            colWidth = new DataGridViewTextBoxColumn();
            colHeight = new DataGridViewTextBoxColumn();
            gboxSizes = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).BeginInit();
            panel1.SuspendLayout();
            gboxGuidlines.SuspendLayout();
            panel3.SuspendLayout();
            pnlGMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).BeginInit();
            gboxSizes.SuspendLayout();
            SuspendLayout();
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
            panel1.Location = new Point(0, 321);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 40);
            panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(248, 8);
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
            gboxGuidlines.Controls.Add(pnlGMargin);
            gboxGuidlines.Dock = DockStyle.Top;
            gboxGuidlines.Location = new Point(0, 0);
            gboxGuidlines.Name = "gboxGuidlines";
            gboxGuidlines.Size = new Size(334, 152);
            gboxGuidlines.TabIndex = 2;
            gboxGuidlines.TabStop = false;
            gboxGuidlines.Text = "Guidlines";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(rbGuidType03);
            panel3.Controls.Add(rbGuidType02);
            panel3.Controls.Add(rbGuidType01);
            panel3.Controls.Add(picboxGuidlineColorSample);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(114, 19);
            panel3.Name = "panel3";
            panel3.Size = new Size(78, 130);
            panel3.TabIndex = 1;
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
            rbGuidType03.CheckedChanged += rbGuidType03_CheckedChanged;
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
            rbGuidType02.Click += rbGuidType02_Click;
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
            rbGuidType01.CheckedChanged += rbGuidType01_CheckedChanged;
            rbGuidType01.Click += rbGuidType01_Click;
            // 
            // pnlGMargin
            // 
            pnlGMargin.AutoSize = true;
            pnlGMargin.Controls.Add(textBox1);
            pnlGMargin.Controls.Add(textBox4);
            pnlGMargin.Controls.Add(textBox2);
            pnlGMargin.Controls.Add(textBox3);
            pnlGMargin.Dock = DockStyle.Left;
            pnlGMargin.Enabled = false;
            pnlGMargin.Location = new Point(3, 19);
            pnlGMargin.Name = "pnlGMargin";
            pnlGMargin.Size = new Size(111, 130);
            pnlGMargin.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 5);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Top";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "10";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(8, 101);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Right";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            textBox4.Text = "10";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 37);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Bottom";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            textBox2.Text = "10";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(8, 69);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Left";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "10";
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
            dataGridSize.Size = new Size(328, 125);
            dataGridSize.TabIndex = 5;
            dataGridSize.CellContentClick += dataGridSize_CellContentClick;
            dataGridSize.CellValidating += dataGridSize_CellValidating;
            // 
            // colWidth
            // 
            colWidth.HeaderText = "Width, px";
            colWidth.Name = "colWidth";
            colWidth.Width = 125;
            // 
            // colHeight
            // 
            colHeight.HeaderText = "Height, px";
            colHeight.Name = "colHeight";
            colHeight.Width = 125;
            // 
            // gboxSizes
            // 
            gboxSizes.Controls.Add(lblInfo);
            gboxSizes.Controls.Add(dataGridSize);
            gboxSizes.Dock = DockStyle.Top;
            gboxSizes.Location = new Point(0, 152);
            gboxSizes.Name = "gboxSizes";
            gboxSizes.Size = new Size(334, 168);
            gboxSizes.TabIndex = 6;
            gboxSizes.TabStop = false;
            gboxSizes.Text = "Sizes";
            // 
            // FormSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 361);
            Controls.Add(gboxSizes);
            Controls.Add(gboxGuidlines);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            Activated += FormTool_Activated;
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).EndInit();
            panel1.ResumeLayout(false);
            gboxGuidlines.ResumeLayout(false);
            gboxGuidlines.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlGMargin.ResumeLayout(false);
            pnlGMargin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).EndInit();
            gboxSizes.ResumeLayout(false);
            gboxSizes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTipTool;
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
        private Panel pnlGMargin;
        private Panel panel3;
        private RadioButton rbGuidType03;
        private RadioButton rbGuidType02;
        private RadioButton rbGuidType01;
        private DataGridViewTextBoxColumn colWidth;
        private DataGridViewTextBoxColumn colHeight;
    }
}