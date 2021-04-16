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
                this.Enabled = false;
                if (string.IsNullOrWhiteSpace(UserNameTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(PassWordTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
                if(!string.IsNullOrEmpty(DXMain.token))
                {
                    string url = @"http://api.ototienthu.com.vn/api/v1/customers/CashierCheckLogin";
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var formContent = new FormUrlEncodedContent(new[]
                        {
                        new KeyValuePair<string, string>("personnalNumberId", UserNameTxt.Text),
                        new KeyValuePair<string, string>("retailStaffPassword", PassWordTxt.Text),
                    });
                    request.Content = formContent;
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var dataList = JsonConvert.DeserializeObject<DataModelString>(body);
                        if (dataList.data.ToString() == "true")
                        {
                            this.Hide();
                            DXMain dx = new DXMain();
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

                this.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
