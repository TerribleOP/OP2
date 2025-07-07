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
        /// <summary>
        /// Validate the textbox to check if the user typed in numbers and if they fit the desired range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int N;
            args.IsValid = int.TryParse(TextBox1.Text, out N) && N >= 1 && N <= 20;
        }

        /// <summary>
        /// Validate the textbox to check if the user typed in numbers and if they fit the desired range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int M;
            args.IsValid = int.TryParse(TextBox2.Text, out M) && M >= 1 && M <= 30;
        }
        /// <summary> 
        /// Generates the graphical output in the website 
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        /// <param name="Table"></param> 
        public static void GenerateTable(Square[,] map, int N, int M, Table Table)
        {
            Table.Rows.Clear();

            for (int i = 0; i < N; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < M; j++)
                {
                    TableCell cell = new TableCell();
                    int colorCode = map[i, j].Colour;
                    switch (colorCode)
                    {
                        case 0:
                            cell.BackColor = System.Drawing.Color.Green;
                            break;
                        case 1:
                            cell.BackColor = System.Drawing.Color.Red;
                            break;
                        case 2:
                            cell.BackColor = System.Drawing.Color.Yellow;
                            break;
                    }
                    if (map[i, j].Answer)
                    {
                        cell.Text = "*";
                    }
                    else
                    {
                        cell.Text = " ";
                    }

                    cell.Style["width"] = "25px";
                    cell.Style["height"] = "25px";
                    row.Cells.Add(cell);

                }
                Table.Rows.Add(row);
            }
        }
    }
}