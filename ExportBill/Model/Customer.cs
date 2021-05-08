﻿namespace ExportBill
{

    public class Customer
    {
        public Customer() { }
        public Customer(string maPhieu, string userName , string bs = null, string lx = null, string tsc = null, string dg = null, decimal discount = 0,
                        int total = 0, string detaiMoney = null, string company = null, string adress = null, string date = null,
                        string pBill = null, string payment = null, string print = "print", string recallBill = "Hủy")
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
            PostBill = pBill;
            Payment = payment;
            PrintBill = print;
            RecallBill = recallBill;
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
        public string RecallBill { get; set; }
    }
}
