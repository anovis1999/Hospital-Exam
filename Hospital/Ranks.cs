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

        }

        public string GetRankName
        {
            get { return this.RankName; }
        }
      
    }
}
