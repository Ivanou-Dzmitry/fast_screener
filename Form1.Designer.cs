namespace screener3
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnMainMenu = new Button();
            contextMenuMain = new ContextMenuStrip(components);
            mit600_337 = new ToolStripMenuItem();
            mit600_600 = new ToolStripMenuItem();
            mit600_700 = new ToolStripMenuItem();
            mit960_600 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mitShowGuidlines = new ToolStripMenuItem();
            mitSettings = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mitTakeScreen = new ToolStripMenuItem();
            panel1 = new Panel();
            btnScreen = new Button();
            lblInfo = new Label();
            toolTipMain = new ToolTip(components);
            contextMenuMain.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnMainMenu
            // 
            btnMainMenu.ContextMenuStrip = contextMenuMain;
            btnMainMenu.Image = (Image)resources.GetObject("btnMainMenu.Image");
            btnMainMenu.Location = new Point(12, 12);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(24, 24);
            btnMainMenu.TabIndex = 0;
            toolTipMain.SetToolTip(btnMainMenu, "Main menu");
            btnMainMenu.UseVisualStyleBackColor = true;
            btnMainMenu.Click += btnMainMenu_Click;
            // 
            // contextMenuMain
            // 
            contextMenuMain.Items.AddRange(new ToolStripItem[] { mit600_337, mit600_600, mit600_700, mit960_600, toolStripSeparator2, mitShowGuidlines, mitSettings, toolStripSeparator1, mitTakeScreen });
            contextMenuMain.Name = "contextMenuStrip1";
            contextMenuMain.Size = new Size(231, 170);
            contextMenuMain.Opening += contextMenuMain_Opening;
            // 
            // mit600_337
            // 
            mit600_337.Name = "mit600_337";
            mit600_337.ShortcutKeys = Keys.Alt | Keys.D1;
            mit600_337.Size = new Size(230, 22);
            mit600_337.Text = "600x377";
            mit600_337.Click += toolStripMenuItem2_Click;
            // 
            // mit600_600
            // 
            mit600_600.Name = "mit600_600";
            mit600_600.ShortcutKeys = Keys.Alt | Keys.D2;
            mit600_600.Size = new Size(230, 22);
            mit600_600.Text = "600x600";
            mit600_600.Click += toolStripMenuItem3_Click;
            // 
            // mit600_700
            // 
            mit600_700.Name = "mit600_700";
            mit600_700.ShortcutKeys = Keys.Alt | Keys.D3;
            mit600_700.Size = new Size(230, 22);
            mit600_700.Text = "600x700";
            mit600_700.Click += toolStripMenuItem4_Click;
            // 
            // mit960_600
            // 
            mit960_600.Name = "mit960_600";
            mit960_600.ShortcutKeys = Keys.Alt | Keys.D4;
            mit960_600.Size = new Size(230, 22);
            mit960_600.Text = "960x600";
            mit960_600.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(227, 6);
            // 
            // mitShowGuidlines
            // 
            mitShowGuidlines.Checked = true;
            mitShowGuidlines.CheckState = CheckState.Checked;
            mitShowGuidlines.Name = "mitShowGuidlines";
            mitShowGuidlines.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
            mitShowGuidlines.Size = new Size(230, 22);
            mitShowGuidlines.Text = "Show Guidlines";
            mitShowGuidlines.Click += mitShowGuidlines_Click;
            // 
            // mitSettings
            // 
            mitSettings.Name = "mitSettings";
            mitSettings.Size = new Size(230, 22);
            mitSettings.Text = "Settings";
            mitSettings.Click += mitCustomRes_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(227, 6);
            // 
            // mitTakeScreen
            // 
            mitTakeScreen.Image = (Image)resources.GetObject("mitTakeScreen.Image");
            mitTakeScreen.Name = "mitTakeScreen";
            mitTakeScreen.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            mitTakeScreen.Size = new Size(230, 22);
            mitTakeScreen.Text = "Take Screenshot";
            mitTakeScreen.Click += toolStripMenuItem5_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(btnScreen);
            panel1.Controls.Add(btnMainMenu);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(584, 39);
            panel1.TabIndex = 1;
            // 
            // btnScreen
            // 
            btnScreen.Image = (Image)resources.GetObject("btnScreen.Image");
            btnScreen.Location = new Point(50, 12);
            btnScreen.Name = "btnScreen";
            btnScreen.Size = new Size(24, 24);
            btnScreen.TabIndex = 1;
            toolTipMain.SetToolTip(btnScreen, "Take screenshot");
            btnScreen.UseVisualStyleBackColor = true;
            btnScreen.Click += btnScreen_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.SteelBlue;
            lblInfo.Dock = DockStyle.Bottom;
            lblInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.ForeColor = Color.White;
            lblInfo.Location = new Point(0, 281);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(192, 17);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Screenshot copied to clipboard";
            lblInfo.TextAlign = ContentAlignment.BottomCenter;
            lblInfo.Visible = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(584, 298);
            Controls.Add(lblInfo);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(90, 50);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Deactivate += FormMain_Deactivate;
            Load += FormMain_Load;
            Paint += FormMain_Paint;
            Move += FormMain_Move;
            contextMenuMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMainMenu;
        private Panel panel1;
        private Button btnScreen;
        private ContextMenuStrip contextMenuMain;
        private ToolStripMenuItem mit600_337;
        private ToolStripMenuItem mit600_600;
        private ToolStripMenuItem mit600_700;
        private ToolStripMenuItem mit960_600;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mitTakeScreen;
        private Label lblInfo;
        private ToolTip toolTipMain;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mitSettings;
        private ToolStripMenuItem mitShowGuidlines;
    }
}