using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace L3
{
	public static class InOutUtils
    {
        public static WebForm WebForm
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

        public static Hotel Hotel
        {
            get => default;
            set
            {
            }
        }
        /// <summary>
        /// Reads tourist data from the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Tourists"></param>
        public static void ReadTourists(string fileName, CustomLinkedList<Tourist> Tourists)
		{
			string[] lines = File.ReadAllLines(fileName);

			foreach (string line in lines)
			{
				string[] data = line.Split(';');

				Tourists.AddToEnd(new Tourist(data[0], data[1], data[2], data[3], int.Parse(data[4])));
			}
		}
        /// <summary>
        /// Reads hotel data from the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Hotels"></param>
        public static void ReadHotel(string fileName, CustomLinkedList<Hotel> Hotels)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');

                Hotels.AddToEnd(new Hotel(data[0], data[1], int.Parse(data[2])));
            }
        }


        /// <summary>
        /// Method that prints everything to the file as needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="header"></param>
        /// <param name="values"></param>
        /// <param name="answer"></param>
        /// <param name="data"></param>
        public static void Print<T>(string file, string header, string values, bool answer, CustomLinkedList<T> data) where T : IComparable<T>, IEquatable<T>
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                if (data.Count != 0)
                {
                    writer.WriteLine(values);
                    string line = new string('-', header.Length);
                    writer.WriteLine(header);
                    writer.WriteLine(line);
                    foreach (T item in data)
                    {
                        if (answer && item is Tourist tourist)
                        {
                            string format = $"{tourist.LastName,-15} | {tourist.FirstName,-15} | {tourist.Sum,10}|";
                            writer.WriteLine(format);
                        }
                        else
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    writer.WriteLine(line);
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteLine(values);
                    writer.WriteLine("Tokio tipo duomenų nėra");
                }
            }
        }
    }
}