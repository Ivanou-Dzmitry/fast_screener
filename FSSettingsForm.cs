
using fast_screener.Properties;
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
            picboxArrowColorSample.BackColor = FormMain.arrowColor;


            switch (FormMain.GuidlinesType)
            {
                case 1:
                    rbGuidType01.Checked = true;
                    break;
                case 2:
                    rbGuidType02.Checked = true;
                    break;
                case 3:
                    rbGuidType03.Checked = true;
                    break;
            }


            switch (FormMain.ArrowsType)
            {
                case 1:
                    rbArrowType01.Checked = true;
                    break;
                case 2:
                    rbArrowType02.Checked = true;
                    break;
                case 3:
                    rbArrowType03.Checked = true;
                    break;
                case 4:
                    rbArrowType04.Checked = true;
                    break;

                default:
                    break;
            }

            tbGridlineTop.Text = FormMain.CUSTOM_GRID[0].ToString();
            tbGridlineBottom.Text = FormMain.CUSTOM_GRID[1].ToString();
            tbGridlineLeft.Text = FormMain.CUSTOM_GRID[2].ToString();
            tbGridlineRight.Text = FormMain.CUSTOM_GRID[3].ToString();

            //get current work resolution
            for (int col = 0; col < 1; col++)
                for (int row = 0; row < FormMain.RES_WORKED.GetLength(1); row++)
                    this.dataGridSize.Rows.Add(FormMain.RES_WORKED[col, row], FormMain.RES_WORKED[1, row]);

            if (FormMain.indentValueLock == true)
            {
                cbLock.Checked = true;
                cbLock_Click(this, EventArgs.Empty);
            }
            else
            {
                cbLock.Checked = false;
                cbLock_Click(this, EventArgs.Empty);
            }
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


            if (rbArrowType01.Checked == true)
            {
                FormMain.ArrowsType = 1;
            }

            if (rbArrowType02.Checked == true)
            {
                FormMain.ArrowsType = 2;
            }

            if (rbArrowType03.Checked == true)
            {
                FormMain.ArrowsType = 3;
            }

            if (rbArrowType04.Checked == true)
            {
                FormMain.ArrowsType = 4;
            }



            try
            {
                FormMain.CUSTOM_GRID[0] = int.Parse(tbGridlineTop.Text);
            }
            catch
            {

                FormMain.CUSTOM_GRID[0] = 10;
            }

            try
            {
                FormMain.CUSTOM_GRID[1] = int.Parse(tbGridlineBottom.Text);
            }
            catch
            {

                FormMain.CUSTOM_GRID[1] = 10;
            }

            try
            {
                FormMain.CUSTOM_GRID[2] = int.Parse(tbGridlineLeft.Text);
            }
            catch
            {

                FormMain.CUSTOM_GRID[2] = 10;
            }

            try
            {
                FormMain.CUSTOM_GRID[3] = int.Parse(tbGridlineRight.Text);
            }
            catch
            {

                FormMain.CUSTOM_GRID[3] = 10;
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
                    lblInfo.BackColor = SystemColors.Control;
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

                    lblInfo.BackColor = SystemColors.Control;
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




        private void tbGridlineTop_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(tbGridlineTop.Text, "[^0-9]"))
            {
                tbGridlineTop.Text = tbGridlineTop.Text.Remove(tbGridlineTop.Text.Length - 1);
            }

            if (Int32.TryParse(tbGridlineTop.Text, out int numValueH) == true && numValueH > FormMain.clientHeight / 2)
            {
                tbGridlineTop.Text = tbGridlineTop.Text.Remove(tbGridlineTop.Text.Length - 1);

            }

            if (FormMain.indentValueLock == true)
            {
                tbGridlineBottom.Text = tbGridlineTop.Text;

                tbGridlineLeft.Text = tbGridlineTop.Text;
                tbGridlineRight.Text = tbGridlineTop.Text;
            }
        }

        private void tbGridlineBottom_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbGridlineBottom.Text, "[^0-9]"))
            {
                tbGridlineBottom.Text = tbGridlineBottom.Text.Remove(tbGridlineBottom.Text.Length - 1);
            }

            if (Int32.TryParse(tbGridlineBottom.Text, out int numValueH) == true && numValueH > FormMain.clientHeight / 2)
            {
                tbGridlineBottom.Text = tbGridlineBottom.Text.Remove(tbGridlineBottom.Text.Length - 1);
            }
        }

        private void tbGridlineLeft_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbGridlineLeft.Text, "[^0-9]"))
            {
                tbGridlineLeft.Text = tbGridlineLeft.Text.Remove(tbGridlineLeft.Text.Length - 1);
            }

            if (Int32.TryParse(tbGridlineLeft.Text, out int numValueW) == true && numValueW > FormMain.clientWidth / 2)
            {
                tbGridlineLeft.Text = tbGridlineLeft.Text.Remove(tbGridlineLeft.Text.Length - 1);
            }
        }

        private void tbGridlineRight_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbGridlineRight.Text, "[^0-9]"))
            {
                tbGridlineRight.Text = tbGridlineRight.Text.Remove(tbGridlineRight.Text.Length - 1);
            }

            if (Int32.TryParse(tbGridlineRight.Text, out int numValueW) == true && numValueW > FormMain.clientWidth / 2)
            {
                tbGridlineRight.Text = tbGridlineRight.Text.Remove(tbGridlineRight.Text.Length - 1);
            }
        }

        private void cbLock_Click(object sender, EventArgs e)
        {
            if (!cbLock.Checked)
            {
                cbLock.Image = Resources.unlocked;
                FormMain.indentValueLock = false;

                tbGridlineBottom.Enabled = true;
                tbGridlineLeft.Enabled = true;
                tbGridlineRight.Enabled = true;
            }
            else
            {
                cbLock.Image = Resources.locked;
                FormMain.indentValueLock = true;

                tbGridlineTop_TextChanged(sender, e);

                tbGridlineBottom.Enabled = false;
                tbGridlineLeft.Enabled = false;
                tbGridlineRight.Enabled = false;
            }

        }
    }
}
