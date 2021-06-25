using System;
using System.Configuration;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAttr = ConfigurationManager.AppSettings.Get("BaseHourleySellary");
            Console.WriteLine(sAttr);
            string jsonData = ConfigurationManager.AppSettings.Get("jobdata");

            var details = JObject.Parse(jsonData);
            Console.WriteLine( details["simple_cleaner"]["ranks"][0]);


        }
    }
}