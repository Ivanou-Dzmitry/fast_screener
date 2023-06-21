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
            gboxNewSize = new GroupBox();
            lblInfo = new Label();
            tbHeight = new TextBox();
            tbWidth = new TextBox();
            toolTipTool = new ToolTip(components);
            picboxGuidlineColorSample = new PictureBox();
            panel1 = new Panel();
            btnOK = new Button();
            gboxGuidlines = new GroupBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            colorDialogGlines = new ColorDialog();
            gboxNewSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).BeginInit();
            panel1.SuspendLayout();
            gboxGuidlines.SuspendLayout();
            SuspendLayout();
            // 
            // gboxNewSize
            // 
            gboxNewSize.Controls.Add(lblInfo);
            gboxNewSize.Controls.Add(tbHeight);
            gboxNewSize.Controls.Add(tbWidth);
            gboxNewSize.Dock = DockStyle.Top;
            gboxNewSize.Location = new Point(0, 0);
            gboxNewSize.Name = "gboxNewSize";
            gboxNewSize.Size = new Size(384, 56);
            gboxNewSize.TabIndex = 0;
            gboxNewSize.TabStop = false;
            gboxNewSize.Text = "New Size";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(128, 28);
            lblInfo.Margin = new Padding(8);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(38, 15);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "label1";
            lblInfo.Click += lblInfo_Click;
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
            // picboxGuidlineColorSample
            // 
            picboxGuidlineColorSample.BackColor = Color.White;
            picboxGuidlineColorSample.BorderStyle = BorderStyle.FixedSingle;
            picboxGuidlineColorSample.Location = new Point(208, 64);
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
            panel1.Location = new Point(0, 213);
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
            gboxGuidlines.Controls.Add(textBox4);
            gboxGuidlines.Controls.Add(textBox3);
            gboxGuidlines.Controls.Add(textBox2);
            gboxGuidlines.Controls.Add(textBox1);
            gboxGuidlines.Enabled = false;
            gboxGuidlines.Location = new Point(0, 56);
            gboxGuidlines.Name = "gboxGuidlines";
            gboxGuidlines.Size = new Size(200, 152);
            gboxGuidlines.TabIndex = 2;
            gboxGuidlines.TabStop = false;
            gboxGuidlines.Text = "Guidlines";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(8, 120);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(8, 88);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // FormTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(picboxGuidlineColorSample);
            Controls.Add(gboxGuidlines);
            Controls.Add(panel1);
            Controls.Add(gboxNewSize);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormTool";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuration";
            TopMost = true;
            Activated += FormTool_Activated;
            Deactivate += FormTool_Deactivate;
            gboxNewSize.ResumeLayout(false);
            gboxNewSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picboxGuidlineColorSample).EndInit();
            panel1.ResumeLayout(false);
            gboxGuidlines.ResumeLayout(false);
            gboxGuidlines.PerformLayout();
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
    }
}