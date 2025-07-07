using L5.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L5
{
    public partial class WebForm : System.Web.UI.Page
    {
        /// <summary>
        /// Dinamic table creation for game data.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="TablesContainer"></param>
        protected void AddToTablesGames(List<GamesRegister> Data, Panel TablesContainer)
        {
            int number = 1;
            foreach (var GameRegister in Data)
            {
                
                Table table = new Table
                {
                    CssClass = "table"
                };

                Label label = new Label
                {
                    Text = $"Lentele nr.{number} " + GameRegister.date.ToString("yyyy-MM-dd"),
                    CssClass = "table-header"

                };
                
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Team Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Last Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "First Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Played Minutes" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Points Earned" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Fouls Earned" });
                
                table.Rows.Add(headerRow);

                foreach (var game in GameRegister)
                {
                    TableRow row = game.ToTableRow();
                    table.Rows.Add(row);
                }
                TablesContainer.Controls.Add(label);
                TablesContainer.Controls.Add(table);
                number++;
            }
        }
        /// <summary>
        /// Adds queried data to the specified table for players.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="TablesContainer"></param>
        protected void AddToTablesPlayers(List<Players> Data, Panel TablesContainer)
        {
            Table table = new Table
            {
                CssClass = "table"
            };
            Label label = new Label
            {
                Text = "Player Data",
                CssClass = "table-header"
            };
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableHeaderCell { Text = "Team Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Last Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "First Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Position" });
            table.Rows.Add(headerRow);
            foreach (var player in Data)
            {
                TableRow row = player.ToTableRow();
                table.Rows.Add(row);
            }
            TablesContainer.Controls.Add(label);
            TablesContainer.Controls.Add(table);
        }
        /// <summary>
        /// Adds queried data to the specified table.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Table"></param>
        /// <param name="Header"></param>
        protected void AddQueriedDataToTable(List<QueriedData> Data, Table Table, string Header)
        {
            
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableHeaderCell { Text = "Team Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Last Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "First Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Played Minutes" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Points Earned" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Fouls Earned" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Position" });
            Table.Rows.Add(headerRow);
            foreach (var player in Data)
            {
                TableRow row = player.ToTableRow();
                Table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Custom validator for the TextBox1 control.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int N;
            args.IsValid = int.TryParse(TextBox1.Text, out N) && N >= 1;
        }       

    }
}