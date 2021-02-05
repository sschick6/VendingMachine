using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 

namespace Capstone
{
    class SalesReport
    {

        static string FilePath = Directory.GetCurrentDirectory();
        static string fileDate = DateTime.Now.ToString("yyyy'-'MM'-'dd'-'hh'-'mm'-'ss'-'tt");
        static string fileType = ".txt";
        static string FileName = fileDate + fileType;
        static string FullPath = Path.Combine(FilePath, FileName);
        static StreamWriter sw = new StreamWriter(FullPath);
        public static void LogSales(Dictionary<string, Item>SalesLogDictionary) 
        {
            try
            {
                if (sw == null)
                {
                    sw.Flush();
                }
                else
                {
                    decimal totalSales = 0; 
                    foreach (KeyValuePair<string, Item> product in SalesLogDictionary)
                    {

                        sw.WriteLine($"{product.Value.ItemName}|{product.Value.ItemSold}");
                        totalSales += Convert.ToDecimal(product.Value.ItemSold)*(product.Value.ItemPrice);

                    }
                    sw.WriteLine($"\n{totalSales:C2}");
                    //sw.WriteLine($"{functionPerformed} {variable:C2} {currentBalance:C2}");

                    //Console.WriteLine("");
                    sw.Flush();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Oops");
            }
        }
    }
}

