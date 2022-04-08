using FoodStatus.ApiClient;
using Restaurant.Database;
using Restaurant.Database.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Restaurant.Business
{
    /// <summary>
    /// Restaurant Business class to implement all the business logic
    /// </summary>
    public class RestaurantBusiness : IRestaurantBusiness
    {
        private readonly IRestaurantDatabase _restaurantDatabase;
        private readonly IFoodStatusClientFactory _foodStatusClientFactory;

        /// <summary>
        /// Restaurant Business Constructer
        /// </summary>
        /// <param name="restaurantDatabase"></param>
        /// <param name="foodStatusClientFactory"></param>
        public RestaurantBusiness(IRestaurantDatabase restaurantDatabase, IFoodStatusClientFactory foodStatusClientFactory)
        {
            _restaurantDatabase = restaurantDatabase;
            _foodStatusClientFactory = foodStatusClientFactory;
        }

        /// <summary>
        /// Retrive the Available Restaurant Details
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public IList<RestaurantDetails> GetAvailableRestaurantDetails(DateTime dateTime)
        {
            return _restaurantDatabase.FetchAvailableRestaurantDetails(dateTime);
        }

        /// <summary>
        /// Save the Available Restaurant Details from stream
        /// </summary>
        /// <param name="reader"></param>
        public void SaveAvailableRestaurantDetails(StreamReader reader)
        {
            IList<RestaurantModel> restaurantDetailList = SaveAvailableRestaurantDetailsfromStream(reader);
            foreach (var restaurantDetail in restaurantDetailList)
            {
                _restaurantDatabase.InsertAvailableRestaurantDetails(restaurantDetail);
            }
        }

        /// <summary>
        /// To get the Food status from the given Postman API
        /// </summary>
        /// <returns></returns>
        public object GetFoodStatus()
        {
            var client = _foodStatusClientFactory.GetClient();
            var response = client.GetFoodStatus().Result;
            return response;
        }

        /// <summary>
        /// Save the Available Restaurant Details from file Stream to SQL database
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private IList<RestaurantModel> SaveAvailableRestaurantDetailsfromStream(StreamReader reader)
        {
            IList<RestaurantModel> restaurantDetails = new List<RestaurantModel>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                RestaurantModel restaurant = new RestaurantModel();
                restaurant.Name = line.Split(",")[0];
                var fullAvailabily = line.Replace(restaurant.Name + ",", ""); // We can do this with substring also
                if (fullAvailabily.Split("/").Length > 1)
                {
                    fullAvailabily = fullAvailabily.Replace("\"", "");
                }
                restaurant.RestaurantAvailability = new List<RestaurantAvailabilityModel>();
                foreach (var availability in fullAvailabily.Split("/"))
                {
                    var availableDays = availability.Replace("\"", "");
                    var availableSlots = availableDays.TrimEnd().TrimStart().Split(",");
                    if (availableSlots.Length == 1)
                    {
                        var availableDay = availableSlots[0].Split(" ");
                        var days = GenerateAvailableDaysList(availableDay[0]);
                        var timeSlot = availableSlots[0].Replace(availableDay[0], "").TrimStart().TrimEnd();
                        foreach (var day in days)
                        {
                            restaurant.RestaurantAvailability.Add(GenerateAvailableDay(day, timeSlot));
                        }
                    }
                    else
                    {
                        foreach (var daySlot in availableSlots)
                        {
                            if (daySlot.Contains("Mon-"))
                            {
                                var timeSlot = availableDays.TrimEnd().TrimStart().Replace(daySlot + ", ", "").Substring(3);
                                var days = GenerateAvailableDaysList(daySlot);
                                foreach (var day in days)
                                {
                                    restaurant.RestaurantAvailability.Add(GenerateAvailableDay(day, timeSlot));
                                }
                            }
                            else if (daySlot.Contains("Mon"))
                            {
                                var timeSlot = availableDays.TrimEnd().TrimStart().Replace(daySlot + ", ", "").Substring(9);
                                var days = GenerateAvailableDaysList(daySlot);
                                foreach (var day in days)
                                {
                                    restaurant.RestaurantAvailability.Add(GenerateAvailableDay(day, timeSlot));
                                }
                            }
                            else if (daySlot.Contains("Wed-"))
                            {
                                var timeSlot = daySlot.TrimEnd().TrimStart().Substring(8);
                                var days = GenerateAvailableDaysList(daySlot.TrimStart().TrimEnd().Substring(0, 7));
                                foreach (var day in days)
                                {
                                    restaurant.RestaurantAvailability.Add(GenerateAvailableDay(day, timeSlot));
                                }
                            }
                            else
                            {
                                var timeSlot = daySlot.TrimEnd().TrimStart().Substring(3);
                                var days = GenerateAvailableDaysList(daySlot.TrimStart().TrimEnd().Substring(0, 3));
                                foreach (var day in days)
                                {
                                    restaurant.RestaurantAvailability.Add(GenerateAvailableDay(day, timeSlot));
                                }
                            }
                        }
                    }
                }
                restaurantDetails.Add(restaurant);
            }
            return restaurantDetails;
        }

        /// <summary>
        /// Generate the available days list from the given days range
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<string> GenerateAvailableDaysList(string input)
        {
            switch (input.TrimStart().TrimEnd())
            {
                case "Mon-Tue":
                    return new List<string>() { "Monday", "Tuesday" };
                case "Mon-Wed":
                    return new List<string>() { "Monday", "Tuesday", "Wednesday" };
                case "Mon-Thu":
                    return new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday" };
                case "Mon-Fri":
                    return new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
                case "Mon-Sat":
                    return new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                case "Mon-Sun":
                    return new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                case "Fri-Sat":
                    return new List<string>() { "Friday", "Saturday" };
                case "Fri-Sun":
                    return new List<string>() { "Friday", "Saturday", "Sunday" };
                case "Sat-Sun":
                    return new List<string>() { "Saturday", "Sunday" };
                case "Thu-Fri":
                    return new List<string>() { "Thursday", "Friday" };
                case "Wed-Sun":
                    return new List<string>() { "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                case "Mon":
                    return new List<string>() { "Monday" };
                case "Tue":
                    return new List<string>() { "Tuesday" };
                case "Wed":
                    return new List<string>() { "Wednesday" };
                case "Thu":
                    return new List<string>() { "Thursday" };
                case "Fri":
                    return new List<string>() { "Friday" };
                case "Sat":
                    return new List<string>() { "Saturday" };
                case "Sun":
                    return new List<string>() { "Sunday" };
            }
            return null;
        }

        /// <summary>
        /// To Generate the available day model from the day and time
        /// </summary>
        /// <param name="day"></param>
        /// <param name="timeSlot"></param>
        /// <returns></returns>
        private RestaurantAvailabilityModel GenerateAvailableDay(string day, string timeSlot)
        {
            return new RestaurantAvailabilityModel()
            {
                Day = day,
                FromTime = Convert.ToDateTime(timeSlot.TrimStart().TrimEnd().Split("-")[0]),
                ToTime = Convert.ToDateTime(timeSlot.TrimStart().TrimEnd().Split("-")[1])
            };
        }

    }
}
