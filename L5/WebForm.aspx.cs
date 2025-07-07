using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using L5.App_Code;

namespace L5
{
	public partial class WebForm : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["Games"] != null && Session["Players"] != null)
            {
                string errors = string.Empty;
                var games = (List<GamesRegister>)Session["Games"];
                var players = (List<Players>)Session["Players"];
                AddToTablesGames(games, TablesContainer1);
                AddToTablesPlayers(players, TablesContainer2);

                var queriedData = TaskUtils.GetQueriedData(games, players);
                //AddQueriedDataToTable(queriedData, Table2, "Initial Queried Data");

                Button2.Visible = true;
                TextBox1.Visible = true;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string CIN = Server.MapPath(@"App_Data/Var1");
            string CIN2 = Server.MapPath(@"App_Data/Zaidejai.txt");
            string COUT = Server.MapPath(@"App_Data");

            File.Delete(COUT + @"\Output.txt");
            
            string errors = string.Empty;   

            List<GamesRegister> Games = InOut.ReadGameData(CIN);
            List<Players> Players = InOut.ReadPlayersData(CIN2);

            Session["Games"] = Games;
            Session["Players"] = Players;

            AddToTablesGames(Games, TablesContainer1);
            AddToTablesPlayers(Players, TablesContainer2);

            InOut.PrintGameInitialData(COUT, "Games", Games);
            InOut.PrintPlayerInitialData(COUT, "Players", Players);

            List<QueriedData> queriedData = TaskUtils.GetQueriedData(Games, Players);
            //InOut.PrintQueriedData(COUT, "Initial Queried Data", queriedData);
            Button2.Visible = true;
            TextBox1.Visible = true;

            
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string CIN = Server.MapPath(@"App_Data/Var1");
                string CIN2 = Server.MapPath(@"App_Data/Zaidejai.txt");
                string COUT = Server.MapPath(@"App_Data");

                string errors = string.Empty;

                List<GamesRegister> Games = InOut.ReadGameData(CIN);
                List<Players> Players = InOut.ReadPlayersData(CIN2);

                List<QueriedData> queriedData = TaskUtils.GetQueriedData(Games, Players);
                int HowManyToTake = int.Parse(TextBox1.Text);
                List<QueriedData> refinedData = TaskUtils.RefineQueriedData(queriedData, HowManyToTake);
                List<QueriedData> sortedData = TaskUtils.Sort(refinedData); 
                string leastPlayerPosition = TaskUtils.LeastOfPosition(refinedData);
                List<QueriedData> lowestPositionPlayers = TaskUtils.SelectLowestPosition(refinedData, leastPlayerPosition);

                AddQueriedDataToTable(refinedData, Table2, "Refined Data");
                InOut.PrintQueriedData(COUT, "Refined Data", refinedData);

                AddQueriedDataToTable(sortedData, Table3, "Sorted Data");
                InOut.PrintQueriedData(COUT, "Sorted Data", sortedData);

                AddQueriedDataToTable(lowestPositionPlayers, Table4, "Lowest Position Players");
                InOut.PrintQueriedData(COUT, "Lowest Position Players", lowestPositionPlayers);

                
            }
        }

        
    }
}