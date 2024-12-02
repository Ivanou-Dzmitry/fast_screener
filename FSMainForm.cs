using fast_screener;
using fast_screener.Properties;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;



namespace screener3
{

    public partial class FormMain : Form
    {
        public struct Line
        {
            public Point StartPoint { get; set; }
            public Point EndPoint { get; set; }
            public Color Color { get; set; }
            public float Width { get; set; }

            public Line(Point start, Point end, Color color, float width)
            {
                StartPoint = start;
                EndPoint = end;
                Color = color;
                Width = width;
            }
        }


        //Name
        public const string PROG_NAME = "F.S. ", SUBPATH = "screenshots";

        private string URLString = "";

        //all monitors
        public static int VirtScreenWidth = 0,
            VirtScreenHeight = 0,
            clientWidth,
            clientHeight,
            arrowLenght,
            NewWidth = 0,
            NewHeight = 0,
            numberFontSize;

        public static int FrameWidth, FrameHeight;

        public const int FrameInitialSize = 80, FrameMinSize = 16;


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
        public static bool drawGrid, drawArrows, saveToFile, drawNumber, drawFrame;

        public static bool indentValueLock = false;

        //1 - 3x3, 2 - 4x4, 3 - custom
        public static int GridType, ArrowType, StartResW = 0, StartResH = 0, numbering = 1, pnlToolBarH = 0, clickCount = 0;

        static Point relativePoint;

        //screen sizes
        public static object[,] RES_DEFAULT = { { 600, 600, 600, 960 }, { 337, 600, 700, 600 } };
        public static object[,] RES_WORKED = new object[2, 4];
        public static object[] CUSTOM_GRID = new object[] { 0, 0, 0, 0 };

        // Create the Mouse Hook
        MouseHook mouseHook = new MouseHook();

        // Create the Keyboard Hook
        KeyboardHook keyboardHook = new KeyboardHook();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public static float scalingFactor;

        private Point startPoint;
        private Rectangle currentRectangle;
        private bool isDrawing;
        private bool isLineDrawing;

        private List<Rectangle> drawnRectangles = new List<Rectangle>();
        private List<Line> drawnArrows = new List<Line>();

        private int minDrawSize = 3;

        private int arrowSize = 6;



        public FormMain()
        {
            InitializeComponent();

            pnlToolBarH = pnlToolbarMain.Height;

            lblHeader.TabStop = false;

            //set transparent
            this.BackColor = ALPHA_KEY_COLOR;
            this.TransparencyKey = ALPHA_KEY_COLOR;

            SettingsManager.LoadSettings();

            //this.ClientSize = new Size(StartResW, StartResH);

            //get scaling
            scalingFactor = GetScalingFactor(this);

            // Set client size
            this.ClientSize = new Size((int)(StartResW), (int)(StartResH));

            //set client size
            clientWidth = this.ClientSize.Width;
            clientHeight = this.ClientSize.Height; //set height

            //grid
            mitShowGrid.Checked = SettingsManager.DrawGridConfigValue;

            //arrow
            mitShowArrows.Checked = SettingsManager.DrawArrowConfigValue;
            btnArrowType.Enabled = SettingsManager.DrawArrowConfigValue;

            //numbers
            mitAddNumber.Checked = SettingsManager.DrawNumberConfigValue;

            //files
            mitSaveFile.Checked = SettingsManager.SaveFileConfigValue;

            //frame
            mitFrame.Checked = SettingsManager.DrawFrameConfigValue;

            MenuItemUpdate();

            //Update form name
            if (scalingFactor == 1)
            {
                lblHeader.Text = TextUpdater(PROG_NAME, clientWidth, clientHeight);
            }
            else
            {
                lblHeader.Text = TextUpdater(PROG_NAME, (int)(clientWidth / scalingFactor), (int)(clientHeight / scalingFactor));
            }


            Rectangle VirtScreenRect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

            foreach (Screen screen in Screen.AllScreens)
                VirtScreenRect = Rectangle.Union(VirtScreenRect, screen.Bounds);

            //Get virtual screen size
            VirtScreenWidth = VirtScreenRect.Width;
            VirtScreenHeight = VirtScreenRect.Height;

            arrowPictureUpdater(ArrowType);

            // Capture the events
            mouseHook.MiddleButtonDown += new MouseHook.MouseHookCallback(mouseHook_MMB);
            mouseHook.MiddleButtonUp += new MouseHook.MouseHookCallback(mouseHook_MouseUp);
            mouseHook.MouseMove += new MouseHook.MouseHookCallback(mouseHook_MouseMove);

            //Installing the Mouse Hooks
            mouseHook.Install();
            // Using the Keyboard Hook:

            // Capture the events
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);

