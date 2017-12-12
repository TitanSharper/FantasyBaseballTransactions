using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Infrastructure.IO
{
    public class FileServices
    {

        public static void CreateTextFile(string filename, string content)
        {
            // Check if file already exists. If yes, delete it. 
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            // Create a new file 
            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine(content);
            }

            //// Write file contents on console. 
            //using (StreamReader sr = File.OpenText(filename))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
        }
    }
}
