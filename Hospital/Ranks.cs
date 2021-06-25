using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    class Ranks
    {
        private string RankName;
        private int ExpansionRate;
        private int MinimumHours;
        private int FixedHours;
        private int Risk;


        public Ranks(string RankName, int ExpansionRate, int MinimumHours, int FixedHours, int Risk)
        {
            this.RankName = RankName;
            this.ExpansionRate = ExpansionRate;
            this.MinimumHours = MinimumHours;
            this.FixedHours = FixedHours;
            this.Risk = Risk;

        }

        public string GetRankName
        {
            get { return this.RankName; }
        }
        public int GetExpansionRate
        {
            get { return this.ExpansionRate; }
        }
        public int GetMinimumHours
        {
            get { return this.MinimumHours; }
        }
        public int GetFixedHours
        {
            get { return this.FixedHours; }
        }
        public int GetRisk
        {
            get { return this.Risk; }
        }

        public static long GetMonthlySalary()
        {

            return 123;
        }

    }
}
