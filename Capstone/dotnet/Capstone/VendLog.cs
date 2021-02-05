using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class VendLog
    {
        static string FilePath = Directory.GetCurrentDirectory();
        static string FileName = @"Log.txt";
        static string FullPath = Path.Combine(FilePath, FileName);
        static StreamWriter sw = new StreamWriter(FullPath);
        public static void Log(string functionPerformed, decimal variable, decimal currentBalance)
        {
            try
            {
                if (sw == null)
                {
                    sw.Flush();
                }
                else
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss' 'tt")} {functionPerformed} {variable:C2} {currentBalance:C2}");
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
