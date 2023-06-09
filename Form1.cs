using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using static System.Windows.Forms.DataFormats;
using System.Reflection.Emit;
using System.Configuration;
using System.Collections.Specialized;

namespace screener3
{

    public partial class FormMain : Form
    {
        public const string PROG_NAME = "Fast Screener 2023";

        public static int NewWidth = 0;
        public static int NewHeight = 0;

        public static int VirtScreenWidth = 0;
        public static int VirtScreenHeight = 0;

        public const int MinWidth = 200;
        public const int MinHeight = 100;

        public FormMain()
        {
            InitializeComponent();

            //set transparent
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

            // Set client size
            this.ClientSize = new System.Drawing.Size(600, 337);

            //Update form name
            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);


            Rectangle VirtScreenRect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

            foreach (Screen screen in Screen.AllScreens)
                VirtScreenRect = Rectangle.Union(VirtScreenRect, screen.Bounds);

            VirtScreenWidth = VirtScreenRect.Width;
            VirtScreenHeight = VirtScreenRect.Height;

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            contextMenuMain.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 337);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 600);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 700);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(960, 600);

            this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
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

        private string TextUpdater(string Text, int Size1, int Size2)
        {
            string FinalText = "";

            FinalText = (Text + ". Size: " + Size1.ToString() + "x" + Size2.ToString() + "px");

            toolTipMain.SetToolTip(btnScreen, "Take screenshot " + ". Size: " + Size1.ToString() + "x" + Size2.ToString() + "px");

            lblInfo.Text = "Size setted to " + Size1.ToString() + "x" + Size2.ToString() + "px";

            lblInfo.Visible = true;
            lblInfo.BackColor = Color.SteelBlue;

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


            if ((NewWidth >= MinWidth) && (NewHeight >= MinHeight))
            {

                this.ClientSize = new System.Drawing.Size(NewWidth, NewHeight);

                this.Text = TextUpdater(PROG_NAME, this.ClientSize.Width, this.ClientSize.Height);

            }
            else
            {
                lblInfo.Text = "Ñan't set size! Minimum size is 200x100px";
                lblInfo.BackColor = Color.DarkRed;
                lblInfo.Visible = true;
            }
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {

        }
    }
}