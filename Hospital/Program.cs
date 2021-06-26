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
            

            AuthorList.Add(new Ranks("Professional", 30, 0, 0, 20));
            AuthorList.Add(new Ranks("Simple_cleaner", 0, 0, 0, 0));

            AuthorList.Add(new Ranks("manager", 50, 0, 0, 0));
            Job j = new Job("Cleaner", "Professional",AuthorList);
            Worker w = new Worker("jhon", 55, j);

            //Console.WriteLine(w.GetWorkerJobData.GetJobRanks[0].GetRisk );
            Console.WriteLine(w.GetWorkerJobData.Calc(w.GetWorkhours));

            string sAttr = ConfigurationManager.AppSettings.Get("BaseHourleySellary");
            Console.WriteLine(sAttr);
            string jsonData = ConfigurationManager.AppSettings.Get("jobdata");

            var details = JObject.Parse(jsonData);
            Console.WriteLine(details["simple_cleaner"]["ranks"][0]);


        }
    }
}