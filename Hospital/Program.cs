using System;
using System.Configuration;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
           

            List<Ranks> AuthorList = new List<Ranks>();

            AuthorList.Add(new Ranks("pro", 0, 0, 0, 20));
            AuthorList.Add(new Ranks("prof", 0, 0, 0, 0));

            Job j = new Job("zutar", "pro",AuthorList);
            Worker w = new Worker("jhon", 55, j);

            Console.WriteLine(w.GetWorkerJobData.GetJobRanks[0].GetRisk);

            string sAttr = ConfigurationManager.AppSettings.Get("BaseHourleySellary");
            Console.WriteLine(sAttr);
            string jsonData = ConfigurationManager.AppSettings.Get("jobdata");

            var details = JObject.Parse(jsonData);
            Console.WriteLine( details["simple_cleaner"]["ranks"][0]);


        }
    }
}