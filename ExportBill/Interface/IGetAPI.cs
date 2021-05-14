using System.Net.Http;
using System.Threading.Tasks;

namespace ExportBill.Interface
{
    public interface IGetAPI
    {
        Task<HttpResponseMessage> post(string url, FormUrlEncodedContent formContent);
    }
}
