using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    public class TaskUtils
    {
        /// <summary>
        /// Finds the sum of nights in hotels for each tourist
        /// </summary>
        /// <param name="tourists"></param>
        /// <param name="hotels"></param>
        public static void FindSumOfNightsInHotels(TouristLinkedList tourists, HotelLinkedList hotels)
        {
            for (tourists.Start(); tourists.Exists(); tourists.Next())
            {
                Tourist tourist = tourists.Get();
                for (hotels.Start(); hotels.Exists(); hotels.Next())
                {
                    Hotel hotel = hotels.Get();
                    if (hotel == tourist)
                    {
                        tourist.Sum = hotel*tourist;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Finds the longest night in the hotels
        /// </summary>
        /// <param name="tourists"></param>
        /// <returns></returns>
        public static int FindLongestNight(TouristLinkedList tourists)
        {
            int longestStay = 0;
            for (tourists.Start(); tourists.Exists(); tourists.Next())
            {
                Tourist tourist = tourists.Get();
                if (tourist.BookedNights > longestStay)
                {
                    longestStay = tourist.BookedNights;
                }
            }
            return longestStay;
        }
        /// <summary>
        /// Finds the tourist with the longest stay
        /// </summary>
        /// <param name="BaseTourists"></param>
        /// <param name="asnwerList"></param>
        /// <param name="longestStay"></param>
        public static void FindTouristWithLongestStay(TouristLinkedList BaseTourists, TouristLinkedList asnwerList, int longestStay)
        {
            for (BaseTourists.Start(); BaseTourists.Exists(); BaseTourists.Next())
            {
                Tourist tourist = BaseTourists.Get();
                if (tourist.BookedNights == longestStay)
                {
                    asnwerList.AddToEnd(tourist);
                }
            }
        }
        /// <summary>
        /// Finds the tourist with the smallest sum
        /// </summary>
        /// <param name="BaseTourists"></param>
        /// <param name="asnwerList"></param>
        /// <param name="Limit"></param>
        public static void FindMinSpenders(TouristLinkedList BaseTourists, TouristLinkedList asnwerList, int Limit)
        {
            for (BaseTourists.Start(); BaseTourists.Exists(); BaseTourists.Next())
            {
                Tourist tourist = BaseTourists.Get();
                if (tourist.Sum < Limit && tourist.Sum != 0) 
                {
                    asnwerList.AddToEnd(tourist);
                }
            }
        }

        public static void FindUsedUnused(TouristLinkedList BaseTourists, HotelLinkedList original, HotelLinkedList used, HotelLinkedList unused)
        {
            for (original.Start(); original.Exists(); original.Next())
            {
                Hotel hotel = original.Get();
                bool isUsed = false;

                for (BaseTourists.Start(); BaseTourists.Exists(); BaseTourists.Next())
                {
                    Tourist tourist = BaseTourists.Get();
                    if (hotel == tourist)
                    {
                        isUsed = true;
                        break;
                    }
                }

                if (isUsed)
                {
                    used.AddToEnd(hotel);
                }
                else
                {
                    unused.AddToEnd(hotel);
                }
            }
        }
    }
}