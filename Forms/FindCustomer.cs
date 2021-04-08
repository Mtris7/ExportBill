using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExportBill
{
    public partial class FindCustomer : Form
    {
        //##############################################################################################
        #region const
        private const string URL = @"http://api.ototienthu.com.vn/api/v1/oauth/token";
        private const string username = "apitest@tienthu.vn";
        private const string password = "62&z!]r*RV";
        #endregion
        //##############################################################################################

        public FindCustomer()
        {
            InitializeComponent();
        }
        //##############################################################################################
        #region event
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToolTip toolTip = new ToolTip();
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    toolTip.AutoPopDelay = 5000;
                    toolTip.InitialDelay = 1000;
                    toolTip.ReshowDelay = 500;
                    toolTip.Show("Nhập thông tin cần tìm.", textBox1);
                    this.textBox1.Focus();
                    return;
                }
                string url = string.Empty;
                if (this.chkSDT.Checked)
                {
                    url = @"http://api.ototienthu.com.vn/api/v1/customers/searchcustomers?searchtext=" + this.textBox1.Text + "&searchtype=CustomerPhone";
                }
                else
                {
                    url = @"http://api.ototienthu.com.vn/api/v1/customers/searchcustomers?searchtext=" + this.textBox1.Text + "&searchtype=LicensePlate";
                }
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Main.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var dataList = JsonConvert.DeserializeObject<DataModel>(body);
                    if (dataList.data.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var customerData = dataList.data[0].Split(';');
                    var customer = new CustomerModel();
                    customer.MaKH = customerData[0];
                    //customer.Name = customerData[1];
                    //customer.Address = customerData[2];
                    //customer.Tel = customerData[3];
                    //customer.BS = customerData[4];
                    customer.SoLanKTDK = customerData[5];
                    List<CustomerModel> list = new List<CustomerModel>();
                    list.Add(customer);
                    this.dataGridView1.AutoGenerateColumns = true;
                    this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView1.DataSource = list;
                    this.dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
                    this.dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
                    this.dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                    this.dataGridView1.Columns[3].HeaderText = "Số điện thoại";
                    this.dataGridView1.Columns[4].HeaderText = "Biển số xe";
                    this.dataGridView1.Columns[5].HeaderText = "CMND";
                    this.dataGridView1.Columns[6].HeaderText = "Số lần KTĐK";
                }
                else
                {
                    MessageBox.Show("Vui lòng đăng nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Tạo phiếu dịch vụ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.Equals(DialogResult.Yes))
                {
                    var makh = this.dataGridView1.Rows[0].Cells[0].Value?.ToString();
                    var bs = this.dataGridView1.Rows[0].Cells[4].Value?.ToString();
                    var createService = new CreateService(makh, bs);
                    createService.ShowDialog();
                }
                //MessageBox.Show("Khách hàng chỉ thay Nhớt", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if(this.DialogResult.Equals(DialogResult.OK))
                //{
                //    var changeOils = new ChangeOils();
                //    changeOils.ShowDialog();
                //}   
                //else
                //{

                //}    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //##############################################################################################
        #region method
        
        #endregion
        //##############################################################################################
    }
}
