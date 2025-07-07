using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace L2
{
    class InOutUtils
    {
        /// <summary>
        /// Reads tourists from the file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="tourists"></param>
        public static void ReadTourists(string file, TouristLinkedList tourists)
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                string LastName = data[0];
                string FirstName = data[1];
                string Hotel = data[2];
                string RoomType = data[3];
                int Days = int.Parse(data[4]);

                Tourist tourist = new Tourist(LastName, FirstName, Hotel, RoomType, Days);
                tourists.AddToEnd(tourist);
            }
        }
        /// <summary>
        /// Reads hotels from the file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="hotels"></param>
        public static void ReadHotels(string file, HotelLinkedList hotels)
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                string Name = data[0];
                string RoomType = data[1];                
                int Price = int.Parse(data[2]);

                Hotel hotel = new Hotel(Name, RoomType, Price);
                hotels.AddToEnd(hotel);
            }
        }


        /// <summary>
        /// Prints tourists to the file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="tourists"></param>
        /// <param name="header"></param>
        /// <param name="answer"></param>
        public static void PrintTourists(string file, TouristLinkedList tourists, string header, bool answer)
        {
            using (StreamWriter writer = new StreamWriter(file,true))
            {                
                string line = new string('-', header.Length);
                if (answer)
                {
                    writer.WriteLine("Turistai, kurie praleido daugiausia nakčių:");
                }
                else
                {
                    writer.WriteLine("Pradiniai turistų duomenys:");
                }
                writer.WriteLine(line);
                writer.WriteLine(header);
                writer.WriteLine(line);
                if (tourists == null)
                {
                    writer.WriteLine("Turistu nėra");
                }
                else
                {
                    for (tourists.Start(); tourists.Exists(); tourists.Next()) 
                    {
                        Tourist tourist = tourists.Get();
                        writer.WriteLine(tourist.ToString());
                    }
                }
                writer.WriteLine(line);
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Prints hotels to the file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="hotels"></param>
        /// <param name="header"></param>
        public static void PrintHotels(string file, HotelLinkedList hotels, string header)
        {
            using (StreamWriter writer = new StreamWriter(file,true))
            {                
                string line = new string('-', header.Length);
                writer.WriteLine("Pradiniai viesbuciu duomenys:");
                writer.WriteLine(line);
                writer.WriteLine(header);
                writer.WriteLine(line);              
                for (hotels.Start(); hotels.Exists(); hotels.Next())
                {
                Hotel hotel = hotels.Get();
                writer.WriteLine(hotel.ToString());
                }
                writer.WriteLine(line);
                writer.WriteLine();
            }
        }
        public static void PrintHotelsAnswer(string file, HotelLinkedList hotels, string header, bool first)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                string line = new string('-', header.Length);
                if (first)
                {
                    writer.WriteLine("Pasirinkti viesbuciai:");
                }
                else
                {
                    writer.WriteLine("Nepasirinkti viesbuciai:");
                }

                if (hotels.Count == 0)
                {
                    if (first)
                    {
                        writer.WriteLine("Pasirinktu viesbuciu nera\n");
                    }
                    else
                    {
                        writer.WriteLine("Nepasirinkti viesbuciu nera\n");
                    }
                }
                else
                {
                    writer.WriteLine(line);
                    writer.WriteLine(header);
                    writer.WriteLine(line);
                    for (hotels.Start(); hotels.Exists(); hotels.Next())
                    {
                        Hotel hotel = hotels.Get();
                        writer.WriteLine(hotel.ToString());
                    }
                    writer.WriteLine(line);
                    writer.WriteLine();
                }
            }
        }
        /// <summary>
        /// Prints tourists who paid less than the limit
        /// </summary>
        /// <param name="file"></param>
        /// <param name="tourists"></param>
        /// <param name="header"></param>
        /// <param name="limit"></param>
        public static void PrintMinTurists(string file, TouristLinkedList tourists, string header, int limit)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                if (tourists.Count != 0)
                {
                    string line = new string('-', header.Length);
                    writer.WriteLine($"Turistai, kurie už kambarius sumokėjo mažiau negu {limit}:");
                    writer.WriteLine(line);
                    writer.WriteLine(header);
                    writer.WriteLine(line);
                    if (tourists == null)
                    {
                        writer.WriteLine("Turistu nėra");
                    }
                    else
                    {
                        for (tourists.Start(); tourists.Exists(); tourists.Next())
                        {
                            Tourist tourist = tourists.Get();
                            string format = $"{tourist.LastName,-15} | {tourist.FirstName,-15} | {tourist.Sum,10}|";
                            writer.WriteLine(format);
                        }
                    }
                    writer.WriteLine(line);
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteLine("Turistu, kurie už kambarius sumokėjo mažiau negu nurodyta, nėra");
                }
            }
        }
    }
}