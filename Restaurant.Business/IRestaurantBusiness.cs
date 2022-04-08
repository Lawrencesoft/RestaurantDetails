using Restaurant.Database;
using Restaurant.Database.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business
{
    public interface IRestaurantBusiness
    {
        public IList<RestaurantDetails> GetAvailableRestaurantDetails(DateTime dateTime);

        public void SaveAvailableRestaurantDetails(StreamReader reader);

        public object GetFoodStatus();
    }
}
