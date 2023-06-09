using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace screener3
{
    public partial class FormTool : Form
    {
        public FormTool()
        {
            InitializeComponent();
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
            lblInfo.Text = "Max: " + FormMain.VirtScreenWidth.ToString() + "x" + FormMain.VirtScreenHeight.ToString() + "px. Min: 200x100px";
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
