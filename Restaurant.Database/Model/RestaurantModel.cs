using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Model
{
    /// <summary>
    /// RestaurantModel to store the Restaurant details
    /// </summary>
    public class RestaurantModel
    {
        /// <summary>
        /// Restaurant Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Restaurant Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Restaurant Availability Days
        /// </summary>
        public List<RestaurantAvailabilityModel> RestaurantAvailability { get; set; }
    }

    /// <summary>
    /// Class to pass the Restaurant Availability Days
    /// </summary>
    public class RestaurantAvailabilityModel
    {
        /// <summary>
        /// Restaurant Id
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Restaurant Available Day
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// Restaurant FromTime
        /// </summary>
        public DateTime FromTime { get; set; }

        /// <summary>
        /// Restaurant ToTime
        /// </summary>
        public DateTime ToTime { get; set; }
    }
}
