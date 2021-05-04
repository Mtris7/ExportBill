namespace ExportBill
{
    public class ItemSell
    {
        //DẦU NHỚT PHUY XE TAY GA 200L-10W30(MB);0.80;liters;86,000.00;0.00"
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemQuality { get; set; }
        public string ItemUnit { get; set; }
        public string ItemPrice { get; set; }
        public string TotalBeforeDiscount { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }
        public string WorkerId { get; set; }
        public string AdviserId { get; set; }
        public decimal LineDisc { get; set; }
        public ItemSell()
        {
        }
        public ItemSell(string itemID ,string itemName , string itemQuality = null, string itemUnit = null, string itemPrice = null,
                            string totalBeforeDiscount = null, string discount = null, string total = null
                            , string workerId = null, string adviserId = null, decimal lineDisc = 0)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemQuality = itemQuality;
            ItemUnit = itemUnit;
            ItemPrice = itemPrice;
            TotalBeforeDiscount = totalBeforeDiscount;
            Discount = discount;
            Total = total;
            WorkerId = workerId;
            AdviserId = adviserId;
            LineDisc = lineDisc;
        }
    }
}
