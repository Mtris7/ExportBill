﻿namespace ExportBill
{
    public class ItemSell
    {
        //DẦU NHỚT PHUY XE TAY GA 200L-10W30(MB);0.80;liters;86,000.00;0.00"
        public string itemName { get; set; }
        public string itemQuality { get; set; }
        public string itemUnit { get; set; }
        public string itemPrice { get; set; }
        public string TotalBeforeDiscount { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }
        public string workerId { get; set; }
        public string adviserId { get; set; }
        public decimal lineDisc { get; set; }
    }
}
