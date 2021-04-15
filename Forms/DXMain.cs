using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class DXMain : DevExpress.XtraEditors.XtraForm
    {
        //##############################################################################################
        #region const
        private const string URL = @"http://api.ototienthu.com.vn/api/v1/oauth/token";
        private const string username = "apitest@tienthu.vn";
        private const string password = "62&z!]r*RV";
        private const string PBill = "Post Bill";
        public static string token = string.Empty;
        #endregion
        //###############################################################################################
        #region field
        private BindingList<Customer> ds = new BindingList<Customer>();
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
        #region constructor
        public DXMain()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.RowCellClick += gridView1_RowCellClick;
        }
        #endregion
        //##############################################################################################
        #region event

        private void DXMain_Load(object sender, EventArgs e)
        {
            this.getToken();
            SetDefault();
        }


        private void DatetimeLbl_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            DatetimeLbl.Visible = false;
        }
        private  void button2_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.ds.Clear();
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
                    foreach (var item in dataList.data)
                    {
                        var data = item.Split(';');
                        //public Customer(string maPhieu, string userName, string bs, string lx, string tsc, string dg, decimal discount, decimal total, string detaiMoney, string company, string adress, string date, string print)
                        ds.Add(new Customer(data[0], data[1], data[2], data[3], data[4], data[5], Convert.ToInt32(Convert.ToDecimal(data[6])), Convert.ToInt32(Convert.ToDecimal(data[7])), data[8], data[9], data[10],this.dateTimePicker1.Text, PBill));
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
        void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "MaPhieu")
            {
                var getData = ds.Where(x => x.MaPhieu == (string)e.CellValue).FirstOrDefault();
                Customer cs = new Customer();
                cs.MaPhieu = getData.MaPhieu;
                cs.UserName = getData.UserName;
                cs.BS = getData.BS;
                cs.LX = getData.LX;
                cs.TSC = getData.TSC;
                cs.DG = getData.DG;
                cs.Total = getData.Total;
                cs.Company = getData.Company;
                cs.Adress = getData.Adress;
                cs.Discount = getData.Discount;
                cs.DetailMoney = getData.DetailMoney;
                cs.Date = getData.Date;
                new PrintInvoiceForm(cs).ShowDialog();
            }
            if(e.Column.FieldName == PBill)
            {
                var MaPhieu = this.gridView1.GetRowCellValue(e.RowHandle, "MaPhieu")?.ToString();
                var getData = ds.Where(x => x.MaPhieu == MaPhieu).FirstOrDefault();
                Customer cs = new Customer();
                cs.MaPhieu = getData.MaPhieu;
                cs.UserName = getData.UserName;
                cs.BS = getData.BS;
                cs.LX = getData.LX;
                cs.TSC = getData.TSC;
                cs.DG = getData.DG;
                cs.Total = getData.Total;
                cs.Company = getData.Company;
                cs.Adress = getData.Adress;
                cs.Discount = getData.Discount;
                cs.DetailMoney = getData.DetailMoney;
                cs.Date = getData.Date;
                new PrintInvoiceForm(cs, true).ShowDialog(); ;
            }
        }
        #endregion
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
}