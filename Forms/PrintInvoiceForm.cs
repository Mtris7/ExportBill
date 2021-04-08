using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExportBill
{
    public partial class PrintInvoiceForm : Form
    {
        bool auto = false;
        public PrintInvoiceForm()
        {
            InitializeComponent();
        }

        private void PrintInvoiceForm_Load(object sender, EventArgs e)
        {
            if (!auto)
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
                dt.Columns.Add("Image", typeof(byte[]));

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
                {
                    BarWidth = 1,
                };
                Image img = barcode.Encode(BarcodeLib.TYPE.CODE128B, "www.tienthu.com.vn", Color.Black, Color.White, 100, 30);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                dt.Rows.Add("1", "04052021", "Cửa hàng xe máy honda", "179 Phan Châu Trinh", "92E1-33719", "Exciter", 50, "nhớt", 1, 180000, 90000, "chín mươi ngàn đồng", "title bot", "OK", ms.ToArray());

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
            else
                Run();

        }
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
        }
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
        private void Run()
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
            dt.Columns.Add("Image", typeof(byte[]));

            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                BarWidth = 1,
            };
            Image img = barcode.Encode(BarcodeLib.TYPE.CODE128B, "www.tienthu.com.vn", Color.Black, Color.White, 100, 30);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            dt.Rows.Add("1", "04052021", "Cửa hàng xe máy honda", "179 Phan Châu Trinh", "92E1-33719", "Exciter", 50, "nhớt", 1, 180000, 90000, "chín mươi ngàn đồng", "title bot", "OK", ms.ToArray());

            ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);

            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + @"\Report\Report1.rdlc";
            report.DataSources.Add(dataSource);
            Export(report);
            Print();
        }
    }
}
