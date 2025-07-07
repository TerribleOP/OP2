using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace L2
{
    public partial class WebForm : System.Web.UI.Page
    {
        /// <summary>
        /// Method to validate text box input for a positive integer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {            
            int N;
            args.IsValid = int.TryParse(TextBox1.Text, out N) && N > 0 && !String.IsNullOrEmpty(TextBox1.Text);
            
        }
        /// <summary>
        /// updates the table with the tourist data
        /// </summary>
        /// <param name="tourists"></param>
        private void UpdateTable(TouristLinkedList tourists)
        {
            
            Table1.Rows.Clear();


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableHeaderCell { Text = "Pavarde" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Vardas" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Nakvynių skaičius" });
            Table1.Rows.Add(headerRow);

            
            for (tourists.Start(); tourists.Exists(); tourists.Next())
            {
                Tourist tourist = tourists.Get();
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = tourist.LastName });
                row.Cells.Add(new TableCell { Text = tourist.FirstName });
                row.Cells.Add(new TableCell { Text = tourist.HotelName });
                row.Cells.Add(new TableCell { Text = tourist.RoomType });
                row.Cells.Add(new TableCell { Text = tourist.BookedNights.ToString() });
                Table1.Rows.Add(row);
            }
        }
        /// <summary>
        /// Method to update the result table with the tourist data
        /// </summary>
        /// <param name="tourists"></param>
        private void UpdateResultTable(TouristLinkedList tourists)
        {
            
            Table3.Rows.Clear();

            
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableHeaderCell { Text = "Pavarde" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Vardas" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Nakvynių skaičius" });
            Table3.Rows.Add(headerRow);

            
            for (tourists.Start(); tourists.Exists(); tourists.Next())
            {
                Tourist tourist = tourists.Get();
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = tourist.LastName });
                row.Cells.Add(new TableCell { Text = tourist.FirstName });
                row.Cells.Add(new TableCell { Text = tourist.HotelName });
                row.Cells.Add(new TableCell { Text = tourist.RoomType });
                row.Cells.Add(new TableCell { Text = tourist.BookedNights.ToString() });
                Table3.Rows.Add(row);
            }
        }
        /// <summary>
        /// Method to update the hotel table with the hotel data
        /// </summary>
        /// <param name="hotels"></param>
        private void UpdateHotelTable(HotelLinkedList hotels)
        {
            
            Table2.Rows.Clear();

            
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Kaina" });
            Table2.Rows.Add(headerRow);

            
            for (hotels.Start(); hotels.Exists(); hotels.Next())
            {
                Hotel hotel = hotels.Get();
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = hotel.HotelName });
                row.Cells.Add(new TableCell { Text = hotel.HotelType });
                row.Cells.Add(new TableCell { Text = hotel.Cost.ToString() });
                Table2.Rows.Add(row);
            }
        }
        /// <summary>
        /// Method to update the table with the tourists who spent less than the specified amount
        /// </summary>
        /// <param name="tourists"></param>
        private void UpdateMinTuristTable(TouristLinkedList tourists)
        {
            
            Table4.Rows.Clear();

            if (tourists.Count != 0 )
            {
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Pavarde" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Vardas" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Suma" });
                Table4.Rows.Add(headerRow);

                
                for (tourists.Start(); tourists.Exists(); tourists.Next())
                {
                    Tourist tourist = tourists.Get();
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = tourist.LastName });
                    row.Cells.Add(new TableCell { Text = tourist.FirstName });
                    row.Cells.Add(new TableCell { Text = tourist.Sum.ToString() });
                    Table4.Rows.Add(row);
                }
            }
            else
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = "Turistų, kurie išleido mažiau negu nurodyta suma nėra" });
                Table4.Rows.Add(row);
            }
        }
        private void UpdateHotelTableTwo(HotelLinkedList hotels)
        {

            if (hotels.Count != 0)
            {
                Table5.Rows.Clear();


                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Kaina" });
                Table5.Rows.Add(headerRow);


                for (hotels.Start(); hotels.Exists(); hotels.Next())
                {
                    Hotel hotel = hotels.Get();
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = hotel.HotelName });
                    row.Cells.Add(new TableCell { Text = hotel.HotelType });
                    row.Cells.Add(new TableCell { Text = hotel.Cost.ToString() });
                    Table5.Rows.Add(row);
                }
            }
            
            else
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = "Nera" });
                Table5.Rows.Add(row);
            }
        }
        private void UpdateHotelTableThree(HotelLinkedList hotels)
        {
            if (hotels.Count != 0)
            {
                Table6.Rows.Clear();


                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Viešbutis" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Kambario tipas" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Kaina" });
                Table6.Rows.Add(headerRow);


                for (hotels.Start(); hotels.Exists(); hotels.Next())
                {
                    Hotel hotel = hotels.Get();
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = hotel.HotelName });
                    row.Cells.Add(new TableCell { Text = hotel.HotelType });
                    row.Cells.Add(new TableCell { Text = hotel.Cost.ToString() });
                    Table6.Rows.Add(row);
                }
            }
            
            else
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = "nera" });
                Table6.Rows.Add(row);
            }
        }
    }
}
