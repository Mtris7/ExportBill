using System.Collections.Generic;

namespace ExportBill
{
    public class DataModel // from service
    {
        public string statusCode { get; set; }
        public string statusText { get; set; }
        public IList<string> data { get; set; }
    }
}
