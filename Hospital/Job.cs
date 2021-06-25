using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    class Job
    {
        private string JobName;
        private string JobType;
        private string[] JobRanks;

        public Job(string JobName, string JobType, string[] JobRanks)
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
        public string[] GetJobRanks
        {
            get { return this.JobRanks; }
        }
    }
}
