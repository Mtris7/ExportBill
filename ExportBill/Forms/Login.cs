using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class Login : Form
    {
        public Login()
        {
            try
            {
                InitializeComponent();
                this.getToken();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserNameTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PassWordTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string user = UserNameTxt.Text;
                string passw = PassWordTxt.Text;
                if (bunifuCheckbox1.Checked)
                {
                    Properties.Settings.Default.userName = user;
                    Properties.Settings.Default.passWord = passw;
                    Properties.Settings.Default.Save();
                }
                if (!string.IsNullOrEmpty(Settings.token))
                {
                    this.Enabled = false;
                    string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/CashierCheckLogin";
                    var formContent = new FormUrlEncodedContent(new[]
                        {
                        new KeyValuePair<string, string>("personnalNumberId", user),
                        new KeyValuePair<string, string>("retailStaffPassword", passw),
                    });
                    GetAPI Login = new GetAPI();
                    var response = await Login.post(url, formContent);
                    this.Enabled = true;
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                         var dataList = JsonConvert.DeserializeObject<DataModelString>(body);
                        if (dataList.data == null)
                        {
                            MessageBox.Show("Hệ thống AX đang bị lỗi, vui lòng đăng nhập sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var data = dataList.data.Split(';');
                        if (data[0] == "true")
                        {
                            Staff.UserID = user;
                            Staff.passWord = passw;
                            Staff.UserName = data[1];
                            Staff.Address = data[2];
                            Staff.AddressID = data[3];
                            Staff.Phone = data[4];
                            this.Hide();
                            DXMain dx = new DXMain(data[1], data[2]);
                            dx.Closed += (s, args) => this.Close();
                            dx.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Không kết nối được với máy chủ, vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Không kết nối được với máy chủ, vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuCheckbox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    bunifuCheckbox1.Checked = !bunifuCheckbox1.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                new ChangePassword().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void getToken()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, Settings.URL);
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", Settings.userName),
                        new KeyValuePair<string, string>("password", Settings.passWord),
                        new KeyValuePair<string, string>("grant_type", "password"),
                    });
                request.Content = formContent;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonConvert.DeserializeObject<Token>(body);
                    Settings.token = tokenData.access_token;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
