using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace L4.App_Code
{
	public abstract class Question : IComparable<Question>, IEquatable<Question>
	{
		public string Theme { get; set; }
		public int Difficulty { get; set; }
		public string Author { get; set; }
		public string Text { get; set; }

		public string Answer { get; set; }
		public int Points { get; set; }

        public Question() { }

        public Question(string theme, int difficulty, string author, string text, string answer, int points)
        {
            Theme = theme;
            Difficulty = difficulty;
            Author = author;
            Text = text;
            Answer = answer;
            Points = points;
        }

        /// <summary>
        /// compare two Question objects by Theme and Difficulty
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual int CompareTo(Question other)
        {
            if (this.Theme.CompareTo(other.Theme) == 0)
            {
                return this.Difficulty.CompareTo(other.Difficulty);
            }
            return this.Theme.CompareTo(other.Theme);
        }
        /// <summary>
        /// compare two Question objects by Author
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(Question other)
        {
            return this.Author == other.Author;
        }

        /// <summary>
        /// Set data for Question object
        /// </summary>
        /// <param name="line"></param>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public virtual void SetData(string line)
        {
            string[] data = Regex.Split(line, "; ");

            try
            {
                Theme = data[0];
                Difficulty = int.Parse(data[1]);
                Author = data[2];
                Text = data[3];
                Answer = data[4];                
                Points = int.Parse(data[5]);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid data format");
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Data is missing");
            }
        }
        /// <summary>
        /// Convert Question object to CSV format
        /// </summary>
        /// <returns></returns>
        public abstract string ToCSV();

        /// <summary>
        /// Convert Question object to string format
        /// </summary>
        /// <returns></returns>
        public virtual string ToString()
        {
            return $"{Theme, -10} | {Difficulty, 10} | {Author, -30} | {Text, -75} | {Answer, -30} | {Points, 6}|";
        }

        /// <summary>
        /// Convert Question object to TableRow format
        /// </summary>
        /// <returns></returns>
        public virtual TableRow ToTableRow()
        {
            TableRow row = new TableRow();

            row.Cells.Add(new TableCell { Text = Theme });
            row.Cells.Add(new TableCell { Text = Difficulty.ToString()});
            row.Cells.Add(new TableCell { Text = Author });
            row.Cells.Add(new TableCell { Text = Text });
            row.Cells.Add(new TableCell { Text = Answer });
            row.Cells.Add(new TableCell { Text = Points.ToString() });

            return row;
        }       
    }
}