using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using L4.App_Code;


namespace L4
{
    public partial class Web : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string CIN = Server.MapPath(@"App_Data/Input");
            string COUT = Server.MapPath(@"App_Data");
            string log = Server.MapPath(@"App_Data");
            File.Delete(COUT + @"\Output.txt");
            File.Delete(COUT + @"\SudėtingiMuzikiniai.csv");
            File.Delete(COUT + @"\SudėtingiBendrai.csv");

            string errors = string.Empty;


            List<StudentAssociation> MainDataList = InOut.ReadData(CIN, ref errors);
            int levelOneHardness = 0;
            int levelTwoHardness = 0;
            int levelThreeHardness = 0;

            InOut.PrintDataInitial(COUT, "Pradiniai Duomenys:", MainDataList);

            TaskUtils.FindDifficultyCount(ref levelOneHardness, ref levelTwoHardness, ref levelThreeHardness, MainDataList, ref errors);

            AddToTables(MainDataList, ref TablesContainer1);

            int MaxDifficulty = 3;

            List<Dictionary<string, int>> MentionedAuthorCount = TaskUtils.FindMostMentionedAuthors(MainDataList, ref errors);
            List<Dictionary<string, int>> MostMentionedAuthors = TaskUtils.maxAuthor(MentionedAuthorCount, ref errors);

            List<StudentAssociation> MaxDifficultyList = TaskUtils.FindMaxDifficultyList(MainDataList, MaxDifficulty, ref errors);

            

            WriteDifficultiesIntoLabels(ref Label2, ref Label3, ref Label4, ref Label5, levelOneHardness, levelTwoHardness, levelThreeHardness);
            WriteAuthorsMaxCount(ref Label6, ref Label7, MostMentionedAuthors);

            List<StudentAssociation> MaxDifficultyListMusical = TaskUtils.FindMaxDifficultyMusical(MaxDifficultyList, ref errors);

            string SpecifiedTheme = "Music";
            File.Delete(COUT + $@"\{SpecifiedTheme}.csv");

            List<Question> ThemeList = TaskUtils.FindQuestionsByTheme(MainDataList, SpecifiedTheme, ref errors);

            ThemeList.BubbleSort();

            InOut.PrintQuestionsByDifficulty(COUT, levelOneHardness, levelTwoHardness, levelThreeHardness);

            InOut.PrintMaxAuthors(COUT, MaxDifficultyList, MaxDifficulty);

            InOut.PrintToCSV(COUT, MaxDifficultyListMusical, "SudėtingiMuzikiniai.csv", "Sudetingi muzikiniai");

            InOut.PrintToCSV(COUT, MaxDifficultyList, "SudėtingiBendrai.csv", "Sudetingi Bendrai");

            InOut.PrintToCSVSorted(COUT, ThemeList, $"{SpecifiedTheme}.csv", "Surikiuoti");

            ErrorLabel.Text = errors;

            Checking(ErrorLabel, Label1, Label2, Label3, Label4, Label5, Label6, Label7, TablesContainer1);
        


        }
    }
}
