using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace L4.App_Code
{
    public class TestQuestion : Question, IComparable<Question>, IEquatable<Question>
    {

        public string[] AnswerVariants = new string[4];

        public TestQuestion(string line)
        {
            SetData(line);
        }

        public TestQuestion(string theme, int difficulty, string author, string text, string answer, int points, string[] AnswerVariants) : base(theme, difficulty, author, text, answer, points)
        {
            this.AnswerVariants = AnswerVariants;
        }
        /// <summary>
        /// compare two TestQuestion objects by Theme and Difficulty
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Question other)
        {
            if (other is TestQuestion testQuestion)
            {
                if (this.Theme.CompareTo(other.Theme) == 0)
                {
                    return this.Difficulty.CompareTo(other.Difficulty);
                }
                return this.Theme.CompareTo(other.Theme);
            }
            return base.CompareTo(other);
        }
        /// <summary>
        /// compare two TestQuestion objects by Author
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Question other)
        {
            return base.Equals(other);
        }
        /// <summary>
        /// Set data for TestQuestion object
        /// </summary>
        /// <param name="line"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] data = Regex.Split(line, "; ");

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    AnswerVariants[i] = data[i + 6];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("Not enough answer variants provided");
                }
            }
        }


        /// <summary>
        /// returns a string representation of the TestQuestion object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"{AnswerVariants[0],-40} | {AnswerVariants[1],-40} | {AnswerVariants[2],-40} | {AnswerVariants[3],-40} |";
        }
        /// <summary>
        /// returns a TableRow representation of the TestQuestion object
        /// </summary>
        /// <returns></returns>
        public override TableRow ToTableRow()
        {
            TableRow row = base.ToTableRow();

            row.Cells.Add(new TableCell { Text = AnswerVariants[0] });
            row.Cells.Add(new TableCell { Text = AnswerVariants[1] });
            row.Cells.Add(new TableCell { Text = AnswerVariants[2] });
            row.Cells.Add(new TableCell { Text = AnswerVariants[3] });

            return row;
        }

        /// <summary>
        /// returns a CSV representation of the TestQuestion object
        /// </summary>
        /// <returns></returns>
        public override string ToCSV()
        {
            return $"{Theme}; {Difficulty}; {Author}; {Text}; {Answer}; {Points}; {AnswerVariants[0]}; {AnswerVariants[1]}; {AnswerVariants[2]}; {AnswerVariants[3]}";
        }
    }
}