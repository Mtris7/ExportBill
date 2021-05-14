using ExportBill.Interface;
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
    }
}
