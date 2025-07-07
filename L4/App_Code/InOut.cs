using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace L4.App_Code
{
    public static class InOut
    {

        /// <summary>
        /// read data from file
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <returns></returns>
        public static List<StudentAssociation> ReadData(string FileFolder, ref string errors)
        {
            List<StudentAssociation> result = new List<StudentAssociation>();
            StringBuilder errorBuilder = new StringBuilder(errors);

            foreach (string filePath in Directory.GetFiles(FileFolder, "*.txt"))
            {
                string[] lines = File.ReadAllLines(filePath);
                StudentAssociation SA = new StudentAssociation(lines[0]);

                foreach (string line in lines.Skip(1))
                {
                    try
                    {
                        int count = Regex.Split(line, "; ").Length;

                        switch (count)
                        {
                            case 7:
                                SA.Add(new MusicQuestion(line));
                                break;
                            case 10:
                                SA.Add(new TestQuestion(line));
                                break;
                            default:
                                throw new FormatException("Incorrect initial data format");
                        }
                    }
                    catch (FormatException ex)
                    {
                        errorBuilder.AppendLine($"Error in file {Path.GetFileName(filePath)}: {ex.Message} - Line: {line}<br/>");
                    }
                }
                result.Add(SA);
            }
            errors = errorBuilder.ToString();
            return result;
        }




        /// <summary>
        /// print initial data to file
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="header"></param>
        /// <param name="List"></param>
        public static void PrintDataInitial(string FileFolder, string header, List<StudentAssociation> List)
        {
            using (StreamWriter writer = new StreamWriter(FileFolder + @"\Output.txt", true))
            {
                writer.WriteLine(header);

                foreach (StudentAssociation data in List)
                {
                    writer.WriteLine(data.name);
                    writer.WriteLine(new string('-', 348));
                    writer.WriteLine($"{"Theme",-10} | {"Difficulty",10} | {"Author",-30} | {"Text",-75} | {"Answer",-30} | {"Points",6}| {"Music Filename OR 4 different answer possibilities",-168} |");
                    writer.WriteLine(new string('-', 348));
                    foreach (Question question in data)
                    {
                        writer.WriteLine(question.ToString());
                        writer.WriteLine(new string('-', 348));
                    }
                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// prints questions by difficulty
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="One"></param>
        /// <param name="Two"></param>
        /// <param name="Three"></param>

        public static void PrintQuestionsByDifficulty(string FileFolder, int One, int Two, int Three)
        {
            using (StreamWriter writer = new StreamWriter(FileFolder + @"\Output.txt", true))
            {
                writer.WriteLine("Questions by difficulty");                
                if (One > 0)
                {
                    writer.WriteLine("Difficulty 1: " + One.ToString());
                }
                else
                {
                    writer.WriteLine("Difficulty 1: No questions");
                }

                if (Two > 0)
                {
                    writer.WriteLine("Difficulty 2: " + One.ToString());
                }
                else
                {
                    writer.WriteLine("Difficulty 2: No questions");
                }

                if (Three > 0)
                {
                    writer.WriteLine("Difficulty 3: " + One.ToString());
                }
                else
                {
                    writer.WriteLine("Difficulty 3: No questions");
                }
                writer.WriteLine();
            }


        }

        /// <summary>
        /// prints the number of difficult questions written by each author
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="List"></param>
        /// <param name="number"></param>

        public static void PrintMaxAuthors(string FileFolder, List<StudentAssociation> List, int number)
        {
            using (StreamWriter writer = new StreamWriter(FileFolder + @"\Output.txt", true))
            {
                writer.WriteLine("Authors name and the number of difficult questions they wrote");

                foreach (StudentAssociation SA in List)
                {
                    string authorNames = string.Empty;
                    foreach (Question question in SA)
                    {                       
                        authorNames += question.Author + ", ";                       
                        
                    }
                    if (authorNames != string.Empty)
                    {
                        writer.WriteLine(SA.name + ": " + authorNames.TrimEnd(',') + number.ToString());
                    }
                    else
                    {
                        writer.WriteLine(SA.name + ": No questions");
                    }
                }
                writer.WriteLine();
            }
        }
        /// <summary>
        /// prints to CSV file
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="List"></param>
        /// <param name="FileName"></param>
        public static void PrintToCSV(string FileFolder, List<StudentAssociation> List, string FileName, string header)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(FileFolder, FileName), true))
            {
                writer.WriteLine(header);
                
                if (List == null || !List.Any() || List.All(data => data == null || !data.Any()))
                {
                    writer.WriteLine("No Questions fitting the criteria");
                    return;
                }
                else
                {
                    writer.WriteLine($"Theme; Difficulty; Author; Text; Answer; Points; Music Filename OR 4 different answer possibilities");
                } 

                foreach (StudentAssociation data in List)
                {
                    if (data != null && data.Any())
                    {
                        foreach (Question question in data)
                        {
                            writer.WriteLine(question.ToCSV());
                        }
                    }
                }
            }
        }


        /// <summary>
        /// prints to CSV file sorted by theme and difficulty
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <param name="List"></param>
        /// <param name="FileName"></param>
        public static void PrintToCSVSorted(string FileFolder, List<Question> List, string FileName, string header)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(FileFolder, FileName), true))
            {
                writer.WriteLine(header);
                if (List == null || !List.Any())
                {
                    writer.WriteLine("No Questions fitting the criteria");
                    return;
                }
                else
                {
                    writer.WriteLine($"Theme; Difficulty; Author; Text; Answer; Points; Music Filename OR 4 different answer possibilities");
                }
                foreach (Question question in List)
                {
                    if (question != null)
                    {
                        writer.WriteLine(question.ToCSV());
                    }
                }
            }
        }
    }
}
    