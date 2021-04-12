using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ExportBill
{
    public partial class DXMain : DevExpress.XtraEditors.XtraForm
    {
        //##############################################################################################
        #region const
        private const string URL = @"http://api.ototienthu.com.vn/api/v1/oauth/token";
        private const string username = "apitest@tienthu.vn";
        private const string password = "62&z!]r*RV";
        public static string token = string.Empty;
        #endregion
        //###############################################################################################
        #region Initialize
        public void MainLoad()
        {
            try
            {
                this.getToken();
                SetDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        //##############################################################################################
        public DXMain()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }
        

        private void DXMain_Load(object sender, EventArgs e)
        {
            this.getToken();
            SetDefault();
        }

        private  void button2_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {


            try
            {
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/CashierService?personnalNumberId=TT_0762_16092016&serviceDate=" + this.dateTimePicker1.Text;
                if(!string.IsNullOrWhiteSpace(this.SearchControl1Txt.Text))
                {
                    url += "&plateId=" + this.SearchControl1Txt.Text;
                }
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var dataList = JsonConvert.DeserializeObject<DataModel>(body);
                    if (dataList.data == null)
                    {
                        MessageBox.Show("Có lỗi dữ liệu từ máy chủ, vui lòng đăng nhập lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dataList.data.Count == 0)
                    {
                        DialogResult result = MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    BindingList<Customer> ds = new BindingList<Customer>();
                    foreach (var item in dataList.data)
                    {
                        var data = item.Split(';');
                        //customer( view,  userName,  bs,  lx,  tsc,  dg,  tt,  shop,  adress,  print))
                        ds.Add(new Customer(data[0], data[1], data[2], data[3], data[4], data[5], Convert.ToDecimal(data[6]), data[7], data[8], "print"));
                    }
                    this.gridControl1.DataSource = ds;
                }
                else
                {
                    MessageBox.Show("Có lỗi dữ liệu từ máy chủ, vui lòng đăng nhập lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //##############################################################################################
        #region method
        public async void getToken()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, URL);
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("grant_type", "password"),
                    });
                request.Content = formContent;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonConvert.DeserializeObject<Token>(body);
                    DXMain.token = tokenData.access_token;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetDefault()
        {
            try
            {
                this.DatetimeLbl.Text = this.DatetimeLbl2.Text = DateTime.Now.ToLocalTime().ToShortDateString();
                //this.egencylb.Text = this.egencylb2.Text = "";
                //this.Diemltn.Text = this.Diemltn2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //##############################################################################################
    }
    public class Customer
    {
        public Customer() { }
        public Customer(string view, string userName, string bs, string lx, string tsc, string dg, decimal tt, string shop, string adress, string print)
        {
            View = view;
            UserName = userName;
            BS = bs;
            LX = lx;
            TSC = tsc;
            DG = dg;
            TT = tt;
            Shop = shop;
            Adress = adress;
            PrintBill = print;
        }
        public string View { get; set; }
        public string UserName { get; set; }
        public string BS { get; set; }
        public string LX { get; set; }
        public string TSC { get; set; }
        public string DG { get; set; }
        public decimal TT { get; set; }
        public string Shop { get; set; }
        public string Adress { get; set; }
        public string PrintBill { get; set; }
    }
}