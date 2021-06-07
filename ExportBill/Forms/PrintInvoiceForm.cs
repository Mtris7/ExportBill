using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class PrintInvoiceForm : Form
    {
        string titleBottom = "*chỉ xuất hóa đơn trong ngày*";
        bool auto = false;
        Customer customer = new Customer();
        public PrintInvoiceForm(Customer customer, bool auto = false)
        {
            InitializeComponent();
            this.auto = auto;
            this.customer = customer;
        }

        private async void PrintInvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!auto)
                {
                    DataTable dt = await LoadData();

                    ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
                    
                    reportViewer1.Reset();
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Report\Report1.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(dataSource);
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                    reportViewer1.ShowPrintButton = false;
                }
                else
                    Run();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>2.84in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.04in</MarginLeft>
                <MarginRight>0.04in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        private async void Run()
        {
            DataTable dt = await LoadData();

            ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);

            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + @"\Report\Report1.rdlc";
            report.DataSources.Add(dataSource);
            Export(report);
            Print();
            this.Close();
        }
        private async Task<DataTable> LoadData()
        {
            try
            {
                DataTable dt = new DataTable("DataTable_Report");
                DataColumn workCol = dt.Columns.Add("InvoiceID", typeof(Int32));
                dt.Columns.Add("InvoiceDate", typeof(String));
                dt.Columns.Add("CompanyName", typeof(String));
                dt.Columns.Add("Address", typeof(String));
                dt.Columns.Add("BS", typeof(String));
                dt.Columns.Add("Loaixe", typeof(String));
                dt.Columns.Add("Discount", typeof(String));

                dt.Columns.Add("ItemName", typeof(String));
                dt.Columns.Add("ItemQuality", typeof(String));
                dt.Columns.Add("ItemPrice", typeof(String));
                dt.Columns.Add("TotalBeforeDiscount", typeof(String));
                dt.Columns.Add("ItemTotal", typeof(String));
                dt.Columns.Add("ItemDetailPrice", typeof(String));
                dt.Columns.Add("TitleBotom", typeof(String));
                dt.Columns.Add("PhieuDV", typeof(String));
                dt.Columns.Add("Image", typeof(byte[]));
                dt.Columns.Add("PhoneStaff", typeof(String));
                dt.Columns.Add("NameStaff", typeof(String));

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
                {
                    BarWidth = 1,
                };
                Image img = barcode.Encode(BarcodeLib.TYPE.CODE128B, this.customer.MaPhieu, Color.Black, Color.White, 100, 30);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);

                List<ItemSell> itemSell = new List<ItemSell>();
                if (this.customer != null)
                {
                    string url = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/customers/BillService?serviceOrderId=" + this.customer.MaPhieu;
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, url);

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var dataList = JsonConvert.DeserializeObject<DataModel>(body);
                        if (dataList.data == null)
                        {
                            MessageBox.Show("Có lỗi dữ liệu từ máy chủ, vui lòng đăng nhập lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        if (dataList.data.Count == 0)
                        {
                            DialogResult result = MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return null;
                        }
                        foreach (var item in dataList.data)
                        {
                            var data = item.Split(';');
                            ItemSell items = new ItemSell();
                            items.ItemName = data[0];
                            items.ItemQuality = Convert.ToDecimal(data[1]).ToString("N2");
                            items.ItemUnit = data[2];
                            items.ItemPrice = Convert.ToDecimal(data[3]).ToString("N0");
                            items.TotalBeforeDiscount = Convert.ToDecimal(data[3]).ToString("N0");
                            itemSell.Add(items);
                        }
                        foreach(var item in itemSell) item.TotalBeforeDiscount = itemSell.Sum(x=> Convert.ToDecimal(x.ItemPrice)).ToString("N0");
                    }
                    int i = 0;
                    foreach (var item in itemSell)
                    {
                        var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        dt.Rows.Add(i, "Ngày in phiếu: " + dateTime, this.customer.Company, this.customer.Adress, "Biển số: " + this.customer.BS, "Dòng xe:" + this.customer.LX,
                            this.customer.Discount.ToString("N0"), item.ItemName, item.ItemQuality, item.ItemPrice, item.TotalBeforeDiscount, Convert.ToDecimal(this.customer.Total).ToString("N0"),
                            "(" + this.customer.DetailMoney + ")", this.titleBottom, "Số phiếu:" + this.customer.MaPhieu, ms.ToArray(),"ĐT: " +Staff.Phone, "Thu ngân: " + Staff.UserName);
                        i++;
                    }
                }
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
