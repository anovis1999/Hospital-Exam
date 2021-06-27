using System;
using System.Configuration;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Transactions;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
           
            while (true)
            {
                Console.WriteLine("press 1 to watch more workers salary's");
                Console.WriteLine("press 2 to add worker");
                Console.WriteLine("press 3 to set worker hours");
                string UserAction = Console.ReadLine();
                int UserActionInt = Int32.Parse(UserAction);
                Boolean result = Menu.MenuOptions(UserActionInt);
                return;
            }



            //string sql = "insert into Workers (workerId, workerName, workerHours, workerJobId) values (1, roni, 55, 1)";




            //string sAttr = ConfigurationManager.AppSettings.Get("BaseHourleySellary");
            //Console.WriteLine(sAttr);
            //string jsonData = ConfigurationManager.AppSettings.Get("jobdata");

            //var details = JObject.Parse(jsonData);
            //Console.WriteLine(details["simple_cleaner"]["ranks"][0]);
        }
    }
}