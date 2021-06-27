using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    class Worker
    {
        private string WorkerName;
        private Guid WorkerId;
        private int WorkHours;
        private Job WorkerJobData;
     

        public Worker(string WorkerName, int WorkHours, Job WorkerJobData)
        {
            this.WorkerName = WorkerName;
            this.WorkerId = new Guid();
            this.WorkHours = WorkHours;
            this.WorkerJobData = WorkerJobData;
        }

        public string GetName
        {
            get { return this.WorkerName; }
        }
        public Guid GetWorkerid
        {
            get { return this.WorkerId; }
        }
        public int GetWorkhours
        {
            get { return this.WorkHours; }
        }
        public Job GetWorkerJobData
        {
            get { return this.WorkerJobData; }
        }

    }
} 