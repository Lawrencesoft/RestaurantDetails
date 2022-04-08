using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FoodStatus.ApiClient
{
    /// <summary>
    /// Client used to invoke the Postman API to get the Food Status.
    /// </summary>
    public sealed class FoodStatusApiClient : IFoodStatusApiClient
    {
        /// <summary>
        /// Postman Api base address
        /// </summary>
        private readonly string _baseAddress;

        /// <summary>
        /// Http Client
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Food Status Api client constructor
        /// </summary>
        /// <param name="baseUri"></param>
        public FoodStatusApiClient(string baseUri)
        {
            _baseAddress = baseUri;
        }
        public FoodStatusApiClient()
        {
        }

        /// <summary>
        /// To get the Food status from Postman API service
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetFoodStatus()
        {
            const string route = "get?foo1=bar1&foo2=bar2";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string requestUri = _baseAddress + route;
            var response = await client.GetAsync(requestUri);
            var contentString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var foodStatus = JsonConvert.DeserializeObject(contentString.ToString(), typeof(object));
               return foodStatus;
            }
            return null;
        }

        /// <summary>
        /// Dispose the client object
        /// </summary>
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
