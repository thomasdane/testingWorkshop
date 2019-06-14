using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestingWorkshop.Fundamentals
{
    public class DmsManager
    {
        private readonly string dmsUrl = "http://dummy.restapiexample.com/api/v1/employee/";
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<string> Get(int documentId)
        {
            var response = await httpClient.GetAsync($"{dmsUrl}{documentId}");

            return response.StatusCode == HttpStatusCode.OK 
                ? await response.Content.ReadAsStringAsync() 
                : "Error";
        }

        public async Task<string> Save(string document)
        {
            var content = new StringContent(document);
            var response = await httpClient.PostAsync(dmsUrl, content);

            return response.StatusCode == HttpStatusCode.Created
                ? await response.Content.ReadAsStringAsync()
                : "Error";
        }
    }
}
