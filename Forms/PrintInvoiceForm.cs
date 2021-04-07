using Microsoft.Reporting.WinForms;
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
    public partial class PrintInvoiceForm : Form
    {
        public PrintInvoiceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void PrintInvoiceForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("DataTable_Report");
            DataColumn workCol = dt.Columns.Add("InvoiceID", typeof(Int32));
            dt.Columns.Add("InvoiceDate", typeof(String));
            dt.Columns.Add("CompanyName", typeof(String));
            dt.Columns.Add("Address", typeof(String));
            dt.Columns.Add("BS", typeof(String));
            dt.Columns.Add("Loaixe", typeof(String));
            dt.Columns.Add("Discount", typeof(int));

            dt.Columns.Add("ItemName", typeof(String));
            dt.Columns.Add("ItemQuality", typeof(int));
            dt.Columns.Add("ItemPrice", typeof(int));
            dt.Columns.Add("ItemTotal", typeof(decimal));
            dt.Columns.Add("ItemDetailPrice", typeof(String));
            dt.Columns.Add("TitleBotom", typeof(String));
            dt.Columns.Add("PhieuDV", typeof(String));
            dt.Rows.Add("1", "04052021", "Cửa hàng xe máy honda", "179 Phan Châu Trinh", "92E1-33719", "Exciter", 50, "nhớt", 1, 180000, 90000, "chín mươi ngàn đồng", "title bot", "OK");

            ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
            //Microsoft.Reporting.WinForms.ReportParameter[] param =  new ReportParameter[]
            //{
            //}
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Report\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
