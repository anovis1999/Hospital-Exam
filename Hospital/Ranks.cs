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
        private double Risk;


        public Ranks(string RankName, double ExpansionRate, int MinimumHours, int FixedHours, double Risk)
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
        public double GetRisk
        {
            get { return this.Risk; }
        }

        public double  GetMonthlySalary(int hours)
        {
            string salary = ConfigurationManager.AppSettings.Get("BaseHourleySellary");
            int newsala = Int32.Parse(salary);

            if (this.ExpansionRate == 0)
            {
                double CurrentSalary = hours * newsala;
                return CurrentSalary + (this.Risk / 100 * CurrentSalary);
            }
            else if (this.MinimumHours!=0) {
                double CurrentSalary = (this.ExpansionRate / 100 * newsala + newsala) * this.FixedHours;
                return CurrentSalary + (this.Risk/100 * CurrentSalary);
            }
            else
            {
                double CurrentSalary = (this.ExpansionRate / 100 * newsala + newsala) * hours;
                return CurrentSalary + (this.Risk / 100 * CurrentSalary);
            }
        }

    }
}
