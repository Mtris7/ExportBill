using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportBill
{
    public class ItemSell
    {
        //DẦU NHỚT PHUY XE TAY GA 200L-10W30(MB);0.80;liters;86,000.00;0.00"
        public string itemName { get; set; }
        public int itemQuality { get; set; }
        public string itemType { get; set; }
        public int itemPrice { get; set; }
    }
}
