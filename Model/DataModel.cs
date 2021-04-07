using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportBill
{
    public class DataModel // from service
    {
        public string statusCode { get; set; }
        public string statusText { get; set; }
        public IList<string> data { get; set; }
    }
}
