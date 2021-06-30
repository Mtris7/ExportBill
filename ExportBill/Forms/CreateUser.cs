using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class CreateUser : Form
    {
        private bool _onlyCustomer;
        private string _sdt;
        public CreateUser(string sdt, bool onlyCreateCustomer = false)
        {
            InitializeComponent();
            _onlyCustomer = onlyCreateCustomer;
            if (_onlyCustomer)
            {
                CreateSaveBtn.Text = "Lưu";
                CreateSaveBtn.Size = new System.Drawing.Size(80, 43);
                BXPanel.Visible = false;
                this.Size = new System.Drawing.Size(509, 280);
                CreateSaveBtn.Location = new System.Drawing.Point(390, 175);
            }
            _sdt = sdt;
            DateOfBirth.Text = null;
        }
        public static string Bso = string.Empty;
        public static string SDT = string.Empty;
        public static string User = string.Empty;
        Dictionary<string, Dictionary<string, string>> ListProvinceToDistrict = new Dictionary<string, Dictionary<string, string>>();
        //####################################################################
        private void CreateSaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save_User())
                {
                    string maKH = string.Empty;
                    CreateUser.Bso = BSTxt.Text;
                    CreateUser.SDT = SDTTxt.Text;
                    CreateUser.User = NameTxt.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Save_User()
        {
            if (string.IsNullOrWhiteSpace(NameTxt.Text))
            {
                MessageBox.Show("Tên Khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(BSTxt.Text) && !_onlyCustomer)
            {
                MessageBox.Show("Biển số không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(SDTTxt.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(ProductCbx.Text) && !_onlyCustomer)
            {
                MessageBox.Show("Loại xe không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.Enabled = false;
            string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/createcustomer";
            var data_create = new List<KeyValuePair<string, string>>();
            data_create.Add(new KeyValuePair<string, string>("FirstName", NameTxt.Text));
            data_create.Add(new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID));
            //data_create.Add(new KeyValuePair<string, string>("Fax", ""));
            if (!string.IsNullOrEmpty(comboBox1.Text))
                data_create.Add(new KeyValuePair<string, string>("Gender", comboBox1.Text));
            if (!string.IsNullOrWhiteSpace(DateOfBirth.Text))
                data_create.Add(new KeyValuePair<string, string>("DateOfBirth", DateOfBirth.Text));
            if (!string.IsNullOrEmpty(SDTTxt.Text))
                data_create.Add(new KeyValuePair<string, string>("Phone", SDTTxt.Text));
            if (!string.IsNullOrEmpty(CMNDTxt.Text))
                data_create.Add(new KeyValuePair<string, string>("CMND", CMNDTxt.Text));
            if (!string.IsNullOrEmpty(StreetTxt.Text))
                data_create.Add(new KeyValuePair<string, string>("CustomerAddress", StreetTxt.Text));
            var District = DistrictCbx.SelectedItem as ComboboxItem;
            if (District != null)
                data_create.Add(new KeyValuePair<string, string>("District", District.Value.ToString()));

            FormUrlEncodedContent formContent = new FormUrlEncodedContent(data_create);
            GetAPI get_API = new GetAPI();
            var response = get_API.Post_NoAsyn(url, formContent);

            this.Enabled = true;
            if (!string.IsNullOrEmpty(response))
            {
                var result = (JObject)JsonConvert.DeserializeObject(response);
                string test = result["data"].Value<string>();
                bool check = response.ToString().Contains("status: true");
                if (result["status"].Value<string>().ToUpper().Contains("TRUE"))
                {
                    CreateUser.Bso = BSTxt.Text;
                    if (_onlyCustomer)
                        MessageBox.Show("Đăng kí khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Số điện thoại đã tồn tại hoặc đã có sự cố trong quá trình đăng ký", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (!_onlyCustomer)
            {
                string _url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/createplate";
                var data_create1 = new List<KeyValuePair<string, string>>();
                data_create1.Add(new KeyValuePair<string, string>("LicensePlate", BSTxt.Text));
                var Product = this.ProductCbx.SelectedItem as ComboboxItem;
                if (Product != null)
                    data_create1.Add(new KeyValuePair<string, string>("CategoryName", Product.Value.ToString()));
                if (!string.IsNullOrEmpty(InvoceDate.Text))
                    data_create1.Add(new KeyValuePair<string, string>("InvoceDate", InvoceDate.Text));
                if (!string.IsNullOrEmpty(SDTTxt.Text))
                    data_create1.Add(new KeyValuePair<string, string>("CustomerPhone", SDTTxt.Text));
                FormUrlEncodedContent _formContent = new FormUrlEncodedContent(data_create1);

                this.Enabled = false;
                var _response = get_API.Post_NoAsyn(_url, _formContent);
                this.Enabled = true;
                if (!string.IsNullOrEmpty(_response))
                {
                    var result1 = (JObject)JsonConvert.DeserializeObject(_response);
                    bool check = response.ToString().Contains("status: true");
                    if (result1["status"].Value<string>().ToUpper().Contains("TRUE"))
                    {
                        CreateUser.Bso = BSTxt.Text;
                        MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Biển số xe đã tồn tại hoặc đã có sự cố trong quá trình đăng ký", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                }
                else
                {
                    MessageBox.Show("Đăng kí không thành công", "Thông báo");
                    return false;
                }
            }
            return true;
        }
        private void lookupProduct()
        {
            try
            {
                this.Enabled = false;
                string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/LookupProduct";
                var data_create = new List<KeyValuePair<string, string>>();
                data_create.Add(new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID));

                FormUrlEncodedContent formContent = new FormUrlEncodedContent(data_create);
                GetAPI get_API = new GetAPI();
                var response = get_API.Post_NoAsyn(url, formContent);
                this.Enabled = true;
                if (!string.IsNullOrEmpty(response))
                {
                    var result = JsonConvert.DeserializeObject<DataModel>(response);
                    if (result.data != null)
                    {
                        this.ProductCbx.Items.Clear();
                        foreach (var item in result.data)
                        {
                            var itemDetail = item.ToString().Split(';');
                            ComboboxItem itemcbx = new ComboboxItem();
                            itemcbx.Text = itemDetail[1];
                            itemcbx.Value = itemDetail[0];

                            this.ProductCbx.Items.Add(itemcbx);
                        }
                        this.ProductCbx.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra , không tải xuống được loai xe. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra , không kết nối được máy chủ. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //####################################################################
        private async void SetComboBox()
        {
            try
            {
                #region combobox Province 
                string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/LookupCity";
                var formContent = new FormUrlEncodedContent(new[]
                        {
                        new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID),
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

                    this.ProvinceCbx.Items.Clear();
                    foreach (var item in dataList.data)
                    {
                        var data = item.Split(';');
                        ComboboxItem itemcbx = new ComboboxItem();
                        itemcbx.Text = data[1];
                        itemcbx.Value = data[0];

                        this.ProvinceCbx.Items.Add(itemcbx);
                    }
                }
                else
                {
                    MessageBox.Show("Load dữ liệu không thành công, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                this.ProvinceCbx.SelectedIndex = -1;
                this.DistrictCbx.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            this.SetComboBox();
            this.lookupProduct();
            SDTTxt.isPlaceHolder = false;
            SDTTxt.Text = _sdt;
        }

        private async void ProvinceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var province = (sender as ComboBox).SelectedItem as ComboboxItem;
                this.DistrictCbx.SelectedIndex = -1;
                this.DistrictCbx.Items.Clear();
                string url = "http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/LookupDistrict";
                var formContent = new FormUrlEncodedContent(new[]
                        {
                        new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID),
                        new KeyValuePair<string, string>("City", province.Value.ToString()),
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
                    foreach (var item in dataList.data)
                    {
                        var data = item.Split(';');
                        ComboboxItem itemcbx = new ComboboxItem();
                        itemcbx.Text = data[1];
                        itemcbx.Value = data[0];

                        this.DistrictCbx.Items.Add(itemcbx);
                    }
                }
                else
                {
                    MessageBox.Show("Load dữ liệu không thành công, vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int countDatePicker = 0;// enable custom format in date picker
        private void DateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            countDatePicker++;
            if (countDatePicker > 1)
            this.DateOfBirth.CustomFormat = string.Empty;
        }

        private void InvoceDate_ValueChanged(object sender, EventArgs e)
        {
            countDatePicker++;
            if (countDatePicker > 1)
                this.InvoceDate.CustomFormat = string.Empty;
        }
        //####################################################################
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
