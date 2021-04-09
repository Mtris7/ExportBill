using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class Main : Form
    {
        //##############################################################################################
        #region const
        private const string URL = @"http://api.ototienthu.com.vn/api/v1/oauth/token";
        private const string username = "apitest@tienthu.vn";
        private const string password = "62&z!]r*RV";
        public static string token = string.Empty;
        #endregion
        public Main()
        {
            InitializeComponent();
            MainLoad();
        }
        //###############################################################################################
        public void MainLoad()
        {
            myTxtbx.GotFocus += RemoveText;
            myTxtbx.LostFocus += AddText;
            textBox1.GotFocus += RemoveText;
            textBox1.LostFocus += AddText;
            this.getToken();
            InitializeGrid();
        }
        public void InitializeGrid()
        {

            int columnIndex = 4;
            this.CreateServiceGrid.Columns.Add("TenKH", "khách hàng");
            this.CreateServiceGrid.Columns.Add("BS", "Biển số xe");
            this.CreateServiceGrid.Columns.Add("Lx", "Loại xe");
            this.CreateServiceGrid.Columns.Add("SDT", "Số điện thoại");
            if (CreateServiceGrid.Columns["CreateServiceBtn"] == null)
            {
                DataGridViewButtonColumn CreateServiceBtn = new DataGridViewButtonColumn()
                {
                    Text = "+",
                    HeaderText = "Tạo phiếu",
                    Name = "CreateServiceBtn",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.WhiteSmoke, ForeColor = Color.Blue, Alignment = DataGridViewContentAlignment.MiddleCenter},
                };
                CreateServiceGrid.Columns.Insert(columnIndex, CreateServiceBtn);
            }
            CreateServiceGrid.RowCount = 10;
            for(int i =0; i < this.CreateServiceGrid.RowCount;i++)
            {
                this.CreateServiceGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.Blue;
            }
        }
        #region event
        public void RemoveText(object sender, EventArgs e)
        {
            if (myTxtbx.Text == "Nhập biển số xe...")
            {
                myTxtbx.Font = new Font(myTxtbx.Font, FontStyle.Regular);
                myTxtbx.Text = "";
            }
            if (textBox1.Text == "Tìm khách hàng: Biển số/SĐT")
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
                textBox1.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(myTxtbx.Text))
            {
                myTxtbx.Font = new Font(myTxtbx.Font, FontStyle.Italic);
                myTxtbx.Text = "Nhập biển số xe...";
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
                textBox1.Text = "Tìm khách hàng: Biển số/SĐT";
            }
        }
        #endregion

        //##############################################################################################
        #region event
        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                ToolTip toolTip = new ToolTip();
                if (textBox1.Text == "Tìm khách hàng: Biển số/SĐT")
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
                    if(dataList.data == null)
                    {
                        MessageBox.Show("Có lỗi dữ liệu từ máy chủ, liên hệ phòng công nghệ để giải quyết", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dataList.data.Count == 0)
                    {
                        DialogResult result = MessageBox.Show("Không tìm thấy khách hàng. Tạo khách hàng mới không?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if(result == DialogResult.OK)
                        {
                            new CreateUser().ShowDialog(); 
                        }
                        return;
                    }
                    this.CreateServiceGrid.AutoGenerateColumns = true;
                    this.CreateServiceGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    var data = dataList.data[0].Split(';');
                    this.CreateServiceGrid.Rows[0].Cells[0].Tag = data[0]; // MaKH
                    this.CreateServiceGrid.Rows[0].Cells[0].Value = data[1];
                    this.CreateServiceGrid.Rows[0].Cells[3].Value = data[3];
                    //for (int i = 0; i < dataList.data.Count; i++)
                    //{
                    //    var data = dataList.data[0].Split(';');
                    //    this.CreateServiceGrid.Rows[i].Cells[0].Tag = data[0]; // MaKH
                    //    this.CreateServiceGrid.Rows[i].Cells[0].Value = data[1];
                    //    this.CreateServiceGrid.Rows[i].Cells[3].Value = data[3];
                    //}
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
        private void CreateServiceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == CreateServiceGrid.Columns["CreateServiceBtn"].Index && e.RowIndex >= 0)
                {
                    DialogResult result = MessageBox.Show("Tạo phiếu dịch vụ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result.Equals(DialogResult.Yes))
                    {
                        var makh = this.CreateServiceGrid.Rows[0].Cells[0].Tag?.ToString();
                        var tenkh = this.CreateServiceGrid.Rows[0].Cells[0].Value?.ToString();
                        var bs = this.CreateServiceGrid.Rows[0].Cells[1].Value?.ToString();
                        var createService = new CreateService(makh, tenkh, bs);
                        createService.ShowDialog();
                    }
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
                    Main.token = tokenData.access_token;
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
