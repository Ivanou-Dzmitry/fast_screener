using fast_screener;
using fast_screener.Properties;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace screener3
{

    public partial class FormMain : Form
    {
        //Name
        public const string PROG_NAME = "F.S. ", SUBPATH = "screenshots";

        //all monitors
        public static int VirtScreenWidth = 0, VirtScreenHeight = 0, clientWidth, clientHeight, arrowLenght, NewWidth = 0, NewHeight = 0, numberFontSize;

        //Min size
        public const int MIN_WIDTH = 300, MIN_HEIGHT = 200;

        //alpha color to remove 
        private Color ALPHA_KEY_COLOR = Color.FromArgb(255, 1, 0, 1);

        //default guidlines color
        public static Color gridColor = Color.LightGray,
            arrowColor = Color.Aqua,
            numberColor = Color.Yellow,
            frameColor = Color.Gray;

        //for guidlines
        private bool drawGrid, drawArrows, saveToFile, drawNumber;

        public static bool indentValueLock = false;

        //1 - 3x3, 2 - 4x4, 3 - custom
        public static int GridType, ArrowType, StartResW = 0, StartResH = 0, numbering = 1, pnlToolBarH = 0, clickCount = 0;

        static Point relativePoint;

        //screen sizes
        public static object[,] RES_DEFAULT = { { 600, 600, 600, 960 }, { 337, 600, 700, 600 } };
        public static object[,] RES_WORKED = new object[2, 4];
        public static object[] CUSTOM_GRID = new object[] { 0, 0, 0, 0 };

        public static string[] tempStringArray = new string[] { "" };

        // Create the Mouse Hook
        MouseHook mouseHook = new MouseHook();

        // Create the Keyboard Hook
        KeyboardHook keyboardHook = new KeyboardHook();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        public FormMain()
        {
            InitializeComponent();

            pnlToolBarH = pnlToolbarMain.Height;

            lblHeader.TabStop = false;

            //set transparent
            this.BackColor = ALPHA_KEY_COLOR;
            this.TransparencyKey = ALPHA_KEY_COLOR;

            LoadSettings();

            // Capture the events
            mouseHook.MiddleButtonDown += new MouseHook.MouseHookCallback(mouseHook_MMB);

            //Installing the Mouse Hooks
            mouseHook.Install();
            // Using the Keyboard Hook:

            // Capture the events
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);

            //Installing the Keyboard Hooks
            keyboardHook.Install();

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }


        //hook keys
        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {

            if (key == KeyboardHook.VKeys.F4)
            {
                CaptureMyScreen();
            }

        }


        //hook mouse
        private void mouseHook_MMB(MouseHook.MSLLHOOKSTRUCT mouse)
        {

            // important point
            relativePoint = pnlCanvas.PointToClient(Cursor.Position);


            if (drawArrows == true)
            {

                DrawArrow(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, arrowColor);

            }

            if (drawNumber == true)
            {
                DrawNumber(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, numberColor, numbering.ToString());
                numbering++;
            }


        }

        public static void DrawNumber(PaintEventArgs e, Point relativePoint, Color color, String numberString)
        {
            //for outline
            int outlineShift = 1;

            Font drawFont = new Font("Arial", numberFontSize, FontStyle.Bold);
            //outline
            Font outlineFont = new Font("Arial", numberFontSize + outlineShift, FontStyle.Bold);

            SolidBrush drawBrush = new SolidBrush(color);
            //outline
            SolidBrush outlineBrush = new SolidBrush(Color.Black);

            StringFormat drawFormat = new StringFormat();

            //align string
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            //outline
            e.Graphics.DrawString(numberString, outlineFont, outlineBrush, relativePoint.X, relativePoint.Y + outlineShift, drawFormat);
            //number
            e.Graphics.DrawString(numberString, drawFont, drawBrush, relativePoint.X, relativePoint.Y, drawFormat);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;


            drawFont.Dispose();
            drawBrush.Dispose();
            e.Graphics.Dispose();

        }

        //load SETTINGS
        private void LoadSettings()
        {

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
                StartResH = Convert.ToInt32(tempStringArray[1]); //set height
                this.ClientSize = new Size(StartResW, StartResH);
            }
            catch
            {
                this.ClientSize = new Size(Convert.ToInt32(RES_WORKED[0, 0]), Convert.ToInt32(RES_WORKED[1, 0]));

            }


            //set client size
            clientWidth = this.ClientSize.Width;
            clientHeight = this.ClientSize.Height; //set height

            //Update form name
            lblHeader.Text = TextUpdater(PROG_NAME, clientWidth, clientHeight);

            Rectangle VirtScreenRect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

            foreach (Screen screen in Screen.AllScreens)
                VirtScreenRect = Rectangle.Union(VirtScreenRect, screen.Bounds);

            //Get virtual screen size
            VirtScreenWidth = VirtScreenRect.Width;
            VirtScreenHeight = VirtScreenRect.Height;


            //Grid COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["guidlines_color"];
            try
            {
                gridColor = ColorTranslator.FromHtml(tempValueFromConfig);
            }
            catch
            {
                gridColor = Color.FromName(tempValueFromConfig);
            }

            //Arrow COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["arrow_color"];
            arrowColor = ColorTranslator.FromHtml(tempValueFromConfig);

            //Number COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["number_color"];
            numberColor = ColorTranslator.FromHtml(tempValueFromConfig);


            try
            {
                tempValueFromConfig = ConfigurationManager.AppSettings["number_size"];
                FormMain.numberFontSize = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.numberFontSize = 1;
            }

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
            drawGrid = Convert.ToBoolean(tempValueFromConfig);

            if (drawGrid == true)
            {
                mitShowGrid.Checked = true;
            }
            else
            {
                mitShowGrid.Checked = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["draw_arrows"];
            drawArrows = Convert.ToBoolean(tempValueFromConfig);

            if (drawArrows == true)
            {
                mitShowArrows.Checked = true;
                btnArrowType.Enabled = true;
            }
            else
            {
                mitShowArrows.Checked = false;
                btnArrowType.Enabled = false;
            }



            tempValueFromConfig = ConfigurationManager.AppSettings["draw_number"];
            drawNumber = Convert.ToBoolean(tempValueFromConfig);

            if (drawNumber == true)
            {
                mitAddNumber.Checked = true;
            }
            else
            {
                mitAddNumber.Checked = false;
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

            arrowPictureUpdater(ArrowType);

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
            int clientW = Convert.ToInt32(RES_WORKED[0, 0]);
            int clientH = Convert.ToInt32(RES_WORKED[1, 0]) + pnlToolBarH;

            this.ClientSize = new Size(clientW, clientH);

            TextUpdater(PROG_NAME, clientW, clientH);

            this.Refresh();
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            int clientW = Convert.ToInt32(RES_WORKED[0, 1]);
            int clientH = Convert.ToInt32(RES_WORKED[1, 1]) + pnlToolBarH;

            this.ClientSize = new Size(clientW, clientH);

            TextUpdater(PROG_NAME, clientW, clientH);

            this.Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            int clientW = Convert.ToInt32(RES_WORKED[0, 2]);
            int clientH = Convert.ToInt32(RES_WORKED[1, 2]) + pnlToolBarH;

            this.ClientSize = new Size(clientW, clientH);

            TextUpdater(PROG_NAME, clientW, clientH);

            this.Refresh();
        }

        private void mitSize04_Click(object sender, EventArgs e)
        {

            int clientW = Convert.ToInt32(RES_WORKED[0, 3]);
            int clientH = Convert.ToInt32(RES_WORKED[1, 3]) + pnlToolBarH;

            this.ClientSize = new Size(clientW, clientH);

            TextUpdater(PROG_NAME, clientW, clientH);

            this.Refresh();
        }



        private void FormMain_Move(object sender, EventArgs e)
        {
            toolTipMain.Hide(pnlToolbarMain);
        }

        private void contextMenuMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolTipMain.Hide(pnlToolbarMain);
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private string TextUpdater(string Text, int Width, int Height)
        {
            string FinalText = "";

            FinalText = (Width.ToString() + "x" + (Height - pnlToolBarH).ToString()); //set size

            lblHeader.Text = FinalText;

            toolTipMain.SetToolTip(btnScreen, "Take screenshot. Size: " + FinalText + "px");

            toolTipMain.Show("Size setted to " + FinalText + "px", pnlToolbarMain);

            this.Text = FinalText;

            return FinalText;
        }

        //SCREEN
        private void CaptureMyScreen()
        {

            pnlCanvas.BorderStyle = BorderStyle.None;
            toolTipMain.Hide(pnlToolbarMain);

            bool gridIsOn = false;

            //turn off grid
            if (mitShowGrid.Checked == true)
            {
                gridIsOn = true;

                DrawGrid(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), ALPHA_KEY_COLOR);
                toolTipMain.Hide(pnlToolbarMain);
            }

            // bitmap size
            int bitmapWidth = pnlCanvas.Width;
            int bitmapHeight = pnlCanvas.Height;

            //Creating a new Bitmap object
            Bitmap captureBitmap = new Bitmap(bitmapWidth, bitmapHeight, PixelFormat.Format32bppArgb);

            //Creating a Rectangle object which will capture our Current Screen
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

            //Creating a New Graphics Object
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);

            //Position of screenshot
            int posY = this.Location.Y + pnlToolBarH; //set size
            int posX = this.Location.X;

            //Copying Image from The Screen

            captureGraphics.CopyFromScreen(posX, posY, 0, 0, captureRectangle.Size);
            captureGraphics.Dispose();

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

            pnlCanvas.BorderStyle = BorderStyle.FixedSingle;

            lblHeader.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);

            //turn on grid again
            if (gridIsOn == true)
            {
                DrawGrid(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), gridColor);

            }

            toolTipMain.Show("Screenshot copied to clipboard", pnlToolbarMain);

            //is save to file
            if (saveToFile == true)
            {
                string longString = "Screenshot copied to clipboard and saved to file: " + Environment.NewLine + URLString;

                toolTipMain.Show(longString, pnlToolbarMain);
            }

            //return nubering to start
            numbering = 1;

            //dispose objects
            captureBitmap.Dispose();
            captureGraphics.Dispose();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {

            toolTipMain.Hide(pnlToolbarMain);
        }


        //draw grid
        private void DrawGrid(PaintEventArgs e, Color lineColor)
        {

            int initialPointVertical, initialPointHorizontal;

            if (GridType == 1)
            {
                initialPointVertical = pnlCanvas.Width / 3;
                initialPointHorizontal = pnlCanvas.Height / 3; //set size

                Pen gridPen = new Pen(lineColor);

                //vertical
                e.Graphics.DrawLine(gridPen, initialPointVertical, 0, initialPointVertical, this.ClientSize.Height);
                e.Graphics.DrawLine(gridPen, initialPointVertical * 2, 0, initialPointVertical * 2, this.ClientSize.Height);

                //horizontal
                e.Graphics.DrawLine(gridPen, 0, initialPointHorizontal, this.ClientSize.Width, initialPointHorizontal);
                e.Graphics.DrawLine(gridPen, 0, initialPointHorizontal * 2, this.ClientSize.Width, initialPointHorizontal * 2);

                gridPen.Dispose();
            }

            if (GridType == 2)
            {

                initialPointVertical = pnlCanvas.Width / 4;
                initialPointHorizontal = pnlCanvas.Height / 4;

                Pen gridPen = new Pen(lineColor);

                //vertical
                e.Graphics.DrawLine(gridPen, initialPointVertical, 0, initialPointVertical, this.ClientSize.Height);
                e.Graphics.DrawLine(gridPen, initialPointVertical * 2, 0, initialPointVertical * 2, this.ClientSize.Height);
                e.Graphics.DrawLine(gridPen, initialPointVertical * 3, 0, initialPointVertical * 3, this.ClientSize.Height);

                //horizontal
                e.Graphics.DrawLine(gridPen, 0, initialPointHorizontal, this.ClientSize.Width, initialPointHorizontal);
                e.Graphics.DrawLine(gridPen, 0, initialPointHorizontal * 2, this.ClientSize.Width, initialPointHorizontal * 2);
                e.Graphics.DrawLine(gridPen, 0, initialPointHorizontal * 3, this.ClientSize.Width, initialPointHorizontal * 3);

                gridPen.Dispose();

            }

            if (GridType == 3)
            {

                int topIndent = Convert.ToInt32(CUSTOM_GRID[0]);
                int bottonIndent = Convert.ToInt32(CUSTOM_GRID[1]);

                int leftIndent = Convert.ToInt32(CUSTOM_GRID[2]);
                int rightIndent = Convert.ToInt32(CUSTOM_GRID[3]);

                Pen gridPen = new Pen(lineColor);

                //top
                e.Graphics.DrawLine(gridPen, 0, topIndent, pnlCanvas.Width, topIndent);

                // border fix
                int canvasSizeH = pnlCanvas.Height - 3;
                int canvasSizeW = pnlCanvas.Width - 3;

                //bottom
                e.Graphics.DrawLine(gridPen, 0, canvasSizeH - bottonIndent, pnlCanvas.Width, canvasSizeH - bottonIndent);

                //left
                e.Graphics.DrawLine(gridPen, leftIndent, 0, leftIndent, pnlCanvas.Height);

                //right
                e.Graphics.DrawLine(gridPen, canvasSizeW - rightIndent, 0, canvasSizeW - rightIndent, pnlCanvas.Height);

                gridPen.Dispose();

            }


        }

        //draw arrow
        public static void DrawArrow(PaintEventArgs e, Point relativePoint, Color color)
        {

            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(relativePoint.X, relativePoint.Y);

            switch (ArrowType)
            {
                case 1:
                    startPoint = new Point(relativePoint.X - arrowLenght, relativePoint.Y + arrowLenght);

                    break;

                case 2:
                    startPoint = new Point(relativePoint.X - arrowLenght, relativePoint.Y - arrowLenght);

                    break;

                case 3:
                    startPoint = new Point(relativePoint.X + arrowLenght, relativePoint.Y - arrowLenght);

                    break;
                case 4:
                    startPoint = new Point(relativePoint.X + arrowLenght, relativePoint.Y + arrowLenght);

                    break;
            }

            //Color arrow
            var arrowPen = new Pen(color, 1);

            // for outline
            var arrowPenOutline = new Pen(Color.Black, 2);

            //TODO settings
            int ArrowSize = 6;

            // for outline
            arrowPenOutline.CustomEndCap = new AdjustableArrowCap(ArrowSize, ArrowSize + 1);

            //color arrow
            arrowPen.CustomEndCap = new AdjustableArrowCap(ArrowSize, ArrowSize);

            e.Graphics.DrawLine(arrowPenOutline, startPoint, endPoint);
            e.Graphics.DrawLine(arrowPen, startPoint, endPoint);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            arrowPen.Dispose();
            arrowPenOutline.Dispose();
        }


        private void drawGridStatus()
        {

            if (mitShowGrid.CheckState == CheckState.Checked)
            {
                mitShowGrid.CheckState = CheckState.Unchecked;
                drawGrid = false;
                toolTipMain.Show("Grid turned OFF", pnlToolbarMain);
            }
            else
            {
                mitShowGrid.CheckState = CheckState.Checked;
                drawGrid = true;
                toolTipMain.Show("Grid turned ON", pnlToolbarMain);
            }

        }

        private void drawArrowStatus()
        {

            if (mitShowArrows.CheckState == CheckState.Checked)
            {
                mitShowArrows.CheckState = CheckState.Unchecked;
                drawArrows = false;
                toolTipMain.Show("Arrows turned OFF", pnlToolbarMain);
                btnArrowType.Enabled = false;
            }
            else
            {
                mitShowArrows.CheckState = CheckState.Checked;
                drawArrows = true;
                toolTipMain.Show("Arrows turned ON", pnlToolbarMain);
                btnArrowType.Enabled = true;
            }
        }

        private void drawNumberStatus()
        {

            if (mitAddNumber.CheckState == CheckState.Checked)
            {
                mitAddNumber.CheckState = CheckState.Unchecked;
                drawNumber = false;
                toolTipMain.Show("Numbers turned OFF", pnlToolbarMain);

            }
            else
            {
                mitAddNumber.CheckState = CheckState.Checked;
                drawNumber = true;
                toolTipMain.Show("Numbers turned ON", pnlToolbarMain);

            }
        }

        private void saveToFileStatus()
        {

            if (mitSaveFile.CheckState == CheckState.Checked)
            {
                mitSaveFile.CheckState = CheckState.Unchecked;
                saveToFile = false;
                toolTipMain.Show("Save to file turned OFF", pnlToolbarMain);
            }
            else
            {
                mitSaveFile.CheckState = CheckState.Checked;
                saveToFile = true;
                toolTipMain.Show("Save to file turned ON", pnlToolbarMain);
            }
        }

        private void mitShowGrid_Click(object sender, EventArgs e)
        {
            drawGridStatus();

            if (drawArrows != true && drawNumber != true)
            {
                this.Refresh();
            }

            if (drawGrid == false)
            {
                DrawGrid(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), ALPHA_KEY_COLOR);
            }
            else
            {
                DrawGrid(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), gridColor);
            }

        }


        private void mitShowArrows_Click(object sender, EventArgs e)
        {
            drawArrowStatus();
        }


        private void mitTakeScreen_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private void mitAddNumber_Click(object sender, EventArgs e)
        {
            drawNumberStatus();

            numbering = 1;
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
            SetSetting("guidlines_color", ColorTranslator.ToHtml(gridColor)); //COLOR
            SetSetting("arrow_color", ColorTranslator.ToHtml(arrowColor));
            SetSetting("number_color", ColorTranslator.ToHtml(numberColor));


            SetSetting("guidline_type", GridType.ToString());
            SetSetting("arrows_type", ArrowType.ToString());
            SetSetting("arrow_lenght", arrowLenght.ToString());
            SetSetting("number_size", numberFontSize.ToString());

            SetSetting("draw_guidlines", drawGrid.ToString().ToLower());
            SetSetting("draw_arrows", drawArrows.ToString().ToLower());
            SetSetting("draw_number", drawNumber.ToString().ToLower());
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

            if (drawGrid == true)
            {
                this.Refresh();
                DrawGrid(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), gridColor);
            }
        }

        private void MenuItemUpdate()
        {
            mitSize01.Text = RES_WORKED[0, 0].ToString() + "x" + RES_WORKED[1, 0].ToString();
            mitSize02.Text = RES_WORKED[0, 1].ToString() + "x" + RES_WORKED[1, 1].ToString();
            mitSize03.Text = RES_WORKED[0, 2].ToString() + "x" + RES_WORKED[1, 2].ToString();
            mitSize04.Text = RES_WORKED[0, 3].ToString() + "x" + RES_WORKED[1, 3].ToString();
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

        private void OnApplicationExit(object sender, EventArgs e)
        {
            keyboardHook.KeyDown -= new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Uninstall();

            mouseHook.MiddleButtonDown -= new MouseHook.MouseHookCallback(mouseHook_MMB);
            mouseHook.Uninstall();

            SaveConfig();
        }

        private void pnlToolbarMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnlToolbarMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnlToolbarMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveConfig();
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if ((drawGrid == true) && (mitShowGrid.CheckState == CheckState.Checked))
            {
                DrawGrid(e, gridColor);
            }
        }

        private void mitClear_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }


        private void arrowPictureUpdater(int number)
        {

            if (clickCount > 4)
            {
                clickCount = 1;
                number = 1;
            }

            switch (number)
            {
                case 1:
                    btnArrowType.Image = Resources.arrow_type01;
                    ArrowType = 1; clickCount = 1;
                    break;
                case 2:
                    btnArrowType.Image = Resources.arrow_type02;
                    ArrowType = 2; clickCount = 2;
                    break;
                case 3:
                    btnArrowType.Image = Resources.arrow_type03;
                    ArrowType = 3; clickCount = 3;
                    break;
                case 4:
                    btnArrowType.Image = Resources.arrow_type04;
                    ArrowType = 4; clickCount = 4;
                    break;

                default:
                    break;
            }
        }

        private void btnArrowType_Click(object sender, EventArgs e)
        {
            clickCount++;

            arrowPictureUpdater(clickCount);

            toolTipMain.Hide(pnlToolbarMain);
        }
    }

}