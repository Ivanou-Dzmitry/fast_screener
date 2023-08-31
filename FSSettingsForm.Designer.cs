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
            toolTipTool = new ToolTip(components);
            panel1 = new Panel();
            btnOK = new Button();
            colorDialogGlines = new ColorDialog();
            pgSettings = new PropertyGrid();
            lboxSetCat = new ListBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 373);
            panel1.Name = "panel1";
            panel1.Size = new Size(534, 38);
            panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(452, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // pgSettings
            // 
            pgSettings.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            pgSettings.Location = new Point(88, 8);
            pgSettings.Name = "pgSettings";
            pgSettings.Size = new Size(440, 361);
            pgSettings.TabIndex = 6;
            pgSettings.PropertyValueChanged += pgSettings_PropertyValueChanged;
            // 
            // lboxSetCat
            // 
            lboxSetCat.BackColor = SystemColors.Control;
            lboxSetCat.BorderStyle = BorderStyle.None;
            lboxSetCat.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lboxSetCat.FormattingEnabled = true;
            lboxSetCat.ItemHeight = 17;
            lboxSetCat.Items.AddRange(new object[] { "Arrow", "Grid", "Numbers", "Sizes" });
            lboxSetCat.Location = new Point(4, 35);
            lboxSetCat.Name = "lboxSetCat";
            lboxSetCat.Size = new Size(80, 323);
            lboxSetCat.TabIndex = 8;
            lboxSetCat.Click += lboxSetCat_Click;
            // 
            // FormSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 411);
            Controls.Add(lboxSetCat);
            Controls.Add(panel1);
            Controls.Add(pgSettings);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTipTool;
        private Panel panel1;
        private Button btnOK;
        private ColorDialog colorDialogGlines;
        private PropertyGrid pgSettings;
        private ListBox lboxSetCat;
    }
}