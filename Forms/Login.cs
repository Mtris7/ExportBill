using System;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserNameTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PassWordTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string _adHostname = @"LDAP://tienthu.vn";
                string _adUserName = UserNameTxt.Text + @"@tienthu.vn";
                string _adPassword = PassWordTxt.Text;
                bool loged = false;

                LdapDirectoryIdentifier identifier = new LdapDirectoryIdentifier(_adHostname, 636);
                NetworkCredential credential = new NetworkCredential(_adUserName, _adPassword);
                using (LdapConnection connection = new LdapConnection(identifier, credential))
                {
                    connection.SessionOptions.SecureSocketLayer = true;
                    connection.SessionOptions.VerifyServerCertificate += delegate { return true; };
                    connection.AuthType = AuthType.Basic;
                    connection.Bind(credential);

                    loged = connection.SessionOptions.Signing;
                    if (loged)
                    {
                        //var membersrv = ApplicationContext.Current.Services.MemberService;
                        //var member = membersrv.GetByUsername(UserNameTxt.Text);
                        //if (member != null && member.IsApproved)
                        //{
                        //    this.Close();
                        //    new FindCustomer().ShowDialog();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
