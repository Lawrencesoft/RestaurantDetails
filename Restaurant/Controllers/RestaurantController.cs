using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Business;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Restaurant.Controllers
{
    /// <summary>
    /// Restaurant Controller
    /// </summary>
    public class RestaurantController : Controller
    {
        private readonly IRestaurantBusiness _restaurantBusiness;

        /// <summary>
        /// Constructer of Restaurant Controller 
        /// </summary>
        /// <param name="restaurantBusiness"></param>
        public RestaurantController(IRestaurantBusiness restaurantBusiness)
        {
            _restaurantBusiness = restaurantBusiness;
        }
        
        /// <summary>
        /// To retrive all the available restaurent details from the given datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RestaurantDetails(string date)
        {
            IList<RestaurantViewModel> restaurantDetails;
            restaurantDetails = GetAvailableRestaurantDetails(date);

            return View(restaurantDetails);
        }

        /// <summary>
        /// To upload the restaurent details from file to database
        /// </summary>
        /// <param name="uploadFiles"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RestaurantDetails(List<IFormFile> uploadFiles)
        {
            try
            {
                foreach (IFormFile postedFile in uploadFiles)
                {
                    var result = new StringBuilder();
                    using (var reader = new StreamReader(postedFile.OpenReadStream()))
                    {
                        _restaurantBusiness.SaveAvailableRestaurantDetails(reader);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", postedFile.FileName);
                    }
                }
            }
            catch(Exception)
            {
                //TODO: Log the exception
            }

            return View();
        }

        /// <summary>
        /// To search the available Restaurent details from the given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Search(string date)
        {
            return PartialView("_partial", GetAvailableRestaurantDetails(date));
        }

        [HttpGet]
        public IActionResult ApiResult()
        {
            try
            {
                ViewBag.Message = _restaurantBusiness.GetFoodStatus();
            }
            catch (Exception)
            {
                //TODO: Log the exception
            }

            return View();
        }

        /// <summary>
        /// Retrive the available details and map to the UI model
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private IList<RestaurantViewModel> GetAvailableRestaurantDetails(string date)
        {
            IList<RestaurantViewModel> restaurantDetails = new List<RestaurantViewModel>();
            if (!string.IsNullOrWhiteSpace(date))
            {
                try
                {
                    var restaurantList = _restaurantBusiness.GetAvailableRestaurantDetails(Convert.ToDateTime(date));
                    foreach (var item in restaurantList)
                    {
                        restaurantDetails.Add(new RestaurantViewModel { RestaurantName = item.RestaurantName, RestaurantId = item.RestaurantId, Day = item.Day, FromTime = item.FromTime, ToTime = item.ToTime });
                    }
                }
                catch (Exception)
                {
                    //TODO: Log the exception
                }
            }
            return restaurantDetails;
        }

    }
}
