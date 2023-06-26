using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace screener3
{



    public partial class FormMain : Form
    {
        //Name
        public const string PROG_NAME = "F.S. ";

        public static int NewWidth = 0;
        public static int NewHeight = 0;

        //all monitors
        public static int VirtScreenWidth = 0;
        public static int VirtScreenHeight = 0;

        public static int clientWidth, clientHeight;

        //Min size
        public const int MIN_WIDTH = 200;
        public const int MIN_HEIGHT = 100;

        //alpha color to remove 
        private Color ALPHA_KEY_COLOR = Color.FromArgb(255, 0, 1, 0);

        //default guidlines color
        public static Color guidlinesColor = Color.LightGray;
        public static Color arrowColor = Color.Aqua;

        //for guidlines
        private bool drawGuidlines, drawArrows;

        //1 - 3x3, 2 - 4x4, 3 - custom
        public static int GuidlinesType;

        static Point relativePoint;

        //screen sizes
        public static object[,] RES_DEFAULT = { { 600, 600, 600, 960 }, { 337, 600, 700, 600 } };
        public static object[,] RES_WORKED = new object[2, 4];

        public FormMain()
        {
            InitializeComponent();

            //set transparent
            this.BackColor = ALPHA_KEY_COLOR;
            this.TransparencyKey = ALPHA_KEY_COLOR;

            drawGuidlinesStatus();
            drawArrowStatus();

            //copy daefault data
            RES_WORKED = RES_DEFAULT;

            // Set client size
            this.ClientSize = new System.Drawing.Size(Convert.ToInt32(RES_WORKED[0, 0]), Convert.ToInt32(RES_WORKED[1, 0]));

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

            FormMain.GuidlinesType = 1;

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            contextMenuMain.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void mitSize01_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(Convert.ToInt32(RES_WORKED[0, 0]), Convert.ToInt32(RES_WORKED[1, 0]));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(Convert.ToInt32(RES_WORKED[0, 1]), Convert.ToInt32(Convert.ToInt32(RES_WORKED[1, 1])));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(Convert.ToInt32(Convert.ToInt32(RES_WORKED[0, 2])), Convert.ToInt32(RES_WORKED[1, 2]));

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(Convert.ToInt32(RES_WORKED[0, 3]), Convert.ToInt32(Convert.ToInt32(RES_WORKED[1, 3])));

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

            FinalText = (Text + "WxH, px: " + Width.ToString() + "x" + Height.ToString());

            toolTipMain.SetToolTip(btnScreen, "Take screenshot " + ". Size: " + Width.ToString() + "x" + Height.ToString() + "px");

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

            //Saving the Image File (I am here Saving it in My E drive).
            //captureBitmap.Save(@"D:\Capture.jpg", ImageFormat.Jpeg);


            Clipboard.SetImage(captureBitmap);

            //this.Show();
            pnlToolbarMain.Visible = true;


            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);

            lblInfo.Text = "Screenshot copied to clipboard";

        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            lblInfo.Visible = false;

            this.Refresh();

            if (drawArrows == true)
            {
                Graphics tempGraphics;

                tempGraphics = this.CreateGraphics();

                relativePoint = this.PointToClient(Cursor.Position);

                DrawArrow(tempGraphics, relativePoint, arrowColor, 45);
            }

        }

        private void mitCustomRes_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            FormSet toolForm = new FormSet();

            // Show the settings form
            toolForm.ShowDialog();

            mitSize01.Text = RES_WORKED[0, 0].ToString() + "x" + RES_WORKED[1, 0].ToString();
            mitSize02.Text = RES_WORKED[0, 1].ToString() + "x" + RES_WORKED[1, 1].ToString();
            mitSize03.Text = RES_WORKED[0, 2].ToString() + "x" + RES_WORKED[1, 2].ToString();
            mitSize04.Text = RES_WORKED[0, 3].ToString() + "x" + RES_WORKED[1, 3].ToString();

            this.Refresh();
        }


        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if (drawGuidlines == true)
            {
                DrawLines(e, guidlinesColor);
            }

        }


        private void DrawLines(PaintEventArgs e, Color lineColor)
        {

            int point01Top, point01Left, point02Top, point02Left, point03Top, point03Left;

            if (GuidlinesType == 1)
            {
                point01Top = this.ClientSize.Width / 3;
                point01Left = this.ClientSize.Height / 3;

                point02Top = (this.ClientSize.Width / 3) * 2;
                point02Left = (this.ClientSize.Height / 3) * 2;

                Pen pen = new Pen(lineColor);

                //vertical
                e.Graphics.DrawLine(pen, point01Top, 0, point01Top, this.ClientSize.Height);
                e.Graphics.DrawLine(pen, point02Top, 0, point02Top, this.ClientSize.Height);

                //horizontal
                e.Graphics.DrawLine(pen, 0, point01Left, this.ClientSize.Width, point01Left);
                e.Graphics.DrawLine(pen, 0, point02Left, this.ClientSize.Width, point02Left);
            }
            else
            {

                point01Top = this.ClientSize.Width / 4;
                point01Left = this.ClientSize.Height / 4;

                point02Top = (this.ClientSize.Width / 4) * 2;
                point02Left = (this.ClientSize.Height / 4) * 2;

                point03Top = (this.ClientSize.Width / 4) * 3;
                point03Left = (this.ClientSize.Height / 4) * 3;

                Pen pen = new Pen(lineColor);

                //vertical
                e.Graphics.DrawLine(pen, point01Top, 0, point01Top, this.ClientSize.Height);
                e.Graphics.DrawLine(pen, point02Top, 0, point02Top, this.ClientSize.Height);
                e.Graphics.DrawLine(pen, point03Top, 0, point03Top, this.ClientSize.Height);

                //horizontal
                e.Graphics.DrawLine(pen, 0, point01Left, this.ClientSize.Width, point01Left);
                e.Graphics.DrawLine(pen, 0, point02Left, this.ClientSize.Width, point02Left);
                e.Graphics.DrawLine(pen, 0, point03Left, this.ClientSize.Width, point03Left);

            }


        }




        private void drawGuidlinesStatus()
        {
            if (mitShowGuidlines.CheckState == CheckState.Checked)
            {
                mitShowGuidlines.CheckState = CheckState.Unchecked;
                drawGuidlines = false;
            }
            else
            {
                mitShowGuidlines.CheckState = CheckState.Checked;
                drawGuidlines = true;
            }


        }

        private void drawArrowStatus()
        {
            if (mitShowArrows.CheckState == CheckState.Checked)
            {
                mitShowArrows.CheckState = CheckState.Unchecked;
                drawArrows = false;
            }
            else
            {
                mitShowArrows.CheckState = CheckState.Checked;
                drawArrows = true;
            }
        }

        private void mitShowGuidlines_Click(object sender, EventArgs e)
        {
            drawGuidlinesStatus();
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

        public static void DrawArrow(Graphics g, Point relativePoint, Color color, int Angle)
        {

            Point startPoint = new Point(relativePoint.X + 50, relativePoint.Y + 50);
            Point endPoint = new Point(relativePoint.X, relativePoint.Y);

            var arrowPen = new Pen(color, 1);

            arrowPen.CustomEndCap = new AdjustableArrowCap(8, 8);

            g.DrawLine(arrowPen, startPoint, endPoint);


        }

        private void FormMain_MouseHover(object sender, EventArgs e)
        {

        }
    }

}