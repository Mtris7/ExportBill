using System;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class ChangeInfo : Form
    {
        public static string SDTChange = string.Empty;
        public static string chk = "true";
        public string TheValue
        {
            get { return SDTTxt.Text; }
        }
        public ChangeInfo()
        {
            InitializeComponent();
            SDTChange = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = Int32.TryParse(SDTTxt.Text, out _);
            if (!result)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SDTChange = SDTTxt.Text;
            this.Close();
        }

        private void SDTMainChk_CheckedChanged(object sender, EventArgs e)
        {
            chk = "true";
        }

        private void SDTChk_CheckedChanged(object sender, EventArgs e)
        {
            chk = "false";
        }
    }
}
