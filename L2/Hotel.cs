using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// Base class for the hotel object
    /// </summary>
    class Hotel
    {
        public string HotelName { get; set; }
        public string HotelType { get; set; }
        public int Cost { get; set; }
        /// <summary>
        /// Constructor for the hotel object
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="hotelType"></param>
        /// <param name="cost"></param>
        public Hotel(string hotelName, string hotelType, int cost)
        {
            HotelName = hotelName;
            HotelType = hotelType;
            Cost = cost;
        }
        /// <summary>
        /// Overriden ToString method for the hotel object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line = $"{HotelName,-15} | {HotelType,-15} | {Cost,5}|";
            return line;
        }
    }
}