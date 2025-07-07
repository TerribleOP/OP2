using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace L4.App_Code
{
	public class MusicQuestion : Question , IComparable<Question>, IEquatable<Question>
    {     

        public string MusicFile { get; set; }

        public MusicQuestion(string line)
        {
            SetData(line);
        }

        public MusicQuestion(string theme, int difficulty, string author, string text, string answer, int points, string MusicFile) : base(theme, difficulty, author, text, answer, points)
        {
            this.MusicFile = MusicFile;
        }
        /// <summary>
        /// compare two MusicQuestion objects by MusicFile
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Question other)
        {
            if (other is MusicQuestion otherMusicQuestion)
            {
                return this.MusicFile.CompareTo(otherMusicQuestion.MusicFile);
            }
            return base.CompareTo(other);
        }
        /// <summary>
        /// compare two MusicQuestion objects by Author
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Question other)
        {
            return base.Equals(other);
        }

        /// <summary>
        /// Set data for MusicQuestion object
        /// </summary>
        /// <param name="line"></param>
        /// <exception cref="FormatException"></exception>
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] data = Regex.Split(line, "; ");
            try
            {                
                MusicFile = data[6];
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid data format");
            }
        }
        /// <summary>
        /// returns a string representation of the MusicQuestion object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"{MusicFile, -40} | {"-", -40} | {"-",-40} | {"-",-40} |";
        }

        /// <summary>
        /// returns a TableRow object for the MusicQuestion object
        /// </summary>
        /// <returns></returns>
        public override TableRow ToTableRow()
        {
            TableRow row = base.ToTableRow();

            row.Cells.Add(new TableCell { Text = MusicFile });
            row.Cells.Add(new TableCell { Text = "-" });
            row.Cells.Add(new TableCell { Text = "-" });
            row.Cells.Add(new TableCell { Text = "-" });


            return row;
        }
        /// <summary>
        /// returns a CSV representation of the MusicQuestion object
        /// </summary>
        /// <returns></returns>
        public override string ToCSV()
        {
            return $"{Theme}; {Difficulty}; {Author}; {Text}; {Answer}; {Points};{MusicFile}";
        }
    }
}