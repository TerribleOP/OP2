using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L3
{
    /// <summary>
    /// Base class for the hotel object
    /// </summary>
    public class Hotel : IComparable<Hotel>, IEquatable<Hotel>
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

        /// <summary>
        /// Implementation of IEquatable<Hotel>.Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Hotel other)
        {
            if (other == null) return false;
            return HotelName == other.HotelName && HotelType == other.HotelType && Cost == other.Cost;
        }

        /// <summary>
        /// Implementation of IComparable<Hotel>.CompareTo
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Hotel other)
        {
            if(HotelName.CompareTo(other.HotelName)==0)
            {
                if (HotelType.CompareTo(other.HotelType) == 0)
                {
                    return Cost.CompareTo(other.Cost);
                }
                return HotelType.CompareTo(other.HotelType);
            }
            return HotelName.CompareTo(other.HotelName);
        }
        /// <summary>
        /// Makes sure the objects are equal by comparing their properties
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Hotel hotel &&
                   HotelName == hotel.HotelName &&
                   HotelType == hotel.HotelType &&
                   Cost == hotel.Cost;
        }
        /// <summary>
        /// Converts the hotel object to a table row
        /// </summary>
        /// <returns></returns>
        public TableRow ToTableRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell { Text = HotelName });
            row.Cells.Add(new TableCell { Text = HotelType });
            row.Cells.Add(new TableCell { Text = Cost.ToString() });
            return row;
        }
    }
}