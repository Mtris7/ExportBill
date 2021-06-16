using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class ChangeCustomer : Form
    {
        public ChangeCustomer()
        {
            InitializeComponent();
        }

        private BindingList<CustomerModel> ListCustomerSearch = new BindingList<CustomerModel>();
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchCustomerTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập mục tìm kiếm");
                    searchCustomerTxt.Focus();
                    return;
                }
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/searchcustomers?searchtext=" + searchCustomerTxt.Text + "&searchtype=CustomerPhone";

                GetAPI Search = new GetAPI();
                this.Enabled = false;
                var response = await Search.Only_url(url);
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
                        DialogResult result = MessageBox.Show("Không tìm thấy khách hàng, Tạo khách hàng mới không?.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            CreateUser createUser = new CreateUser(true);
                            createUser.ShowDialog();
                        }
                        else
                        {
                            return;
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

        private void gvServiceHeader_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DXMain.sSelect.CustomerNumber = this.gvServiceHeader.GetRowCellValue(this.gvServiceHeader.FocusedRowHandle,_CustomerNumber)?.ToString();
                DXMain.sSelect.CustomerName = this.gvServiceHeader.GetRowCellValue(this.gvServiceHeader.FocusedRowHandle, _Customer)?.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
