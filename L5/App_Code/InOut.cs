using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace L5.App_Code
{
    public static class InOut
    {
        /// <summary>
        /// Reads game data from a specified folder.
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <returns></returns>
        public static List<GamesRegister> ReadGameData(string FileFolder)
        {
            List<GamesRegister> result = new List<GamesRegister>();

            foreach (string filePath in Directory.GetFiles(FileFolder, "*.txt"))
            {
                string[] lines = File.ReadAllLines(filePath);
                GamesRegister gamesRegister = new GamesRegister(DateTime.Parse(lines[0]));
                foreach (string line in lines.Skip(1))
                {
                    try
                    {
                        string[] parts = Regex.Split(line, "; ");
                        gamesRegister.AddGame(new Games(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    }
                    catch (Exception ex)
                    {
                        HttpContext.Current.Response.Write($"<script>alert('Error in file {Path.GetFileName(filePath)}: {ex.Message} - Line: {line}<br/>');</script>");
                    }
                }
                result.Add(gamesRegister);
            }
            return result;
        }

        /// <summary>
        /// Reads player data from a file.
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static List<Players> ReadPlayersData(string FilePath)
        {
            List<Players> result = new List<Players>();

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                try
                {
                    string[] parts = Regex.Split(line, "; ");
                    Players player = new Players(parts[0], parts[1], parts[2], parts[3]);
                    result.Add(player);
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write($"<script>alert('Error in file {Path.GetFileName(FilePath)}: {ex.Message} - Line: {line}<br/>');</script>");
                }
            }
            return result;
        }

        /// <summary>
        /// Writes game data to a file.
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="header"></param>
        /// <param name="List"></param>
        public static void PrintGameInitialData(string FileFolder, string header, List<GamesRegister> List)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileFolder + @"\Output.txt", true))
                {
                    writer.WriteLine(header);

                    int number = 1;
                    foreach (GamesRegister data in List)
                    {
                        writer.WriteLine($"Lentelė Nr.{number}");
                        writer.WriteLine(data.date.ToString("yyyy-MM-dd"));
                        writer.WriteLine(new string('-', 100));
                        writer.WriteLine($"{"Team Name",-15} | {"Last Name",-15} | {"First Name",-15} | {"Played Minutes",-14} | {"Points Earned",-13} | {"Fouls Earned",-12}|");
                        writer.WriteLine(new string('-', 100));
                        foreach (Games question in data)
                        {
                            writer.WriteLine(question.ToString());
                            writer.WriteLine(new string('-', 100));
                        }
                        writer.WriteLine();
                        number++;
                    }
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error while writing game data: {ex.Message}<br/>');</script>");
            }
        }

        /// <summary>
        /// Writes player data to a file.
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="header"></param>
        /// <param name="List"></param>
        public static void PrintPlayerInitialData(string FileFolder, string header, List<Players> List)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileFolder + @"\Output.txt", true))
                {
                    writer.WriteLine(header);
                    writer.WriteLine(new string('-', 75));
                    writer.WriteLine($"{"Team Name",-15} | {"Last Name",-15} | {"First Name",-15} | {"Position",-20}|");
                    writer.WriteLine(new string('-', 75));
                    foreach (Players question in List)
                    {
                        writer.WriteLine(question.ToString());
                        writer.WriteLine(new string('-', 75));
                    }
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error while writing player data: {ex.Message}<br/>');</script>");
            }
        }

        /// <summary>
        /// Writes queried data to a file.
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="header"></param>
        /// <param name="List"></param>
        public static void PrintQueriedData(string FileFolder, string header, List<QueriedData> List)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileFolder + @"\Output.txt", true))
                {
                    writer.WriteLine(header);
                    writer.WriteLine(new string('-', 121));
                    writer.WriteLine($"{"Team Name",-15} | {"Last Name",-15} | {"First Name",-15} | {"Played Minutes",-14} | {"Points Earned",-13} | {"Fouls Earned",-12} | {"Position",-20}|");
                    writer.WriteLine(new string('-', 121));
                    foreach (QueriedData question in List)
                    {
                        writer.WriteLine(question.ToString());
                        writer.WriteLine(new string('-', 121));
                    }
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error while writing queried data: {ex.Message}<br/>');</script>");
            }
        }
    }
}
