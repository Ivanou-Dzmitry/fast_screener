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
            mitTakeScreen = new ToolStripMenuItem();
            mitClear = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            mitShowGrid = new ToolStripMenuItem();
            mitShowArrows = new ToolStripMenuItem();
            mitAddNumber = new ToolStripMenuItem();
            mitSaveFile = new ToolStripMenuItem();
            mitSettings = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            mitExit = new ToolStripMenuItem();
            pnlToolbarMain = new Panel();
            lblHeader = new Label();
            btnArrowType = new Button();
            btnMinimize = new Button();
            btnClose = new Button();
            btnScreen = new Button();
            lblInfo = new Label();
            toolTipMain = new ToolTip(components);
            pnlCanvas = new Panel();
            contextMenuMain.SuspendLayout();
            pnlToolbarMain.SuspendLayout();
            pnlCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // btnMainMenu
            // 
            btnMainMenu.BackColor = Color.Transparent;
            btnMainMenu.ContextMenuStrip = contextMenuMain;
            btnMainMenu.Dock = DockStyle.Left;
            btnMainMenu.FlatAppearance.BorderSize = 0;
            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.Image = fast_screener.Properties.Resources.menu;
            btnMainMenu.Location = new Point(0, 0);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(40, 40);
            btnMainMenu.TabIndex = 0;
            toolTipMain.SetToolTip(btnMainMenu, "Main menu");
            btnMainMenu.UseVisualStyleBackColor = false;
            btnMainMenu.Click += btnMainMenu_Click;
            // 
            // contextMenuMain
            // 
            contextMenuMain.Items.AddRange(new ToolStripItem[] { mitSize01, mitSize02, mitSize03, mitSize04, toolStripSeparator2, mitTakeScreen, mitClear, toolStripSeparator3, mitShowGrid, mitShowArrows, mitAddNumber, mitSaveFile, mitSettings, toolStripSeparator1, aboutToolStripMenuItem, mitExit });
            contextMenuMain.Name = "contextMenuStrip1";
            contextMenuMain.Size = new Size(236, 308);
            contextMenuMain.Opening += contextMenuMain_Opening;
            // 
            // mitSize01
            // 
            mitSize01.Name = "mitSize01";
            mitSize01.ShortcutKeys = Keys.Alt | Keys.D1;
            mitSize01.Size = new Size(235, 22);
            mitSize01.Text = "600x377";
            mitSize01.Click += mitSize01_Click;
            // 
            // mitSize02
            // 
            mitSize02.Name = "mitSize02";
            mitSize02.ShortcutKeys = Keys.Alt | Keys.D2;
            mitSize02.Size = new Size(235, 22);
            mitSize02.Text = "600x600";
            mitSize02.Click += toolStripMenuItem3_Click;
            // 
            // mitSize03
            // 
            mitSize03.Name = "mitSize03";
            mitSize03.ShortcutKeys = Keys.Alt | Keys.D3;
            mitSize03.Size = new Size(235, 22);
            mitSize03.Text = "600x700";
            mitSize03.Click += toolStripMenuItem4_Click;
            // 
            // mitSize04
            // 
            mitSize04.Name = "mitSize04";
            mitSize04.ShortcutKeys = Keys.Alt | Keys.D4;
            mitSize04.Size = new Size(235, 22);
            mitSize04.Text = "960x600";
            mitSize04.Click += mitSize04_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(232, 6);
            // 
            // mitTakeScreen
            // 
            mitTakeScreen.Image = (Image)resources.GetObject("mitTakeScreen.Image");
            mitTakeScreen.Name = "mitTakeScreen";
            mitTakeScreen.ShortcutKeys = Keys.F4;
            mitTakeScreen.Size = new Size(235, 22);
            mitTakeScreen.Text = "Take Screenshot";
            mitTakeScreen.Click += mitTakeScreen_Click;
            // 
            // mitClear
            // 
            mitClear.Name = "mitClear";
            mitClear.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            mitClear.Size = new Size(235, 22);
            mitClear.Text = "Clear";
            mitClear.Click += mitClear_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(232, 6);
            // 
            // mitShowGrid
            // 
            mitShowGrid.Checked = true;
            mitShowGrid.CheckState = CheckState.Checked;
            mitShowGrid.Name = "mitShowGrid";
            mitShowGrid.ShortcutKeys = Keys.Control | Keys.Shift | Keys.G;
            mitShowGrid.Size = new Size(235, 22);
            mitShowGrid.Text = "Show Grid";
            mitShowGrid.Click += mitShowGrid_Click;
            // 
            // mitShowArrows
            // 
            mitShowArrows.Checked = true;
            mitShowArrows.CheckState = CheckState.Checked;
            mitShowArrows.Name = "mitShowArrows";
            mitShowArrows.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            mitShowArrows.Size = new Size(235, 22);
            mitShowArrows.Text = "Show Arrow";
            mitShowArrows.Click += mitShowArrows_Click;
            // 
            // mitAddNumber
            // 
            mitAddNumber.Name = "mitAddNumber";
            mitAddNumber.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            mitAddNumber.Size = new Size(235, 22);
            mitAddNumber.Text = "Add Numbering";
            mitAddNumber.Click += mitAddNumber_Click;
            // 
            // mitSaveFile
            // 
            mitSaveFile.Name = "mitSaveFile";
            mitSaveFile.Size = new Size(235, 22);
            mitSaveFile.Text = "Save To File";
            mitSaveFile.Click += mitSaveFile_Click;
            // 
            // mitSettings
            // 
            mitSettings.Image = fast_screener.Properties.Resources.settings;
            mitSettings.Name = "mitSettings";
            mitSettings.Size = new Size(235, 22);
            mitSettings.Text = "Settings";
            mitSettings.Click += mitSettings_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(232, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(235, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // mitExit
            // 
            mitExit.Name = "mitExit";
            mitExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mitExit.Size = new Size(235, 22);
            mitExit.Text = "Exit";
            mitExit.Click += mitExit_Click;
            // 
            // pnlToolbarMain
            // 
            pnlToolbarMain.BackColor = Color.SlateGray;
            pnlToolbarMain.Controls.Add(lblHeader);
            pnlToolbarMain.Controls.Add(btnArrowType);
            pnlToolbarMain.Controls.Add(btnMinimize);
            pnlToolbarMain.Controls.Add(btnClose);
            pnlToolbarMain.Controls.Add(btnScreen);
            pnlToolbarMain.Controls.Add(btnMainMenu);
            pnlToolbarMain.Dock = DockStyle.Top;
            pnlToolbarMain.Location = new Point(0, 0);
            pnlToolbarMain.Margin = new Padding(0);
            pnlToolbarMain.Name = "pnlToolbarMain";
            pnlToolbarMain.Size = new Size(600, 40);
            pnlToolbarMain.TabIndex = 1;
            pnlToolbarMain.MouseDown += pnlToolbarMain_MouseDown;
            pnlToolbarMain.MouseMove += pnlToolbarMain_MouseMove;
            pnlToolbarMain.MouseUp += pnlToolbarMain_MouseUp;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Left;
            lblHeader.Location = new Point(120, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(64, 40);
            lblHeader.TabIndex = 4;
            lblHeader.Text = "9999x9999";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Click += lblHeader_Click;
            // 
            // btnArrowType
            // 
            btnArrowType.BackColor = Color.Transparent;
            btnArrowType.Dock = DockStyle.Left;
            btnArrowType.FlatAppearance.BorderSize = 0;
            btnArrowType.FlatStyle = FlatStyle.Flat;
            btnArrowType.Image = fast_screener.Properties.Resources.arrow_type01;
            btnArrowType.Location = new Point(80, 0);
            btnArrowType.Name = "btnArrowType";
            btnArrowType.Size = new Size(40, 40);
            btnArrowType.TabIndex = 2;
            toolTipMain.SetToolTip(btnArrowType, "Arrow type");
            btnArrowType.UseVisualStyleBackColor = false;
            btnArrowType.Click += btnArrowType_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Image = fast_screener.Properties.Resources.minimize;
            btnMinimize.Location = new Point(520, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Firebrick;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = fast_screener.Properties.Resources.close;
            btnClose.Location = new Point(560, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnScreen
            // 
            btnScreen.BackColor = Color.Transparent;
            btnScreen.Dock = DockStyle.Left;
            btnScreen.FlatAppearance.BorderSize = 0;
            btnScreen.FlatStyle = FlatStyle.Flat;
            btnScreen.Image = fast_screener.Properties.Resources.scr;
            btnScreen.Location = new Point(40, 0);
            btnScreen.Name = "btnScreen";
            btnScreen.Size = new Size(40, 40);
            btnScreen.TabIndex = 1;
            toolTipMain.SetToolTip(btnScreen, "Take screenshot");
            btnScreen.UseVisualStyleBackColor = false;
            btnScreen.Click += btnScreen_Click;
            // 
            // lblInfo
            // 
            lblInfo.BackColor = Color.SteelBlue;
            lblInfo.Dock = DockStyle.Bottom;
            lblInfo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.ForeColor = Color.White;
            lblInfo.Location = new Point(0, 262);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(598, 33);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Screenshot copied to clipboard";
            lblInfo.TextAlign = ContentAlignment.MiddleLeft;
            lblInfo.Visible = false;
            // 
            // pnlCanvas
            // 
            pnlCanvas.BorderStyle = BorderStyle.FixedSingle;
            pnlCanvas.Controls.Add(lblInfo);
            pnlCanvas.Dock = DockStyle.Fill;
            pnlCanvas.Location = new Point(0, 40);
            pnlCanvas.Name = "pnlCanvas";
            pnlCanvas.Size = new Size(600, 297);
            pnlCanvas.TabIndex = 6;
            pnlCanvas.Paint += pnlCanvas_Paint;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(600, 337);
            Controls.Add(pnlCanvas);
            Controls.Add(pnlToolbarMain);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(90, 50);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Deactivate += FormMain_Deactivate;
            Shown += FormMain_Shown;
            Move += FormMain_Move;
            contextMenuMain.ResumeLayout(false);
            pnlToolbarMain.ResumeLayout(false);
            pnlCanvas.ResumeLayout(false);
            ResumeLayout(false);
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
        private ToolStripMenuItem mitShowGrid;
        private ToolStripMenuItem mitShowArrows;
        private ToolStripMenuItem mitExit;
        private ToolStripMenuItem mitSaveFile;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem mitAddNumber;
        private Button btnClose;
        private Button btnMinimize;
        private Label lblHeader;
        private Panel pnlCanvas;
        private ToolStripMenuItem mitClear;
        private Button btnArrowType;
    }
}