using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L5.App_Code
{
	public class Players
	{
        public string TeamName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerFirstName { get; set; }
        public string Position { get; set; }

        public Players(string teamName, string playerLastName, string playerFirstName, string position)
        {
            TeamName = teamName;
            PlayerLastName = playerLastName;
            PlayerFirstName = playerFirstName;
            Position = position;
        }

        public Players()
        {
        }
        /// <summary>
        /// Converts the player data to a string for display in a console or log.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{TeamName,-15} | {PlayerLastName,-15} | {PlayerFirstName,-15} | {Position,-20}|";
        }
        /// <summary>
        /// Converts the player data to a table row for display in a web form.
        /// </summary>
        /// <returns></returns>
        public TableRow ToTableRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = TeamName });
            row.Cells.Add(new TableCell() { Text = PlayerLastName });
            row.Cells.Add(new TableCell() { Text = PlayerFirstName });
            row.Cells.Add(new TableCell() { Text = Position });
            return row;
        }

    }
}