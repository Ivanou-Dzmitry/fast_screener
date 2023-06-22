using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
        private Color ALPHA_KEY_COLOR = Color.FromArgb(255, 1, 254, 1);

        //default guidlines color
        public static Color guidlinesColor = Color.LightGray;

        //for guidlines
        private bool drawGuidlines;


        //screen sizes
        public static int[,] resArray = { { 600, 600, 600, 960 }, { 337, 600, 700, 600 } };

        public FormMain()
        {
            InitializeComponent();

            //set transparent
            this.BackColor = ALPHA_KEY_COLOR;
            this.TransparencyKey = ALPHA_KEY_COLOR;

            drawGuidlinesStatus();

            // Set client size
            this.ClientSize = new System.Drawing.Size(resArray[0, 0], resArray[1, 0]);

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

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            contextMenuMain.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void mitSize01_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(resArray[0, 0], resArray[1, 0]);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(resArray[0, 1], resArray[1, 1]);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(resArray[0, 2], resArray[1, 2]);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(resArray[0, 3], resArray[1, 3]);

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

            FinalText = (Text + "Size: " + Width.ToString() + "x" + Height.ToString() + "px");

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

            this.Hide();

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

            this.Show();

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);

            lblInfo.Text = "Screenshot copied to clipboard";

        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void mitCustomRes_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            FormTool toolForm = new FormTool();

            // Show the settings form
            toolForm.ShowDialog();


            if ((NewWidth >= MIN_WIDTH) && (NewHeight >= MIN_HEIGHT))
            {

                this.ClientSize = new System.Drawing.Size(NewWidth, NewHeight);

                this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);

            }
            else
            {
                lblInfo.Text = "Ñan't set size! It doesn't fit within the limits.";
                lblInfo.BackColor = Color.DarkRed;
                lblInfo.Visible = true;
            }

            this.Refresh();
        }


        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if (drawGuidlines == true)
            {
                DrawLines(e, guidlinesColor);
            }

        }

        private void ClearDrawings(PaintEventArgs e, Color colorToClear)
        {
            // Clear screen with teal background.
            e.Graphics.Clear(colorToClear);
        }


        private void DrawLines(PaintEventArgs e, Color lineColor)
        {
            int p1, p2, p3, p4;

            p1 = this.ClientSize.Width / 3;
            p2 = this.ClientSize.Height / 3;

            p3 = (this.ClientSize.Width / 3) * 2;
            p4 = (this.ClientSize.Height / 3) * 2;

            //Color lineColor = Color.FromArgb(128, 0, 254, 0);

            Pen pen = new Pen(lineColor);

            //vertical
            e.Graphics.DrawLine(pen, p1, 0, p1, this.ClientSize.Height);
            e.Graphics.DrawLine(pen, p3, 0, p3, this.ClientSize.Height);

            //horizontal
            e.Graphics.DrawLine(pen, 0, p2, this.ClientSize.Width, p2);
            e.Graphics.DrawLine(pen, 0, p4, this.ClientSize.Width, p4);
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

        private void mitShowGuidlines_Click(object sender, EventArgs e)
        {
            drawGuidlinesStatus();
            this.Refresh();
        }

        private void mitTakeScreen_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }


    }
}