using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Model
{
    /// <summary>
    /// RestaurantDetails class to retrive the data from database
    /// </summary>
    public class RestaurantDetails
    {
        /// <summary>
        /// Restaurant Id
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Restaurant Name
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// Restaurant Day
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// Restaurant FromTime
        /// </summary>
        public string FromTime { get; set; }

        /// <summary>
        /// Restaurant ToTime
        /// </summary>
        public string ToTime { get; set; }

    }
}
