using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L5.App_Code
{
	public class Games
	{
		public string TeamName { get; set; }
		public string PlayerLastName { get; set; }
		public string PlayerFirstName { get; set; }
		public int PlayedMinutes { get; set; }
		public int Points { get; set; }
		public int Fouls { get; set; }

        public Games(string teamName, string playerLastName, string playerFirstName, int playedMinutes, int points, int fouls)
        {
            TeamName = teamName;
            PlayerLastName = playerLastName;
            PlayerFirstName = playerFirstName;
            PlayedMinutes = playedMinutes;
            Points = points;
            Fouls = fouls;
        }
        public Games()
        {
        }
        /// <summary>
        /// Converts the game data to a string for display in a console or log.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{TeamName,-15} | {PlayerLastName,-15} | {PlayerFirstName,-15} | {PlayedMinutes,14} | {Points,13} | {Fouls,12}|";
        }
        /// <summary>
        /// Converts the game data to a table row for display in a web form.
        /// </summary>
        /// <returns></returns>
        public TableRow ToTableRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = this.TeamName });
            row.Cells.Add(new TableCell() { Text = this.PlayerLastName });
            row.Cells.Add(new TableCell() { Text = this.PlayerFirstName });
            row.Cells.Add(new TableCell() { Text = this.PlayedMinutes.ToString() });
            row.Cells.Add(new TableCell() { Text = this.Points.ToString() });
            row.Cells.Add(new TableCell() { Text = this.Fouls.ToString() });
            return row;
        }

    }
}