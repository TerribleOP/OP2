using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;

namespace L1
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string FilePath = Server.MapPath(@"App_Data/Results.txt");
                File.Delete(FilePath);

                int N = InOutUtils.ReadBox(TextBox1); int M = InOutUtils.ReadBox(TextBox2);
                int sizeOne = 0; int sizeTwo = 0; int colourOne = -1; int colourTwo = -1;

                Square[,] filledMapOne = TaskUtils.GenerateMap(N, M); Thread.Sleep(250);
                Square[,] filledMapTwo = TaskUtils.GenerateMap(N, M);

                TaskUtils.FindLargestConnectedArea(filledMapOne, N, M, ref sizeOne, ref colourOne);
                TaskUtils.FindLargestConnectedArea(filledMapTwo, N, M, ref sizeTwo, ref colourTwo);
                if (sizeOne > sizeTwo)
                {
                    TaskUtils.RemoveAnswerTag(filledMapTwo, N, M); TaskUtils.FindLargestConnectedAreaColour(filledMapTwo, N, M, ref sizeTwo, ref colourOne);
                }
                else if (sizeTwo > sizeOne)
                {
                    TaskUtils.RemoveAnswerTag(filledMapOne, N, M); TaskUtils.FindLargestConnectedAreaColour(filledMapOne, N, M, ref sizeOne, ref colourTwo);
                }

                int sharedX = -1, sharedY = -1;
                TaskUtils.SharedPoint(filledMapOne, filledMapTwo, N, M, ref sharedX, ref sharedY);

                GenerateTable(filledMapOne, N, M, Table1); 
                GenerateTable(filledMapTwo, N, M, Table2);
                string resultText = $"Didžiausia plotą sudaro viršuje {sizeOne} ir apačioje {sizeTwo} langelių.Bendras langelis: {sharedX + 1} eilute, {sharedY + 1} stulpelis";
                Label3.Text = resultText;

                InOutUtils.PrintToTxt(filledMapOne, N, M, FilePath);
                InOutUtils.PrintToTxt(filledMapTwo, N, M, FilePath);
                InOutUtils.PrintHeaderToTxt(resultText, FilePath);
            }

        }
    }
}


