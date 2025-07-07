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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary> 
        /// Method for the button click event 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string TouristFile = Server.MapPath("App_Data/U17a.txt");
                string HotelFile = Server.MapPath("App_Data/U17b.txt");
                string Result = Server.MapPath("App_Data/Rezultatai.txt");
                File.Delete(Result);
                int Limit = int.Parse(TextBox1.Text);

                TouristLinkedList Tourists = new TouristLinkedList();
                HotelLinkedList Hotels = new HotelLinkedList();

                InOutUtils.ReadTourists(TouristFile, Tourists);
                InOutUtils.ReadHotels(HotelFile, Hotels);

                string headerOne = $"{"Pavarde",-15} | {"Vardas",-15} | {"Viesbutis",-10} | { "Kambario tipas",-15} | { "Nakvyniu skaicius",-22}| "; 
                string headerTwo = $"{"Viesbutis",-15} | {"Kambario tipas",-15} | {"Kaina",5}|";
                InOutUtils.PrintTourists(Result, Tourists, headerOne, false);
                InOutUtils.PrintHotels(Result, Hotels, headerTwo);


                HotelLinkedList usedHotel = new HotelLinkedList();
                HotelLinkedList unusedHotel = new HotelLinkedList();
                TaskUtils.FindUsedUnused(Tourists, Hotels, usedHotel, unusedHotel);


                int longestStay = TaskUtils.FindLongestNight(Tourists);

                InOutUtils.PrintHotelsAnswer(Result, usedHotel, headerTwo, true);
                InOutUtils.PrintHotelsAnswer(Result, unusedHotel, headerTwo, false);

                TaskUtils.FindSumOfNightsInHotels(Tourists, Hotels);
                TouristLinkedList TouristWithLongestStay = new TouristLinkedList();
                TaskUtils.FindTouristWithLongestStay(Tourists, TouristWithLongestStay,longestStay);
                TouristWithLongestStay.BubbleSort();
                InOutUtils.PrintTourists(Result, TouristWithLongestStay, headerOne, true);

                string HeaderThree = $"{"Pavarde",-15} | {"Vardas",-15} | {"Suma",10}|";
                TouristLinkedList MinSpenders = new TouristLinkedList();
                TaskUtils.FindMinSpenders(Tourists, MinSpenders, Limit);
                MinSpenders.BubbleSort();
                InOutUtils.PrintMinTurists(Result, MinSpenders, HeaderThree, Limit);

                UpdateTable(Tourists);
                UpdateHotelTable(Hotels);
                UpdateHotelTableTwo(usedHotel);
                UpdateHotelTableThree(unusedHotel);
                UpdateResultTable(TouristWithLongestStay);
                UpdateMinTuristTable(MinSpenders);

            }
        }
    }
}