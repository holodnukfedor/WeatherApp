using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeartherStateBLL.Utils
{
    internal static class HttpClientExtension
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundException();

            response.EnsureSuccessStatusCode();
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}
