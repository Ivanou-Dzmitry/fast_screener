using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace screener3
{

    public partial class FormMain : Form
    {
        //Name
        public const string PROG_NAME = "F.S. ";

        public const string SUBPATH = "screenshots";

        public static int NewWidth = 0;
        public static int NewHeight = 0;

        //all monitors
        public static int VirtScreenWidth = 0;
        public static int VirtScreenHeight = 0;

        public static int clientWidth, clientHeight;

        //Min size
        public const int MIN_WIDTH = 200;
        public const int MIN_HEIGHT = 100;

        public static int arrowLenght;

        //alpha color to remove 
        private Color ALPHA_KEY_COLOR = Color.FromArgb(255, 1, 255, 1);

        //default guidlines color
        public static Color gridLinesColor = Color.LightGray;
        public static Color arrowColor = Color.Aqua;

        //for guidlines
        private bool drawGuidlines, drawArrows, saveToFile;

        public static bool indentValueLock = false;

        //1 - 3x3, 2 - 4x4, 3 - custom
        public static int GridType, ArrowType, StartResW = 0, StartResH = 0;

        static Point relativePoint;

        //screen sizes
        public static object[,] RES_DEFAULT = { { 600, 600, 600, 960 }, { 337, 600, 700, 600 } };
        public static object[,] RES_WORKED = new object[2, 4];
        public static object[] CUSTOM_GRID = new object[] { 0, 0, 0, 0 };

        public static string[] tempStringArray = new string[] { "" };


        public FormMain()
        {
            InitializeComponent();

            //set transparent
            this.BackColor = ALPHA_KEY_COLOR;
            this.TransparencyKey = ALPHA_KEY_COLOR;

            //temp value for read
            string tempValueFromConfig;

            //add resolution
            for (int i = 1; i < 5; i++)
            {

                tempValueFromConfig = ConfigurationManager.AppSettings["resolution_" + i.ToString()];
                tempStringArray = tempValueFromConfig.Split(",");

                try
                {
                    RES_WORKED[0, i - 1] = int.Parse(tempStringArray[0]);
                }
                catch
                {
                    RES_WORKED[0, i - 1] = RES_DEFAULT[0, i - 1];
                }

                try
                {
                    RES_WORKED[1, i - 1] = int.Parse(tempStringArray[1]);
                }
                catch
                {
                    RES_WORKED[1, i - 1] = RES_DEFAULT[1, i - 1];
                }

            }

            MenuItemUpdate();

            //resolution on close
            tempValueFromConfig = ConfigurationManager.AppSettings["res_on_close"];
            tempStringArray = tempValueFromConfig.Split(",");


            // Set client size
            try
            {
                StartResW = Convert.ToInt32(tempStringArray[0]);
                StartResH = Convert.ToInt32(tempStringArray[1]);
                this.ClientSize = new Size(StartResW, StartResH);
            }
            catch
            {
                this.ClientSize = new Size(Convert.ToInt32(RES_WORKED[0, 0]), Convert.ToInt32(RES_WORKED[1, 0]));

            }


            //set client size
            clientWidth = this.ClientSize.Width;
            clientHeight = this.ClientSize.Height;

            //Update form name
            this.Text = TextUpdater(PROG_NAME, clientWidth, clientHeight);

            Rectangle VirtScreenRect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

            foreach (Screen screen in Screen.AllScreens)
                VirtScreenRect = Rectangle.Union(VirtScreenRect, screen.Bounds);

            //Get virtual screen size
            VirtScreenWidth = VirtScreenRect.Width;
            VirtScreenHeight = VirtScreenRect.Height;


            tempValueFromConfig = ConfigurationManager.AppSettings["guidlines_color"];
            gridLinesColor = System.Drawing.ColorTranslator.FromHtml(tempValueFromConfig);

            tempValueFromConfig = ConfigurationManager.AppSettings["arrow_color"];
            arrowColor = System.Drawing.ColorTranslator.FromHtml(tempValueFromConfig);


            try
            {
                tempValueFromConfig = ConfigurationManager.AppSettings["guidline_type"];
                FormMain.GridType = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.GridType = 1;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["draw_guidlines"];
            drawGuidlines = Convert.ToBoolean(tempValueFromConfig);

            if (drawGuidlines == true)
            {
                mitShowGuidlines.Checked = true;
            }
            else
            {
                mitShowGuidlines.Checked = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["draw_arrows"];
            drawArrows = Convert.ToBoolean(tempValueFromConfig);

            if (drawArrows == true)
            {
                mitShowArrows.Checked = true;
            }
            else
            {
                mitShowArrows.Checked = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["arrows_type"];
            try
            {
                ArrowType = int.Parse(tempValueFromConfig);
            }
            catch
            {

                ArrowType = 1;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["arrow_lenght"];
            try
            {
                arrowLenght = int.Parse(tempValueFromConfig);
            }
            catch
            {
                arrowLenght = 50;
            }


            //resolution on close
            tempValueFromConfig = ConfigurationManager.AppSettings["custom_grid"];
            tempStringArray = tempValueFromConfig.Split(",");

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    CUSTOM_GRID[i] = int.Parse(tempStringArray[i]);
                }
                catch
                {
                    CUSTOM_GRID[i] = 10;
                }


            }

            tempValueFromConfig = ConfigurationManager.AppSettings["ident_value_lock"];
            indentValueLock = Convert.ToBoolean(tempValueFromConfig);

            tempValueFromConfig = ConfigurationManager.AppSettings["save_to_file"];
            saveToFile = Convert.ToBoolean(tempValueFromConfig);

            if (saveToFile == true)
            {
                mitSaveFile.Checked = true;
            }

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            contextMenuMain.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void mitSize01_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Convert.ToInt32(RES_WORKED[0, 0]), Convert.ToInt32(RES_WORKED[1, 0]));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Convert.ToInt32(RES_WORKED[0, 1]), Convert.ToInt32(Convert.ToInt32(RES_WORKED[1, 1])));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Convert.ToInt32(Convert.ToInt32(RES_WORKED[0, 2])), Convert.ToInt32(RES_WORKED[1, 2]));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Convert.ToInt32(RES_WORKED[0, 3]), Convert.ToInt32(Convert.ToInt32(RES_WORKED[1, 3])));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }



        private void FormMain_Move(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void contextMenuMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private string TextUpdater(string Text, int Width, int Height)
        {
            string FinalText = "";

            FinalText = (Width.ToString() + "x" + Height.ToString());

            toolTipMain.SetToolTip(btnScreen, "Take screenshot. Size: " + Width.ToString() + "x" + Height.ToString() + "px");

            lblInfo.Text = "Size setted to " + Width.ToString() + "x" + Height.ToString() + "px";

            lblInfo.Visible = true;
            lblInfo.BackColor = Color.SteelBlue;

            //refresh screen
            this.Refresh();

            return FinalText;
        }

        private void CaptureMyScreen()
        {

            //this.Hide();
            pnlToolbarMain.Visible = false;
            lblInfo.Visible = false;

            bool gridIsOn = false;

            if (mitShowGuidlines.Checked == true)
            {
                gridIsOn = true;
                // mitShowGuidlines.PerformClick();
                DrawGrid(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle), ALPHA_KEY_COLOR);
                lblInfo.Visible = false;
            }

            //Creating a new Bitmap object
            Bitmap captureBitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height, PixelFormat.Format32bppArgb);

            //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
            //Creating a Rectangle object which will
            //capture our Current Screen
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;


            //Creating a New Graphics Object
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);

            //Get window elements
            int captionH = SystemInformation.CaptionHeight;
            int frameSH = SystemInformation.FrameBorderSize.Height;
            int frameSW = SystemInformation.FrameBorderSize.Width;

            //Posytion of screenshot
            int posY = captionH + this.Location.Y + frameSH * 2;
            int posX = this.Location.X + frameSW * 2;

            //Copying Image from The Screen
            captureGraphics.CopyFromScreen(posX, posY, 0, 0, captureRectangle.Size);

            string URLString = "";

            //Saving the Image File (I am here Saving it in My E drive).
            if (saveToFile == true)
            {
                string appExeDir = Directory.GetCurrentDirectory();

                //check directory for files
                bool exists = Directory.Exists(appExeDir + "\\" + SUBPATH);

                // create if not exists
                if (!exists)
                    Directory.CreateDirectory(appExeDir + "\\" + SUBPATH);

                //datatime for random_name
                string currentTime = DateTime.Now.ToString("yyyyMMddHHmmss");

                //full filename
                string fileName = currentTime + "_screenshot.png";

                //full path to file
                URLString = appExeDir + "\\" + SUBPATH + "\\" + fileName;

                try
                {
                    captureBitmap.Save(URLString, ImageFormat.Png);
                }
                catch
                {
                    MessageBox.Show("Can't save screenshot to file! Path: " + URLString, "FastScreener Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            Clipboard.SetImage(captureBitmap);

            //this.Show();
            pnlToolbarMain.Visible = true;


            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);

            //turn on grid again
            if (gridIsOn == true)
            {
                DrawGrid(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle), gridLinesColor);
                // mitShowGuidlines.PerformClick();
            }

            lblInfo.Text = "Screenshot copied to clipboard";

            if (saveToFile == true)
            {
                lblInfo.Text = lblInfo.Text + " and saved to file: " + Environment.NewLine + URLString;
            }



        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            
            lblInfo.Visible = false;

            this.Refresh();

            if (drawArrows == true)
            {
               
                relativePoint = this.PointToClient(Cursor.Position);

                DrawArrow(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle), relativePoint, arrowColor);
            }

        }


        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if ((drawGuidlines == true) && (mitShowGuidlines.CheckState == CheckState.Checked))
            {
                DrawGrid(e, gridLinesColor);
            }

        }

        //draw grid
        private void DrawGrid(PaintEventArgs e, Color lineColor)
        {

            int initialPointVertical, initialPointHorizontal;

            if (GridType == 1)
            {
                initialPointVertical = this.ClientSize.Width / 3;
                initialPointHorizontal = this.ClientSize.Height / 3;

                Pen pen = new Pen(lineColor);

                //vertical
                e.Graphics.DrawLine(pen, initialPointVertical, 0, initialPointVertical, this.ClientSize.Height);
                e.Graphics.DrawLine(pen, initialPointVertical * 2, 0, initialPointVertical * 2, this.ClientSize.Height);

                //horizontal
                e.Graphics.DrawLine(pen, 0, initialPointHorizontal, this.ClientSize.Width, initialPointHorizontal);
                e.Graphics.DrawLine(pen, 0, initialPointHorizontal * 2, this.ClientSize.Width, initialPointHorizontal * 2);
            }

            if (GridType == 2)
            {

                initialPointVertical = this.ClientSize.Width / 4;
                initialPointHorizontal = this.ClientSize.Height / 4;

                Pen pen = new Pen(lineColor);

                //vertical
                e.Graphics.DrawLine(pen, initialPointVertical, 0, initialPointVertical, this.ClientSize.Height);
                e.Graphics.DrawLine(pen, initialPointVertical * 2, 0, initialPointVertical * 2, this.ClientSize.Height);
                e.Graphics.DrawLine(pen, initialPointVertical * 3, 0, initialPointVertical * 3, this.ClientSize.Height);

                //horizontal
                e.Graphics.DrawLine(pen, 0, initialPointHorizontal, this.ClientSize.Width, initialPointHorizontal);
                e.Graphics.DrawLine(pen, 0, initialPointHorizontal * 2, this.ClientSize.Width, initialPointHorizontal * 2);
                e.Graphics.DrawLine(pen, 0, initialPointHorizontal * 3, this.ClientSize.Width, initialPointHorizontal * 3);

            }

            if (GridType == 3)
            {

                int topIndent = Convert.ToInt32(CUSTOM_GRID[0]);
                int bottonIndent = Convert.ToInt32(CUSTOM_GRID[1]);

                int leftIndent = Convert.ToInt32(CUSTOM_GRID[2]);
                int rightIndent = Convert.ToInt32(CUSTOM_GRID[3]);

                Pen pen = new Pen(lineColor);

                //top
                e.Graphics.DrawLine(pen, 0, topIndent, this.ClientSize.Width, topIndent);

                //bottom
                e.Graphics.DrawLine(pen, 0, this.ClientSize.Height - bottonIndent, this.ClientSize.Width, this.ClientSize.Height - bottonIndent);

                //left
                e.Graphics.DrawLine(pen, leftIndent, 0, leftIndent, this.ClientSize.Height);

                //right
                e.Graphics.DrawLine(pen, this.ClientSize.Width - rightIndent, 0, this.ClientSize.Width - rightIndent, this.ClientSize.Height);

            }


        }

        //draw arrow
        public static void DrawArrow(PaintEventArgs e, Point relativePoint, Color color)
        {
            //DrawGrid(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle), gridLinesColor);

            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(relativePoint.X, relativePoint.Y);

            switch (ArrowType)
            {
                case 1:
                    startPoint = new Point(relativePoint.X - arrowLenght, relativePoint.Y + arrowLenght);

                    break;

                case 2:
                    startPoint = new Point(relativePoint.X + arrowLenght, relativePoint.Y + arrowLenght);

                    break;

                case 3:
                    startPoint = new Point(relativePoint.X - arrowLenght, relativePoint.Y - arrowLenght);

                    break;
                case 4:
                    startPoint = new Point(relativePoint.X + arrowLenght, relativePoint.Y - arrowLenght);

                    break;
            }


            var arrowPen = new Pen(color, 1);

            int ArrowSize = 8;

            arrowPen.CustomEndCap = new AdjustableArrowCap(ArrowSize, ArrowSize);

            
            e.Graphics.DrawLine(arrowPen, startPoint, endPoint);

        }


        private void drawGridStatus()
        {

            lblInfo.Visible = true;

            if (mitShowGuidlines.CheckState == CheckState.Checked)
            {
                mitShowGuidlines.CheckState = CheckState.Unchecked;
                drawGuidlines = false;
                lblInfo.Text = "Guidlines turned OFF";
            }
            else
            {
                mitShowGuidlines.CheckState = CheckState.Checked;
                drawGuidlines = true;
                lblInfo.Text = "Guidlines turned ON";
            }

        }

        private void drawArrowStatus()
        {
            lblInfo.Visible = true;

            if (mitShowArrows.CheckState == CheckState.Checked)
            {
                mitShowArrows.CheckState = CheckState.Unchecked;
                drawArrows = false;
                lblInfo.Text = "Arrows turned OFF";
            }
            else
            {
                mitShowArrows.CheckState = CheckState.Checked;
                drawArrows = true;
                lblInfo.Text = "Arrows turned ON";
            }
        }

        private void saveToFileStatus()
        {
            lblInfo.Visible = true;

            if (mitSaveFile.CheckState == CheckState.Checked)
            {
                mitSaveFile.CheckState = CheckState.Unchecked;
                saveToFile = false;
                lblInfo.Text = "Save to file turned OFF";
            }
            else
            {
                mitSaveFile.CheckState = CheckState.Checked;
                saveToFile = true;
                lblInfo.Text = "Save to file turned ON";
            }
        }

        private void mitShowGuidlines_Click(object sender, EventArgs e)
        {
            drawGridStatus();
            this.Refresh();

        }


        private void mitShowArrows_Click(object sender, EventArgs e)
        {
            drawArrowStatus();
            this.Refresh();
        }


        private void mitTakeScreen_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

 


        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);

        }

        private void mitExit_Click(object sender, EventArgs e)
        {

            SaveConfig();
            Close();
        }

        private void SaveConfig()
        {
            SetSetting("guidlines_color", ColorTranslator.ToHtml(gridLinesColor));
            SetSetting("arrow_color", ColorTranslator.ToHtml(arrowColor));

            SetSetting("guidline_type", GridType.ToString());
            SetSetting("arrows_type", ArrowType.ToString());
            SetSetting("arrow_lenght", arrowLenght.ToString());

            SetSetting("draw_guidlines", drawGuidlines.ToString().ToLower());
            SetSetting("draw_arrows", drawArrows.ToString().ToLower());
            SetSetting("save_to_file", saveToFile.ToString().ToLower());


            for (int i = 1; i < 5; i++)
            {
                SetSetting("resolution_" + i.ToString(), RES_WORKED[0, i - 1] + "," + RES_WORKED[1, i - 1]);
            }

            SetSetting("res_on_close", this.ClientSize.Width.ToString() + "," + this.ClientSize.Height.ToString());

            SetSetting("custom_grid", CUSTOM_GRID[0].ToString() + "," + CUSTOM_GRID[1].ToString() + "," + CUSTOM_GRID[2].ToString() + "," + CUSTOM_GRID[3].ToString());

            SetSetting("ident_value_lock", indentValueLock.ToString().ToLower());


        }

        private void mitSettings_Click(object sender, EventArgs e)
        {

            clientWidth = this.ClientSize.Width;
            clientHeight = this.ClientSize.Height;

            // Create a new instance of the Form2 class
            FormSet toolForm = new FormSet();

            // Show the settings form
            toolForm.ShowDialog();

            MenuItemUpdate();

            SaveConfig();

            this.Refresh();
        }

        private void MenuItemUpdate()
        {
            mitSize01.Text = RES_WORKED[0, 0].ToString() + "x" + RES_WORKED[1, 0].ToString();
            mitSize02.Text = RES_WORKED[0, 1].ToString() + "x" + RES_WORKED[1, 1].ToString();
            mitSize03.Text = RES_WORKED[0, 2].ToString() + "x" + RES_WORKED[1, 2].ToString();
            mitSize04.Text = RES_WORKED[0, 3].ToString() + "x" + RES_WORKED[1, 3].ToString();
        }


        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D1)
            {
                ArrowType = 1;
            }

            if (e.Control && e.KeyCode == Keys.D2)
            {
                ArrowType = 2;
            }


            if (e.Control && e.KeyCode == Keys.D3)
            {
                ArrowType = 3;
            }


            if (e.Control && e.KeyCode == Keys.D4)
            {
                ArrowType = 4;
            }


        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.TopLevel = true;
            this.TopMost = true;
            this.Focus();
            this.TopMost = true;
        }

        private void mitSaveFile_Click(object sender, EventArgs e)
        {
            saveToFileStatus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutText = "Author: Dzmitry Ivanou" + "\n" + "e-mail: frosofco@gmail.com" + "\n" + "https://github.com/Ivanou-Dzmitry/fast_screener";
            MessageBox.Show(aboutText, "About FastScreener 0.1");
        }
    }

}