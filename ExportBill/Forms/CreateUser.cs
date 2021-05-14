using ExportBill.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
            MainLoad();
        }
        public void MainLoad()
        {
        }
        private IGetAPI getApi;
        private void CreateSaveBtn_Click(object sender, EventArgs e)
        {
            string maKH = string.Empty;
            this.Close();
            new CreateService(maKH, NameTxt.Text,BSTxt.Text).ShowDialog();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                if (string.IsNullOrWhiteSpace(NameTxt.Text) ||
                    string.IsNullOrWhiteSpace(CMNDTxt.Text))
                {
                    MessageBox.Show("Họ Tên và Mã ID không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Enabled = false;
                    string url = @"http://api.ototienthu.com.vn/api/v1/customers/createcustomer";
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var formContent = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("HcmPersonnelNumberId", CMNDTxt.Text),
                            new KeyValuePair<string, string>("FirstName", NameTxt.Text),
                            new KeyValuePair<string, string>("Gender", comboBox1.Text),
                            new KeyValuePair<string, string>("CMND", CMNDTxt.Text),
                            new KeyValuePair<string, string>("CustomerAddress", StreetTxt.Text + ";" + DictrictTxt.Text + ";" + CityTxt.Text),
                            new KeyValuePair<string, string>("Phone", SDTTxt.Text),
                            new KeyValuePair<string, string>("Provine", NoteTxt.Text),
                        });
                    request.Content = formContent;
                    var response = getApi.post(url, formContent);
                    this.Enabled = true;
                    if (response.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đăng kí thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí không thành công", "Thông báo");
                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
