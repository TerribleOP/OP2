using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace L3
{
	public partial class WebForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                

                string inputHotels = Server.MapPath($"App_Data/U17b.txt");
                string inputTourists = Server.MapPath($"App_Data/U17a.txt");
                string result = Server.MapPath($"App_Data/Rezultatai.txt");

                string headerOne = $"{"Pavarde",-15} | {"Vardas",-15} | {"Viesbutis",-10} | {"Kambario tipas",-15} | {"Nakvyniu skaicius",-22}| ";
                string headerTwo = $"{"Viesbutis",-15} | {"Kambario tipas",-15} | {"Kaina",5}|";
                string HeaderThree = $"{"Pavarde",-15} | {"Vardas",-15} | {"Suma",10}|";

                if (File.Exists(inputHotels)) File.Delete(inputHotels);
                if (File.Exists(inputTourists)) File.Delete(inputTourists);
                if (File.Exists(result)) File.Delete(result);

                FileUpload1.SaveAs(inputTourists);
                FileUpload2.SaveAs(inputHotels);

                CustomLinkedList<Tourist> Tourists = new CustomLinkedList<Tourist>();
                CustomLinkedList<Hotel> Hotels = new CustomLinkedList<Hotel>();

                InOutUtils.ReadTourists(inputTourists, Tourists);
                InOutUtils.ReadHotel(inputHotels, Hotels);
                UpdateTables(Tourists, Table1, false, false);
                UpdateTables(Hotels, Table2, true, false);

                //UpdateTableTourist(Tourists, Table1);
                //UpdateTableHotel(Hotels, Table2);


                //InOutUtils.PrintTourists(result, Tourists, headerOne, false);
                //InOutUtils.PrintHotels(result, Hotels, headerTwo);
                InOutUtils.Print(result, headerOne, "Pradiniai turistų duomenys:", false, Tourists);
                InOutUtils.Print(result, headerTwo, "Pradiniai viesbuciu duomenys:", false, Hotels);
                
                CustomLinkedList<Hotel> usedHotels = new CustomLinkedList<Hotel>();
                CustomLinkedList<Hotel> unsedHotels = new CustomLinkedList<Hotel>();

                TaskUtils.FindUsedUnused(Tourists, Hotels, usedHotels, unsedHotels);

                UpdateTables(usedHotels, Table5, true, false);
                UpdateTables(unsedHotels, Table6, true, false);
                InOutUtils.Print(result, headerTwo, "Panaudoti viešbučiai:", false, usedHotels);
                InOutUtils.Print(result, headerTwo, "Nepanaudoti viešbučiai:", false, unsedHotels);

                int maximum = int.Parse(TextBox1.Text);
                int longestStay = TaskUtils.FindLongestStay(Tourists);

                
                CustomLinkedList<Tourist> LongestStayTourists = new CustomLinkedList<Tourist>();
                CustomLinkedList<Tourist> MinimumSpenderTourists = new CustomLinkedList<Tourist>();

                TaskUtils.FindTouristsWithLongestStay(Tourists, longestStay, LongestStayTourists);
                LongestStayTourists.BubbleSort();


                UpdateTables(LongestStayTourists, Table3, false, false);
                InOutUtils.Print(result, headerOne, "Ilgiausiai prabuve turistai:", false, LongestStayTourists);

                TaskUtils.FindSum(Tourists, Hotels);
                TaskUtils.findMinSpenders(Tourists, maximum, MinimumSpenderTourists);
                MinimumSpenderTourists.BubbleSort();
                UpdateTables(MinimumSpenderTourists,Table4,false,true);
                InOutUtils.Print(result, HeaderThree, "Mažiausiai išleidę turistai:", true, MinimumSpenderTourists);
                Label6.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                Label9.Visible = true;
            }        
        }
    }
}