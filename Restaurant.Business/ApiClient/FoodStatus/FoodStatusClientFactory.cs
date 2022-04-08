using Microsoft.Extensions.Configuration;

namespace FoodStatus.ApiClient
{
    /// <summary>
    /// This class used to build the Http Client object
    /// </summary>
    public class FoodStatusClientFactory : IFoodStatusClientFactory
    {
        /// <summary>
        /// Food Status Api client
        /// </summary>
        private static IFoodStatusApiClient _client;

        /// <summary>
        /// TFL Api base URL
        /// </summary>
        private readonly string _baseUri;

        /// <summary>
        /// Food Status Client Factory Constructor
        /// </summary>
        public FoodStatusClientFactory(IConfiguration configuration)
        {
            _baseUri = configuration.GetSection("FoodApiURL").Value;
        }

        /// <summary>
        /// To dispose the http client
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
            _client = null;
        }

        /// <summary>
        /// To get the http client object
        /// </summary>
        /// <returns></returns>
        public IFoodStatusApiClient GetClient() => _client ?? (_client = CreateNewClient());

        /// <summary>
        /// To create the new http client
        /// </summary>
        /// <returns></returns>
        private IFoodStatusApiClient CreateNewClient() => new FoodStatusApiClient(_baseUri);

    }
}
