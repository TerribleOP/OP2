using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

namespace L1
{
    /// <summary> 
    /// class meant to send out and receive data 
    /// </summary> 
    public class InOutUtils
    {
        
        /// <summary> 
        /// Reads the user input 
        /// </summary> 
        /// <param name="Box"></param> 
        /// <returns></returns> 
        public static int ReadBox(TextBox Box)
        {
            return int.Parse(Box.Text);
        }
        /// <summary>
        /// prints results to TXT
        /// </summary>
        /// <param name="map"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="filePath"></param>
        public static void PrintToTxt(Square[,] map, int N, int M, string filePath)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    File.AppendAllText(filePath, map[i,j].Colour.ToString());
                }
                File.AppendAllText(filePath, "\n");
            }
            File.AppendAllText(filePath, "\n");
        }
        /// <summary>
        /// Prints the header to TXT seperatly
        /// </summary>
        /// <param name="header"></param>
        /// <param name="filePath"></param>
        public static void PrintHeaderToTxt(string header, string filePath)
        {
            File.AppendAllText(filePath, header);
        }
    }
}