using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public string Day { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }

    }
}
