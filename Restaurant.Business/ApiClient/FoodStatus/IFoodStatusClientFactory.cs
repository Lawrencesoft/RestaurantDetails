using System;

namespace FoodStatus.ApiClient
{
    /// <summary>
    /// This class used to build the Http Client object
    /// </summary>
    public interface IFoodStatusClientFactory:IDisposable
    {
        /// <summary>
        /// To get the http client object
        /// </summary>
        /// <returns></returns>
        IFoodStatusApiClient GetClient();
    }
}
