using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Hospital
{
    class Menu
    {
        public static bool MenuOptions(int UserWantedAction)
        {
            if (UserWantedAction == 1)
            {
                double WorkerSalary = CalculateSalary();
                Console.WriteLine("the following worker salray is: "+WorkerSalary);
                Console.WriteLine("press 1 to watch more workers salary's");
                Console.WriteLine("press 2 to add worker");

                string UserAction = Console.ReadLine();
                int userACk = Int32.Parse(UserAction);
                MenuOptions(userACk); 
                return true;
            }
            else
            {
                Console.WriteLine("press 1 to watch more workers salary's");
                Console.WriteLine("press 2 to add worker");

                string UserAction = Console.ReadLine();
                int userACk = Int32.Parse(UserAction);
                MenuOptions(userACk);
            }

            return false;

        }
        public static double CalculateSalary()
        {
            SQLiteConnection conn = DBManager.CreateConn();


            string SelectWorkers = "SELECT * FROM Workers";
            SQLiteCommand SelectWorkersCursor = new SQLiteCommand(SelectWorkers, conn);
            SQLiteDataReader ReadersWorkers = SelectWorkersCursor.ExecuteReader();
            Dictionary<int, int> WorkersDict = new Dictionary<int, int>();
            while (ReadersWorkers.Read())
            {
                Console.WriteLine($"{ReadersWorkers.GetInt32(0)} {ReadersWorkers.GetString(1)} {ReadersWorkers.GetInt32(2)} {ReadersWorkers.GetInt32(3)} ");
                WorkersDict.Add(ReadersWorkers.GetInt32(0), ReadersWorkers.GetInt32(3));
            }
            Console.WriteLine("Enter the worker id to watch his current salary:");
            string WorkerId = Console.ReadLine();
            int WorkerJobId = Int32.Parse(WorkerId);
            int SelectedWorkerJobId = WorkersDict[WorkerJobId];

        
            string SelectJobRanks = String.Format("SELECT * FROM Job2Rank where jobId={0}", SelectedWorkerJobId);
            SQLiteCommand SelectJobRanksCursor = new SQLiteCommand(SelectJobRanks, conn);
            SQLiteDataReader JobsReader = SelectJobRanksCursor.ExecuteReader();
            List<int> RanksData = new List<int>();
            while (JobsReader.Read())
            {
                //Console.WriteLine($"{JobsReader.GetInt32(0)} {JobsReader.GetInt32(1)}");
                RanksData.Add(JobsReader.GetInt32(1));
            }


            List<Dictionary<string, dynamic>> Ranks = new List<Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> TempRanks = new Dictionary<string, dynamic>();
            List<Ranks> RanksList = new List<Ranks>();
            for (int i = 0; i < RanksData.Count; i++)
            {
                //Console.WriteLine(i);
                string SelectRanks = String.Format("SELECT * FROM Ranks where rankId in ({0})", RanksData[i]);
                SQLiteCommand SelectRanksCursor = new SQLiteCommand(SelectRanks, conn);
                SQLiteDataReader RanksReader = SelectRanksCursor.ExecuteReader();

                while (RanksReader.Read())
                {
                    //Console.WriteLine($"{RanksReader.GetInt32(0)} {RanksReader.GetString(1)} {RanksReader.GetFloat(2)} {RanksReader.GetInt32(3)} {RanksReader.GetInt32(4)}");
                    TempRanks.Add("rankName", RanksReader.GetString(1));
                    TempRanks.Add("expansionRate", RanksReader.GetFloat(2));
                    TempRanks.Add("minimumHours", RanksReader.GetInt32(3));
                    TempRanks.Add("fixedHours", RanksReader.GetInt32(4));
                }
                Ranks.Add(new Dictionary<string, dynamic>(TempRanks));
                TempRanks.Clear();
                var rankName = Ranks[i]["rankName"];
                var expansionRate = Ranks[i]["expansionRate"];
                var minimumHours = Ranks[i]["minimumHours"];
                var fixedHours = Ranks[i]["fixedHours"];
                //Console.WriteLine(Ranks[i]["rankName"]);
                RanksList.Add(new Ranks(rankName, expansionRate, minimumHours, fixedHours));
            }


            Job job = new Job("Cleaner", "Professional", RanksList, 0);
            Worker worker = new Worker("jhon", 55, job);
            return (worker.GetWorkerJobData.CalculateSalary(worker.GetWorkhours));
        }
        public static void InsertUser()
        {
            SQLiteConnection conn = DBManager.CreateConn();

            string SelectJobs = "SELECT * FROM Jobs";
            SQLiteCommand SelectJobsCursor = new SQLiteCommand(SelectJobs, conn);
            SQLiteDataReader r = SelectJobsCursor.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r.GetInt32(0)} {r.GetString(1)} {r.GetString(2)} {r.GetInt32(3)} ");
            }


            //string jobId = Console.ReadLine();
            //int JobId = Int32.Parse(jobId);
        }
    }
}
