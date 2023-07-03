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
            mitSize01 = new ToolStripMenuItem();
            mitSize02 = new ToolStripMenuItem();
            mitSize03 = new ToolStripMenuItem();
            mitSize04 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mitShowGuidlines = new ToolStripMenuItem();
            mitShowArrows = new ToolStripMenuItem();
            mitSettings = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mitTakeScreen = new ToolStripMenuItem();
            mitExit = new ToolStripMenuItem();
            pnlToolbarMain = new Panel();
            btnScreen = new Button();
            lblInfo = new Label();
            toolTipMain = new ToolTip(components);
            contextMenuMain.SuspendLayout();
            pnlToolbarMain.SuspendLayout();
            SuspendLayout();
            // 
            // btnMainMenu
            // 
            btnMainMenu.ContextMenuStrip = contextMenuMain;
            btnMainMenu.Image = fast_screener.Properties.Resources.menu;
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
            contextMenuMain.Items.AddRange(new ToolStripItem[] { mitSize01, mitSize02, mitSize03, mitSize04, toolStripSeparator2, mitShowGuidlines, mitShowArrows, mitSettings, toolStripSeparator1, mitTakeScreen, mitExit });
            contextMenuMain.Name = "contextMenuStrip1";
            contextMenuMain.Size = new Size(231, 214);
            contextMenuMain.Opening += contextMenuMain_Opening;
            // 
            // mitSize01
            // 
            mitSize01.Name = "mitSize01";
            mitSize01.ShortcutKeys = Keys.Alt | Keys.D1;
            mitSize01.Size = new Size(230, 22);
            mitSize01.Text = "600x377";
            mitSize01.Click += mitSize01_Click;
            // 
            // mitSize02
            // 
            mitSize02.Name = "mitSize02";
            mitSize02.ShortcutKeys = Keys.Alt | Keys.D2;
            mitSize02.Size = new Size(230, 22);
            mitSize02.Text = "600x600";
            mitSize02.Click += toolStripMenuItem3_Click;
            // 
            // mitSize03
            // 
            mitSize03.Name = "mitSize03";
            mitSize03.ShortcutKeys = Keys.Alt | Keys.D3;
            mitSize03.Size = new Size(230, 22);
            mitSize03.Text = "600x700";
            mitSize03.Click += toolStripMenuItem4_Click;
            // 
            // mitSize04
            // 
            mitSize04.Name = "mitSize04";
            mitSize04.ShortcutKeys = Keys.Alt | Keys.D4;
            mitSize04.Size = new Size(230, 22);
            mitSize04.Text = "960x600";
            mitSize04.Click += toolStripMenuItem1_Click;
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
            mitShowGuidlines.ShortcutKeys = Keys.Control | Keys.Alt | Keys.G;
            mitShowGuidlines.Size = new Size(230, 22);
            mitShowGuidlines.Text = "Show Guidlines";
            mitShowGuidlines.Click += mitShowGuidlines_Click;
            // 
            // mitShowArrows
            // 
            mitShowArrows.Checked = true;
            mitShowArrows.CheckState = CheckState.Checked;
            mitShowArrows.Name = "mitShowArrows";
            mitShowArrows.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
            mitShowArrows.Size = new Size(230, 22);
            mitShowArrows.Text = "Show Arrows";
            mitShowArrows.Click += mitShowArrows_Click;
            // 
            // mitSettings
            // 
            mitSettings.Name = "mitSettings";
            mitSettings.Size = new Size(230, 22);
            mitSettings.Text = "Settings";
            mitSettings.Click += mitSettings_Click;
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
            mitTakeScreen.Click += mitTakeScreen_Click;
            // 
            // mitExit
            // 
            mitExit.Name = "mitExit";
            mitExit.Size = new Size(230, 22);
            mitExit.Text = "Exit";
            mitExit.Click += mitExit_Click;
            // 
            // pnlToolbarMain
            // 
            pnlToolbarMain.AutoSize = true;
            pnlToolbarMain.BackColor = Color.Transparent;
            pnlToolbarMain.Controls.Add(btnScreen);
            pnlToolbarMain.Controls.Add(btnMainMenu);
            pnlToolbarMain.Location = new Point(0, 0);
            pnlToolbarMain.Name = "pnlToolbarMain";
            pnlToolbarMain.Size = new Size(80, 39);
            pnlToolbarMain.TabIndex = 1;
            // 
            // btnScreen
            // 
            btnScreen.Image = fast_screener.Properties.Resources.scr;
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
            Controls.Add(pnlToolbarMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(90, 50);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Deactivate += FormMain_Deactivate;
            Shown += FormMain_Shown;
            Paint += FormMain_Paint;
            KeyDown += FormMain_KeyDown;
            Move += FormMain_Move;
            contextMenuMain.ResumeLayout(false);
            pnlToolbarMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMainMenu;
        private Panel pnlToolbarMain;
        private Button btnScreen;
        private ContextMenuStrip contextMenuMain;
        private ToolStripMenuItem mitSize01;
        private ToolStripMenuItem mitSize02;
        private ToolStripMenuItem mitSize03;
        private ToolStripMenuItem mitSize04;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mitTakeScreen;
        private Label lblInfo;
        private ToolTip toolTipMain;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mitSettings;
        private ToolStripMenuItem mitShowGuidlines;
        private ToolStripMenuItem mitShowArrows;
        private ToolStripMenuItem mitExit;
    }
}