using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplicationNetFramework.Utilities
{
    public class CustomLogger
    {
        readonly static string relativePath = "Resources/log.txt";
        readonly string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

        public void Log(string message)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message} \n");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}