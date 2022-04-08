using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Restaurant.Business;
using Restaurant.Controllers;
using Restaurant.Database.Model;
using Restaurant.Models;
using System;
using System.Collections.Generic;

namespace Restaurant.Test
{
    [TestClass]
    public class RestaurantControllerTest
    {
        private readonly IRestaurantBusiness _restaurantBusiness;
        private readonly RestaurantController _restaurantController;

        public RestaurantControllerTest()
        {
            _restaurantBusiness = Substitute.For<IRestaurantBusiness>();
            _restaurantController = new RestaurantController(_restaurantBusiness);
        }

        [TestMethod]
        public void RestaurantDetails_ValidDate_ShouldMatchTheResult()
        {
            //Arrange
            string date = "2022-04-08 10:17";
            IList<RestaurantDetails> restaurantList = new List<RestaurantDetails>
            {
                new RestaurantDetails(){Day = "Friday", RestaurantName="UberEats", FromTime="06:00", ToTime="24:00"},
                new RestaurantDetails(){Day = "Friday", RestaurantName="IndianFood", FromTime="05:00", ToTime="18:00"},
                new RestaurantDetails(){Day = "Friday", RestaurantName="AsianMeal", FromTime="16:00", ToTime="22:30"}
            };
            _restaurantBusiness.GetAvailableRestaurantDetails(Convert.ToDateTime(date)).Returns(restaurantList);

            //Act
            var response = _restaurantController.RestaurantDetails(date) as ViewResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Model);
            var model = response.Model as IList<RestaurantViewModel>;
            Assert.AreEqual(model.Count,3);
            Assert.AreEqual(model[0].RestaurantName, "UberEats");
            Assert.AreEqual(model[1].RestaurantName, "IndianFood");
            Assert.AreEqual(model[2].RestaurantName, "AsianMeal");
            Assert.IsTrue(string.IsNullOrEmpty(response.ViewName) || response.ViewName == "RestaurantDetails");
        }

        [TestMethod]
        [DataRow(null)]
        public void RestaurantDetails_InvalidDate_ShouldReturnZeroCounts(string date)
        {
            //Arrange
            IList<RestaurantDetails> restaurantList = new List<RestaurantDetails>
            {
                new RestaurantDetails(){Day = "Friday", RestaurantName="UberEats", FromTime="06:00", ToTime="24:00"},
                new RestaurantDetails(){Day = "Friday", RestaurantName="IndianFood", FromTime="05:00", ToTime="18:00"},
                new RestaurantDetails(){Day = "Friday", RestaurantName="AsianMeal", FromTime="16:00", ToTime="22:30"}
            };
            _restaurantBusiness.GetAvailableRestaurantDetails(Convert.ToDateTime(date)).Returns(restaurantList);

            //Act
            var response = _restaurantController.RestaurantDetails(date) as ViewResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Model);
            var model = response.Model as IList<RestaurantViewModel>;
            Assert.AreEqual(model.Count, 0);
            Assert.IsTrue(string.IsNullOrEmpty(response.ViewName) || response.ViewName == "RestaurantDetails");
        }
    }
}
