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
                Prints();
                return true;
            }
            if (UserWantedAction == 2)
            {
                bool AddedWorker = AddWorker();
                Prints();
                return true;
            }
            if (UserWantedAction == 3)
            {
                bool WorkerHours = SetWorkerHours();
                Prints();
                return true;
            }
            else
            {
                Prints();
            }
            return false;
        }

        public static void Prints()
        {
            Console.WriteLine("press 1 to watch more workers salary's");
            Console.WriteLine("press 2 to add worker");
            Console.WriteLine("press 3 to set worker hours");

            string UserAction = Console.ReadLine();
            int UserActionInt = Int32.Parse(UserAction);
            MenuOptions(UserActionInt);
        }

        public static double CalculateSalary()
        {
            try
            {
                SQLiteConnection conn = DBManager.CreateConn();

                int WorkerHours = 0;
                int WorkerRisk = 0;
                string WorkerName = "";
                string WorkerJobName = "";
                string WorkerJobType = "";

                string SelectWorkers = "SELECT * FROM Workers";
                SQLiteCommand SelectWorkersCursor = new SQLiteCommand(SelectWorkers, conn);
                SQLiteDataReader ReadersWorkers = SelectWorkersCursor.ExecuteReader();
                Dictionary<int, int> WorkersDict2Job = new Dictionary<int, int>();
                Dictionary<int, int> WorkersDictHours = new Dictionary<int, int>();
                Dictionary<int, string> WorkersDictName = new Dictionary<int, string>();

                while (ReadersWorkers.Read())
                {
                    Console.WriteLine($"{ReadersWorkers.GetInt32(0)} {ReadersWorkers.GetString(1)} ");
                    WorkersDict2Job.Add(ReadersWorkers.GetInt32(0), ReadersWorkers.GetInt32(3));
                    WorkersDictHours.Add(ReadersWorkers.GetInt32(0), ReadersWorkers.GetInt32(2));
                    WorkersDictName.Add(ReadersWorkers.GetInt32(0), ReadersWorkers.GetString(1));

                }

                Console.WriteLine("Enter the worker id to watch his current salary:");
                string WorkerId = Console.ReadLine();
                int WorkerJobId = Int32.Parse(WorkerId);
                int SelectedWorkerJobId = WorkersDict2Job[WorkerJobId];
                WorkerHours = WorkersDictHours[WorkerJobId];
                WorkerName = WorkersDictName[WorkerJobId];

                string SelectJobs = "SELECT * FROM Jobs";
                SQLiteCommand SelectJobsCursor = new SQLiteCommand(SelectJobs, conn);
                SQLiteDataReader JobReader = SelectJobsCursor.ExecuteReader();
                while (JobReader.Read())
                {
                    if (JobReader.GetInt32(0) == SelectedWorkerJobId)
                    {
                        WorkerRisk = JobReader.GetInt32(3);
                        WorkerJobType = JobReader.GetString(1);
                    }
                }

                string SelectJobRanks = String.Format("SELECT * FROM Job2Rank where jobId={0}", SelectedWorkerJobId);
                SQLiteCommand SelectJobRanksCursor = new SQLiteCommand(SelectJobRanks, conn);
                SQLiteDataReader JobsReader = SelectJobRanksCursor.ExecuteReader();
                List<int> RanksData = new List<int>();

                while (JobsReader.Read())
                {
                    RanksData.Add(JobsReader.GetInt32(1));
                }

                List<Dictionary<string, dynamic>> Ranks = new List<Dictionary<string, dynamic>>();
                Dictionary<string, dynamic> TempRanks = new Dictionary<string, dynamic>();
                List<Ranks> RanksList = new List<Ranks>();
                for (int i = 0; i < RanksData.Count; i++)
                {
                    string SelectRanks = String.Format("SELECT * FROM Ranks where rankId in ({0})", RanksData[i]);
                    SQLiteCommand SelectRanksCursor = new SQLiteCommand(SelectRanks, conn);
                    SQLiteDataReader RanksReader = SelectRanksCursor.ExecuteReader();

                    while (RanksReader.Read())
                    {
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
                    RanksList.Add(new Ranks(rankName, expansionRate, minimumHours, fixedHours));
                }


                Job job = new Job(WorkerJobName, WorkerJobType, RanksList, WorkerRisk);
                Worker worker = new Worker(WorkerName, WorkerHours, job);
                return (worker.GetWorkerJobData.CalculateSalary(worker.GetWorkhours));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
           
        }


        public static bool AddWorker()
        {
            try
            {
                SQLiteConnection conn = DBManager.CreateConn();

                Console.WriteLine("Welcome to signup page for new worker");
                Console.WriteLine("Fill worker name");
                string WorkerName = Console.ReadLine();
                Console.WriteLine("Fill worker monthly work hours");
                string WorkerHours = Console.ReadLine();
                int WorkerHoursInt = Int32.Parse(WorkerHours);

                string SelectJobs = "SELECT * FROM Jobs";
                SQLiteCommand SelectJobsCursor = new SQLiteCommand(SelectJobs, conn);
                SQLiteDataReader Jobs = SelectJobsCursor.ExecuteReader();
                while (Jobs.Read())
                {
                    Console.WriteLine($"{Jobs.GetInt32(0)} {Jobs.GetString(1)} {Jobs.GetString(2)} {Jobs.GetInt32(3)}");
                }

                Console.WriteLine("Choose worker work type, please select the job ID");
                string WorkerJobId = Console.ReadLine();
                int WorkerJobIdInt = Int32.Parse(WorkerJobId);

                string SqlInsertWorker = string.Format("INSERT INTO Workers (workerName, workerHours, jobId) values ('{0}', '{1}', '{2}')", WorkerName, WorkerHours, WorkerJobIdInt);
                SQLiteCommand command = new SQLiteCommand(SqlInsertWorker, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public static bool SetWorkerHours()
        {
            try
            {
                SQLiteConnection conn = DBManager.CreateConn();
                Console.WriteLine("Welcome to edit page for our worker");
                string SelectWorkers = "SELECT * FROM Workers";
                SQLiteCommand SelectWorkersCursor = new SQLiteCommand(SelectWorkers, conn);
                SQLiteDataReader ReadersWorkers = SelectWorkersCursor.ExecuteReader();
                Dictionary<int, int> WorkersDict2Hours = new Dictionary<int, int>();

                while (ReadersWorkers.Read())
                {
                    Console.WriteLine($"{ReadersWorkers.GetInt32(0)} {ReadersWorkers.GetString(1)} ");
                    WorkersDict2Hours.Add(ReadersWorkers.GetInt32(0), ReadersWorkers.GetInt32(2));
                }

                Console.WriteLine("Choose worker ID");
                string WorkerId = Console.ReadLine();

                Console.WriteLine("Choose worker start time in format: 27/6/2021 13:00:00 PM");
                string StartTime = Console.ReadLine();
                DateTime StartTimeDate = DateTime.Parse(StartTime);

                Console.WriteLine("Choose worker end time in format: 27/6/2021 16:00:00 PM");
                string EndTime = Console.ReadLine();
                DateTime EndTimeDate = DateTime.Parse(EndTime);

                int TimeDiff = (EndTimeDate - StartTimeDate).Hours;
                int SelectedWorkerIdHours = WorkersDict2Hours[Int32.Parse(WorkerId)];
                int NewHours = TimeDiff + SelectedWorkerIdHours;

                string UpdateQuery = string.Format("UPDATE Workers SET workerHours = '{0}' WHERE workerId='{1}' ", NewHours, WorkerId);
                SQLiteCommand command = new SQLiteCommand(UpdateQuery, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
          
            
        }

    }
}
