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
            picboxArrowColorSample = new PictureBox();
            panel1 = new Panel();
            btnOK = new Button();
            gboxGuidlines = new GroupBox();
            pnlGMargin = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            rbGuidType02 = new RadioButton();
            rbGuidType03 = new RadioButton();
            rbGuidType01 = new RadioButton();
            colorDialogGlines = new ColorDialog();
            dataGridSize = new DataGridView();
            colWidth = new DataGridViewTextBoxColumn();
            colHeight = new DataGridViewTextBoxColumn();
            gboxSizes = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            gboxArrows = new GroupBox();
            rbArrowType04 = new RadioButton();
            rbArrowType03 = new RadioButton();
            rbArrowType02 = new RadioButton();
            rbArrowType01 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxArrowColorSample).BeginInit();
            panel1.SuspendLayout();
            gboxGuidlines.SuspendLayout();
            pnlGMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).BeginInit();
            gboxSizes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gboxArrows.SuspendLayout();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
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
            picboxGuidlineColorSample.Location = new Point(8, 112);
            picboxGuidlineColorSample.Name = "picboxGuidlineColorSample";
            picboxGuidlineColorSample.Size = new Size(32, 32);
            picboxGuidlineColorSample.TabIndex = 4;
            picboxGuidlineColorSample.TabStop = false;
            toolTipTool.SetToolTip(picboxGuidlineColorSample, "Set guidlines color");
            picboxGuidlineColorSample.Click += picboxGuidlineColorSample_Click;
            // 
            // picboxArrowColorSample
            // 
            picboxArrowColorSample.BackColor = Color.Cyan;
            picboxArrowColorSample.BorderStyle = BorderStyle.FixedSingle;
            picboxArrowColorSample.Location = new Point(8, 112);
            picboxArrowColorSample.Name = "picboxArrowColorSample";
            picboxArrowColorSample.Size = new Size(32, 32);
            picboxArrowColorSample.TabIndex = 8;
            picboxArrowColorSample.TabStop = false;
            toolTipTool.SetToolTip(picboxArrowColorSample, "Set arrow color");
            picboxArrowColorSample.Click += picboxArrowColorSample_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 338);
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
            gboxGuidlines.Controls.Add(pnlGMargin);
            gboxGuidlines.Controls.Add(rbGuidType02);
            gboxGuidlines.Controls.Add(rbGuidType03);
            gboxGuidlines.Controls.Add(picboxGuidlineColorSample);
            gboxGuidlines.Controls.Add(rbGuidType01);
            gboxGuidlines.Dock = DockStyle.Fill;
            gboxGuidlines.Location = new Point(3, 3);
            gboxGuidlines.Name = "gboxGuidlines";
            gboxGuidlines.Size = new Size(167, 154);
            gboxGuidlines.TabIndex = 2;
            gboxGuidlines.TabStop = false;
            gboxGuidlines.Text = "Guidlines";
            // 
            // pnlGMargin
            // 
            pnlGMargin.Controls.Add(textBox1);
            pnlGMargin.Controls.Add(textBox2);
            pnlGMargin.Controls.Add(textBox3);
            pnlGMargin.Controls.Add(textBox4);
            pnlGMargin.Dock = DockStyle.Right;
            pnlGMargin.Enabled = false;
            pnlGMargin.Location = new Point(80, 19);
            pnlGMargin.Name = "pnlGMargin";
            pnlGMargin.Size = new Size(84, 132);
            pnlGMargin.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 8);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Top";
            textBox1.Size = new Size(72, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "10";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 40);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Bottom";
            textBox2.Size = new Size(72, 23);
            textBox2.TabIndex = 1;
            textBox2.Text = "10";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(8, 72);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Left";
            textBox3.Size = new Size(72, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "10";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(8, 104);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Right";
            textBox4.Size = new Size(72, 23);
            textBox4.TabIndex = 3;
            textBox4.Text = "10";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // rbGuidType02
            // 
            rbGuidType02.AutoSize = true;
            rbGuidType02.Location = new Point(8, 48);
            rbGuidType02.Name = "rbGuidType02";
            rbGuidType02.Size = new Size(43, 19);
            rbGuidType02.TabIndex = 6;
            rbGuidType02.Text = "4x4";
            rbGuidType02.UseVisualStyleBackColor = true;
            // 
            // rbGuidType03
            // 
            rbGuidType03.AutoSize = true;
            rbGuidType03.Location = new Point(8, 72);
            rbGuidType03.Name = "rbGuidType03";
            rbGuidType03.Size = new Size(67, 19);
            rbGuidType03.TabIndex = 7;
            rbGuidType03.Text = "Custom";
            rbGuidType03.UseVisualStyleBackColor = true;
            rbGuidType03.CheckedChanged += rbGuidType03_CheckedChanged;
            // 
            // rbGuidType01
            // 
            rbGuidType01.AutoSize = true;
            rbGuidType01.Checked = true;
            rbGuidType01.Location = new Point(8, 24);
            rbGuidType01.Name = "rbGuidType01";
            rbGuidType01.Size = new Size(43, 19);
            rbGuidType01.TabIndex = 5;
            rbGuidType01.TabStop = true;
            rbGuidType01.Text = "3x3";
            rbGuidType01.UseVisualStyleBackColor = true;
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
            dataGridSize.Size = new Size(328, 127);
            dataGridSize.TabIndex = 5;
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
            gboxSizes.Dock = DockStyle.Bottom;
            gboxSizes.Location = new Point(0, 168);
            gboxSizes.Name = "gboxSizes";
            gboxSizes.Size = new Size(334, 170);
            gboxSizes.TabIndex = 6;
            gboxSizes.TabStop = false;
            gboxSizes.Text = "Sizes";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.7964058F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.2035942F));
            tableLayoutPanel1.Controls.Add(gboxGuidlines, 0, 0);
            tableLayoutPanel1.Controls.Add(gboxArrows, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(334, 160);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // gboxArrows
            // 
            gboxArrows.Controls.Add(rbArrowType04);
            gboxArrows.Controls.Add(rbArrowType03);
            gboxArrows.Controls.Add(rbArrowType02);
            gboxArrows.Controls.Add(rbArrowType01);
            gboxArrows.Controls.Add(picboxArrowColorSample);
            gboxArrows.Dock = DockStyle.Fill;
            gboxArrows.Location = new Point(176, 3);
            gboxArrows.Name = "gboxArrows";
            gboxArrows.Size = new Size(155, 154);
            gboxArrows.TabIndex = 3;
            gboxArrows.TabStop = false;
            gboxArrows.Text = "Arrows";
            // 
            // rbArrowType04
            // 
            rbArrowType04.Image = FastScreener.Properties.Resources.arrow_type04;
            rbArrowType04.Location = new Point(56, 48);
            rbArrowType04.Name = "rbArrowType04";
            rbArrowType04.Size = new Size(40, 24);
            rbArrowType04.TabIndex = 12;
            rbArrowType04.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType04, "Arrow type 4");
            rbArrowType04.UseVisualStyleBackColor = true;
            rbArrowType04.CheckedChanged += rbArrowType04_CheckedChanged;
            // 
            // rbArrowType03
            // 
            rbArrowType03.Image = FastScreener.Properties.Resources.arrow_type03;
            rbArrowType03.Location = new Point(56, 24);
            rbArrowType03.Name = "rbArrowType03";
            rbArrowType03.Size = new Size(40, 24);
            rbArrowType03.TabIndex = 11;
            rbArrowType03.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType03, "Arrow type 3");
            rbArrowType03.UseVisualStyleBackColor = true;
            // 
            // rbArrowType02
            // 
            rbArrowType02.Image = FastScreener.Properties.Resources.arrow_type02;
            rbArrowType02.Location = new Point(8, 48);
            rbArrowType02.Name = "rbArrowType02";
            rbArrowType02.Size = new Size(40, 24);
            rbArrowType02.TabIndex = 10;
            rbArrowType02.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType02, "Arrow type 2");
            rbArrowType02.UseVisualStyleBackColor = true;
            // 
            // rbArrowType01
            // 
            rbArrowType01.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rbArrowType01.Image = FastScreener.Properties.Resources.arrow_type01;
            rbArrowType01.Location = new Point(8, 24);
            rbArrowType01.Name = "rbArrowType01";
            rbArrowType01.Size = new Size(40, 24);
            rbArrowType01.TabIndex = 9;
            rbArrowType01.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType01, "Arrow type 1");
            rbArrowType01.UseVisualStyleBackColor = true;
            // 
            // FormSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 378);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(gboxSizes);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            Activated += FormTool_Activated;
            Load += FormSet_Load;
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxArrowColorSample).EndInit();
            panel1.ResumeLayout(false);
            gboxGuidlines.ResumeLayout(false);
            gboxGuidlines.PerformLayout();
            pnlGMargin.ResumeLayout(false);
            pnlGMargin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).EndInit();
            gboxSizes.ResumeLayout(false);
            gboxSizes.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            gboxArrows.ResumeLayout(false);
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
        private RadioButton rbGuidType03;
        private RadioButton rbGuidType02;
        private RadioButton rbGuidType01;
        private DataGridViewTextBoxColumn colWidth;
        private DataGridViewTextBoxColumn colHeight;
        private PictureBox picboxArrowColorSample;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gboxArrows;
        private Panel pnlGMargin;
        private RadioButton rbArrowType02;
        private RadioButton rbArrowType01;
        private RadioButton rbArrowType03;
        private RadioButton rbArrowType04;
    }
}