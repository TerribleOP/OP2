using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L3
{
    public partial class WebForm : System.Web.UI.Page
    {
        /// <summary>
        /// validates the textbox input
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int N;
            args.IsValid = int.TryParse(TextBox1.Text, out N) && N > 0 && !String.IsNullOrEmpty(TextBox1.Text);

        }
        /// <summary>
        /// validates the file upload
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FileUpload1.HasFile && FileUpload1.FileName == "U17a.txt")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
        /// <summary>
        /// validates the file upload
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FileUpload2.HasFile && FileUpload2.FileName == "U17b.txt")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
        /// <summary>
        /// Method that updates the tables with the data from the linked list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="table"></param>
        /// <param name="IsHotel"></param>
        /// <param name="IsAnswer"></param>
        private void UpdateTables<T>(CustomLinkedList<T> list, Table table, bool IsHotel, bool IsAnswer) where T : IComparable<T>, IEquatable<T>
        {
            if (list.Count != 0)
            {
                table.Rows.Clear();
                TableHeaderRow headerRow = new TableHeaderRow();
                if (IsAnswer)
                {
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Pavarde" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Vardas" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Suma" });                    
                }
                else if (IsHotel)
                {
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Kaina" });
                }
                else
                {
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Pavarde" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Vardas" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
                    headerRow.Cells.Add(new TableHeaderCell { Text = "Nakvynių skaičius" });
                }  
                table.Rows.Add(headerRow);
                foreach (T item in list)
                {
                    TableRow row = new TableRow();
                    if (IsAnswer && item is Tourist tourist)
                    {
                        row = tourist.ToTableRow(true);
                    }
                    else if (item is Tourist tourist2)
                    {
                        row = tourist2.ToTableRow();
                    }
                    else if (item is Hotel hotel)
                    {
                        row = hotel.ToTableRow();
                    }
                    table.Rows.Add(row);
                }
            }
            else
            {
                table.Rows.Clear();
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Nera duomenu" });
                table.Rows.Add(headerRow);
            }
        }
    }
}