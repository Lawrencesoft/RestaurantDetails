using System;
using System.Threading.Tasks;

namespace FoodStatus.ApiClient
{
    /// <summary>
    /// Client used to invoke the Postman API to get the Food Status.
    /// </summary>
    public interface IFoodStatusApiClient:IDisposable
    {
        /// <summary>
        /// To get the Food status from Postman API
        /// </summary>
        /// <returns></returns>
        Task<object> GetFoodStatus();
    }
}
