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
            rbArrowType04 = new RadioButton();
            rbArrowType03 = new RadioButton();
            rbArrowType02 = new RadioButton();
            rbArrowType01 = new RadioButton();
            cbLock = new CheckBox();
            trackBarArrowLenght = new TrackBar();
            picboxNumberColorSample = new PictureBox();
            tbNumberFontSize = new TextBox();
            lbArrowLenght = new Label();
            panel1 = new Panel();
            btnOK = new Button();
            gboxGuidlines = new GroupBox();
            label8 = new Label();
            label2 = new Label();
            lbIndent = new Label();
            label1 = new Label();
            pnlGMargin = new Panel();
            tbGridlineTop = new TextBox();
            tbGridlineBottom = new TextBox();
            tbGridlineLeft = new TextBox();
            tbGridlineRight = new TextBox();
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            grboxNumbers = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxArrowColorSample).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarArrowLenght).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxNumberColorSample).BeginInit();
            panel1.SuspendLayout();
            gboxGuidlines.SuspendLayout();
            pnlGMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSize).BeginInit();
            gboxSizes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gboxArrows.SuspendLayout();
            grboxNumbers.SuspendLayout();
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
            picboxGuidlineColorSample.Location = new Point(136, 136);
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
            picboxArrowColorSample.Location = new Point(136, 104);
            picboxArrowColorSample.Name = "picboxArrowColorSample";
            picboxArrowColorSample.Size = new Size(32, 32);
            picboxArrowColorSample.TabIndex = 8;
            picboxArrowColorSample.TabStop = false;
            toolTipTool.SetToolTip(picboxArrowColorSample, "Set arrow color");
            picboxArrowColorSample.Click += picboxArrowColorSample_Click;
            // 
            // rbArrowType04
            // 
            rbArrowType04.Image = fast_screener.Properties.Resources.arrow_type04;
            rbArrowType04.Location = new Point(280, 24);
            rbArrowType04.Name = "rbArrowType04";
            rbArrowType04.Size = new Size(40, 24);
            rbArrowType04.TabIndex = 12;
            rbArrowType04.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType04, "Arrow type 4");
            rbArrowType04.UseVisualStyleBackColor = true;
            // 
            // rbArrowType03
            // 
            rbArrowType03.Image = fast_screener.Properties.Resources.arrow_type03;
            rbArrowType03.Location = new Point(232, 24);
            rbArrowType03.Name = "rbArrowType03";
            rbArrowType03.Size = new Size(40, 24);
            rbArrowType03.TabIndex = 11;
            rbArrowType03.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType03, "Arrow type 3");
            rbArrowType03.UseVisualStyleBackColor = true;
            // 
            // rbArrowType02
            // 
            rbArrowType02.Image = fast_screener.Properties.Resources.arrow_type02;
            rbArrowType02.Location = new Point(184, 24);
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
            rbArrowType01.Image = fast_screener.Properties.Resources.arrow_type01;
            rbArrowType01.Location = new Point(136, 24);
            rbArrowType01.Name = "rbArrowType01";
            rbArrowType01.Size = new Size(40, 24);
            rbArrowType01.TabIndex = 9;
            rbArrowType01.TabStop = true;
            toolTipTool.SetToolTip(rbArrowType01, "Arrow type 1");
            rbArrowType01.UseVisualStyleBackColor = true;
            // 
            // cbLock
            // 
            cbLock.Appearance = Appearance.Button;
            cbLock.Image = fast_screener.Properties.Resources.unlocked;
            cbLock.Location = new Point(96, 8);
            cbLock.Name = "cbLock";
            cbLock.Size = new Size(23, 23);
            cbLock.TabIndex = 13;
            toolTipTool.SetToolTip(cbLock, "Lock values");
            cbLock.UseVisualStyleBackColor = true;
            cbLock.Click += cbLock_Click;
            // 
            // trackBarArrowLenght
            // 
            trackBarArrowLenght.LargeChange = 20;
            trackBarArrowLenght.Location = new Point(136, 56);
            trackBarArrowLenght.Maximum = 200;
            trackBarArrowLenght.Minimum = 30;
            trackBarArrowLenght.Name = "trackBarArrowLenght";
            trackBarArrowLenght.Size = new Size(144, 45);
            trackBarArrowLenght.SmallChange = 10;
            trackBarArrowLenght.TabIndex = 13;
            trackBarArrowLenght.Tag = "";
            trackBarArrowLenght.TickFrequency = 50;
            toolTipTool.SetToolTip(trackBarArrowLenght, "Arrow lenght");
            trackBarArrowLenght.Value = 50;
            trackBarArrowLenght.ValueChanged += trackBarArrowLenght_ValueChanged;
            // 
            // picboxNumberColorSample
            // 
            picboxNumberColorSample.BackColor = Color.Yellow;
            picboxNumberColorSample.BorderStyle = BorderStyle.FixedSingle;
            picboxNumberColorSample.Location = new Point(136, 56);
            picboxNumberColorSample.Name = "picboxNumberColorSample";
            picboxNumberColorSample.Size = new Size(32, 32);
            picboxNumberColorSample.TabIndex = 4;
            picboxNumberColorSample.TabStop = false;
            toolTipTool.SetToolTip(picboxNumberColorSample, "Set numbers color");
            picboxNumberColorSample.Click += picboxNumberColorSample_Click;
            // 
            // tbNumberFontSize
            // 
            tbNumberFontSize.Location = new Point(136, 24);
            tbNumberFontSize.Name = "tbNumberFontSize";
            tbNumberFontSize.Size = new Size(40, 23);
            tbNumberFontSize.TabIndex = 5;
            toolTipTool.SetToolTip(tbNumberFontSize, "Font size");
            tbNumberFontSize.TextChanged += textBox1_TextChanged;
            // 
            // lbArrowLenght
            // 
            lbArrowLenght.AutoSize = true;
            lbArrowLenght.Location = new Point(288, 56);
            lbArrowLenght.Name = "lbArrowLenght";
            lbArrowLenght.Size = new Size(31, 15);
            lbArrowLenght.TabIndex = 14;
            lbArrowLenght.Text = "9999";
            toolTipTool.SetToolTip(lbArrowLenght, "Current arrow lenght. Click to reset");
            lbArrowLenght.Click += lbArrowLenght_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 628);
            panel1.Name = "panel1";
            panel1.Size = new Size(335, 37);
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
            gboxGuidlines.Controls.Add(label8);
            gboxGuidlines.Controls.Add(label2);
            gboxGuidlines.Controls.Add(lbIndent);
            gboxGuidlines.Controls.Add(label1);
            gboxGuidlines.Controls.Add(pnlGMargin);
            gboxGuidlines.Controls.Add(rbGuidType02);
            gboxGuidlines.Controls.Add(rbGuidType03);
            gboxGuidlines.Controls.Add(rbGuidType01);
            gboxGuidlines.Controls.Add(picboxGuidlineColorSample);
            gboxGuidlines.Dock = DockStyle.Fill;
            gboxGuidlines.Location = new Point(3, 3);
            gboxGuidlines.Name = "gboxGuidlines";
            gboxGuidlines.Size = new Size(330, 178);
            gboxGuidlines.TabIndex = 2;
            gboxGuidlines.TabStop = false;
            gboxGuidlines.Text = "Grid";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 96);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(114, 15);
            label8.TabIndex = 16;
            label8.Text = "Padding Letft/ Right";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 136);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 15;
            label2.Text = "Color";
            // 
            // lbIndent
            // 
            lbIndent.AutoSize = true;
            lbIndent.Location = new Point(8, 64);
            lbIndent.Margin = new Padding(0);
            lbIndent.Name = "lbIndent";
            lbIndent.Size = new Size(121, 15);
            lbIndent.TabIndex = 14;
            lbIndent.Text = "Padding Top/ Bottom";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 24);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 9;
            label1.Text = "Type";
            // 
            // pnlGMargin
            // 
            pnlGMargin.Controls.Add(cbLock);
            pnlGMargin.Controls.Add(tbGridlineTop);
            pnlGMargin.Controls.Add(tbGridlineBottom);
            pnlGMargin.Controls.Add(tbGridlineLeft);
            pnlGMargin.Controls.Add(tbGridlineRight);
            pnlGMargin.Enabled = false;
            pnlGMargin.Location = new Point(136, 53);
            pnlGMargin.Margin = new Padding(0);
            pnlGMargin.Name = "pnlGMargin";
            pnlGMargin.Size = new Size(184, 75);
            pnlGMargin.TabIndex = 8;
            // 
            // tbGridlineTop
            // 
            tbGridlineTop.Location = new Point(0, 8);
            tbGridlineTop.Name = "tbGridlineTop";
            tbGridlineTop.PlaceholderText = "Top";
            tbGridlineTop.Size = new Size(40, 23);
            tbGridlineTop.TabIndex = 0;
            tbGridlineTop.Text = "10";
            tbGridlineTop.TextChanged += tbGridlineTop_TextChanged;
            // 
            // tbGridlineBottom
            // 
            tbGridlineBottom.Location = new Point(48, 8);
            tbGridlineBottom.Name = "tbGridlineBottom";
            tbGridlineBottom.PlaceholderText = "Bottom";
            tbGridlineBottom.Size = new Size(40, 23);
            tbGridlineBottom.TabIndex = 1;
            tbGridlineBottom.Text = "10";
            tbGridlineBottom.TextChanged += tbGridlineBottom_TextChanged;
            // 
            // tbGridlineLeft
            // 
            tbGridlineLeft.Location = new Point(0, 40);
            tbGridlineLeft.Margin = new Padding(0);
            tbGridlineLeft.Name = "tbGridlineLeft";
            tbGridlineLeft.PlaceholderText = "Left";
            tbGridlineLeft.Size = new Size(40, 23);
            tbGridlineLeft.TabIndex = 2;
            tbGridlineLeft.Text = "10";
            tbGridlineLeft.TextChanged += tbGridlineLeft_TextChanged;
            // 
            // tbGridlineRight
            // 
            tbGridlineRight.Location = new Point(48, 40);
            tbGridlineRight.Name = "tbGridlineRight";
            tbGridlineRight.PlaceholderText = "Right";
            tbGridlineRight.Size = new Size(40, 23);
            tbGridlineRight.TabIndex = 3;
            tbGridlineRight.Text = "10";
            tbGridlineRight.TextChanged += tbGridlineRight_TextChanged;
            // 
            // rbGuidType02
            // 
            rbGuidType02.AutoSize = true;
            rbGuidType02.Location = new Point(192, 24);
            rbGuidType02.Name = "rbGuidType02";
            rbGuidType02.Size = new Size(43, 19);
            rbGuidType02.TabIndex = 6;
            rbGuidType02.Text = "4x4";
            rbGuidType02.UseVisualStyleBackColor = true;
            rbGuidType02.Click += rbGuidType02_Click;
            // 
            // rbGuidType03
            // 
            rbGuidType03.AutoSize = true;
            rbGuidType03.Location = new Point(248, 24);
            rbGuidType03.Name = "rbGuidType03";
            rbGuidType03.Size = new Size(67, 19);
            rbGuidType03.TabIndex = 7;
            rbGuidType03.Text = "Custom";
            rbGuidType03.UseVisualStyleBackColor = true;
            rbGuidType03.CheckedChanged += rbGuidType03_CheckedChanged;
            rbGuidType03.Click += rbGuidType03_Click;
            // 
            // rbGuidType01
            // 
            rbGuidType01.AutoSize = true;
            rbGuidType01.Checked = true;
            rbGuidType01.Location = new Point(136, 24);
            rbGuidType01.Name = "rbGuidType01";
            rbGuidType01.Size = new Size(43, 19);
            rbGuidType01.TabIndex = 5;
            rbGuidType01.TabStop = true;
            rbGuidType01.Text = "3x3";
            rbGuidType01.UseVisualStyleBackColor = true;
            rbGuidType01.Click += rbGuidType01_Click;
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
            dataGridSize.Location = new Point(3, 47);
            dataGridSize.Name = "dataGridSize";
            dataGridSize.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridSize.RowTemplate.Height = 25;
            dataGridSize.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridSize.Size = new Size(329, 138);
            dataGridSize.TabIndex = 5;
            dataGridSize.CellValidating += dataGridSize_CellValidating;
            // 
            // colWidth
            // 
            colWidth.HeaderText = "Width, px";
            colWidth.Name = "colWidth";
            colWidth.Width = 140;
            // 
            // colHeight
            // 
            colHeight.HeaderText = "Height, px";
            colHeight.Name = "colHeight";
            colHeight.Width = 140;
            // 
            // gboxSizes
            // 
            gboxSizes.Controls.Add(lblInfo);
            gboxSizes.Controls.Add(dataGridSize);
            gboxSizes.Dock = DockStyle.Bottom;
            gboxSizes.Location = new Point(0, 440);
            gboxSizes.Name = "gboxSizes";
            gboxSizes.Size = new Size(335, 188);
            gboxSizes.TabIndex = 6;
            gboxSizes.TabStop = false;
            gboxSizes.Text = "Sizes";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(gboxGuidlines, 0, 0);
            tableLayoutPanel1.Controls.Add(gboxArrows, 0, 1);
            tableLayoutPanel1.Controls.Add(grboxNumbers, 0, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(336, 432);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // gboxArrows
            // 
            gboxArrows.Controls.Add(label5);
            gboxArrows.Controls.Add(label4);
            gboxArrows.Controls.Add(lbArrowLenght);
            gboxArrows.Controls.Add(label3);
            gboxArrows.Controls.Add(trackBarArrowLenght);
            gboxArrows.Controls.Add(rbArrowType04);
            gboxArrows.Controls.Add(rbArrowType03);
            gboxArrows.Controls.Add(rbArrowType02);
            gboxArrows.Controls.Add(rbArrowType01);
            gboxArrows.Controls.Add(picboxArrowColorSample);
            gboxArrows.Dock = DockStyle.Fill;
            gboxArrows.Location = new Point(3, 187);
            gboxArrows.Name = "gboxArrows";
            gboxArrows.Size = new Size(330, 142);
            gboxArrows.TabIndex = 3;
            gboxArrows.TabStop = false;
            gboxArrows.Text = "Arrow";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 104);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 17;
            label5.Text = "Color";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 56);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 16;
            label4.Text = "Length";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 24);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 15;
            label3.Text = "Type";
            // 
            // grboxNumbers
            // 
            grboxNumbers.Controls.Add(label7);
            grboxNumbers.Controls.Add(label6);
            grboxNumbers.Controls.Add(tbNumberFontSize);
            grboxNumbers.Controls.Add(picboxNumberColorSample);
            grboxNumbers.Dock = DockStyle.Fill;
            grboxNumbers.Location = new Point(3, 335);
            grboxNumbers.Name = "grboxNumbers";
            grboxNumbers.Size = new Size(330, 94);
            grboxNumbers.TabIndex = 4;
            grboxNumbers.TabStop = false;
            grboxNumbers.Text = "Numbers";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 56);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 18;
            label7.Text = "Color";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 24);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 17;
            label6.Text = "Font Size";
            // 
            // FormSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 665);
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
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxArrowColorSample).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarArrowLenght).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxNumberColorSample).EndInit();
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
            gboxArrows.PerformLayout();
            grboxNumbers.ResumeLayout(false);
            grboxNumbers.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTipTool;
        private Panel panel1;
        private Button btnOK;
        private Label lblInfo;
        private GroupBox gboxGuidlines;
        private TextBox tbGridlineRight;
        private TextBox tbGridlineLeft;
        private TextBox tbGridlineBottom;
        private TextBox tbGridlineTop;
        private ColorDialog colorDialogGlines;
        private PictureBox picboxGuidlineColorSample;
        private DataGridView dataGridSize;
        private GroupBox gboxSizes;
        private RadioButton rbGuidType03;
        private RadioButton rbGuidType02;
        private RadioButton rbGuidType01;
        private PictureBox picboxArrowColorSample;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gboxArrows;
        private Panel pnlGMargin;
        private RadioButton rbArrowType02;
        private RadioButton rbArrowType01;
        private RadioButton rbArrowType03;
        private RadioButton rbArrowType04;
        private CheckBox cbLock;
        private TrackBar trackBarArrowLenght;
        private Label lbArrowLenght;
        private Label lbIndent;
        private PictureBox picboxNumberColorSample;
        private GroupBox grboxNumbers;
        private TextBox tbNumberFontSize;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridViewTextBoxColumn colWidth;
        private DataGridViewTextBoxColumn colHeight;
        private Label label8;
    }
}