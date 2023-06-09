﻿
using fast_screener;
using fast_screener.Properties;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace screener3
{
    public partial class FormSet : Form
    {

        private string limitsText = "Limits (WxH): max " + FormMain.VirtScreenWidth.ToString() + "x" + FormMain.VirtScreenHeight.ToString() + ", min " + FormMain.MIN_WIDTH.ToString() + "x" + FormMain.MIN_HEIGHT.ToString();

        public FormSet()
        {
            InitializeComponent();

            picboxGuidlineColorSample.BackColor = FormMain.gridColor;
            picboxArrowColorSample.BackColor = FormMain.arrowColor;
            picboxNumberColorSample.BackColor = FormMain.numberColor;


            switch (FormMain.GridType)
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


            switch (FormMain.ArrowType)
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

            tbNumberFontSize.Text = FormMain.numberFontSize.ToString();

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

            //hypotinusa
            int arrowLenght = Convert.ToInt32(CalcHypo(FormMain.clientWidth, FormMain.pnlToolBarH));


            trackBarArrowLenght.Maximum = arrowLenght;

            string trackBarArrowLenghtToolTip = "Arrow lenght. Min 30, Max " + arrowLenght.ToString();

            toolTipTool.SetToolTip(trackBarArrowLenght, trackBarArrowLenghtToolTip);

            lbArrowLenght.Text = trackBarArrowLenght.Value.ToString();

            try
            {
                trackBarArrowLenght.Value = FormMain.arrowLenght;
            }
            catch
            {
                trackBarArrowLenght.Value = trackBarArrowLenght.Maximum;
            }

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

        }


        private void SettingCloseActions()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++)
                    FormMain.RES_WORKED[i, j] = dataGridSize.Rows[j].Cells[i].Value;


            if (rbGuidType01.Checked == true)
            {
                FormMain.GridType = 1;
            }

            if (rbGuidType02.Checked == true)
            {
                FormMain.GridType = 2;
            }

            if (rbGuidType03.Checked == true)
            {
                FormMain.GridType = 3;
            }


            if (rbArrowType01.Checked == true)
            {
                FormMain.ArrowType = 1;
            }

            if (rbArrowType02.Checked == true)
            {
                FormMain.ArrowType = 2;
            }

            if (rbArrowType03.Checked == true)
            {
                FormMain.ArrowType = 3;
            }

            if (rbArrowType04.Checked == true)
            {
                FormMain.ArrowType = 4;
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

            FormMain.arrowLenght = trackBarArrowLenght.Value;

            try
            {
                FormMain.numberFontSize = int.Parse(tbNumberFontSize.Text);
            }
            catch
            {

                FormMain.numberFontSize = 26;
            }


        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //set data update
            SettingCloseActions();

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
                FormMain.gridColor = colorDialogGlines.Color;
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

        private void trackBarArrowLenght_ValueChanged(object sender, EventArgs e)
        {

            lbArrowLenght.Text = trackBarArrowLenght.Value.ToString();
        }

        private double CalcHypo(int width, int height)
        {
            double side1, side2, hypo;
            side1 = Convert.ToDouble(width);
            side2 = Convert.ToDouble(height);
            hypo = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2));

            return hypo;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //set data update
            SettingCloseActions();
        }

        private void lbArrowLenght_Click(object sender, EventArgs e)
        {
            trackBarArrowLenght.Value = 50;
        }

        private void picboxNumberColorSample_Click(object sender, EventArgs e)
        {
            if (colorDialogGlines.ShowDialog() == DialogResult.OK)
            {
                picboxNumberColorSample.BackColor = colorDialogGlines.Color;
                FormMain.numberColor = colorDialogGlines.Color;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbNumberFontSize.Text, "[^0-9]"))
            {
                tbNumberFontSize.Text = tbNumberFontSize.Text.Remove(tbNumberFontSize.Text.Length - 1);
            }

            int maxFontSize = 96, minFontSize = 8;

            if (Int32.TryParse(tbNumberFontSize.Text, out int numValueW) == true && numValueW > maxFontSize)
            {
                tbNumberFontSize.Text = tbNumberFontSize.Text.Remove(tbNumberFontSize.Text.Length - 1);
            }

            if (tbNumberFontSize.Text == "0")
                tbNumberFontSize.Text = minFontSize.ToString();

        }

        private void rbGuidType01_Click(object sender, EventArgs e)
        {
            FormMain.GridType = 1;
        }

        private void rbGuidType02_Click(object sender, EventArgs e)
        {
            FormMain.GridType = 2;
        }

        private void rbGuidType03_Click(object sender, EventArgs e)
        {
            FormMain.GridType = 3;
        }
    }
}
