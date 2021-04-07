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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class CreateService : Form
    {
        //######################################################
        #region constructor
        public CreateService()
        {
            InitializeComponent();
        }
        public CreateService(string makh, string bs)
        {
            InitializeComponent();
            this.MaKHTxt.Text = makh;
            this.BSTxt.Text = bs;
        }
        #endregion
        //######################################################
        #region property


        #endregion
        //######################################################
        #region event
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToolTip toolTip1 = new ToolTip();

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;

                if (string.IsNullOrWhiteSpace(MaKHTxt.Text))
                {
                    toolTip1.Show("Mục bắt buộc nhập.", MaKHTxt);
                    this.MaKHTxt.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    toolTip1.Show("Mục bắt buộc nhập.", textBox5);
                    this.textBox5.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    toolTip1.Show("Mục bắt buộc nhập.", textBox8);
                    this.textBox8.Focus();
                    return;
                }
                var cl = new HttpClient();
                string url = "http://api.ototienthu.com.vn/api/v1/customers/createserviceorder";
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/x-www-form-urlencoded";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", FindCustomer.token);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("CustAccount", MaKHTxt.Text));
                if (!string.IsNullOrWhiteSpace(BSTxt.Text))
                    nvc.Add(new KeyValuePair<string, string>("PlateId", BSTxt.Text));

                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    nvc.Add(new KeyValuePair<string, string>("CurrentKM", textBox3.Text));

                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                    nvc.Add(new KeyValuePair<string, string>("ServicePool", textBox4.Text));

                nvc.Add(new KeyValuePair<string, string>("DimensionStore", textBox5.Text));

                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                    nvc.Add(new KeyValuePair<string, string>("CustRef", textBox6.Text));

                if (!string.IsNullOrWhiteSpace(textBox7.Text))
                    nvc.Add(new KeyValuePair<string, string>("EngineID", textBox7.Text));

                nvc.Add(new KeyValuePair<string, string>("PersonnelNumberId", textBox8.Text));

                if (!string.IsNullOrWhiteSpace(textBox9.Text))
                    nvc.Add(new KeyValuePair<string, string>("InventSerialId", textBox9.Text));
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
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
