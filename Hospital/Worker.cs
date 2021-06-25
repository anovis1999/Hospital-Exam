using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    class Worker
    {
        private string Name;
        private Guid WorkerId;
        private int WorkHours;
     

        public Worker(string Name, int WorkHours)
        {
            this.Name = Name;
            this.WorkerId = new Guid();
            this.WorkHours = WorkHours;
        }

        public string GetName
        {
            get { return this.Name; }
        }
        public Guid GetWorkerid
        {
            get { return this.WorkerId; }
        }
        public int GetWorkhours
        {
            get { return this.WorkHours; }
        }

    }
} 