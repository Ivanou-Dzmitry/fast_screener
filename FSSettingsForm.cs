
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace screener3
{
    public partial class FormSet : Form
    {

        public Color guidlinesColor;

        private string limitsText = "Limits (WxH): max " + FormMain.VirtScreenWidth.ToString() + "x" + FormMain.VirtScreenHeight.ToString() + ", min 200x100";

        public FormSet()
        {
            InitializeComponent();

            picboxGuidlineColorSample.BackColor = FormMain.guidlinesColor;


            if (FormMain.GuidlinesType == 1)
            {
                rbGuidType01.Checked = true;
            }


            if (FormMain.GuidlinesType == 2)
            {
                rbGuidType02.Checked = true;
            }


            if (FormMain.GuidlinesType == 3)
            {
                rbGuidType03.Checked = true;
            }



            //get current work resolution
            for (int col = 0; col < 1; col++)
                for (int row = 0; row < FormMain.RES_WORKED.GetLength(1); row++)
                    this.dataGridSize.Rows.Add(FormMain.RES_WORKED[col, row], FormMain.RES_WORKED[1, row]);


        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //set data update
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++)
                    FormMain.RES_WORKED[i, j] = dataGridSize.Rows[j].Cells[i].Value;


            if (rbGuidType01.Checked == true)
            {
                FormMain.GuidlinesType = 1;
            }

            if (rbGuidType02.Checked == true)
            {
                FormMain.GuidlinesType = 2;
            }

            if (rbGuidType03.Checked == true)
            {
                FormMain.GuidlinesType = 3;
            }

            Close();
        }

        private void FormTool_Activated(object sender, EventArgs e)
        {
            lblInfo.Text = limitsText;
        }

        private void picboxGuidlineColorSample_Click(object sender, EventArgs e)
        {
            if (colorDialogGlines.ShowDialog() == DialogResult.OK)
            {
                picboxGuidlineColorSample.BackColor = colorDialogGlines.Color;
                FormMain.guidlinesColor = colorDialogGlines.Color;
            }
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

        private void rbGuidType03_CheckedChanged(object sender, EventArgs e)
        {


            if (rbGuidType03.Checked == true)
            {
                pnlGMargin.Enabled = true;
            }
            else
            {
                pnlGMargin.Enabled = false;
            }
        }

        private void picboxArrowColorSample_Click(object sender, EventArgs e)
        {
            if (colorDialogGlines.ShowDialog() == DialogResult.OK)
            {
                picboxArrowColorSample.BackColor = colorDialogGlines.Color;
                FormMain.arrowColor = colorDialogGlines.Color;
            }
        }
    }
}
