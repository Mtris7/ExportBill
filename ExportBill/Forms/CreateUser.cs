using ExportBill.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                if (string.IsNullOrWhiteSpace(NameTxt.Text) ||
                    string.IsNullOrWhiteSpace(BSTxt.Text) ||
                    string.IsNullOrWhiteSpace(SDTTxt.Text))
                {
                    MessageBox.Show("Tên Khách hàng, Biển số và SĐT Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Enabled = false;
                    string url = @"http://api.ototienthu.com.vn/api/v1/customers/createcustomer";
                    var data_create = new List<KeyValuePair<string, string>>();
                    data_create.Add(new KeyValuePair<string, string>("FirstName", NameTxt.Text));
                    data_create.Add(new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID));
                    data_create.Add(new KeyValuePair<string, string>("Fax", "0979300094"));
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                        data_create.Add(new KeyValuePair<string, string>("Gender", comboBox1.Text));
                    if (!string.IsNullOrEmpty(dateTimePicker1.Text))
                        data_create.Add(new KeyValuePair<string, string>("DateOfBirth", dateTimePicker1.Text));
                    if (!string.IsNullOrEmpty(SDTTxt.Text))
                        data_create.Add(new KeyValuePair<string, string>("Phone", SDTTxt.Text));
                    if (!string.IsNullOrEmpty(CMNDTxt.Text))
                        data_create.Add(new KeyValuePair<string, string>("CMND", CMNDTxt.Text));
                    if (!string.IsNullOrEmpty(StreetTxt.Text))
                        data_create.Add(new KeyValuePair<string, string>("CustomerAddress", StreetTxt.Text));
                    if (!string.IsNullOrEmpty(DictrictTxt.Text))
                        data_create.Add(new KeyValuePair<string, string>("District", DictrictTxt.Text));
        
                                FormUrlEncodedContent formContent = new FormUrlEncodedContent(data_create);
                    GetAPI get_API = new GetAPI();
                    var response = get_API.Post_NoAsyn(url, formContent);

                    string _url = @"http://api.ototienthu.com.vn/api/v1/customers/createplate";
                    var data_create1 = new List<KeyValuePair<string, string>>();
                    data_create1.Add(new KeyValuePair<string, string>("LicensePlate", BSTxt.Text));
                    if (!string.IsNullOrEmpty(comboBox3.Text))
                        data_create1.Add(new KeyValuePair<string, string>("CategoryName", comboBox3.Text));
                    if (!string.IsNullOrEmpty(dateTimePicker2.Text))
                        data_create1.Add(new KeyValuePair<string, string>("InvoceDate", dateTimePicker2.Text));
                    if (!string.IsNullOrEmpty(SDTTxt.Text))
                        data_create1.Add(new KeyValuePair<string, string>("CustomerPhone", SDTTxt.Text));
                    FormUrlEncodedContent _formContent = new FormUrlEncodedContent(data_create1);
                    var _response = get_API.Post_NoAsyn(_url, _formContent);
                    this.Enabled = true;
                    if(!response.Equals("") && !_response.Equals(""))

                    {
                        
                        var result = (JObject)JsonConvert.DeserializeObject(response);
                        var result1 = (JObject)JsonConvert.DeserializeObject(_response);
                        string test = result["data"].Value<string>();
                        bool check = response.ToString().Contains("status: true");
                        if (result["status"].Value<string>().ToUpper().Contains("TRUE")  && result1["status"].Value<string>().ToUpper().Contains("TRUE"))
                        {
                            MessageBox.Show("Đăng kí thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Đăng kí không thành công", "Thông báo");
                        }
                        return;
                        
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí không thành công", "Thông báo");
                        return;
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
