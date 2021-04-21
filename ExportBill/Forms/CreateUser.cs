using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
            MainLoad();
        }
        public void MainLoad()
        {
        }

        private void CreateSaveBtn_Click(object sender, EventArgs e)
        {
            string maKH = string.Empty;
            this.Close();
            new CreateService(maKH, NameTxt.Text,BSTxt.Text).ShowDialog();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
