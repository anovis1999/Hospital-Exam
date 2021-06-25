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
