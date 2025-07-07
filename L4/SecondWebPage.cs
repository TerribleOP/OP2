using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using L4.App_Code;

namespace L4
{
    public partial class Web : System.Web.UI.Page
    {
        /// <summary>
        /// generic add to tables method
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="TablesContainer"></param>
        protected void AddToTables(List<StudentAssociation> Data, ref Panel TablesContainer)
        {
            foreach (var studentAssociation in Data)
            {
                Table table = new Table
                {
                    CssClass = "table"
                };

                Label label = new Label
                {
                    Text = studentAssociation.name,
                    CssClass = "table-header"
                };

                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Theme" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Difficulty" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Author" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Text" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Answer" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Points" });
                TableHeaderCell mergedHeaderCell = new TableHeaderCell
                {
                    Text = "Music Filename OR 4 different answer possibilities",
                    ColumnSpan = 4, 
                    HorizontalAlign = HorizontalAlign.Center 
                };
                headerRow.Cells.Add(mergedHeaderCell);
                table.Rows.Add(headerRow);

                foreach (var question in studentAssociation)
                {        
                                        
                    TableRow row = question.ToTableRow();                    

                    table.Rows.Add(row);
                }

                TablesContainer.Controls.Add(label);
                TablesContainer.Controls.Add(table);
            }
        }

        /// <summary>
        /// Writes the number of questions by difficulty into the labels
        /// </summary>
        /// <param name="label2"></param>
        /// <param name="label3"></param>
        /// <param name="label4"></param>
        /// <param name="label5"></param>
        /// <param name="levelOneHardness"></param>
        /// <param name="levelTwoHardness"></param>
        /// <param name="levelThreeHardness"></param>
        public static void WriteDifficultiesIntoLabels(ref Label label2, ref Label label3, ref Label label4, ref Label label5, int levelOneHardness, int levelTwoHardness, int levelThreeHardness)
        {
            label2.Text = "Questions by difficulty";
            if (levelOneHardness > 0)
            {
                label3.Text = "Difficulty 1: " + levelOneHardness.ToString();
            }
            else
            {
                label3.Text = "Difficulty 1: No questions";
            }

            if (levelTwoHardness > 0)
            {
                label4.Text = "Difficulty 2: " + levelTwoHardness.ToString();
            }
            else
            {
                label4.Text = "Difficulty 2: No questions";
            }

            if (levelThreeHardness > 0)
            {
                label5.Text = "Difficulty 3: " + levelThreeHardness.ToString();
            }
            else
            {
                label5.Text = "Difficulty 3: No questions";
            }            
            
        }

        /// <summary>
        /// Writes the authors and the number of difficult questions they wrote into the labels
        /// </summary>
        /// <param name="label6"></param>
        /// <param name="label7"></param>
        /// <param name="data"></param>
        public static void WriteAuthorsMaxCount(ref Label label6, ref Label label7, List<Dictionary<string, int>> data)
        {
            label6.Text = "Authors name and the number of difficult questions they wrote";
            string answer = "";
            foreach (var dictionary in data)
            {
                foreach (var item in dictionary)
                {
                    answer += $"{item.Key} {item.Value} <br />";
                }
            }
            label7.Text = answer;
        }


        /// <summary>
        /// checks if any error is triggered and then clears the labels and the table
        /// </summary>
        /// <param name="ErrorLabel"></param>
        /// <param name="Label1"></param>
        /// <param name="Label2"></param>
        /// <param name="Label3"></param>
        /// <param name="Label4"></param>
        /// <param name="Label5"></param>
        /// <param name="Label6"></param>
        /// <param name="Label7"></param>
        /// <param name="TablesContainer1"></param>
        private static void Checking(Label ErrorLabel, Label Label1, Label Label2, Label Label3, Label Label4, Label Label5, Label Label6, Label Label7, Panel TablesContainer1)
        {
            if (ErrorLabel.Text != string.Empty)
            {
                // Clear all labels
                Label1.Text = string.Empty;
                Label2.Text = string.Empty;
                Label3.Text = string.Empty;
                Label4.Text = string.Empty;
                Label5.Text = string.Empty;
                Label6.Text = string.Empty;
                Label7.Text = string.Empty;

                // Clear and hide the table panel
                TablesContainer1.Controls.Clear();
                TablesContainer1.Visible = false;
            }
        }
    }
}