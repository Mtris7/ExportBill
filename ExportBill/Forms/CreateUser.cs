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
        public CreateUser()
        {
            InitializeComponent();
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
            if (string.IsNullOrWhiteSpace(BSTxt.Text))
            {
                MessageBox.Show("Biển số không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(SDTTxt.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(ProductCbx.Text))
            {
                MessageBox.Show("Loại xe không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                this.Enabled = false;
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/createcustomer";
                var data_create = new List<KeyValuePair<string, string>>();
                data_create.Add(new KeyValuePair<string, string>("FirstName", NameTxt.Text));
                data_create.Add(new KeyValuePair<string, string>("HcmPersonnelNumberId", Staff.UserID));
                //data_create.Add(new KeyValuePair<string, string>("Fax", ""));
                if (!string.IsNullOrEmpty(comboBox1.Text))
                    data_create.Add(new KeyValuePair<string, string>("Gender", comboBox1.Text));
                if (!string.IsNullOrEmpty(DateOfBirth.Text))
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

                string _url = @"http://api.ototienthu.com.vn/api/v1/customers/createplate";
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
                var _response = get_API.Post_NoAsyn(_url, _formContent);
                this.Enabled = true;
                if (!string.IsNullOrEmpty(response) && !string.IsNullOrEmpty(_response))

                {

                    var result = (JObject)JsonConvert.DeserializeObject(response);
                    var result1 = (JObject)JsonConvert.DeserializeObject(_response);
                    string test = result["data"].Value<string>();
                    bool check = response.ToString().Contains("status: true");
                    if (result["status"].Value<string>().ToUpper().Contains("TRUE") && result1["status"].Value<string>().ToUpper().Contains("TRUE"))
                    {
                        CreateUser.Bso = BSTxt.Text;
                        //DialogResult Result = MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Đăng kí thành công", "Thông báo");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại hoặc đã có sự cố trong quá trình đăng ký", "Thông báo");
                        return false;
                    }


                }
                else
                {
                    MessageBox.Show("Đăng kí không thành công", "Thông báo");
                    return false;
                }
            }
        }
        private void lookupProduct()
        {
            try
            {
                this.Enabled = false;
                string url = @"http://api.ototienthu.com.vn/api/v1/customers/LookupProduct";
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
        private void SetComboBox()
        {
            try
            {
                #region combobox Province 
                Dictionary<string, string> ListProvince = new Dictionary<string, string>();
                ListProvince.Add("DANANG", "Đà Nẵng");
                ListProvince.Add("QUANGBINH", "Quảng Bình");
                ListProvince.Add("QUANGNAM", "Quảng Nam");
                ListProvince.Add("QUANGNGAI", "Quảng Ngãi");
                //ListProvince.Add("QUANGTRI", "Quảng Trị");
                //ListProvince.Add("BINHDINH", "Bình Định");
                //ListProvince.Add("BINHTHUAN", "Bình Thuận");
                //ListProvince.Add("DAKLAK", "Đắk Lắk");
                //ListProvince.Add("DAKNONG", "Đắk Nông");
                //ListProvince.Add("GIALAI", "Gia Lai");
                //ListProvince.Add("HATINH", "Hà Tĩnh");
                //ListProvince.Add("KHANHHOA", "Khánh Hòa");
                //ListProvince.Add("KONTUM", "Kon Tum");
                //ListProvince.Add("LAMDONG", "Lâm Đồng");
                //ListProvince.Add("NGHEAN", "Nghệ An");
                //ListProvince.Add("NINHTHUAN", "Ninh Thuận");
                //ListProvince.Add("PHUYEN", "Phú Yên");
                //ListProvince.Add("THUATHIENHUE", "Thừa Thiên Huế");
                //ListProvince.Add("TAMKY", "Tam Kỳ");
                this.ProvinceCbx.Items.Clear();
                foreach (var item in ListProvince)
                {
                    ComboboxItem itemcbx = new ComboboxItem();
                    itemcbx.Text = item.Value;
                    itemcbx.Value = item.Key;

                    this.ProvinceCbx.Items.Add(itemcbx);
                }
                #endregion

                #region combobox District


                Dictionary<string, string> ListDistrictDN = new Dictionary<string, string>();
                ListDistrictDN.Add("HOAVANG", "Hoà Vang");
                ListDistrictDN.Add("HOANGSA", "Hoàng Sa");
                ListDistrictDN.Add("CAMLE", "Cẩm Lệ");
                ListDistrictDN.Add("HAICHAU", "Hải Châu");
                ListDistrictDN.Add("LIENCHIEU", "Liên Chiểu");
                ListDistrictDN.Add("NGUHANHSON", "Ngũ Hành Sơn");
                ListDistrictDN.Add("SONTRA", "Sơn Trà");
                ListDistrictDN.Add("THANHKHE", "Thanh Khê");
                ListProvinceToDistrict.Add("DANANG", ListDistrictDN);

                //QUANGBINH
                Dictionary<string, string> ListDistrictQB = new Dictionary<string, string>();
                ListDistrictQB.Add("LETHUY", "Lệ Thủy");
                ListDistrictQB.Add("MINHHOA", "Minh Hóa");
                ListDistrictQB.Add("TUYENHOA", "Tuyên Hóa");
                ListDistrictQB.Add("BOTRACH", "Bố Trạch");
                ListDistrictQB.Add("QUANGNINH", "Quảng Ninh");
                ListDistrictQB.Add("QUANGTRACH", "Quảng Trạch");
                ListDistrictQB.Add("DONGHOI", "Đồng Hới");

                ListProvinceToDistrict.Add("QUANGBINH", ListDistrictQB);

                //QUANG Nam
                Dictionary<string, string> ListDistrictQN = new Dictionary<string, string>();
                ListDistrictQN.Add("BACTRAMY", "Bắc Trà My");
                ListDistrictQN.Add("DAILOC", "Đại Lộc");
                ListDistrictQN.Add("DIENBAN", "Điện Bàn");
                ListDistrictQN.Add("DONGGIANG", "Đông Giang");
                ListDistrictQN.Add("DUYXUYEN", "Duy Xuyên");
                ListDistrictQN.Add("HIEPDUC", "Hiệp Đức");
                ListDistrictQN.Add("NAMGIANG", "Nam Giang");
                ListDistrictQN.Add("NAMTRAMY", "Nam Trà My");
                ListDistrictQN.Add("NONGSON", "Nông Sơn");
                ListDistrictQN.Add("NUITHANH", "Núi Thành");
                ListDistrictQN.Add("PHUNINH", "Phú Ninh");
                ListDistrictQN.Add("PHUOCSON", "Phước Sơn");
                ListDistrictQN.Add("QUESON", "Quế Sơn");
                ListDistrictQN.Add("TAYGIANG", "Tây Giang");
                ListDistrictQN.Add("THANGBINH", "Thăng Bình");
                ListDistrictQN.Add("TIENPHUOC", "Tiên Phước");
                ListDistrictQN.Add("HOIAN", "Hội An");
                ListDistrictQN.Add("TAMKY", "Tam Kỳ");

                ListProvinceToDistrict.Add("QUANGNAM", ListDistrictQN);

                //Quảng Ngãi
                Dictionary<string, string> ListDistrictQNg = new Dictionary<string, string>();
                ListDistrictQNg.Add("BATO", "Ba Tơ");
                ListDistrictQNg.Add("BINHSON", "Bình Sơn");
                ListDistrictQNg.Add("DUCPHO", "Đức Phổ");
                ListDistrictQNg.Add("LYSON", "Lý Sơn");
                ListDistrictQNg.Add("MINHLONG", "Minh Long");
                ListDistrictQNg.Add("MODUC", "Mộ Đức");
                ListDistrictQNg.Add("NGHIAHANH", "Nghĩa Hành");
                ListDistrictQNg.Add("SONHA", "Sơn Hà");
                ListDistrictQNg.Add("SONTAY", "Sơn Tây");
                ListDistrictQNg.Add("SONTINH", "Sơn Tịnh");
                ListDistrictQNg.Add("TAYTRA", "Tây Trà");
                ListDistrictQNg.Add("TRABONG", "Trà Bồng");
                ListDistrictQNg.Add("TUNGHIA", "Tư Nghĩa");
                ListDistrictQNg.Add("QUANGNGAI", "Quảng Ngãi");

                ListProvinceToDistrict.Add("QUANGNGAI", ListDistrictQNg);

                //QUANGTRI
                //Dictionary<string, string> ListDistrictQT = new Dictionary<string, string>();
                //ListDistrictQT.Add("CONCO", "Cồn Cỏ");
                //ListDistrictQT.Add("DAKRONG", "Đa Krông");
                //ListProvinceToDistrict.Add("QUANGTRI", ListDistrictQT);

                ////Bình Định
                //Dictionary<string, string> ListDistrictBD = new Dictionary<string, string>();
                //ListDistrictBD.Add("ANNHON", "An Nhơn");
                //ListDistrictBD.Add("QUINHON", "Qui Nhơn");
                //ListProvinceToDistrict.Add("BINHDINH", ListDistrictBD);

                ////Bình Thuận
                //Dictionary<string, string> ListDistrictBT = new Dictionary<string, string>();
                //ListDistrictBT.Add("PHUQUI", "Phú Quí");
                //ListProvinceToDistrict.Add("BINHTHUAN", ListDistrictBT);

                //Đắk Lắk
                //Dictionary<string, string> ListDistrictDL = new Dictionary<string, string>();
                //ListDistrictDL.Add("CUM'GAR", "Cư M'gar");
                //ListDistrictDL.Add("EAH'LEO", "Ea H'leo");
                //ListDistrictDL.Add("KRONGANA", "Krông A Na");
                //ListDistrictDL.Add("KRONGBUK", "Krông Búk");
                //ListDistrictDL.Add("LAK", "Lắk");
                //ListDistrictDL.Add("M'DRAK", "M'đrắk");
                //ListProvinceToDistrict.Add("DAKLAK", ListDistrictDL);

                foreach (var item in ListProvinceToDistrict)
                {
                    if (!item.Key.Contains("DANANG")) continue;
                    foreach (var itemDistrict in item.Value)
                    {
                        ComboboxItem itemcbx = new ComboboxItem();
                        itemcbx.Text = itemDistrict.Value;
                        itemcbx.Value = itemDistrict.Key;

                        DistrictCbx.Items.Add(itemcbx);
                    }
                }
                this.ProvinceCbx.SelectedIndex = -1;
                this.DistrictCbx.SelectedIndex = -1;
                #endregion
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
        }

        private void ProvinceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var province = (sender as ComboBox).SelectedItem as ComboboxItem ;
                foreach (var item in ListProvinceToDistrict)
                {
                    if (!item.Key.Contains(province.Value.ToString())) continue;
                    this.DistrictCbx.Items.Clear();
                    foreach (var itemDistrict in item.Value)
                    {
                        ComboboxItem itemcbx = new ComboboxItem();
                        itemcbx.Text = itemDistrict.Value;
                        itemcbx.Value = itemDistrict.Key;

                        this.DistrictCbx.Items.Add(itemcbx);
                    }
                }
                this.DistrictCbx.SelectedIndex = 0;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
