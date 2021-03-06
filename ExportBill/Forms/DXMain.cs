using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class DXMain : XtraForm
    {
        //##############################################################################################
        #region const
        private const string PrBill = "PrintBill";
        private const string PBill = "PostBill";
        private const string PostBillStr = "Post Bill";
        private const string Posted = "Posted";
        private const string inProcess = "In process";
        private const string invoiced = "Invoiced";
        private const string MPhieu = "MaPhieu";
        #endregion
        //###############################################################################################
        #region field
        private BindingList<Customer> ds = new BindingList<Customer>();
        private BindingList<CustomerModel> ListCustomerSearch = new BindingList<CustomerModel>();
        private BindingList<ItemSell> ListIS = new BindingList<ItemSell>();
        private BindingList<ItemLookup> ListItemLookup = new BindingList<ItemLookup>();
        private BindingList<StaffModel> ListSM = new BindingList<StaffModel>();
        public static CustomerModel sSelect;
        private string servicePool = "SCPT";
        private string ServiceId = string.Empty;
        private List<string> ListItemID = new List<string>();
        private fsm_BtBack fsm;
        public static bool checkCreateUser = false;
        public static bool ChangeBso = false;
        #endregion
        //###############################################################################################
        #region Initialize

        private void DXMain_Load(object sender, EventArgs e)
        {
            this.SetDefault();
        }
        private void SetDefault()
        {
            try
            {
                this.DatetimeLbl.Text = DateTime.Now.ToLocalTime().ToShortDateString();
                this.dateTimeBill.Value = DateTime.Now;
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
                BindingList<ItemSell> ds = new BindingList<ItemSell>();
                this.ServiceLineCtr.DataSource = ds;
                this.gvServiceLine.AddNewRow();
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
                this.ServicePool.SelectedIndex = 3;//Sửa chữa - thay thế phụ tùng
                this.gridView1.Columns["Total"].DisplayFormat.FormatString = "N0";
                this.gvServiceLine.Columns["Inventory"].DisplayFormat.FormatString = "N0";
                this.pHeader.Enabled = false;
                this.ServiceLineCtr.Enabled = false;
                this.pFooter.Enabled = true;
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
            dateTimeBill.Visible = true;
            DatetimeLbl.Visible = false;
        }

        /// <summary>
        /// Tạo phiếu dịch vụ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            await this.SearchCustomer();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            new ChangeCustomer().ShowDialog();
            //label customer
            this.CreateServicelbl.Text = "Phiếu yêu cầu dịch vụ: " + sSelect.PlateID + " | " + sSelect.CustomerName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadListBike();

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
                if (colI == _RecallBill)
                {
                    string recallBill_Val = view.GetFocusedRowCellValue(_RecallBill).ToString();
                    if (recallBill_Val == Posted)
                        RunRecallBill(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                    GridView view = sender as GridView;
                    if (view.RowCount.Equals(0))
                    {
                        MessageBox.Show("Chưa có dữ liệu, vui lòng tải dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
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
                        if (colI == _RecallBill)
                        {
                            string recallBill_Val = view.GetFocusedRowCellValue(_RecallBill).ToString();
                            if (recallBill_Val == Posted)
                                RunRecallBill(rowIndex);
                        }
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show(" Đã có lỗi xảy ra, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                    if (invoiced == cellValue)
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column == _RecallBill)
                {
                    var cellValue = e.CellValue.ToString();
                    if (Posted == cellValue)
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    else
                        e.Appearance.ForeColor = Color.Black;
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
                e.Cancel = gridView1.FocusedColumn.FieldName == "Payment" && gridView1.GetFocusedRowCellValue(PostBill).ToString() == invoiced;
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
            switch (ServicePool.SelectedIndex)
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
                for (int i = 0; i < this.gvServiceLine.RowCount; i++)
                    if (this.gvServiceLine.GetRowCellValue(i, _WorkerId) == null)
                    {
                        MessageBox.Show("Vui lòng chọn người làm việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                if(string.IsNullOrWhiteSpace(this.CurrentKm.Text) || this.CurrentKm.Text == this.CurrentKm.PlaceHolderText)
                {
                    MessageBox.Show("Vui lòng nhập Số kilomet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.CurrentKm.Focus();
                    return;
                }

                if (RunCreateHeader())
                {
                    if (RunCreateLine())
                    {
                        MessageBox.Show("Tạo phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (PostTransfer())
                            SearchControl1Txt.Text = sSelect.PlateID;
                        else
                            SearchControl1Txt.Text = "TT_";
                        xtraTabControl.SelectedTabPage = ServiceListTab;
                        this.ComeBack();
                        this.LoadListBike();
                    }

                    else
                        MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Tạo phiếu thất bại, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveCol_Click(object sender, EventArgs e)
        {
            try
            {
                this.gvServiceLine.DeleteRow(this.gvServiceLine.FocusedRowHandle);
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
                var check = e.Value?.ToString().Replace(",","").Replace(".","").All(char.IsDigit) ?? false;
                
                if (e.Column.Equals(_DiscountGrid2))
                {
                    if (!check)
                    {
                        MessageBox.Show("Vui lòng nhập chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.gvServiceLine.SetRowCellValue(e.RowHandle, _DiscountGrid2, 0);
                        return;
                    }
                    var itemPrice = this.gvServiceLine.GetRowCellValue(e.RowHandle, _ItemPrice);
                    var itemQuatity = this.gvServiceLine.GetRowCellValue(e.RowHandle, _ItemQuality) ?? 1;
                    var total = Convert.ToDecimal(itemPrice) * Convert.ToDecimal(itemQuatity) - Convert.ToDecimal(e.Value);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _TotalGrid2, total.ToString("N0"));

                    this.gvServiceLine.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _DiscountGrid2, Convert.ToDecimal(e.Value).ToString("N0"));
                    this.gvServiceLine.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
                }

                if (e.Column.Equals(_ItemQuality))
                {
                    if (!check)
                    {
                        MessageBox.Show("Vui lòng nhập chữ số.", "Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.gvServiceLine.SetRowCellValue(e.RowHandle, _ItemQuality, 1);
                        return;
                    }
                    var itemPrice = this.gvServiceLine.GetRowCellValue(e.RowHandle, _ItemPrice);
                    var itemDiscount = this.gvServiceLine.GetRowCellValue(e.RowHandle, _DiscountGrid2);
                    var total = Convert.ToDecimal(itemPrice) * Convert.ToDecimal(e.Value) - Convert.ToDecimal(itemDiscount);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _TotalGrid2, total.ToString("N0"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Equals(_ItemName))
                {
                    //Mã SP; Tên SP; Giá bán: số lượng bán mặc định; tồn kho; ĐVT
                    var item = ListIS.Where(x => x.ItemName.Equals(e.Value));
                    if (!item.Any()) return;
                    var itemID = item.First().ItemID;
                    var itemPrice = Convert.ToDecimal(item.First().ItemPrice);
                    var itemUnit = item.First().ItemUnit;
                    var itemInventory = item.First().Inventory;
                    var itemQuality = item.First().ItemQuality;
                    var itemTotal = itemPrice * Convert.ToDecimal(itemQuality);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _Inventory, itemInventory);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _ItemName, e.Value);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _ItemQuality, itemQuality);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _DiscountGrid2, 0);
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _ItemPrice, itemPrice.ToString("N0"));
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _TotalGrid2, itemTotal.ToString("N0"));
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _ItemUnit, itemUnit);
                }

                if (e.Column.Equals(_WorkerId))
                {
                    ItemSell iS = new ItemSell();
                    var item1 = ListSM.Where(x => x.UserName.Equals(e.Value)).FirstOrDefault();
                    if (item1 == null) return;
                    iS.WorkerId = item1.UserName;
                    iS.AdviserId = item1.NameAdviser;
                    this.gvServiceLine.SetRowCellValue(e.RowHandle, _AdviserId, iS.AdviserId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvServiceLine_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Column == _WorkerId)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 128);
                }
                if(e.Column == _Inventory)
                {
                    var value = e.CellValue?.ToString();
                    if (value == "0.00")
                        e.Appearance.BackColor = Color.FromArgb(244, 37, 52);
                }
            }
            catch (Exception ex)
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
                    this.CreateNewService(e.RowHandle);
                }
                if (e.Column == _Phone)
                {
                    this.ChangePhone(e.RowHandle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Grid Inventory


        #endregion

        private void btnAddLine_Click(object sender, EventArgs e)
        {

            try
            {
                this.gvServiceLine.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                switch (fsm)
                {
                    case fsm_BtBack.fsm_delete_gvServiceLin:
                        {
                            while (this.gvServiceLine.RowCount > 0)
                                this.gvServiceLine.DeleteRow(this.gvServiceLine.FocusedRowHandle);
                            this.gvServiceLine.AddNewRow();

                            this.CurrentKm.Text = string.Empty;
                            this.CurrentKm.Focus();
                            this.NoteTxt.Text = string.Empty;
                            this.NoteTxt.Focus();

                            this.CreateServicelbl.Text = "Phiếu yêu cầu dịch vụ: ";
                            this.pHeader.Enabled = false;
                            this.ServiceLineCtr.Enabled = false;

                            //header
                            this.ServiceHeaderCtr.Enabled = true;
                            this.groupSearch_CreateService.Enabled = true;

                            this.fsm = fsm_BtBack.fsm_delete_gvServiceHeader;
                            break;
                        }
                    case fsm_BtBack.fsm_delete_gvServiceHeader:
                        {
                            while (this.gvServiceHeader.RowCount > 0)
                                this.gvServiceHeader.DeleteRow(this.gvServiceHeader.FocusedRowHandle);
                            this.gvServiceHeader.AddNewRow();
                            this.ServiceHeaderCtr.Enabled = false;
                            this.groupSearch_CreateService.Enabled = true;

                            this.fsm = fsm_BtBack.fsm_delete_number;
                            break;
                        }
                    case fsm_BtBack.fsm_delete_number:
                        {
                            Search2Txt.Text = "";
                            Search2Txt.Focus();
                            this.fsm = fsm_BtBack.fsm_nothing;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CurrentKm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int kilomet;
                bool result = Int32.TryParse(CurrentKm.Text, out kilomet);
                if (CurrentKm.Text == "Số kilomet" || CurrentKm.Text == "")
                    return;
                else if (result == false)
                {
                    CurrentKm.Text = "";
                    MessageBox.Show("vui lòng chỉ nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void BtnSearchInventory_Click(object sender, EventArgs e)
        {
            try
            {
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/LookupOnhandItem";
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID),
                        new KeyValuePair<string, string>("ItemId", SearchInventoryTxt.Text),
                    });
                GetAPI DXMain_PostBill = new GetAPI();
                var response = await DXMain_PostBill.post(url, formContent);
                this.Enabled = true;
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DataModel>(body);
                    if (result.data != null)
                    {
                        List<ItemSell> list = new List<ItemSell>();
                        //Dầu nhớt SL cho động cơ 1L -  xe số;08232-2MA-K1LV1;985.90;BÌNH;NHOT;88,000.00;BÌNH
                        foreach(var item in result.data)
                        {
                            var data        = item.Split(';');
                            ItemSell iS     = new ItemSell();
                            iS.ItemName     = data[0];
                            iS.ItemID       = data[1];
                            iS.Inventory    = Convert.ToDecimal(data[2]);
                            iS.ItemUnit     = data[3];
                            iS.ItemGroup    = data[4];
                            iS.ItemPrice    = data[5];
                            iS.ItemUnitSell = data[6];
                            list.Add(iS);
                        }
                        this.InventoryControl.DataSource = list;
                    }
                    else
                        MessageBox.Show("Tải dữ liệu không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Post bill không thành công, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
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
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/PostBillService";
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("ServiceOrderId", MaPhieu),
                        new KeyValuePair<string, string>("PaymTermId", payment),
                    });
                GetAPI DXMain_PostBill = new GetAPI();
                var response = await DXMain_PostBill.post(url, formContent);
                this.Enabled = true;
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DataModelString>(body);
                    if (result.data.ToUpper().Contains(("POST BILL THÀNH CÔNG")))
                    {
                        MessageBox.Show(result.data, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridView1.SetRowCellValue(row, PBill, invoiced);
                    }
                    else
                        MessageBox.Show(result.data, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Post bill không thành công, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
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
                new PrintInvoiceForm(cs, true).ShowDialog();
                gridView1.SetRowCellValue(rowIndex, _RecallBill, Posted);
                if (pbill != invoiced)
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
                new PrintInvoiceForm(cs).ShowDialog();

                var pbill = this.gridView1.GetRowCellValue(rowIndex, PBill)?.ToString();
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private  void RunRecallBill(int rowIndex)
        {
            try
            {
                var MaPhieu = this.gridView1.GetRowCellValue(rowIndex, MPhieu)?.ToString();
                var getData = ds.Where(x => x.MaPhieu == MaPhieu).FirstOrDefault();
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/RunRecallBill";
                var nvc = new List<KeyValuePair<string, string>>();
                if (!string.IsNullOrEmpty(MaPhieu))
                    nvc.Add(new KeyValuePair<string, string>("SMAServiceOrderId", MaPhieu));
                else
                {
                    MessageBox.Show("Không tìm được mã phiếu");
                    return;
                }
                GetAPI get_API = new GetAPI();
                FormUrlEncodedContent formContent = new FormUrlEncodedContent(nvc);
                var apiResponse = get_API.Post_NoAsyn(url, formContent);
                if (apiResponse != "")
                {
                    var result = (JObject)JsonConvert.DeserializeObject(apiResponse);
                    if (result["data"].Value<string>().ToUpper().Contains("TRUE"))
                    {
                        MessageBox.Show("Hủy bill thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridView1.SetRowCellValue(rowIndex, _RecallBill, inProcess);
                    }
                    else
                        MessageBox.Show("Hủy bill không thành công, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Hủy bill không thành công, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
               
                string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/createserviceorder";
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
                nvc.Add(new KeyValuePair<string, string>("PersonnelNumberId", Staff.UserID));
                GetAPI get_API = new GetAPI();
                FormUrlEncodedContent formContent = new FormUrlEncodedContent(nvc);

                this.Enabled = false;
                var apiResponse = get_API.Post_NoAsyn(url, formContent);
                this.Enabled = true;

                if (apiResponse != "")
                {
                    var result = (JObject)JsonConvert.DeserializeObject(apiResponse);
                    if (result["data"].Value<string>() != null)
                    {
                        this.ServiceId = result["data"].Value<string>();
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
                for (int i = 0; i < gvServiceLine.RowCount; i++)
                {
                    var item = ListIS.Where(x => x.ItemName.Equals(this.gvServiceLine.GetRowCellValue(i, _ItemName)));
                    var workerId = ListSM.Where(x => x.UserName.Equals(this.gvServiceLine.GetRowCellValue(i, _WorkerId)))?.First().UserID;
                    var adviserId = this.gvServiceLine.GetRowCellValue(i, _AdviserId) == null ? "" : ListSM.Where(x => x.UserName.Equals(this.gvServiceLine.GetRowCellValue(i, _AdviserId)))?.First().UserID;
                    var qty = this.gvServiceLine.GetRowCellValue(i, _ItemQuality) == null ? "1" : Convert.ToDecimal(this.gvServiceLine.GetRowCellValue(i, _ItemQuality)).ToString("N2");
                    var Disc = this.gvServiceLine.GetRowCellValue(i, _DiscountGrid2) == null ? "0" : this.gvServiceLine.GetRowCellValue(i, _DiscountGrid2).ToString();
                    if (!item.Any()) return false;
                    var itemID = item.First().ItemID;
                    ListItemID.Add(itemID);
                    string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/CreateServiceLine";
                    var nvc = new List<KeyValuePair<string, string>>();
                    nvc.Add(new KeyValuePair<string, string>("serviceOrderId", this.ServiceId));
                    nvc.Add(new KeyValuePair<string, string>("itemId", itemID));
                    nvc.Add(new KeyValuePair<string, string>("qty", qty));
                    nvc.Add(new KeyValuePair<string, string>("workerId", workerId));
                    nvc.Add(new KeyValuePair<string, string>("adviserId", adviserId));
                    nvc.Add(new KeyValuePair<string, string>("lineDisc", Convert.ToDecimal(Disc).ToString()));
                    GetAPI get_API = new GetAPI();
                    FormUrlEncodedContent formContent = new FormUrlEncodedContent(nvc);

                    this.Enabled = false;
                    var apiResponse = get_API.Post_NoAsyn(url, formContent);
                    this.Enabled = true;

                    if (apiResponse != "")
                    {
                        var result = (JObject)JsonConvert.DeserializeObject(apiResponse);
                        if (result["data"].Value<string>() == null)
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

        private bool PostTransfer()
        {
            try
            {
                string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/PostTransfer";
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("SMAServiceOrderId", this.ServiceId));
                nvc.Add(new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID));
                GetAPI get_API = new GetAPI();
                FormUrlEncodedContent formContent = new FormUrlEncodedContent(nvc);

                this.Enabled = false;
                var apiResponse = get_API.Post_NoAsyn(url, formContent);
                this.Enabled = true;

                if (apiResponse != "")
                {
                    var result = (JObject)JsonConvert.DeserializeObject(apiResponse);
                    if (result["data"].Value<string>() != null)
                    {
                        if(result["data"].Value<string>().ToUpper().Contains("KHÔNG"))
                        {
                            MessageBox.Show(result["data"].Value<string>(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.LoadItemCombobox();
                            return false;
                        }

                        else
                        {
                            MessageBox.Show(result["data"].Value<string>(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadItemCombobox();
                            return true;
                        }
                        
                    }
                }
                else
                {
                    return false;
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
                //var cl = new HttpClient();
                string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/LookupItemCashier";
                var formContent = new FormUrlEncodedContent(new[]
                        {
                        new KeyValuePair<string, string>("personnalNumberId", Staff.UserID),
                    });
                GetAPI Load_Item_CbBox = new GetAPI();
                var res = await Load_Item_CbBox.post(url, formContent);
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
                    ListIS.Clear();
                    ListItemLookup.Clear();
                    foreach (var item in dataList.data)
                    {
                        //Mã SP; Tên SP; Giá bán: gía mặc định; tồn kho; ĐVT
                        //";Dầusố.00;1.00;0.00;BÌNH",
                        var data = item.Split(';');
                        ItemSell iS = new ItemSell();
                        iS.ItemID = data[0];
                        iS.ItemName = data[1];
                        iS.ItemPrice = data[2];
                        iS.ItemQuality = data[3];
                        iS.Inventory = Convert.ToDecimal(data[4]);
                        iS.ItemUnit = data[5];
                        ListIS.Add(iS);

                        ItemLookup itemLookup = new ItemLookup();
                        itemLookup.ItemID = data[0];
                        itemLookup.ItemName = data[1];
                        itemLookup.ItemPrice = data[2];
                        ListItemLookup.Add(itemLookup);
                    }
                    RepositoryItemLookUpEdit repositoryLUE = new RepositoryItemLookUpEdit();
                    repositoryLUE.ValueMember = "ItemName";
                    repositoryLUE.DisplayMember = "ItemName";
                    repositoryLUE.DataSource = ListItemLookup;
                    repositoryLUE.PopupFormMinSize = new  Size(700, 0);
                    repositoryLUE.NullText = "";
                    repositoryLUE.Columns.Add(new LookUpColumnInfo("ItemID", 40, "Mã sản phẩm"));
                    repositoryLUE.Columns.Add(new LookUpColumnInfo("ItemName", 40, "Tên sản phẩm"));
                    repositoryLUE.Columns.Add(new LookUpColumnInfo("ItemPrice", 40, "Giá bán"));

                    gvServiceLine.Columns["ItemName"].ColumnEdit = repositoryLUE;
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
                string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/LookupWorkerCashier";
                var cl = new HttpClient();
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/x-www-form-urlencoded";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.token);
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
                        StaffModel SM = new StaffModel(data[0], data[1], data[2], data[3]);
                        ListSM.Add(SM);
                        WorkerIdCbx.Items.Add(SM.UserName);
                        AdviserIdCbx.Items.Add(SM.UserName);
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

        private async void LoadListBike()
        {
            try
            {
                this.Enabled = false;
                this.ds.Clear();
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/CashierService?personnalNumberId=" + Staff.UserID + "&serviceDate=" + this.dateTimeBill.Value.ToString("dd/MM/yyyy");
                if (!string.IsNullOrWhiteSpace(this.SearchControl1Txt.Text))
                {
                    url += "&plateId=" + this.SearchControl1Txt.Text;
                }
                GetAPI Load_Bike = new GetAPI();
                
                var response = await Load_Bike.Only_url(url);
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
                        var postBill = data[11] == "Open" ? PostBillStr : invoiced;
                        var payment = data[12];
                        var recalbill = data[13] == Posted ? Posted : inProcess;
                        string maPhieu = data[0];
                        string userName = data[1];
                        string phoneNumber = data[15];
                        string bs = data[2];
                        string lx = data[3];
                        string tsc = data[4];
                        string dg = data[5];
                        int discount = Convert.ToInt32(Convert.ToDecimal(data[6]));
                        int total = Convert.ToInt32(Convert.ToDecimal(data[7]));
                        string detaiMoney = data[8];
                        string company = data[9];
                        string address = data[10];
                        //public Customer(string maPhieu, string userName,phoneNumber, string bs, string lx, string tsc,
                        //string dg, decimal discount, decimal total, string detaiMoney, string company, string adress, string date, string print)
                        ds.Add(new Customer(maPhieu, userName, phoneNumber, bs, lx, tsc, dg, discount, total,
                            detaiMoney, company, address, postBill, payment, "Print", recalbill));
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
                MessageBox.Show(ex.Message );
            }
        }

        private void ComeBack()
        {
            try
            {
                this.ServicePool.SelectedIndex = 3;
                this.CurrentKm.Text = "";
                this.CurrentKm.Focus();
                this.NoteTxt.Text = "";
                this.NoteTxt.Focus();
                while (this.gvServiceLine.RowCount > 0)
                {
                    this.gvServiceLine.FocusedRowHandle = this.gvServiceLine.RowCount - 1;
                    this.gvServiceLine.DeleteRow(this.gvServiceLine.FocusedRowHandle);
                }
                this.gvServiceLine.AddNewRow();
                this.CreateServicelbl.Text = "Phiếu yêu cầu dịch vụ: ";
                this.pHeader.Enabled = false;
                this.ServiceLineCtr.Enabled = false;
                this.pFooter.Enabled = false;
                this.groupSearch_CreateService.Enabled = true;

                this.ServiceHeaderCtr.DataSource = null;
                this.Search2Txt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_Changed(object sender, EventArgs e)
        {
            this.fsm = fsm_BtBack.fsm_delete_number;
        }

        private void BsoChange()
        {
            Search2Txt.Text = CreateUser.Bso;
        }
        
        private void Click_Change_Grid3(object sender, EventArgs e)
        {

        }

        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                //if (e.Page == ServiceListTab)
                //    this.SearchControl1Txt.Focus();
                //else
                //    this.Search2Txt.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void CreateNewService(int rowIndex, bool check = false)
        {
            try
            {
                
                if(check)
                {
                    this.fsm = fsm_BtBack.fsm_delete_gvServiceLin;
                    this.groupSearch_CreateService.Enabled = false;
                    this.ServiceHeaderCtr.Enabled = false;
                    //
                    string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/searchcustomers?searchtext=" + CreateUser.Bso + "&searchtype=LicensePlate";

                    GetAPI Search = new GetAPI();
                    var response = await Search.Only_url(url);
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
                            DialogResult result = MessageBox.Show("Không tìm thấy khách hàng, Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }

                        foreach (var item in dataList.data)
                        {
                            var data = item.Split(';');

                            if (data[3].Equals(CreateUser.SDT))
                            {
                                ListCustomerSearch.Add(new CustomerModel(data[0], data[1], data[2], data[3], data[4], null, data[5]));
                                sSelect = ListCustomerSearch.Where(x => x.CustomerNumber == data[0]).FirstOrDefault();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tải dữ liệu thất bại.");
                    }
                }
                else
                {
                    var CustomerNumber = this.gvServiceHeader.GetRowCellValue(rowIndex, _CustomerNumber)?.ToString();
                    sSelect = ListCustomerSearch.Where(x => x.CustomerNumber == CustomerNumber).FirstOrDefault();
                    this.fsm = fsm_BtBack.fsm_delete_gvServiceLin;
                }

                //label customer
                this.CreateServicelbl.Text = "Phiếu yêu cầu dịch vụ: " + sSelect.PlateID + " | " + sSelect.CustomerName;
                //enable 
                this.pHeader.Enabled = true;
                this.ServiceLineCtr.Enabled = true;
                this.pFooter.Enabled = true;

                this.gvServiceLine.FocusedRowHandle = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void ChangePhone(int rowIndex)
        {
            try
            {
                new ChangeInfo().ShowDialog();
                if (!String.IsNullOrWhiteSpace(ChangeInfo.SDTChange))
                {
                    var CustomerNumber = this.gvServiceHeader.GetRowCellValue(rowIndex, _CustomerNumber)?.ToString();
                    var OldPhone = this.gvServiceHeader.GetRowCellValue(rowIndex, _Phone)?.ToString();
                    //
                    string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/ChangeMainPhoneNumber";
                    var formContent = new FormUrlEncodedContent(new[]
                       {
                        new KeyValuePair<string, string>("AccountNum", CustomerNumber),
                        new KeyValuePair<string, string>("OldPhone", OldPhone),
                        new KeyValuePair<string, string>("NewPhone", ChangeInfo.SDTChange),
                        new KeyValuePair<string, string>("chkPhone", ChangeInfo.chk),
                    });
                    GetAPI Search = new GetAPI();
                    var response = await Search.post(url, formContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var dataModel = JsonConvert.DeserializeObject<DataModelString>(body);

                        if(dataModel.data.ToUpper().Equals("TRUE"))
                        {
                            MessageBox.Show("Thay đổi số điện thoại thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if(ChangeInfo.chk == "true")
                                await this.SearchCustomer();
                        }
                        else
                            MessageBox.Show("Thay đổi số điện thoại không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Tải dữ liệu thất bại.");
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task SearchCustomer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Search2Txt.Text))
                {
                    Point Search2TxtLocation = new Point(groupSearch_CreateService.Location.X + Search2Txt.Location.X - 10, groupSearch_CreateService.Location.Y + Search2Txt.Location.Y - 15);
                    toolTip1.Show("Mục bắt buộc nhập.", Search2Txt, Search2TxtLocation);
                    toolTip1.Active = true;

                    System.Threading.Thread.Sleep(500);
                    return;
                }
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/searchcustomers?searchtext=" + Search2Txt.Text + "&searchtype=";
                if (bsCheck.Checked)
                    url += "LicensePlate";
                else
                    url += "CustomerPhone";
                GetAPI Search = new GetAPI();
                this.Enabled = false;
                var response = await Search.Only_url(url);
                this.Enabled = true;
                this.fsm = fsm_BtBack.fsm_delete_gvServiceHeader;
                bool addCustomer = false;
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var dataList = JsonConvert.DeserializeObject<DataModel>(body);
                    if (dataList.data == null)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu, vui lòng kiểm tra thông tin tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dataList.data.Count == 0)
                    {
                        DialogResult result = MessageBox.Show("Không tìm thấy khách hàng, Tạo khách hàng mới không?.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            this.RunCreateUser();
                            addCustomer = true;
                        }
                    }
                    this.ListCustomerSearch.Clear();

                    foreach (var item in dataList.data)
                    {
                        var data = item.Split(';');
                        //"C15-030575;LÊ THỊ DIỆU ANH;BẦU CÂU - HÒA CHÂU - HV - ĐN\nHOAVANG\nDANANG\nVNM;0979300094;43H1-16861;2"
                        ListCustomerSearch.Add(new CustomerModel(data[0], data[1], data[2], data[3], data[4], null, data[5]));
                    }
                    this.ServiceHeaderCtr.DataSource = ListCustomerSearch;
                    if(!addCustomer)
                        this.ServiceHeaderCtr.Enabled = true;
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
        
        private void RunCreateUser()
        {
            try
            {
                CreateUser createUser = new CreateUser(Search2Txt.Text);
                if (createUser.ShowDialog(this) == DialogResult.OK)
                {
                    CreateNewService(0, true);
                    DXMain.checkCreateUser = false;

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