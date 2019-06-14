using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestingWorkshop.Fundamentals
{
    public class Wrapper
    {
        private readonly string dmsUrl = "http://dummy.restapiexample.com/api/v1/employee/";
        private readonly IHttpClientWrapper _httpClientWrapper;

        public Wrapper(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<string> Get(int documentId)
        {
            var response = await _httpClientWrapper.GetAsync($"{dmsUrl}{documentId}");

            return response.StatusCode == HttpStatusCode.OK 
                ? await response.Content.ReadAsStringAsync() 
                : "Error";
        }

        public async Task<string> Save(string document)
        {
            var content = new StringContent(document);
            var response = await _httpClientWrapper.PostAsync(dmsUrl, content);

            return response.StatusCode == HttpStatusCode.Created
                ? await response.Content.ReadAsStringAsync()
                : "Error";
        }
    }

    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }

    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await httpClient.PostAsync(url, content);
        }
    }

}
