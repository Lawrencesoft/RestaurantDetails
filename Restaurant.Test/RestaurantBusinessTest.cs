using FoodStatus.ApiClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Business;
using Restaurant.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Test
{
    [TestClass]
    public class RestaurantBusinessTest
    {
        private readonly IRestaurantDatabase _restaurantDatabase;
        private readonly IFoodStatusClientFactory _foodStatusClientFactory;
        private readonly IRestaurantBusiness _restaurantBusiness;
        
        public RestaurantBusinessTest()
        {
            _restaurantDatabase = NSubstitute.Substitute.For<IRestaurantDatabase>();
            _foodStatusClientFactory = NSubstitute.Substitute.For<IFoodStatusClientFactory>();
            _restaurantBusiness = new RestaurantBusiness(_restaurantDatabase, _foodStatusClientFactory);
        }

        [TestMethod]
        public void SaveAvailableRestaurantDetails_ValidValues_ShouldResturnSuccessfullResponse()
        {
            //Arrange
            //TODO: Add multiple test cases for all pasitive and negative test scenarios
            //Act

            //Arrange
        }
    }
}
