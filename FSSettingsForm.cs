
using System.Reflection.Emit;
using System.Windows.Forms;

namespace screener3
{
    public partial class FormTool : Form
    {

        public Color guidlinesColor;
        private int MaxRows = 4;
        private string limitsText = "Limits (WxH): max " + FormMain.VirtScreenWidth.ToString() + "x" + FormMain.VirtScreenHeight.ToString() + ", min 200x100";


        public FormTool()
        {
            InitializeComponent();

            picboxGuidlineColorSample.BackColor = FormMain.guidlinesColor;

            tbWidth.Text = FormMain.clientWidth.ToString();
            tbHeight.Text = FormMain.clientHeight.ToString();

            string text1 = "";

            for (int col = 0; col < FormMain.resArray.GetLength(0) - 1; col++)
                for (int row = 0; row < FormMain.resArray.GetLength(1); row++)
                    this.dataGridSize.Rows.Add(FormMain.resArray[col, row], FormMain.resArray[col + 1, row]);


            lbTest.Text = text1;

        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbWidth.Text, "[^0-9]"))
            {
                tbWidth.Text = tbWidth.Text.Remove(tbWidth.Text.Length - 1);
            }

            if (Int32.TryParse(tbWidth.Text, out int numValueW) == true && numValueW > FormMain.VirtScreenWidth)
            {
                tbWidth.Text = tbWidth.Text.Remove(tbWidth.Text.Length - 1);
            }
        }

        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbHeight.Text, "[^0-9]"))
            {
                tbHeight.Text = tbHeight.Text.Remove(tbHeight.Text.Length - 1);
            }

            if (Int32.TryParse(tbHeight.Text, out int numValueH) == true && numValueH > FormMain.VirtScreenHeight)
            {
                tbHeight.Text = tbHeight.Text.Remove(tbHeight.Text.Length - 1);
            }
        }

        private void FormTool_Deactivate(object sender, EventArgs e)
        {

            if (Int32.TryParse(tbWidth.Text, out int numValueW))
            {
                FormMain.NewWidth = numValueW;
            }
            else
            {
                FormMain.NewWidth = 0;
            }

            if (Int32.TryParse(tbHeight.Text, out int numValueH))
            {
                FormMain.NewHeight = numValueH;
            }
            else
            {
                FormMain.NewHeight = 0;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormTool_Activated(object sender, EventArgs e)
        {
            lblInfo.Text = limitsText;
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }



        private void picboxGuidlineColorSample_Click(object sender, EventArgs e)
        {
            if (colorDialogGlines.ShowDialog() == DialogResult.OK)
            {
                picboxGuidlineColorSample.BackColor = colorDialogGlines.Color;
                FormMain.guidlinesColor = colorDialogGlines.Color;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridSize_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 1 should be your column index
            {

                if (!int.TryParse(e.FormattedValue.ToString(), out int numValueW) || numValueW > FormMain.VirtScreenWidth || numValueW < FormMain.MIN_WIDTH)
                {
                    e.Cancel = true;
                    lblInfo.BackColor = Color.Tomato;
                    lblInfo.Text = "Width incorrect! " + limitsText;
                }
                else
                {
                    // the input is numeric 
                    lblInfo.BackColor = Color.DarkSeaGreen;
                    lblInfo.Text = limitsText;
                }
            }

            if (e.ColumnIndex == 1) // 1 should be your column index
            {

                if (!int.TryParse(e.FormattedValue.ToString(), out int numValueH) || numValueH > FormMain.VirtScreenHeight || numValueH < FormMain.MIN_HEIGHT)
                {
                    e.Cancel = true;
                    lblInfo.BackColor = Color.Tomato;
                    lblInfo.Text = "Height incorrect! " + limitsText;
                }
                else
                {
                    // the input is numeric 

                    lblInfo.BackColor = Color.DarkSeaGreen;
                    lblInfo.Text = limitsText;
                }
            }
        }

        private void dataGridSize_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
