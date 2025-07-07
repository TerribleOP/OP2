using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5.App_Code
{
    public static class TaskUtils
    {
        /// <summary>
        /// Generates queried data by combining game registers and player data.
        /// </summary>
        /// <param name="gamesRegisters"></param>
        /// <param name="players"></param>
        /// <returns></returns>
        public static List<QueriedData> GetQueriedData(List<GamesRegister> gamesRegisters, List<Players> players)
        {
            List<QueriedData> result = new List<QueriedData>();

            try
            {
                IEnumerable<QueriedData> queriedData =
                    from gameRegister in gamesRegisters
                    from game in gameRegister
                    from player in players
                    where game.TeamName == player.TeamName
                    select new QueriedData(player.TeamName, player.PlayerFirstName, player.PlayerLastName, game.Points, game.PlayedMinutes, game.Fouls, player.Position);

                result = queriedData.ToList();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error in GetQueriedData: {ex.Message}');</script>");
            }

            return result;
        }
        /// <summary>
        /// Refines the queried data by selecting the top players based on points and played minutes.
        /// </summary>
        /// <param name="queriedData"></param>
        /// <param name="selectCount"></param>
        /// <returns></returns>
        public static List<QueriedData> RefineQueriedData(List<QueriedData> queriedData, int selectCount)
        {
            List<QueriedData> result = new List<QueriedData>();

            try
            {
                IEnumerable<QueriedData> refinedData = queriedData
                    .OrderByDescending(p => (double)p.Points / (p.PlayedMinutes + 1) - p.Fouls)
                    .Take(selectCount);

                result = refinedData.ToList();
            }
            catch (DivideByZeroException ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error in RefineQueriedData: {ex.Message}');</script>");
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error in RefineQueriedData: {ex.Message}');</script>");
            }

            return result;
        }
        /// <summary>
        /// Sorts the queried data by team name and last name.
        /// </summary>
        /// <param name="queriedData"></param>
        /// <returns></returns>
        public static List<QueriedData> Sort(List<QueriedData> queriedData)
        {
            List<QueriedData> result = new List<QueriedData>();

            try
            {
                IEnumerable<QueriedData> sortedData = queriedData
                    .OrderBy(p => p.TeamName)
                    .ThenBy(p => p.LastName);

                result = sortedData.ToList();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error in Sort: {ex.Message}');</script>");
            }

            return result;
        }
        /// <summary>
        /// Selects the positiob with the least number of players.
        /// </summary>
        /// <param name="queriedData"></param>
        /// <returns></returns>
        public static string LeastOfPosition(List<QueriedData> queriedData)
        {
            string leastPlayerPosition = null;

            try
            {
                leastPlayerPosition = queriedData
                    .GroupBy(q => q.Position)
                    .OrderBy(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error in LeastOfPosition: {ex.Message}');</script>");
            }

            return leastPlayerPosition;
        }
        /// <summary>
        /// Selects players with the lowest points in a specific position.
        /// </summary>
        /// <param name="queriedData"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static List<QueriedData> SelectLowestPosition(List<QueriedData> queriedData, string position)
        {
            List<QueriedData> result = new List<QueriedData>();

            try
            {
                IEnumerable<QueriedData> lowestPositionPlayers = queriedData
                    .Where(q => q.Position == position)
                    .OrderBy(q => q.Points);

                result = lowestPositionPlayers.ToList();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error in SelectLowestPosition: {ex.Message}');</script>");
            }

            return result;
        }
    }
}
