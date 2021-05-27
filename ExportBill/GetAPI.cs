using ExportBill.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExportBill
{
    public class GetAPI : IGetAPI
    {
        public async Task<HttpResponseMessage> post(string url,FormUrlEncodedContent formContent)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            
            request.Content = formContent;
            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> Only_url(string url)
        {
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            return await client.SendAsync(request);
        }
        public string Post_NoAsyn(string url, FormUrlEncodedContent formContent)
        {
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(url);
            int _TimeoutSec = 90;
            cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
            string _ContentType = "application/x-www-form-urlencoded";
            cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
            cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DXMain.token);

            var req = new HttpRequestMessage(HttpMethod.Post, url);
            req.Content = formContent;
            var res = cl.SendAsync(req).Result;
            string apiResponse = res.Content.ReadAsStringAsync().Result;
            return apiResponse;
        }

    }
    
}
