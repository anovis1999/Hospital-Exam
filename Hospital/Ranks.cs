using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Hospital
{
    class Ranks
    {
        private string RankName;
        private double ExpansionRate;
        private int MinimumHours;
        private int FixedHours;


        public Ranks(string RankName, double ExpansionRate, int MinimumHours, int FixedHours)
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

        public double GetExpansionRate
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

        

        public double GetCurrentSalary(int hours, int Risk)
        {
            string salary = ConfigurationManager.AppSettings.Get("BaseHourleySellary");
            int newsalary = Int32.Parse(salary);

            if (this.ExpansionRate == 0)
            {
                double CurrentSalary = hours * newsalary;
                return CurrentSalary + (Risk / 100 * CurrentSalary);
            }
            else if (this.MinimumHours!=0) {
                if (hours >= MinimumHours)
                {
                    double CurrentSalary = (this.ExpansionRate / 100 * newsalary + newsalary) * this.FixedHours;
                    return CurrentSalary + (Risk / 100 * CurrentSalary);
                }
                else
                    return 0;
            }
            else
            {
                double CurrentSalary = (this.ExpansionRate / 100 * newsalary + newsalary) * hours;
                return CurrentSalary + (Risk / 100 * CurrentSalary);
            }
        }

    }
}
