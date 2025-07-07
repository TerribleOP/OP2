using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L5.App_Code
{
	public class QueriedData
	{
        public string TeamName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Points { get; set; }
		public int PlayedMinutes { get; set; }
        public int Fouls { get; set; }

        public string Position { get; set; }

        public QueriedData() { }

        public QueriedData(string teamName, string firstName, string lastName, int points, int PlayedMinutes, int fouls, string position)
        {
            this.TeamName = teamName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Points = points;
            this.PlayedMinutes = PlayedMinutes;
            this.Fouls = fouls;
            this.Position = position;
        }
        /// <summary>
        /// Converts the queried data to a string for display in a console or log.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{TeamName,-15} | {LastName,-15} | {FirstName,-15} | {PlayedMinutes,14} | {Points,13} | {Fouls,12} | {Position,-20}|";
        }
        /// <summary>
        /// Converts the queried data to a string for display in a console or log.
        /// </summary>
        /// <returns></returns>
        public TableRow ToTableRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = this.TeamName });
            row.Cells.Add(new TableCell() { Text = this.LastName });
            row.Cells.Add(new TableCell() { Text = this.FirstName });
            row.Cells.Add(new TableCell() { Text = this.PlayedMinutes.ToString() });
            row.Cells.Add(new TableCell() { Text = this.Points.ToString() });
            row.Cells.Add(new TableCell() { Text = this.Fouls.ToString() });
            row.Cells.Add(new TableCell() { Text = this.Position.ToString() });
            return row;
        }

    }
}