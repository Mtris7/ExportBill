﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
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
        private Staff _staff = new Staff();
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
        public DXMain(string userName, string companyName, Staff st)
        {
            InitializeComponent();
            this.CompanyLbl.Text = companyName;
            this.UserNamelbl.Text = userName;
            _staff.maNV = st.maNV;
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
        private  void button2_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.ds.Clear();
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/CashierService?personnalNumberId="+ _staff.maNV + "&serviceDate=" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
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
        #endregion
        //##############################################################################################
        #region method
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
        
        #endregion
        //##############################################################################################
    }
}