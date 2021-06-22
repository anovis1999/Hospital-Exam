using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    class Worker
    {
        private string name;
        private string workerid;
        private string jobname;
        private string jobtype;

        public Worker(string name, string workerid, string jobname, string jobtype)
        {
            this.name = name;
            this.jobname = jobname;
            this.jobtype = jobtype;
            this.workerid = workerid;
        }
        public string Name
        {
            get { return this.name; }
        }
        public string Jobname
        {
            get { return this.jobname; }
        }
        public string Jobtype
        {
            get { return this.jobtype; }
        }
        public string Workerid
        {
            get { return this.workerid; }
        }
    }
}
