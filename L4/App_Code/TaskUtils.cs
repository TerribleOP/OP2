using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace L4.App_Code
{
    public static class TaskUtils
    {
        /// <summary>
        /// finds the difficulty count of the questions
        /// </summary>
        /// <param name="levelOneHardness"></param>
        /// <param name="levelTwoHardness"></param>
        /// <param name="levelThreeHardness"></param>
        /// <param name="Data"></param>
        /// <param name="errors"></param>
        public static void FindDifficultyCount(ref int levelOneHardness, ref int levelTwoHardness, ref int levelThreeHardness, List<StudentAssociation> Data, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            try
            {
                foreach (var SA in Data)
                {
                    foreach (Question question in SA)
                    {
                        try
                        {
                            if (question.Difficulty == 1)
                            {
                                levelOneHardness++;
                            }
                            else if (question.Difficulty == 2)
                            {
                                levelTwoHardness++;
                            }
                            else if (question.Difficulty == 3)
                            {
                                levelThreeHardness++;
                            }
                            else
                            {
                                throw new FormatException($"Invalid difficulty level: {question.Difficulty}");
                            }
                        }
                        catch (FormatException ex)
                        {
                            errorBuilder.AppendLine($"Error in StudentAssociation {SA.name} Question: {question.Text}; {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString();
        }
        /// <summary>
        /// finds the max difficulty of the questions
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static int FindMaxDifficulty(List<StudentAssociation> Data, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            int maxDifficulty = 0;
            try
            {
                foreach (var SA in Data)
                {
                    foreach (Question question in SA)
                    {
                        try
                        {
                            if (question.Difficulty > maxDifficulty)
                            {
                                maxDifficulty = question.Difficulty;
                            }
                        }
                        catch (Exception ex)
                        {
                            errorBuilder.AppendLine($"Error in StudentAssociation {SA.name}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString();
            return maxDifficulty;
        }
        /// <summary>
        /// finds the max difficulty questions
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="maxDifficulty"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<StudentAssociation> FindMaxDifficultyList(List<StudentAssociation> Data, int maxDifficulty, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            List<StudentAssociation> result = new List<StudentAssociation>();
            try
            {
                foreach (var SA in Data)
                {
                    StudentAssociation temp = new StudentAssociation(SA.name);
                    foreach (Question question in SA)
                    {
                        try
                        {
                            if (question.Difficulty == maxDifficulty)
                            {
                                temp.Add(question);
                            }
                        }
                        catch (Exception ex)
                        {
                            errorBuilder.AppendLine($"Error in StudentAssociation {SA.name}: {ex.Message}");
                        }
                    }
                    result.Add(temp);
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString(); // Update the ref parameter
            return result;
        }
        /// <summary>
        /// finds the max difficulty musical questions
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<StudentAssociation> FindMaxDifficultyMusical(List<StudentAssociation> Data, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            List<StudentAssociation> result = new List<StudentAssociation>();
            try
            {
                foreach (var SA in Data)
                {
                    StudentAssociation temp = new StudentAssociation(SA.name);
                    foreach (Question question in SA)
                    {
                        try
                        {
                            if (question is MusicQuestion)
                            {
                                temp.Add(question);
                            }
                        }
                        catch (Exception ex)
                        {
                            errorBuilder.AppendLine($"Error in StudentAssociation {SA.name}: {ex.Message}");
                        }
                    }
                    result.Add(temp);
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString(); // Update the ref parameter
            return result;
        }
        /// <summary>
        /// finds the questions by theme
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="theme"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<Question> FindQuestionsByTheme(List<StudentAssociation> Data, string theme, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            List<Question> result = new List<Question>();
            try
            {
                foreach (var SA in Data)
                {
                    foreach (Question question in SA)
                    {
                        try
                        {
                            if (question.Theme == theme)
                            {
                                result.Add(question);
                            }
                        }
                        catch (Exception ex)
                        {
                            errorBuilder.AppendLine($"Error in StudentAssociation {SA.name}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString();
            return result;
        }
        /// <summary>
        /// finds how many times an author is mentioned
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<Dictionary<string, int>> FindMostMentionedAuthors(List<StudentAssociation> Data, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            List<Dictionary<string, int>> authorCountList = new List<Dictionary<string, int>>();
            try
            {
                foreach (StudentAssociation SA in Data)
                {
                    if (SA == null) continue;
                    Dictionary<string, int> authorCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                    foreach (Question question in SA)
                    {
                        try
                        {
                            if (question?.Author == null) continue;

                            string author = question.Author.Trim();
                            if (!authorCount.ContainsKey(author))
                            {
                                authorCount.Add(author, 1);
                            }
                            else
                            {
                                authorCount[author] += 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            errorBuilder.AppendLine($"Error in StudentAssociation {SA.name}: {ex.Message}");
                        }
                    }
                    authorCountList.Add(authorCount);
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString();
            return authorCountList;
        }

        /// <summary>
        /// puts the max authors into a dictionary list
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<Dictionary<string, int>> maxAuthor(List<Dictionary<string, int>> data, ref string errors)
        {
            StringBuilder errorBuilder = new StringBuilder(errors);
            List<Dictionary<string, int>> answer = new List<Dictionary<string, int>>();
            try
            {
                foreach (var dictionary in data)
                {
                    int max = dictionary.Values.Max();
                    Dictionary<string, int> maxAuthors = new Dictionary<string, int>();
                    foreach (var SA in dictionary)
                    {
                        try
                        {
                            if (SA.Value == max)
                            {
                                maxAuthors.Add(SA.Key, SA.Value);
                            }
                        }
                        catch (Exception ex)
                        {
                            errorBuilder.AppendLine($"Error processing author {SA.Key}: {ex.Message}");
                        }
                    }
                    answer.Add(maxAuthors);
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine($"Unexpected error: {ex.Message}");
            }
            errors = errorBuilder.ToString();
            return answer;
        }



        /// <summary >
        /// Sort the list of questions by theme and difficulty using bubble sort
        /// </summary >
        /// <param name="list" > </param >
        public static void BubbleSort(this List<Question> list)
        {
            for (int i = 0; i < list.Count - 1; i++)

            {
                for (int j = 0; j < list.Count - 1 - i; j++)

                {
                    if (list[j].CompareTo(list[j + 1]) < 0)

                    {
                        Question temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }

                }
            }
        }
    }
}
