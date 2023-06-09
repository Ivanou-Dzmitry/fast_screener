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
            panel1 = new Panel();
            btnOK = new Button();
            gboxNewSize.SuspendLayout();
            panel1.SuspendLayout();
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
            lblInfo.Location = new Point(128, 24);
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
            toolTipTool.SetToolTip(tbHeight, "Input height. Min 100px");
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
            toolTipTool.SetToolTip(tbWidth, "Input width. Min 200px");
            tbWidth.WordWrap = false;
            tbWidth.TextChanged += tbWidth_TextChanged;
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
            // FormTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
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
            panel1.ResumeLayout(false);
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
    }
}