using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class DXMain : XtraForm
    {
        //##############################################################################################
        #region const
        private const string URL = @"http://api.ototienthu.com.vn/api/v1/oauth/token";
        private const string username = "apitest@tienthu.vn";
        private const string password = "62&z!]r*RV";
        private const string PrBill = "PrintBill";
        private const string PBill = "PostBill"; 
        private const string PostBillStr = "Post Bill"; 
        private const string Posted = "Posted"; 
        private const string MPhieu = "MaPhieu";
        public static string token = string.Empty;
        #endregion
        //###############################################################################################
        #region field
        private BindingList<Customer> ds = new BindingList<Customer>();
        private BindingList<CustomerModel> ListCustomerSearch = new BindingList<CustomerModel>();
        #endregion
        //###############################################################################################
        #region Initialize

        private void DXMain_Load(object sender, EventArgs e)
        {
            this.getToken();
            this.SetCombobox();
            this.SetDefault();
        }
        private void SetCombobox()
        {
            try
            {
                string[] payments = { "Cash", "Net07", "Net15", "Net30", "Net45", "Net60" };
                foreach (var item in payments)
                {
                    cmbPayment.Items.Add(item);
                }
                //cmbPayment.SelectedIndexChanged += SelectItemChange();
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
                this.DatetimeLbl.Text = DateTime.Now.ToLocalTime().ToShortDateString();
                this.dateTimePicker1.Value = DateTime.Now;
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
        #region constructor
        public DXMain()
        {
            InitializeComponent();
        }
        public DXMain(string userName, string companyName)
        {
            InitializeComponent();
            this.CompanyLbl.Text = companyName;
            this.UserNamelbl.Text = userName;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.RowCellClick += gridView1_RowCellClick;
            this.gridView1.Columns["Total"].DisplayFormat.FormatString = "N0";
        }
        #endregion
        //##############################################################################################
        #region event

        private void DatetimeLbl_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            DatetimeLbl.Visible = false;
        }

        /// <summary>
        /// Tạo phiếu dịch vụ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Search2Txt.Text))
                {
                    Point Search2TxtLocation = new Point(groupControl3.Location.X + Search2Txt.Location.X - 10, groupControl3.Location.Y + Search2Txt.Location.Y - 15);
                    toolTip1.Show("Mục bắt buộc nhập.", Search2Txt, Search2TxtLocation);
                    System.Threading.Thread.Sleep(1000);
                    toolTip1.Active = false;
                    toolTip1.Active = true;
                    return;
                }
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/searchcustomers?searchtext="+ Search2Txt.Text+ "&searchtype=";
                if (bsCheck.Checked)
                    url += "LicensePlate";
                else
                    url += "CustomerPhone";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await client.SendAsync(request);
                this.Enabled = true;
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
                        //"C15-030575;LÊ THỊ DIỆU ANH;BẦU CÂU - HÒA CHÂU - HV - ĐN\nHOAVANG\nDANANG\nVNM;0979300094;43H1-16861;2"
                        ListCustomerSearch.Add(new CustomerModel(data[0], data[1],data[2],data[3],data[4],null,data[5]));
                    }
                    this.gridControl3.DataSource = ListCustomerSearch;
                }
                else
                {
                    MessageBox.Show("Có lỗi dữ liệu từ máy chủ, vui lòng đăng nhập lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.ds.Clear();
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/CashierService?personnalNumberId="+ Staff.UserID + "&serviceDate=" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
                if(!string.IsNullOrWhiteSpace(this.SearchControl1Txt.Text))
                {
                    url += "&plateId=" + this.SearchControl1Txt.Text;
                }
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await client.SendAsync(request);
                this.Enabled = true;
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
                        var postBill = data[11] == "Open" ? PostBillStr : Posted;
                        var payment = data[12];
                        //public Customer(string maPhieu, string userName, string bs, string lx, string tsc, string dg, decimal discount, decimal total, string detaiMoney, string company, string adress, string date, string print)
                        ds.Add(new Customer(data[0], data[1], data[2], data[3], data[4], data[5], 
                            Convert.ToInt32(Convert.ToDecimal(data[6])), Convert.ToInt32(Convert.ToDecimal(data[7])),
                            data[8], data[9], data[10],this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), "Print",
                            postBill,payment));
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
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == MPhieu)
                {
                    RunViewBill(e.RowHandle);
                }
                if (e.Column.FieldName == PrBill)
                {
                    RunPrintBill(e.RowHandle);
                }
                if (e.Column.FieldName == PBill && (string)e.CellValue == PostBillStr)
                {
                    RunPostBill(e.RowHandle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridView view = sender as GridView;
                var rowIndex = view.FocusedRowHandle;
                var colI = view.FocusedColumn;
                if (colI == MaPhieu)
                {
                    RunViewBill(rowIndex);
                }
                if (colI == PrintBill)
                {
                    RunPrintBill(rowIndex);
                }
                else if (colI == PostBill)
                {
                    string TheID_Val = view.GetFocusedRowCellValue(PostBill).ToString();
                    if(TheID_Val == PostBillStr)
                        RunPostBill(rowIndex);
                }
            }
        }
        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == PBill)
                {
                    var cellValue = e.CellValue.ToString();
                    if (Posted == cellValue)
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column.FieldName == PrBill || e.Column.FieldName == MPhieu)
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                    e.Cancel = gridView1.FocusedColumn.FieldName == "Payment" && gridView1.GetFocusedRowCellValue(PostBill).ToString() == Posted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Column == CreateService)
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridView view = sender as GridView;
                var rowIndex = view.FocusedRowHandle;
                var colI = view.FocusedColumn;
                if (colI == CreateService)
                {
                    RunCreateService(rowIndex);
                }
            }

        }

        private void gridView3_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column == CreateService)
                {
                    RunCreateService(e.RowHandle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private async void RunPostBill(int row)
        {
            try
            {
                this.Enabled = false;
                var MaPhieu = this.gridView1.GetRowCellValue(row, MPhieu)?.ToString();
                var payment = this.gridView1.GetRowCellValue(row, Payment)?.ToString();
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/PostBillService";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("ServiceOrderId", MaPhieu),
                        new KeyValuePair<string, string>("PaymTermId", payment),
                    });
                request.Content = formContent;
                var response = await client.SendAsync(request);
                this.Enabled = true;
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DataModelString>(body);
                    if(result.data.ToUpper().Contains(("POST BILL THÀNH CÔNG")))
                    {
                        MessageBox.Show(result.data, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridView1.SetRowCellValue(row, PBill, Posted);
                        //gridView1.GetRowCellDisplayText(row, PBill);
                    }
                    else
                        MessageBox.Show(result.data, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Post bill không thành công, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        private void RunPrintBill(int rowIndex)
        {
            try
            {
                var MaPhieu = this.gridView1.GetRowCellValue(rowIndex, MPhieu)?.ToString();
                var pbill = this.gridView1.GetRowCellValue(rowIndex, PBill)?.ToString();
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
                new PrintInvoiceForm(cs, true).ShowDialog();
                if (pbill != Posted)
                {
                    var userResult = AutoClosingMessageBox.Show("Bạn có muốn Post Bill không?", "Thông báo", 5000, MessageBoxButtons.YesNo, DialogResult.No);
                    if (userResult == DialogResult.Yes)
                    {
                        RunPostBill(rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        private void RunViewBill(int rowIndex)
        {
            try
            {
                var MaPhieu = this.gridView1.GetRowCellValue(rowIndex, MPhieu)?.ToString();
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
                new PrintInvoiceForm(cs).ShowDialog();

                var pbill = this.gridView1.GetRowCellValue(rowIndex, PBill)?.ToString();
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        private void RunCreateService(int rowIndex)
        {
            try
            {
                var CustomerNumber = this.gridView3.GetRowCellValue(rowIndex, _CustomerNumber)?.ToString();
                var getData = ListCustomerSearch.Where(x => x.CustomerNumber == CustomerNumber).FirstOrDefault();
                
                var cl = new HttpClient();
                string url = "http://api.ototienthu.com.vn/api/v1/customers/createserviceorder";
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/x-www-form-urlencoded";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("CustAccount", CustomerNumber));
                if (!string.IsNullOrEmpty(getData.PlateID))
                    nvc.Add(new KeyValuePair<string, string>("PlateId", getData.PlateID));

                if (!string.IsNullOrWhiteSpace(CurrentKm.Text))
                    nvc.Add(new KeyValuePair<string, string>("CurrentKM", CurrentKm.Text));

                if (!string.IsNullOrWhiteSpace(ServicePool.Text))
                    nvc.Add(new KeyValuePair<string, string>("ServicePool", ServicePool.Text));

                nvc.Add(new KeyValuePair<string, string>("DimensionStore", Staff.AddressID));

                if (!string.IsNullOrWhiteSpace(NoteTxt.Text))
                    nvc.Add(new KeyValuePair<string, string>("CustRef", NoteTxt.Text));

                //if (!string.IsNullOrEmpty(textBox7.Text))
                //    nvc.Add(new KeyValuePair<string, string>("EngineID", Staff.UserID));

                nvc.Add(new KeyValuePair<string, string>("PersonnelNumberId", Staff.UserID));

                //if (!string.IsNullOrEmpty(textBox9.Text))
                //    nvc.Add(new KeyValuePair<string, string>("InventSerialId", textBox9.Text));
                var req = new HttpRequestMessage(HttpMethod.Post, url);
                req.Content = new FormUrlEncodedContent(nvc);
                var res = cl.SendAsync(req).Result;
                string apiResponse = res.Content.ReadAsStringAsync().Result;
                if (apiResponse != "")
                {
                    var result = (JObject)JsonConvert.DeserializeObject(apiResponse);
                    if (result["data"].Value<string>() != null)
                    {
                        MessageBox.Show("Tạo phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //new PrintInvoiceForm().ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        //##############################################################################################
    }
}