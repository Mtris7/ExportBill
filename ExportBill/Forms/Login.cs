using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            DXMain dXMain = new DXMain();
            dXMain.getToken();
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
                if (!string.IsNullOrEmpty(DXMain.token))
                {
                    this.Enabled = false;
                    string url = @"http://api.ototienthu.com.vn/api/v1/customers/CashierCheckLogin";
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var formContent = new FormUrlEncodedContent(new[]
                        {
                        new KeyValuePair<string, string>("personnalNumberId", user),
                        new KeyValuePair<string, string>("retailStaffPassword", passw),
                    });
                    request.Content = formContent;
                    var response = await client.SendAsync(request);
                    this.Enabled = true;
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                         var dataList = JsonConvert.DeserializeObject<DataModelString>(body);
                        if (dataList.data == null)
                        {
                            MessageBox.Show("Hệ thống AX đang bị lỗi, vui lòng đăng nhập sau!");
                            return;
                        }
                        var data = dataList.data.Split(';');
                        if (data[0] == "true")
                        {
                            this.Hide();
                            DXMain dx = new DXMain(data[1],data[2]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void bunifuCheckbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bunifuCheckbox1.Checked = !bunifuCheckbox1.Checked;
            }
        }
    }
}
