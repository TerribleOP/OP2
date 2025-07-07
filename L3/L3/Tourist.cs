using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L3
{
    public class Tourist : IComparable<Tourist>, IEquatable<Tourist>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public int BookedNights { get; set; }

        public int Sum { get; set; } = 0;
        /// <summary>
        /// Constructor for the tourist object
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="hotelName"></param>
        /// <param name="roomType"></param>
        /// <param name="bookedNights"></param>
        public Tourist(string lastName, string firstName, string hotelName, string roomType, int bookedNights)
        {
            LastName = lastName;
            FirstName = firstName;
            HotelName = hotelName;
            RoomType = roomType;
            BookedNights = bookedNights;
        }
        /// <summary>
        /// Overriden ToString method for the tourist object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line = $"{LastName,-15} | {FirstName,-15} | {HotelName,-10} | {RoomType,-15} | {BookedNights,22}|";
            return line;
        }
        /// <summary>
        /// Compares two tourist objects by their last name and first name
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Tourist other)
        {
            if (this.LastName.CompareTo(other.LastName) == 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            return this.LastName.CompareTo(other.LastName);
        }
        /// <summary>
        /// Makes sure the objects are equal by comparing their properties
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Tourist tourist &&
                   LastName == tourist.LastName &&
                   FirstName == tourist.FirstName &&
                   HotelName == tourist.HotelName &&
                   RoomType == tourist.RoomType &&
                   BookedNights == tourist.BookedNights;
        }
        /// <summary>
        /// makes sure the tourists are equal by comparing their properties
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Tourist other)
        {
            return other != null &&
                   LastName == other.LastName &&
                   FirstName == other.FirstName &&
                   HotelName == other.HotelName &&
                   RoomType == other.RoomType &&
                   BookedNights == other.BookedNights;
        }
        /// <summary>
        /// Gets the hashcode of the tourist object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 499324390;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HotelName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RoomType);
            hashCode = hashCode * -1521134295 + BookedNights.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compares a hotel and tourist object by their hotel name and room type
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="tourist"></param>
        /// <returns></returns>
        public static bool operator ==(Hotel hotel, Tourist tourist)
        {
            return hotel.HotelName == tourist.HotelName && hotel.HotelType == tourist.RoomType;
        }
        /// <summary>
        /// Compares a hotel and tourist object by their hotel name and room type
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="tourist"></param>
        /// <returns></returns>
        public static bool operator !=(Hotel hotel, Tourist tourist)
        {
            return !(hotel == tourist);
        }

        /// <summary>
        /// Operator to calculate the total cost of the tourist's stay
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="tourist"></param>
        /// <returns></returns>
        public static int operator *(Hotel hotel, Tourist tourist)
        {
            return tourist.BookedNights * hotel.Cost;
        }

        public TableRow ToTableRow(bool isAnswer = false)
        {
            TableRow row = new TableRow();
            if (isAnswer)
            {
                row.Cells.Add(new TableCell { Text = LastName });
                row.Cells.Add(new TableCell { Text = FirstName });
                row.Cells.Add(new TableCell { Text = Sum.ToString() });                
            }
            else
            {
                row.Cells.Add(new TableCell { Text = LastName });
                row.Cells.Add(new TableCell { Text = FirstName });
                row.Cells.Add(new TableCell { Text = HotelName });
                row.Cells.Add(new TableCell { Text = RoomType });
                row.Cells.Add(new TableCell { Text = BookedNights.ToString() });
            }
            return row;
        }
    }
}