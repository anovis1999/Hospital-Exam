using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    class Job
    {
        private string JobName;
        private string JobType;
        private List<Ranks> JobRanks;

        public Job(string JobName, string JobType, List<Ranks> JobRanks)
        {
            this.JobName = JobName;
            this.JobType = JobType;
            this.JobRanks = JobRanks;
        }

        public double Calc(int hours)
        {
            double salary = 0;
            for (int i = 0; i < this.JobRanks.Count; i++)
            {
                
                Ranks r = new Ranks(this.JobRanks[i].GetRankName, this.JobRanks[i].GetExpansionRate, this.JobRanks[i].GetMinimumHours, this.JobRanks[i].GetFixedHours, this.JobRanks[i].GetRisk);
                salary += r.GetMonthlySalary(hours);
                Console.WriteLine(salary);
            }
            return salary;
        }


        public string GetJobname
        {
            get { return this.JobName; }
        }
        public string GetJobType
        {
            get { return this.JobType; }
        }
        public List<Ranks> GetJobRanks
        {
            get { return this.JobRanks; }
        }
    }
}
