using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportBill
{

    public class Customer
    {
        public Customer() { }
        public Customer(string maPhieu, string userName, string bs, string lx, string tsc, string dg, decimal discount,
                        int total, string detaiMoney, string company, string adress, string date, string print,
                        string pBill, string payment)
        {
            MaPhieu = maPhieu;
            UserName = userName;
            BS = bs;
            LX = lx;
            TSC = tsc;
            DG = dg;
            Discount = discount;
            Total = total;
            DetailMoney = detaiMoney;
            Company = company;
            Adress = adress;
            Date = date;
            PrintBill = print;
            PostBill = pBill;
            Payment = payment;
        }
        public string MaPhieu { get; set; }
        public string UserName { get; set; }
        public string BS { get; set; }
        public string LX { get; set; }
        public string TSC { get; set; }
        public string DG { get; set; }
        public decimal Discount { get; set; }
        public int Total { get; set; }
        public string DetailMoney { get; set; }
        public string Company { get; set; }
        public string Adress { get; set; }
        public string PrintBill { get; set; }
        public string PostBill { get; set; }
        public string Date { get; set; }
        public string Payment { get; set; }
    }
}