            //Installing the Keyboard Hooks
            keyboardHook.Install();

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            ScaleButtonImage(btnScreen, scalingFactor);
            ScaleButtonImage(btnMainMenu, scalingFactor);
            ScaleButtonImage(btnArrowType, scalingFactor);
        }

        private void ScaleButtonImage(Button button, float scalingFactor)
        {
            if (button.Image != null)
            {
                button.Image = ScaleImage(button.Image, scalingFactor);
            }
        }


        private Image ScaleImage(Image originalImage, float scaleFactor)
        {
            int newWidth = (int)(originalImage.Width * scaleFactor);
            int newHeight = (int)(originalImage.Height * scaleFactor);

            Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight));
            return resizedImage;
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

            //draw Frame
            if (drawFrame)
            {
                startPoint = new Point(relativePoint.X, relativePoint.Y);
                currentRectangle = new Rectangle(startPoint, new Size(0, 0));
                isDrawing = true;
            }

            isLineDrawing = true;

            //draw Arrow
            if (drawArrows && isLineDrawing)
            {
                DrawArrow(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, arrowColor);
            }

            //draw Number
            if (drawNumber)
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


        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            contextMenuMain.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void AdjustClientSize(int widthIndex, int heightIndex)
        {
            // Retrieve dimensions
            int clientW = Convert.ToInt32(RES_WORKED[0, widthIndex]);
            int clientH = Convert.ToInt32(RES_WORKED[1, heightIndex]) + pnlToolBarH;

            // Apply scaling factor
            int scaledClientW = (int)(clientW * scalingFactor);
            int scaledClientH = (int)(clientH * scalingFactor);

            // Set client size
            this.ClientSize = new Size(scaledClientW, scaledClientH);

            // Update text
            TextUpdater(PROG_NAME, clientW, clientH);

            // Refresh the form
            this.Refresh();
        }

        // Event handlers calling the common method
        private void mitSize01_Click(object sender, EventArgs e) => AdjustClientSize(0, 0);

        private void toolStripMenuItem3_Click(object sender, EventArgs e) => AdjustClientSize(1, 1);

        private void toolStripMenuItem4_Click(object sender, EventArgs e) => AdjustClientSize(2, 2);

        private void mitSize04_Click(object sender, EventArgs e) => AdjustClientSize(3, 3);


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

            if (scalingFactor == 1)
            {
                FinalText = (Width.ToString() + "x" + (Height - pnlToolBarH).ToString()); //set size
            }
            else
            {
                FinalText = (Width.ToString() + "x" + (Height - pnlToolBarH).ToString()) + " (x" + scalingFactor + ")"; //set size
            }


            lblHeader.Text = FinalText;

            toolTipMain.SetToolTip(btnScreen, "Take screenshot. Size: " + FinalText);

            toolTipMain.Show("Size setted to " + FinalText, pnlToolbarMain);

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

            //set clipboard
            //Clipboard.SetImage(captureBitmap);

            SetScaledBitmapToClipboard(captureBitmap, scalingFactor);

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

            //rectangle data
            pnlCanvas.Invalidate();
            drawnRectangles.Clear();
            currentRectangle = new Rectangle(startPoint, new Size(0, 0));

            drawnArrows.Clear();    
        }


        void SetScaledBitmapToClipboard(Bitmap originalBitmap, float scalingFactor)
        {
            // Calculate new dimensions
            int scaledWidth = (int)(originalBitmap.Width / scalingFactor);
            int scaledHeight = (int)(originalBitmap.Height / scalingFactor);

            // Create a new bitmap with scaled dimensions
            Bitmap scaledBitmap = new Bitmap(scaledWidth, scaledHeight);

            // Draw the original bitmap onto the scaled bitmap
            using (Graphics g = Graphics.FromImage(scaledBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalBitmap, 0, 0, scaledWidth, scaledHeight);
            }

            // Set the scaled bitmap to the clipboard
            Clipboard.SetImage(scaledBitmap);

            // Dispose of the scaled bitmap if no longer needed
            scaledBitmap.Dispose();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            toolTipMain.Hide(pnlToolbarMain);
        }


        // Draw the grid
        private void DrawGrid(PaintEventArgs e, Color lineColor)
        {
            // Create a reusable pen instance
            using (Pen gridPen = new Pen(lineColor))
            {
                int initialPointVertical, initialPointHorizontal;

                if (GridType == 1 || GridType == 2)
                {
                    // Determine the grid size based on the type
                    int divisions = (GridType == 1) ? 3 : 4;
                    initialPointVertical = pnlCanvas.Width / divisions;
                    initialPointHorizontal = pnlCanvas.Height / divisions;

                    // Draw vertical lines
                    for (int i = 1; i < divisions; i++)
                    {
                        int x = initialPointVertical * i;
                        e.Graphics.DrawLine(gridPen, x, 0, x, this.ClientSize.Height);
                    }

                    // Draw horizontal lines
                    for (int i = 1; i < divisions; i++)
                    {
                        int y = initialPointHorizontal * i;
                        e.Graphics.DrawLine(gridPen, 0, y, this.ClientSize.Width, y);
                    }
                }
                else if (GridType == 3)
                {
                    // Custom grid dimensions
                    int topIndent = Convert.ToInt32(CUSTOM_GRID[0]);
                    int bottomIndent = Convert.ToInt32(CUSTOM_GRID[1]);
                    int leftIndent = Convert.ToInt32(CUSTOM_GRID[2]);
                    int rightIndent = Convert.ToInt32(CUSTOM_GRID[3]);

                    // Fix border dimensions
                    int canvasSizeH = pnlCanvas.Height - 3;
                    int canvasSizeW = pnlCanvas.Width - 3;

                    // Draw top and bottom lines
                    e.Graphics.DrawLine(gridPen, 0, topIndent, pnlCanvas.Width, topIndent);
                    e.Graphics.DrawLine(gridPen, 0, canvasSizeH - bottomIndent, pnlCanvas.Width, canvasSizeH - bottomIndent);

                    // Draw left and right lines
                    e.Graphics.DrawLine(gridPen, leftIndent, 0, leftIndent, pnlCanvas.Height);
                    e.Graphics.DrawLine(gridPen, canvasSizeW - rightIndent, 0, canvasSizeW - rightIndent, pnlCanvas.Height);
                }
            }
        }

        private void AddLine(Point startPoint, Point endPoint, Color color)
        {
            Line newLine = new Line(
                startPoint,
                endPoint,
                color,
                1.0f // Example line width
            );

            // Add the line to the list
            drawnArrows.Add(newLine);
        }


        //draw arrow
        public void DrawArrow(PaintEventArgs e, Point relativePoint, Color color)
        {

            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(relativePoint.X, relativePoint.Y);

            int scaledLenght = (int)(arrowLenght * scalingFactor);

            switch (ArrowType)
            {
                case 1:
                    startPoint = new Point(relativePoint.X - scaledLenght, relativePoint.Y + scaledLenght);
                    break;
                case 2:
                    startPoint = new Point(relativePoint.X - scaledLenght, relativePoint.Y - scaledLenght);
                    break;
                case 3:
                    startPoint = new Point(relativePoint.X + scaledLenght, relativePoint.Y - scaledLenght);
                    break;
                case 4:
                    startPoint = new Point(relativePoint.X + scaledLenght, relativePoint.Y + scaledLenght);
                    break;
            }

            AddLine(startPoint, endPoint, color);

            RenderLines(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), arrowSize);
        }

        private void RenderLines(PaintEventArgs e, int aSize)
        {
            foreach (var line in drawnArrows)
            {
                using (Pen linePen = new Pen(line.Color, line.Width))
                {
                    linePen.CustomEndCap = new AdjustableArrowCap(aSize, aSize);

                    // for outline
                    var arrowPenOutline = new Pen(Color.Black, 2);
                    // for outline
                    arrowPenOutline.CustomEndCap = new AdjustableArrowCap(aSize, aSize + 1);
                    e.Graphics.DrawLine(arrowPenOutline, line.StartPoint, line.EndPoint);

                    e.Graphics.DrawLine(linePen, line.StartPoint, line.EndPoint);
                }
            }
        }


        // Generic method to handle status toggling
        private void ToggleStatus(
            ToolStripMenuItem menuItem,
            ref bool statusFlag,
            string onMessage,
            string offMessage,
            Control targetControl = null,
            bool? controlState = null)
        {
            if (menuItem.CheckState == CheckState.Checked)
            {
                menuItem.CheckState = CheckState.Unchecked;
                statusFlag = false;
                toolTipMain.Show(offMessage, pnlToolbarMain);

                // Handle optional control state update
                if (targetControl != null && controlState.HasValue)
                {
                    targetControl.Enabled = controlState.Value;
                }
            }
            else
            {
                menuItem.CheckState = CheckState.Checked;
                statusFlag = true;
                toolTipMain.Show(onMessage, pnlToolbarMain);

                if (targetControl != null && controlState.HasValue)
                {
                    targetControl.Enabled = !controlState.Value;
                }
            }
        }



        private void mitShowGrid_Click(object sender, EventArgs e)
        {
            DrawGridStatus();

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

        // Specific status functions
        private void DrawGridStatus()
        {
            ToggleStatus(mitShowGrid, ref drawGrid, "Grid turned ON", "Grid turned OFF");
        }

        private void DrawArrowStatus()
        {
            ToggleStatus(mitShowArrows, ref drawArrows, "Arrows turned ON", "Arrows turned OFF", btnArrowType, false);
        }

        private void DrawNumberStatus()
        {
            ToggleStatus(mitAddNumber, ref drawNumber, "Numbers turned ON", "Numbers turned OFF");
        }

        private void SaveToFileStatus()
        {
            ToggleStatus(mitSaveFile, ref saveToFile, "Save to file turned ON", "Save to file turned OFF");
        }


        private void mitShowArrows_Click(object sender, EventArgs e)
        {
            DrawArrowStatus();
        }


        private void mitTakeScreen_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private void mitAddNumber_Click(object sender, EventArgs e)
        {
            DrawNumberStatus();

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
            SettingsManager.SaveConfig(this.ClientSize.Width, this.ClientSize.Height);
            Close();
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

            //float currentDpi = GetDpi(this);
            //scalingFactor = GetScalingFactor(this);

            //Console.WriteLine($"Current DPI: {currentDpi}");
            //Console.WriteLine($"Scaling Factor: {scalingFactor}");

            //MessageBox.Show($"CUR DPI: {currentDpi}, Scaling Factor: {scalingFactor}");
        }

        public float GetDpi(Form form)
        {
            using (Graphics g = form.CreateGraphics())
            {
                return g.DpiX; // DpiX for horizontal DPI, DpiY for vertical DPI
            }
        }

        public float GetScalingFactor(Form form)
        {
            using (Graphics g = form.CreateGraphics())
            {
                float dpiX = g.DpiX;
                return dpiX / 96f; // Assuming default DPI is 96
            }
        }

        //on dpi change
        protected override void WndProc(ref Message m)
        {
            const int WM_DPICHANGED = 0x02E0;

            if (m.Msg == WM_DPICHANGED)
            {
                scalingFactor = GetScalingFactor(this);
            }

            base.WndProc(ref m);
        }


        public float GetDeviceDpi(Form form)
        {
            return form.DeviceDpi; // Returns the current DPI
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
            float newDpiX = e.DeviceDpiNew / 96f; // New DPI scaling factor
            MessageBox.Show($"New DPI: {e.DeviceDpiNew}, Scaling Factor: {newDpiX}");
        }

        public float GetScreenDpi()
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                return g.DpiX;
            }
        }

        private void mitSaveFile_Click(object sender, EventArgs e)
        {
            SaveToFileStatus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutText = "Author: Dzmitry Ivanou" + "\n" + "e-mail: frosofco@gmail.com" + "\n" + "https://github.com/Ivanou-Dzmitry/fast_screener";
            MessageBox.Show(aboutText, "About FastScreener 0.3");
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            keyboardHook.KeyDown -= new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Uninstall();


            mouseHook.MiddleButtonDown -= new MouseHook.MouseHookCallback(mouseHook_MMB);
            mouseHook.MiddleButtonUp -= new MouseHook.MouseHookCallback(mouseHook_MouseUp);
            mouseHook.MouseMove -= new MouseHook.MouseHookCallback(mouseHook_MouseMove);

            mouseHook.Uninstall();

            SettingsManager.SaveConfig(this.ClientSize.Width, this.ClientSize.Height);
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
            SettingsManager.SaveConfig(this.ClientSize.Width, this.ClientSize.Height);
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

            if (drawArrows)
            {
                RenderLines(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), arrowSize);
            }
           
            if (drawFrame)
            {
                if (currentRectangle.Width > minDrawSize && currentRectangle.Height > minDrawSize)
                    DrawFrameCurrent(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, frameColor);
                
                DrawFrame(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, frameColor);
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

            ScaleButtonImage(btnArrowType, scalingFactor);
        }

        private void lblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void lblHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lblHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        //open dir with files
        private void mitOpenFolder_Click(object sender, EventArgs e)
        {
            string appExeDir = Directory.GetCurrentDirectory();

            //check directory for files
            bool exists = Directory.Exists(appExeDir + "\\" + SUBPATH);

            // create if not exists
            if (!exists)
                Directory.CreateDirectory(appExeDir + "\\" + SUBPATH);

            //path to open
            string PathToDir = appExeDir + "\\" + SUBPATH;

            //open dir
            Process.Start("explorer.exe", PathToDir);
        }

        private void mitFrame_Click(object sender, EventArgs e)
        {
            DrawFrameStatus();
        }

        private void DrawFrameStatus()
        {
            if (mitFrame.CheckState == CheckState.Checked)
            {
                mitFrame.CheckState = CheckState.Unchecked;
                drawFrame = false;
            }
            else
            {
                mitFrame.CheckState = CheckState.Checked;
                drawFrame = true;
            }
        }


        private void mouseHook_MouseMove(MouseHook.MSLLHOOKSTRUCT mouse)
        {
            isLineDrawing = false;

            if (isDrawing)
            {
                // important point
                relativePoint = pnlCanvas.PointToClient(Cursor.Position);

                int width = relativePoint.X - startPoint.X;
                int height = relativePoint.Y - startPoint.Y;

                currentRectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);

                DrawFrameCurrent(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, frameColor);

                if (drawFrame)
                {
                    DrawFrame(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, frameColor);
                    pnlCanvas.Invalidate();
                }
                  
            }
        }

        // Mouse Middle Button Up (End drawing)
        private void mouseHook_MouseUp(MouseHook.MSLLHOOKSTRUCT mouse)
        {
            isDrawing = false;
            isLineDrawing = false;

            // Calculate the final rectangle
            int width = relativePoint.X - startPoint.X;
            int height = relativePoint.Y - startPoint.Y;

            // Create and add the rectangle
            Rectangle newRectangle = new Rectangle(
                    Math.Min(startPoint.X, relativePoint.X),
                    Math.Min(startPoint.Y, relativePoint.Y),
                    Math.Abs(width),
                    Math.Abs(height)
                );

            if (drawFrame)
            {
                drawnRectangles.Add(newRectangle);
                DrawFrame(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, frameColor);
            }
            
            //avoid draw line on mouse UP
            if (drawArrows && isLineDrawing)
            {
                DrawArrow(new PaintEventArgs(pnlCanvas.CreateGraphics(), pnlCanvas.ClientRectangle), relativePoint, arrowColor);
            }

        }

        private void DrawFrameCurrent(PaintEventArgs e, Point relativePoint, Color color)
        {
            var framePen = new Pen(color, 1);
            if (currentRectangle.Width > 0 && currentRectangle.Height > 0)
                e.Graphics.DrawRectangle(framePen, currentRectangle);
        }


        //drawFrame
        private void DrawFrame(PaintEventArgs e, Point relativePoint, Color color)
        {
            var framePen = new Pen(color, 1);
         
            if (currentRectangle.Width > minDrawSize && currentRectangle.Height > minDrawSize)
            {
                foreach (var rectangle in drawnRectangles)
                {
                    e.Graphics.DrawRectangle(framePen, rectangle);
                }
            }
            
            framePen.Dispose();
        }



    }

}