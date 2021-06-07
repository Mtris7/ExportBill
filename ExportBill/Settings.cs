using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportBill
{
    public class Settings
    {
        public const string API = "api";
        public const string URL = @"http://" + Settings.API + ".ototienthu.com.vn/api/v1/oauth/token";
        public const string userName = "apitest@tienthu.vn";
        public const string passWord = "62&z!]r*RV";
        public static string token = string.Empty;

        //public const string API = "app";
        //public const string userName = "tienthuapi@tienthu.vn";
        //public const string passWord = "Qq>a$5rWTf";
    }
}
