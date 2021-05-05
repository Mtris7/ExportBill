﻿using DevExpress.XtraEditors;
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
        private BindingList<ItemSell> ListIS = new BindingList<ItemSell>();
        private BindingList<StaffModel> ListSM = new BindingList<StaffModel>();
        private CustomerModel sSelect;
        private string servicePool = "KTDK";
        private string ServiceId = string.Empty;
        #endregion
        //###############################################################################################
        #region Initialize

        private void DXMain_Load(object sender, EventArgs e)
        {
            this.getToken();
            this.SetDefault();
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
            InitializeGrid();
            InitializeCombobox();
            this.CompanyLbl.Text = companyName;
            this.UserNamelbl.Text = userName;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.RowCellClick += gridView1_RowCellClick;
            InitializeDefaultStyle();

        }
        #endregion
        //##############################################################################################
        #region Initialize
        public void InitializeGrid()
        {

            try
            {
                //gridView2
                BindingList<ItemSell> ds = new BindingList<ItemSell>();
                //var a = new ItemSell("b");
                //ds.Add(a);
                this.gridControl2.DataSource = ds;
                this.gridView2.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        public void InitializeCombobox()
        {

            try
            {
                string[] payments = { "Cash", "Net07", "Net15", "Net30", "Net45", "Net60" };
                foreach (var item in payments)
                {
                    cmbPayment.Items.Add(item);
                }
                LoadItemCombobox();
                LoadWorkerCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void InitializeDefaultStyle()
        {
            try
            {
                this.gridView1.Columns["Total"].DisplayFormat.FormatString = "N0";
                this.pHeader.Enabled = false;
                this.gridControl2.Enabled = false;
                this.pFooter.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        #region grid 1 danh sách xe
        void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
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
                    if (TheID_Val == PostBillStr)
                        RunPostBill(rowIndex);
                }
            }
            catch(Exception ex)
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
        #endregion

        #region Grid2 Create ServiceLine
        private void ServicePool_EditValueChanged(object sender, EventArgs e)
        {
            switch(ServicePool.SelectedIndex)
            {
                case 0://Kiểm tra định kỳ
                    servicePool = "KTDK";
                    break;
                case 1://Kiểm tra định kỳ thiện chí
                    servicePool = "KTDKTC";
                    break;
                case 2://Sửa chữa lưu động
                    servicePool = "SCLD";
                    break;
                case 3://Sửa chữa - thay thế phụ tùng
                    servicePool = "SCPT";
                    break;
                case 4: // Sửa chữa thiện chí
                    servicePool = "SCTC";
                    break;
                case 5: //Sửa chữa xe bảo hiểm
                    servicePool = "XEBH";
                    break;
                case 6: //Sửa chữa xe bảo hành
                    servicePool = "XEBHANH";
                    break;
                case 7://Sửa chữa xe tai nạn
                    servicePool = "XETN";
                    break;
            }
        }


        private void CreatePrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                if (RunCreateHeader())
                {
                    if (RunCreateLine())
                    {
                        this.Enabled = true;
                        MessageBox.Show("Tạo phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        
                    else
                        MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Enabled = true;
            }
            catch(Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }


        private void gridView2_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedRowHandle == this.gridView2.RowCount - 1 && !string.IsNullOrWhiteSpace(this.gridView2.GetRowCellValue(view.FocusedRowHandle, e.FocusedColumn)?.ToString()))
                    this.gridView2.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RemoveCol_Click(object sender, EventArgs e)
        {
            try
            {
                this.gridView2.DeleteRow(this.gridView2.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Value?.ToString())) return;

                var check = e.Value?.ToString().All(char.IsDigit);

                if (e.Column.Equals(_DiscountGrid2))
                {
                    if (check ?? false)
                        this.gridView2.SetRowCellValue(e.RowHandle, _DiscountGrid2, Convert.ToDecimal(e.Value ?? 0).ToString("N0"));
                }

               
                if (e.Column.Equals(_ItemName))
                {
                    //Mã SP; Tên SP; Giá bán: số lượng bán mặc định; tồn kho; ĐVT
                    var item = ListIS.Where(x => x.ItemName.Equals(this.gridView2.GetRowCellValue(e.RowHandle, _ItemName)));
                    if (!item.Any()) return;
                    var itemID = item.First().ItemID;
                    var itemPrice = item.First().ItemPrice;
                    var itemUnit = item.First().ItemUnit;
                    //var itemInventory = item.First().Inventory;
                    var itemTotal = item.First().Total;
                    this.gridView2.SetRowCellValue(e.RowHandle, _ItemName, e.Value);
                    this.gridView2.SetRowCellValue(e.RowHandle, _ItemPrice, Convert.ToDecimal(itemPrice).ToString("N0"));
                    this.gridView2.SetRowCellValue(e.RowHandle, _TotalGrid2, Convert.ToDecimal(itemTotal).ToString("N0"));
                    this.gridView2.SetRowCellValue(e.RowHandle, _ItemUnit, itemUnit);

                }
                if (e.Column.Equals(_ItemUnit))
                {
                    var itemPrice = this.gridView2.GetRowCellValue(e.RowHandle, _ItemPrice);
                    var total = Convert.ToDecimal(itemPrice) * Convert.ToDecimal(e.Value);
                    if (check ?? false)
                    {
                        this.gridView2.SetRowCellValue(e.RowHandle, _TotalGrid2, total.ToString("N0"));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        #region grid3 Create Service Header

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
                    //RunCreateService(rowIndex);
                }
            }

        }

        private void gridView3_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column == CreateService)
                {
                    var CustomerNumber = this.gridView3.GetRowCellValue(e.RowHandle, _CustomerNumber)?.ToString();
                    sSelect = ListCustomerSearch.Where(x => x.CustomerNumber == CustomerNumber).FirstOrDefault();

                    //label customer
                    this.CreateServicelbl.Text = "Phiếu yêu cầu dịch vụ: " + sSelect.PlateID + " | " + sSelect.CustomerName;

                    //enable 
                    this.pHeader.Enabled = true;
                    this.gridControl2.Enabled = true;
                    this.pFooter.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.pHeader.Enabled = false;
                this.gridControl2.Enabled = false;
                this.pFooter.Enabled = false;
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
        private bool RunCreateHeader()
        {
            try
            {
                var cl = new HttpClient();
                string url = "http://api.ototienthu.com.vn/api/v1/customers/createserviceorder";
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/x-www-form-urlencoded";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("CustAccount", sSelect.CustomerNumber));
                if (!string.IsNullOrEmpty(sSelect.PlateID))
                    nvc.Add(new KeyValuePair<string, string>("PlateId", sSelect.PlateID));

                if (!string.IsNullOrWhiteSpace(CurrentKm.Text))
                    nvc.Add(new KeyValuePair<string, string>("CurrentKM", CurrentKm.Text));

                nvc.Add(new KeyValuePair<string, string>("ServicePool", this.servicePool));

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
                        this.ServiceId = result["data"].Value<string>();
                        return true;
                        //MessageBox.Show("Tạo phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //new PrintInvoiceForm().ShowDialog();
                    }
                    else
                    {
                        return false;
                        //MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return false;
                    //MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private bool RunCreateLine()
        {
            try
            {
                for(int i = 0; i < gridView2.RowCount;i++)
                {
                    var item =  ListIS.Where(x=>x.ItemName.Equals(this.gridView2.GetRowCellValue(i, _ItemName)));
                    if (!item.Any()) return false;
                    var itemID = item.First().ItemID;
                    var ServiceorderID = gridView2.GetRowCellValue(i, _ItemName);
                    var cl = new HttpClient();
                    string url = "http://api.ototienthu.com.vn/api/v1/customers/CreateServiceLine";
                    cl.BaseAddress = new Uri(url);
                    int _TimeoutSec = 90;
                    cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                    string _ContentType = "application/x-www-form-urlencoded";
                    cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                    cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                    var nvc = new List<KeyValuePair<string, string>>();
                    nvc.Add(new KeyValuePair<string, string>("serviceOrderId", this.ServiceId));
                    nvc.Add(new KeyValuePair<string, string>("itemId", itemID));
                    nvc.Add(new KeyValuePair<string, string>("qty", this.gridView2.GetRowCellValue(i, _ItemQuality) != null? "1" : this.gridView2.GetRowCellValue(i, _ItemQuality).ToString()));
                    nvc.Add(new KeyValuePair<string, string>("workerId", this.gridView2.GetRowCellValue(i, _technician)?.ToString()));
                    nvc.Add(new KeyValuePair<string, string>("adviserId", this.gridView2.GetRowCellValue(i, _consultant)?.ToString()));
                    nvc.Add(new KeyValuePair<string, string>("lineDisc", this.gridView2.GetRowCellValue(i, _DiscountGrid2) != null ? "0" : this.gridView2.GetRowCellValue(i, _DiscountGrid2).ToString()));

                    var req = new HttpRequestMessage(HttpMethod.Post, url);
                    req.Content = new FormUrlEncodedContent(nvc);
                    var res = cl.SendAsync(req).Result;
                    string apiResponse = res.Content.ReadAsStringAsync().Result;
                    if (apiResponse != "")
                    {
                        var result = (JObject)JsonConvert.DeserializeObject(apiResponse);
                        if (result["data"].Value<string>() != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        private async void LoadItemCombobox()
        {
            try
            {

                this.Enabled = false;
                var cl = new HttpClient();
                string url = "http://api.ototienthu.com.vn/api/v1/customers/LookupItemCashier";
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/x-www-form-urlencoded";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("personnalNumberId", Staff.UserID));

                var req = new HttpRequestMessage(HttpMethod.Post, url);
                req.Content = new FormUrlEncodedContent(nvc);
                var res = cl.SendAsync(req).Result;
                this.Enabled = true;
                if (res.IsSuccessStatusCode)
                {
                    var body = await res.Content.ReadAsStringAsync();
                    var dataList = JsonConvert.DeserializeObject<DataModel>(body);
                    if (dataList.data == null)
                    {
                        MessageBox.Show("Load dữ liệu không thành công, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dataList.data.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (var item in dataList.data)
                    {
                        //Mã SP; Tên SP; Giá bán: gía mặc định; tồn kho; ĐVT
                        var data = item.Split(';');
                        ItemSell iS = new ItemSell(data[0], data[1]);
                        iS.ItemID = data[0];
                        iS.ItemName = data[1];
                        iS.ItemPrice = data[3];
                        iS.Inventory = Convert.ToDecimal(data[4]);
                        iS.ItemUnit = data[5];
                        ListIS.Add(iS);
                        ServiceCombobox.Items.Add(iS.ItemName);
                    }
                }
                else
                {
                    MessageBox.Show("Load dữ liệu không thành công, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void LoadWorkerCombobox()
        {
            try
            {
                this.Enabled = false;
                var cl = new HttpClient();
                string url = "http://api.ototienthu.com.vn/api/v1/customers/LookupWorkerCashier";
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/x-www-form-urlencoded";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("personnalNumberId", Staff.UserID));

                var req = new HttpRequestMessage(HttpMethod.Post, url);
                req.Content = new FormUrlEncodedContent(nvc);
                var res = cl.SendAsync(req).Result;
                this.Enabled = true;
                if (res.IsSuccessStatusCode)
                {
                    var body = await res.Content.ReadAsStringAsync();
                    var dataList = JsonConvert.DeserializeObject<DataModel>(body);
                    if (dataList.data == null)
                    {
                        MessageBox.Show("Load dữ liệu không thành công, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dataList.data.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (var item in dataList.data)
                    {
                        var data = item.Split(';');
                        StaffModel SM = new StaffModel(data[0], data[1]);
                        ListSM.Add(SM);
                        TechnicianCombobox.Items.Add(SM.UserName);
                        ConsultantCombobox.Items.Add(SM.UserName);
                    }
                }
                else
                {
                    MessageBox.Show("Load dữ liệu không thành công, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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