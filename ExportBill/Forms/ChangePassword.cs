using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class ChangePassword : XtraForm
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        
        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserNameTxt.Text) ||
                    string.IsNullOrWhiteSpace(PassWordTxt.Text) ||
                    string.IsNullOrWhiteSpace(NewPasswordTxt.Text) ||
                    string.IsNullOrWhiteSpace(ConfirmPasswordTxt.Text))
                {
                    MessageBox.Show("Nôi dung không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!NewPasswordTxt.Text.Equals(ConfirmPasswordTxt.Text))
                {
                    MessageBox.Show("Mật khẩu xác nhân không hợp lệ. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Enabled = false;
                string url = @"http://"+ Settings.API +".ototienthu.com.vn/api/v1/customers/CashierChangePassword";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("personnalNumberId", UserNameTxt.Text),
                        new KeyValuePair<string, string>("retailStaffPassword", PassWordTxt.Text),
                        new KeyValuePair<string, string>("newPassword", NewPasswordTxt.Text),
                    });
                request.Content = formContent;
                var response = await client.SendAsync(request);
                this.Enabled = true;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}