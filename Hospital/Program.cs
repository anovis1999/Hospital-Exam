using System;
using System.Configuration;
using System.Collections.Specialized;
namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAttr = ConfigurationManager.AppSettings.Get("BaseHourleySellary");


            Console.WriteLine(sAttr);

        }
    }
}