using Restaurant.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database
{
    /// <summary>
    /// Restaurant Database Interface to store and retrive the data from SQL Server
    /// </summary>
    public interface IRestaurantDatabase
    {
        /// <summary>
        /// To get the available restaurant details from the given datetime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public IList<RestaurantDetails> FetchAvailableRestaurantDetails(DateTime dateTime);

        /// <summary>
        /// To insert the Available Restaurant details into SQL Database
        /// </summary>
        /// <param name="restaurantDetails"></param>
        public void InsertAvailableRestaurantDetails(RestaurantModel restaurantDetails);
    }
}
