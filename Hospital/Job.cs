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
        private int Risk;

        public Job(string JobName, string JobType, List<Ranks> JobRanks, int Risk)
        {
            this.JobName = JobName;
            this.JobType = JobType;
            this.JobRanks = JobRanks;
            this.Risk = Risk;

        }

        public double CalculateSalary(int hours)
        {
            double salary = 0;
            for (int i = 0; i < this.JobRanks.Count; i++)
            {
                
                Ranks r = new Ranks(this.JobRanks[i].GetRankName, this.JobRanks[i].GetExpansionRate, this.JobRanks[i].GetMinimumHours, this.JobRanks[i].GetFixedHours);
                salary += r.GetMonthlySalary(hours, Risk);
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
