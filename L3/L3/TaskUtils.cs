using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L3
{
	public static class TaskUtils
    {
        public static WebForm WebForm
        {
            get => default;
            set
            {
            }
        }

        public static Hotel Hotel
        {
            get => default;
            set
            {
            }
        }

        public static Tourist Tourist
        {
            get => default;
            set
            {
            }
        }
        /// <summary>
        /// Finds the hotels that were used and unused
        /// </summary>
        /// <param name="BaseTourists"></param>
        /// <param name="original"></param>
        /// <param name="used"></param>
        /// <param name="unused"></param>
        public static void FindUsedUnused(CustomLinkedList<Tourist> BaseTourists, CustomLinkedList<Hotel> original, CustomLinkedList<Hotel> used, CustomLinkedList<Hotel> unused)
        {
            foreach(Hotel hotel in original)
            {
                
                bool isUsed = false;

                foreach (Tourist tourist in BaseTourists)
                {
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
        /// <summary>
        /// Finds the sum of each of the tourists
        /// </summary>
        /// <param name="Tourists"></param>
        /// <param name="Hotels"></param>
        public static void FindSum(CustomLinkedList<Tourist> Tourists, CustomLinkedList<Hotel> Hotels)
        {
            foreach (Tourist tourist in Tourists)
            {
                foreach (Hotel hotel in Hotels)
                {
                    if (hotel == tourist)
                    {
                        tourist.Sum = hotel * tourist;
                    }
                }
            }
        }
        /// <summary>
        /// Finds the longest stay
        /// </summary>
        /// <param name="Tourists"></param>
        /// <returns></returns>
        public static int FindLongestStay(CustomLinkedList<Tourist> Tourists)
        {
            int longest = 0;
            foreach (Tourist tourist in Tourists)
            {
                if (tourist.BookedNights > longest)
                {
                    longest = tourist.BookedNights;
                }
            }
            return longest;
        }
        /// <summary>
        /// Finds tourists who stayed the longest
        /// </summary>
        /// <param name="Tourists"></param>
        /// <param name="longestStay"></param>
        /// <param name="LongestStayTourists"></param>
        public static void FindTouristsWithLongestStay(CustomLinkedList<Tourist> Tourists, int longestStay, CustomLinkedList<Tourist> LongestStayTourists)
        {
            foreach (Tourist tourist in Tourists)
            {
                if (tourist.BookedNights == longestStay)
                {
                    LongestStayTourists.AddToEnd(tourist);
                }
            }
        }
        /// <summary>
        /// Finds tourists who spent less than the maximum amount
        /// </summary>
        /// <param name="Tourists"></param>
        /// <param name="maximum"></param>
        /// <param name="MinSpenders"></param>
        public static void findMinSpenders(CustomLinkedList<Tourist> Tourists, int maximum, CustomLinkedList<Tourist> MinSpenders)
        {
            foreach (Tourist tourist in Tourists)
            {
                if (tourist.Sum < maximum && tourist.Sum !=0)
                {
                    MinSpenders.AddToEnd(tourist);
                }
            }
        }
    }
}